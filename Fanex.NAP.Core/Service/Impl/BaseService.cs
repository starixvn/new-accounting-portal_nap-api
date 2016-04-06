// --------------------------------------------------------------------------
// <copyright file="BaseService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Anders.Le" date="2012.8.6">Created</change>
//   <change who="Edward.Nguyen" date="2012.8.14">Add GetRepositoryExecLog</change>
// </history>

namespace Fanex.NAP.Core.Service.Impl
{
    using System;
    using System.Collections.Generic;
    using Fanex.Common.Helper;
    using Fanex.Data.Repository;
    using Fanex.NAP.Core.Criteria.Misc;
    using Fanex.NAP.Core.Service.Interface;
    using Web.Session;
    using Web.Context;
    using Configuration;/// <summary>
                        /// Base service.
                        /// </summary>
    public class BaseService : IBaseService
    {
        private readonly IDynamicRepository _dynamicRepository;

        public BaseService(IDynamicRepository dynamicRepository = null)
        {
            _dynamicRepository = dynamicRepository ?? new DynamicRepository();
        }

        public IServiceContext ServiceContext { get; set; }

        /// <summary>
        /// Gets the list data.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The list data.</returns>
        public virtual IEnumerable<T> GetData<T>(ICriteria criteria)
        {
            Check.Argument.IsNotNull(criteria, "criteria");

            if (criteria.IsValid())
            {
                return _dynamicRepository.Fetch<T>(criteria);
            }

            return new List<T>();
        }

        /// <summary>
        /// Gets item that are satisfied the passed criteria.
        /// </summary>
        /// <typeparam name="T">Type of Object return.</typeparam>
        /// <param name="criteria">Criteria to Query DB.</param>
        /// <returns>Enumerable of Type T.</returns>
        public virtual T GetItem<T>(ICriteria criteria) where T : new()
        {
            Check.Argument.IsNotNull(criteria, "criteria");

            if (criteria.IsValid())
            {
                return _dynamicRepository.Get<T>(criteria);
            }

            return new T();
        }

        /// <summary>
        /// Get execute store procedure log criteria.
        /// </summary>
        /// <returns>Execute SP log criteria.</returns>
        public LogExecSpCriteria GetLogExecSpCriteria()
        {
            var currentSession = new CurrentSession();
            var currentContext = new CurrentContext();

            return new LogExecSpCriteria
            {
                CurrentUserId = currentSession.UserId,
                CurrentSiteId = NapSettings.Settings.SiteId,
                LogDate = DateTime.Now,
                LoginIp = currentContext.IP
            };

        }
    }
}