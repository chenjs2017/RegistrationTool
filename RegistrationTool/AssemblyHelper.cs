using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using PluginRegistrationTool;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace PluginRegistrationTool
{
    internal class AssemblyHelper
    {
        

        /// <summary>
        /// Registration Service.
        /// </summary>
        private RegistrationService _registrationService = new RegistrationService();

        /// <summary>
        /// Registration Service.
        /// </summary>
        private RegistrationService RegistrationService
        {
            get
            {
                return _registrationService;
            }
        }

        /// <summary>
        /// Plugin Helper.
        /// </summary>
        private PluginHelper _pluginHelper = new PluginHelper();

        /// <summary>
        /// Assembly Helper.
        /// </summary>
        private PluginHelper PluginHelper
        {
            get
            {
                return _pluginHelper;
            }
        }

        /// <summary>
        /// XRM Service.
        /// </summary>
        XrmService _xrmService;

        /// <summary>
        /// XRM Service.
        /// </summary>
        private XrmService xrmService
        {
            get
            {
                return _xrmService;
            }
            set
            {
                _xrmService = value;
            }
        }

        private PluginAssembly PluginAssembly { get; set; }
        private bool Result { get; set; }
        private ItemExists XrmAssembly { get; set; }
        private QueryByAttribute AssemblyQuery { get; set; }
        private EntityCollection AssemblyQueryResults { get; set; }
        private XrmSolution XrmSolution { get; set; }
        

        internal void AddAssemblyToSolution(AssemblyRegistration registrationCollection, Registration registration, XrmPluginAssembly assembly)
        {
            if (!string.IsNullOrEmpty(registration.SolutionUniqueName))
            {
                XrmSolution = new XrmSolution(registrationCollection.ConnectionString);
                XrmSolution.AddComponentToSolution(SolutionComponentType.PluginAssembly, assembly.AssemblyId, registration.SolutionUniqueName);
            }
        }

        /// <summary>
        /// Method to retrieve the Assembly according to the Registration Object.
        /// </summary>
        /// <param name="registration">The Registration Object that indicated which Assembly to retrieve as well as the Assembly details to retrieve.</param>
        /// <returns>The retrieved Assembly.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFrom")]
        internal XrmPluginAssembly GetRegistrationAssembly(string xrmServerDetails, Registration registration)
        {
            try
            {
                XrmPluginAssembly xrmPluginAssembly = new XrmPluginAssembly();
                xrmPluginAssembly.Path = registration.AssemblyPath;
                xrmPluginAssembly.IsolationMode = registration.IsolationMode;
                Assembly assembly = Assembly.LoadFrom(registration.AssemblyPath);
                AssemblyName assemblyName = assembly.GetName();
                string defaultGroupName = string.Format(CultureInfo.InvariantCulture, "{0} ({1})", assemblyName.Name, assemblyName.Version);
                ItemExists assemblyExists = GetRegistrationAssemblyId(xrmServerDetails, assemblyName);
                xrmPluginAssembly.Exists = assemblyExists.Exists;
                xrmPluginAssembly.AssemblyId = assemblyExists.ItemId;
                xrmPluginAssembly.SourceType = registration.AssemblySourceType;
                FileInfo fileInfo = new FileInfo(registration.AssemblyPath);
                xrmPluginAssembly.ServerFileName = fileInfo.Name;
                if (xrmPluginAssembly.SourceType != XrmAssemblySourceType.Disk)
                {
                    xrmPluginAssembly.ServerFileName = null;
                }
                string cultureLabel;
                if (assemblyName.CultureInfo.LCID == System.Globalization.CultureInfo.InvariantCulture.LCID)
                {
                    cultureLabel = "neutral";
                }
                else
                {
                    cultureLabel = assemblyName.CultureInfo.Name;
                }
                xrmPluginAssembly.Name = assemblyName.Name;
                xrmPluginAssembly.Version = assemblyName.Version.ToString();
                xrmPluginAssembly.Culture = cultureLabel;
                byte[] tokenBytes = assemblyName.GetPublicKeyToken();
                if (null == tokenBytes || 0 == tokenBytes.Length)
                {
                    xrmPluginAssembly.PublicKeyToken = null;
                }
                else
                {
                    xrmPluginAssembly.PublicKeyToken = string.Join(string.Empty, tokenBytes.Select(b => b.ToString("X2", CultureInfo.InvariantCulture)));
                }
                xrmPluginAssembly = PluginHelper.GetRegistrationPlugins(xrmServerDetails, registration, xrmPluginAssembly, assembly, defaultGroupName);
                return xrmPluginAssembly;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Register an Assembly.
        /// </summary>
        /// <param name="xrmPluginAssembly">The Assembly to Register.</param>
        /// <returns>The Identifier of the newly Registered Assembly.</returns>
        internal Guid RegisterAssembly(string xrmServerDetails, XrmPluginAssembly xrmPluginAssembly)
        {
            try
            {
                using (xrmService = RegistrationService.GetService(xrmServerDetails))
                {
                    PluginAssembly pluginAssembly = GetPluginAssembly(xrmPluginAssembly);
                    return xrmService.Create(pluginAssembly);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Update an Assembly Registration.
        /// </summary>
        /// <param name="xrmPluginAssembly">The Assembly to Update.</param>
        /// <returns>Result.</returns>
        internal bool UpdateAssembly(string  xrmServerDetails, XrmPluginAssembly xrmPluginAssembly)
        {
            try
            {
                using (xrmService = RegistrationService.GetService(xrmServerDetails))
                {
                    PluginAssembly pluginAssembly = GetPluginAssembly(xrmPluginAssembly);
                    xrmService.Update(pluginAssembly);
                }
                Result = true;
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Unregister an Assembly.
        /// </summary>
        /// <param name="xrmPluginAssembly">The Assembly to Unregister.</param>
        /// <returns>Result.</returns>
        internal bool UnregisterAssembly(string xrmServerDetails, XrmPluginAssembly xrmPluginAssembly, Collection<string> errors, SolutionComponentType solutionComponentType)
        {
            try
            {
                Result = RegistrationService.Unregister(xrmServerDetails, PluginAssembly.EntityLogicalName, xrmPluginAssembly.AssemblyId, errors, solutionComponentType);
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to retrieve the Assembly. 
        /// </summary>
        /// <param name="xrmPluginAssembly">The Assembly to retrieve.</param>
        /// <returns>The retrieved Assembly.</returns>
        private PluginAssembly GetPluginAssembly(XrmPluginAssembly xrmPluginAssembly)
        {
            try
            {
                PluginAssembly = new PluginAssembly()
                {
                    PluginAssemblyId = xrmPluginAssembly.AssemblyId,
                    Name = xrmPluginAssembly.Name,
                    SourceType = new OptionSetValue()
                    {
                        Value = (int)xrmPluginAssembly.SourceType
                    },
                    IsolationMode = new OptionSetValue()
                    {
                        Value = (int)xrmPluginAssembly.IsolationMode
                    },
                    Culture = xrmPluginAssembly.Culture,
                    PublicKeyToken = xrmPluginAssembly.PublicKeyToken,
                    Version = xrmPluginAssembly.Version,
                    Description = xrmPluginAssembly.Description
                };
                if (xrmPluginAssembly.SourceType == XrmAssemblySourceType.Database)
                {
                    PluginAssembly.Content = Convert.ToBase64String(File.ReadAllBytes(xrmPluginAssembly.Path));
                }
                switch (xrmPluginAssembly.SourceType)
                {
                    case XrmAssemblySourceType.Disk:
                        PluginAssembly.Path = xrmPluginAssembly.ServerFileName;
                        break;
                    case XrmAssemblySourceType.Database:
                        break;
                    case XrmAssemblySourceType.GAC:
                        break;
                };
                return PluginAssembly;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        private ItemExists GetRegistrationAssemblyId(string xrmServerDetails, AssemblyName assemblyName)
        {
            try
            {
                using (xrmService = RegistrationService.GetService(xrmServerDetails))
                {
                    XrmAssembly = new ItemExists();
                    AssemblyQuery = new QueryByAttribute(PluginAssembly.EntityLogicalName);
                    AssemblyQuery.ColumnSet = new ColumnSet(true);
                    AssemblyQuery.Attributes.AddRange("name");
                    AssemblyQuery.Values.AddRange(assemblyName.Name);
                    AssemblyQueryResults = xrmService.RetrieveMultiple(AssemblyQuery);
                    if (AssemblyQueryResults.Entities != null && AssemblyQueryResults.Entities.Count > 0)
                    {
                        XrmAssembly.ItemId = AssemblyQueryResults.Entities[0].Id;
                        XrmAssembly.Exists = true;
                    }
                    else
                    {
                        XrmAssembly.ItemId = Guid.NewGuid();
                        XrmAssembly.Exists = false;
                    }
                    return XrmAssembly;
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

    }
}
