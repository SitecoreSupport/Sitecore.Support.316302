using Sitecore.Abstractions;
using Sitecore.Common;
using Sitecore.Data.DataProviders.Sql;
using Sitecore.Eventing;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.Data.SqlServer
{
    public class SqlServerClientDataStore : Sitecore.Data.SqlServer.SqlServerClientDataStore
    {
        public SqlServerClientDataStore(SqlDataApi api, string objectLifetime, IEventQueue queue, BaseEventManager eventManager) : base(api, objectLifetime, queue, eventManager)
        {

        }

        public SqlServerClientDataStore(string connectionString, string objectLifetime, IEventQueue queue, BaseEventManager eventManager) : base(connectionString, objectLifetime, queue, eventManager)
        {
           
        }

        protected override string GetDataKey()
        {
            if (!string.IsNullOrEmpty(Switcher<string, string>.CurrentValue))
            {
                string key = Switcher<string, string>.CurrentValue;
                if (key != Sitecore.Owin.Authentication.Constants.LocalIdentityProvider)
                {
                    return key;
                }
            }
            return WebUtil.GetSessionID();
        }
    }
}