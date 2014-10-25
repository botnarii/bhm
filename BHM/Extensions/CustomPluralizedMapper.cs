using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions.Mapper;

namespace BHM.Extensions
{
    public class CustomPluralizedMapper<T> : AutoClassMapper<T> where T : class
    {
        public override void Table(string tableName)
        {
            tableName = string.Format("{0}s", tableName).ToLower();
            TableName = tableName;
            base.Table(tableName);
        }

        public static string Pluralize(string singular)
        {
            return string.Format("{0}s", singular).ToLower();
        }
    }
}
