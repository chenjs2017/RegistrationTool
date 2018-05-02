using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Xml;
using System.Xml.XPath;
using PluginRegistrationTool;

[assembly: CLSCompliant(true)]
namespace PluginRegistrationTool
{
    /// <summary>
    /// The Registration Helper Class.
    /// Contains methods to Register and Unregister Assemblies, Plugins & CWAs, Steps, Secure Configurations and Images in Dynamics CRM.
    /// </summary>
    public class RegistrationHelper
    {
        #region Properties

        /// <summary>
        /// Assembly Helper.
        /// </summary>
        private AssemblyHelper _assemblyHelper = new AssemblyHelper();

        /// <summary>
        /// Assembly Helper.
        /// </summary>
        private AssemblyHelper AssemblyHelper
        {
            get
            {
                return _assemblyHelper;
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
        /// Step Helper.
        /// </summary>
        private StepHelper _stepHelper = new StepHelper();

        /// <summary>
        /// Step Helper.
        /// </summary>
        private StepHelper StepHelper
        {
            get
            {
                return _stepHelper;
            }
        }

        /// <summary>
        /// Image Helper.
        /// </summary>
        private ImageHelper _imageHelper = new ImageHelper();

        /// <summary>
        /// Image Helper.
        /// </summary>
        private ImageHelper ImageHelper
        {
            get
            {
                return _imageHelper;
            }
        }

        /// <summary>
        /// Error messages.
        /// </summary>
        private Collection<string> errors = new Collection<string> ();

        /// <summary>
        /// Error messages.
        /// </summary>
        public Collection<string> Errors
        {
            get
            {
                return errors;
            }
        }

        /// <summary>
        /// Result indicating success or failure.
        /// </summary>
        private bool _result;

        /// <summary>
        /// Result indicating success or failure.
        /// </summary>
        private bool Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        /// <summary>
        /// Assembly Registration.
        /// </summary>
        private AssemblyRegistration _assemblyRegistration;

        /// <summary>
        /// Assembly Registration.
        /// </summary>
        public AssemblyRegistration AssemblyRegistration
        {
            get
            {
                return _assemblyRegistration;
            }
            set
            {
                _assemblyRegistration = value;
            }
        }

        #endregion

        #region Register and Unregister Methods

        /// <summary>
        /// Method to Register a Registration Collection XML.
        /// </summary>
        /// <param name="assemblyRegistrationXml">The Registration Collection XML to Register.</param>
        /// <returns>Result.</returns>
        public bool Register(IXPathNavigable assemblyRegistrationXml)
        {
            try
            {
                SerializeDeserialize serializer = new SerializeDeserialize();
                AssemblyRegistration = (AssemblyRegistration)serializer.DeserializeXml((XmlDocument)assemblyRegistrationXml, typeof(AssemblyRegistration));
                if (AssemblyRegistration.Ignore == true)
                {
                    return true;
                }
                return this.Register(AssemblyRegistration);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> e)
            {
                errors.Add(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Method to Unregister a Registration Collection XML.
        /// </summary>
        /// <param name="assemblyRegistrationXml">The Registration Collection XML to Unregister.</param>
        /// <returns>Result.</returns>
        public bool Unregister(IXPathNavigable assemblyRegistrationXml)
        {
            try
            {
                SerializeDeserialize serializer = new SerializeDeserialize();
                AssemblyRegistration = (AssemblyRegistration)serializer.DeserializeXml((XmlDocument)assemblyRegistrationXml, typeof(AssemblyRegistration));
                return this.Unregister(AssemblyRegistration);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> e)
            {
                errors.Add(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Method to Register a Registration Collection.
        /// </summary>
        /// <param name="registrationCollection">The Registration Collection to Register.</param>
        /// <returns>Result.</returns>
        public bool Register(AssemblyRegistration registrationCollection)
        {
            try
            {
                this.errors = new Collection<string>();
                Result = false;
                if (registrationCollection != null && registrationCollection.Registrations.Count != 0)
                {
                    foreach (Registration registration in registrationCollection.Registrations)
                    {
                        XrmPluginAssembly assembly = AssemblyHelper.GetRegistrationAssembly(registrationCollection.ConnectionString, registration);
                        if (assembly.Exists)
                        {
                            Result = AssemblyHelper.UpdateAssembly(registrationCollection.ConnectionString, assembly);
                            AssemblyHelper.AddAssemblyToSolution(registrationCollection, registration, assembly);
                        }
                        else
                        {
                            assembly.AssemblyId = AssemblyHelper.RegisterAssembly(registrationCollection.ConnectionString, assembly);
                            AssemblyHelper.AddAssemblyToSolution(registrationCollection, registration, assembly);
                            Result = true;
                        }
                        if (assembly.Plugins.Count != 0)
                        {
                            foreach (XrmPlugin plugin in assembly.Plugins)
                            {
                                if (plugin.Exists)
                                {
                                    Result = PluginHelper.UpdatePlugin(registrationCollection.ConnectionString, plugin);
                                }
                                else
                                {
                                    plugin.PluginId = PluginHelper.RegisterPlugin(registrationCollection.ConnectionString, plugin, errors);
                                    Result = true;
                                }
                                if (plugin.Steps.Count != 0)
                                {
                                    foreach (XrmPluginStep step in plugin.Steps)
                                    {
                                        if (step.Exists)
                                        {
                                            Result = StepHelper.UpdateStep(registrationCollection.ConnectionString, step);
                                            StepHelper.AddStepToSolution(registrationCollection, registration, step);
                                        }
                                        else
                                        {
                                            step.StepId = StepHelper.RegisterStep(registrationCollection.ConnectionString, step);
                                            StepHelper.AddStepToSolution(registrationCollection, registration, step);
                                            Result = true;
                                        }
                                        if (step.Images.Count != 0)
                                        {
                                            foreach (XrmPluginImage image in step.Images)
                                            {
                                                if (image.Exists)
                                                {
                                                    Result = ImageHelper.UpdateImage(registrationCollection.ConnectionString, image);
                                                }
                                                else
                                                {
                                                    image.ImageId = ImageHelper.RegisterImage(registrationCollection.ConnectionString, image);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to Unregister a Registration Collection.
        /// </summary>
        /// <param name="registrationCollection">The Registration Collection to Unregister.</param>
        /// <returns>Result.</returns>
        public bool Unregister(AssemblyRegistration registrationCollection)
        {
            try
            {
                this.errors = new Collection<string>();
                Result = false;
                if (registrationCollection != null)
                {
                    foreach (Registration registration in registrationCollection.Registrations)
                    {
                        XrmPluginAssembly assembly = AssemblyHelper.GetRegistrationAssembly(registrationCollection.ConnectionString, registration);
                        if (assembly.Plugins.Count != 0)
                        {
                            foreach (XrmPlugin plugin in assembly.Plugins)
                            {
                                if (plugin.Steps.Count != 0)
                                {
                                    foreach (XrmPluginStep step in plugin.Steps)
                                    {
                                        if (step.Images.Count != 0)
                                        {
                                            foreach (XrmPluginImage image in step.Images)
                                            {
                                                Result = ImageHelper.UnregisterImage(registrationCollection.ConnectionString, image, errors, SolutionComponentType.SDKMessageProcessingStepImage);
                                                if (!Result)
                                                {
                                                    throw new ArgumentException("Unregister image failed!");
                                                }
                                            }
                                        }
                                        Result = StepHelper.UnregisterStep(registrationCollection.ConnectionString, step, errors, SolutionComponentType.SDKMessageProcessingStep);
                                        if (!Result)
                                        {
                                            throw new ArgumentException("Unregister step failed!");
                                        }
                                        if (step.SecureConfiguration != null && step.SecureConfiguration.SecureConfigurationId.HasValue)
                                        {
                                            Result = StepHelper.UnregisterSecureConfiguration(registrationCollection.ConnectionString, step.SecureConfiguration, errors, SolutionComponentType.SDKMessageProcessingStepSecureConfig);
                                            if (!Result)
                                            {
                                                throw new ArgumentException("Unregister secure configuration failed!");
                                            }
                                        }
                                    }
                                }
                                Result = PluginHelper.UnregisterPlugin(registrationCollection.ConnectionString, plugin, errors, SolutionComponentType.PluginType);
                                if (!Result)
                                {
                                    throw new ArgumentException("Unregister plugin failed!");
                                }
                            }
                        }
                        Result = AssemblyHelper.UnregisterAssembly(registrationCollection.ConnectionString, assembly, errors, SolutionComponentType.PluginAssembly);
                        if (!Result)
                        {
                            throw new ArgumentException("Unregister assembly failed!");
                        }
                    }
                }
                return Result;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        #endregion
    }
}
