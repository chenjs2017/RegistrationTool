using System;
using System.Configuration;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace PluginRegistrationTool
{
    /// <summary>
    /// The Dynamics CRM Service Class.
    /// 
    /// This class provides constructors, properties and methods for establishing a Dynamics CRM service and using its methods.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xrm")]
    public class XrmService : IDisposable
    {
      
        string ConnectionString { get; set; }

        /// <summary>
        /// XrmService Class Constructor.
        /// </summary>
        public XrmService(string connString)
        {
            ConnectionString = connString;
        }

        #region Properties
       /// <summary>
        /// Organisation service proxy.
        /// </summary>
        private OrganizationServiceProxy organizationServiceProxy;

        /// <summary>
        /// Organisation service proxy.
        /// </summary>
        public OrganizationServiceProxy OrganizationServiceProxy
        {
            get
            {
                CrmServiceClient conn = new CrmServiceClient(ConnectionString);
                return conn.OrganizationServiceProxy;
           }
        }

        /// <summary>
        /// Organisation service context.
        /// </summary>
        private OrganizationServiceContext organizationServiceContext;

        /// <summary>
        /// Organisation service context.
        /// </summary>
        public OrganizationServiceContext OrganizationServiceContext
        {
            get
            {
                organizationServiceContext = new OrganizationServiceContext(OrganizationServiceProxy);
                return organizationServiceContext;
            }
        }

        /// <summary>
        /// Use Device Credentials.
        /// </summary>
        private bool useDeviceCredentials;

        /// <summary>
        /// Use Device Credentials.
        /// </summary>
        public bool UseDeviceCredentials
        {
            get
            {
                return useDeviceCredentials;
            }
            set
            {
                useDeviceCredentials = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Associate two or more entity records.
        /// </summary>
        /// <param name="entityName">The name of the entity that contains the record.</param>
        /// <param name="entityId">The id of the record being associated.</param>
        /// <param name="relationship">The relatiomship to use for association.</param>
        /// <param name="relatedEntities">The collection of entities to associate the record with.</param>
        public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            try
            {
                using (OrganizationServiceProxy organizationServiceProxy = this.OrganizationServiceProxy)
                {
                    organizationServiceProxy.Associate(entityName, entityId, relationship, relatedEntities);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Create an entity record.
        /// </summary>
        /// <param name="entity">The entity object containing the details of the record to be created.</param>
        /// <returns>The record id.</returns>
        public Guid Create(Entity entity)
        {
            try
            {
                Guid entityId;
                using (OrganizationServiceProxy organizationServiceProxy = this.OrganizationServiceProxy)
                {
                    entityId = organizationServiceProxy.Create(entity);
                }
                return entityId;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete an entity record.
        /// </summary>
        /// <param name="entityName">The name of the entity the record exists in.</param>
        /// <param name="entityRecordId">The record id.</param>
        public void Delete(string entityName, Guid entityRecordId)
        {
            try
            {
                using (OrganizationServiceProxy organizationServiceProxy = this.OrganizationServiceProxy)
                {
                    organizationServiceProxy.Delete(entityName, entityRecordId);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Disassociate two or more entitity records.
        /// </summary>
        /// <param name="entityName">The name of the entity that contains the record.</param>
        /// <param name="entityId">The id of the record being disassociated.</param>
        /// <param name="relationship">The relatiomship being use for the current association.</param>
        /// <param name="relatedEntities">The collection of entities to disassociate the record from.</param>
        public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            try
            {
                using (OrganizationServiceProxy organizationServiceProxy = this.OrganizationServiceProxy)
                {
                    organizationServiceProxy.Disassociate(entityName, entityId, relationship, relatedEntities);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Execute an organisation request.
        /// </summary>
        /// <param name="organizationRequest">The organisation request to be executed.</param>
        /// <returns>The organisation response.</returns>
        public OrganizationResponse Execute(OrganizationRequest organizationRequest)
        {
            try
            {
                OrganizationResponse response;
                using (OrganizationServiceProxy organizationServiceProxy = this.OrganizationServiceProxy)
                {
                    response = organizationServiceProxy.Execute(organizationRequest);
                }
                return response;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves an entity object containing the details of a specific record.
        /// </summary>
        /// <param name="entityName">The name of the entity to which the record belongs.</param>
        /// <param name="entityId">The record id.</param>
        /// <param name="columns">The fields to be included in the returned entity object.</param>
        /// <returns>An entity object containing the details of a specific record.</returns>
        public Entity Retrieve(string entityName, Guid entityId, ColumnSet columns)
        {
            try
            {
                Entity entity;
                using (OrganizationServiceProxy organizationServiceProxy = this.OrganizationServiceProxy)
                {
                    entity = organizationServiceProxy.Retrieve(entityName, entityId, columns);
                }
                return entity;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieves multiple records based on a query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>An entity collection object containing multiple records.</returns>
        public EntityCollection RetrieveMultiple(QueryBase query)
        {
            try
            {
                EntityCollection entityCollection;
                using (OrganizationServiceProxy organizationServiceProxy = this.OrganizationServiceProxy)
                {
                    entityCollection = organizationServiceProxy.RetrieveMultiple(query);
                }
                return entityCollection;
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        /// <summary>
        /// Update an entity record.
        /// </summary>
        /// <param name="entity">The entity object containing the details of the record to be updated.</param>
        public void Update(Entity entity)
        {
            try
            {
                using (OrganizationServiceProxy organizationServiceProxy = this.OrganizationServiceProxy)
                {
                    organizationServiceProxy.Update(entity);
                }
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                throw;
            }
        }

        #endregion

        #region Disposal

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalize.
        /// </summary>
        ~XrmService()
        {
            Dispose(false);
        }


        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (OrganizationServiceProxy != null)
                {
                    OrganizationServiceProxy.Dispose();
                }
                if (OrganizationServiceContext != null)
                {
                    OrganizationServiceContext.Dispose();
                }
                if (organizationServiceProxy != null)
                {
                    organizationServiceProxy.Dispose();
                    organizationServiceProxy = null;
                }
                if (organizationServiceContext != null)
                {
                    organizationServiceContext.Dispose();
                    organizationServiceContext = null;
                }
            }
        }

        #endregion
    }
}
