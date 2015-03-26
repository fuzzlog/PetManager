using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetManager.Interfaces;
using PetManager.Models;
using System.Linq.Expressions;
using PetManager.Managers;

namespace PetManager.Concretes
{
    public class EFRepository : IRepository, IDisposable
    {
        /// <summary>
        /// Returns list of entitiies matching provided type
        /// </summary>
        /// <typeparam name="T">Generically-provided type</typeparam>
        /// <param name="ids">List of integers as ids</param>
        /// <returns>List<T>/></returns>
        public List<T> GetEntitiesByIdList<T>(List<int> ids) where T : class
        {
            Entities ctx = new Entities();
            var values = BuildInList(ids);
            string parameterizedSql = "SELECT " +
                                            "AnimalsID, " +
                                            "Moniker, " +
                                            "PetId, " +
                                            "City, " +
                                            "Located, " +
                                            "AnimalStatusId " +
                                       "FROM {0} " +
                                       "WHERE [{1}] IN ({2})";
            string[] paramsArr = new string[] { "Animals", "AnimalsID", values };
            var sql = string.Format(parameterizedSql, paramsArr);


            var result = ctx.Set<T>().SqlQuery(sql).ToList();

            return result;
        }

        /// <summary>
        /// Returns list of entitiies matching provided parameter
        /// </summary>
        /// <typeparam name="T">Generically-provided type</typeparam>
        /// <param name="ids">List of integers as ids</param>
        /// <returns>List<T>/></returns>
        public List<T> GetEntitiesByStatusList<T>(List<PetStatus> statusList) where T : class
        {
            Entities ctx = new Entities();
            var values = BuildInList(statusList.Cast<int>().ToList());
            string parameterizedSql = "SELECT " +
                                            "AnimalsID, " +
                                            "Moniker, " +
                                            "PetId, " +
                                            "City, " + 
                                            "Located, " +
                                            "AnimalStatusId " +
                                       "FROM {0} " +
                                       "WHERE [{1}] IN ({2})";
            string[] paramsArr = new string[] { "Animals", "AnimalStatusID", values };
            var sql = string.Format(parameterizedSql, paramsArr);

            var result = ctx.Set<T>().SqlQuery(sql).ToList();

            return result;
        }

        /// <summary>
        /// Helper function to bulild sql string
        /// </summary>
        /// <param name="pattern">Parameterized string</param>
        /// <param name="paramArr">List<string> as parameters</param>
        /// <returns></returns>
        private string BuildSqlString(string pattern, string[] paramArr)
        {
            return string.Format(pattern, paramArr);
        }

        //public List<T> GetEntitiesByParameter<T>(Func<T, bool> predicate) where T : class
        //{
        //    Entities ctx = new Entities();

        //    var entities = ctx.Set<T>().Where(predicate).ToList();

        //    return entities;
        //}

        /// <summary>
        /// Saves client provided entities.  Any errors at this point well be propagated to try/catch blocks from the calling methods.
        /// </summary>
        /// <typeparam name="T">Generically-provided type</typeparam>
        /// <param name="newEntity">Entity to save</param>
        /// <returns></returns>
        public int SaveNewEntity<T>(T newEntity) where T : class
        {
            Entities ctx = new Entities();

            ctx.Set<T>().Add(newEntity);
            return ctx.SaveChanges();
        }

        /// <summary>
        /// Helper function to create the "IN" list for a sql string
        /// </summary>
        /// <param name="ids">items to be included in string</param>
        /// <returns></returns>
        private string BuildInList(List<int> ids, bool isTextValues = false)
        {
            var values = new StringBuilder();
            var singleQuotes = isTextValues ? "" : "'";
            values.AppendFormat("{1}{0}{1}", ids[0], singleQuotes);
            for (int i = 1; i < ids.Count; i++)
            {
                values.AppendFormat(", {1}{0}{1}", ids[i], singleQuotes);
            }
            return values.ToString();
        }

        public void Dispose()
        {

        }

    }
}
