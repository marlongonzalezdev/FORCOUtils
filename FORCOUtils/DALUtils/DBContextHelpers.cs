using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FORCOUtils.DALUtils
{
    public static class DBContextHelpers
    {
        /// <author>Jose Alexis Hernandez-jahernandezricardo@gmail.com</author>
        /// <summary>
        /// This helper deletes all entities from the context
        /// </summary>
        /// <typeparam name="T">The type of entities to delete</typeparam>
        /// <param name="aContext">The context</param>
        public static void DeleteAllEntities<T>(this DbContext aContext) where T : class
        {

            var _Adapter = (IObjectContextAdapter)aContext;
            var _ObjectContext = _Adapter.ObjectContext;
            var _Sql = string.Format("DELETE FROM {0}", GetTableName<T>(_ObjectContext));
            var _EntityConnection = _ObjectContext.ExecuteStoreCommand(_Sql);

        }

        private static string GetTableName<T>(ObjectContext aContext) where T : class
        {
            var _Sql = aContext.CreateObjectSet<T>().ToTraceString();
            var _Regex = new Regex("FROM (?<table>.*) AS");
            var _Match = _Regex.Match(_Sql);

            var _Table = _Match.Groups["table"].Value;
            return _Table;

        }
    }
}
