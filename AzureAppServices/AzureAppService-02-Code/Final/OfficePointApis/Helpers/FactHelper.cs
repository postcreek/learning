using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficePointApis.Helpers
{
    public static class FactHelper
    {
        public static Fact GetRandomFact()
        {
            string fact = "";

            //NEED TO ADD YOUR OWN MODEL AND UNCOMMENT
            //using (DataModels.OfficePointEntities entities = new DataModels.OfficePointEntities())
            //{
            //    entities.Database.Connection.ConnectAndOpen();

            //    try
            //    {
            //        fact = entities.GetRandomFact().FirstOrDefault();

            //    }
            //    catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            //    {

            //    }
            //    finally
            //    {
            //        entities.Database.Connection.Close();
            //    }

            //}

            return new Fact()
            {
                Description = fact,
            };
        }
    }
}