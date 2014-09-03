using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JonLong.CRM.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace JonLong.CRM.DAL
{
    public static class ShoeDataProvider
    {
        public static List<string> LoadShoeSize(string customerCode)
        {
            var list = new List<string>();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@khbh", SqlDbType.VarChar);
            parameters[0].Value = customerCode;

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_bas_xt_LoadSize"
                , parameters))
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        list.Add(reader.GetString(0));
                    }
                    else
                    {
                        list.Add(String.Empty);
                    }
                }
            }

            return list;
        }

        public static Dictionary<string,string> LoadShoes(string customerCode)
        {
            var dict = new Dictionary<string, string>();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@khbh", SqlDbType.VarChar);
            parameters[0].Value = customerCode;

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.StoredProcedure
                , "t_bas_xt_LoadShoes"
                , parameters))
            {
                while (reader.Read())
                {
                    dict.Add(reader.GetString(0), reader.GetString(1));
                }
            }

            return dict;
        }

        public static List<string> LoadShoeSizeByShoe(string shoe, string customerCode)
        {
            string sql = @"declare @sql varchar(1000),@szlb varchar(2)
                select top 1 @szlb=Xt_szlb from t_bas_xt t inner join t_Bas_xh h on xt_xt=xh_xt 
                where xh_bh=(case when isnull('" + shoe + @"','')='' then xh_bh else '" + shoe + @"' end)
                and xh_khxh=(case when isnull('','')='' then xh_khxh else '' end) 
                and Xt_khh='" + customerCode + @"' order by t.id desc
                set @sql='select Szdz_sz'+@szlb+' from t_bas_sizedz'
                print @sql
                exec (@sql)";

            var list = new List<string>();

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.Text
                , sql))
            {
                while (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        list.Add(String.Empty);
                        
                    }
                    else
                    {
                        list.Add(reader.GetString(0));
                    }
                }
            }

            return list;

        }
    }
}
