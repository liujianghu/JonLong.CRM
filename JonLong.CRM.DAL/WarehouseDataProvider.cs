using System;
using System.Collections.Generic;
using System.Linq;
using JonLong.CRM.Models;
using JonLong.CRM.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace JonLong.CRM.DAL
{
    public static class WarehouseDataProvider
    {
        public static List<Warehouse> LoadList(string customerCode, string shoe)
        {
            string sql = @"SELECT  xh ,
                        '" + customerCode + @"' AS khbh ,
                        khxh ,
                        COUNT(CASE WHEN b.ms_id = 1 THEN 1
                                   ELSE NULL
                              END) + COUNT(CASE WHEN b.ms_id = 2 THEN 2
                                                ELSE NULL
                                           END) + COUNT(CASE WHEN b.ms_id = 3 THEN 3
                                                             ELSE NULL
                                                        END)
                        + COUNT(CASE WHEN b.ms_id = 4 THEN 4
                                     ELSE NULL
                                END) + COUNT(CASE WHEN b.ms_id = 5 THEN 5
                                                  ELSE NULL
                                             END) + COUNT(CASE WHEN b.ms_id = 6 THEN 6
                                                               ELSE NULL
                                                          END)
                        + COUNT(CASE WHEN b.ms_id = 7 THEN 7
                                     ELSE NULL
                                END) + COUNT(CASE WHEN b.ms_id = 8 THEN 8
                                                  ELSE NULL
                                             END) + COUNT(CASE WHEN b.ms_id = 9 THEN 9
                                                               ELSE NULL
                                                          END)
                        + COUNT(CASE WHEN b.ms_id = 10 THEN 10
                                     ELSE NULL
                                END) + COUNT(CASE WHEN b.ms_id = 11 THEN 11
                                                  ELSE NULL
                                             END) + COUNT(CASE WHEN b.ms_id = 12 THEN 12
                                                               ELSE NULL
                                                          END)
                        + COUNT(CASE WHEN b.ms_id = 13 THEN 13
                                     ELSE NULL
                                END) + COUNT(CASE WHEN b.ms_id = 14 THEN 14
                                                  ELSE NULL
                                             END) + COUNT(CASE WHEN b.ms_id = 15 THEN 15
                                                               ELSE NULL
                                                          END)
                        + COUNT(CASE WHEN b.ms_id = 16 THEN 16
                                     ELSE NULL
                                END) + COUNT(CASE WHEN b.ms_id = 17 THEN 17
                                                  ELSE NULL
                                             END) + COUNT(CASE WHEN b.ms_id = 18 THEN 18
                                                               ELSE NULL
                                                          END)
                        + COUNT(CASE WHEN b.ms_id = 19 THEN 19
                                     ELSE NULL
                                END) + COUNT(CASE WHEN b.ms_id = 20 THEN 20
                                                  ELSE NULL
                                             END) AS sumS ,
                        COUNT(CASE WHEN b.ms_id = 1 THEN 1
                                   ELSE NULL
                              END) AS s1 ,
                        COUNT(CASE WHEN b.ms_id = 2 THEN 2
                                   ELSE NULL
                              END) AS s2 ,
                        COUNT(CASE WHEN b.ms_id = 3 THEN 3
                                   ELSE NULL
                              END) AS s3 ,
                        COUNT(CASE WHEN b.ms_id = 4 THEN 4
                                   ELSE NULL
                              END) AS s4 ,
                        COUNT(CASE WHEN b.ms_id = 5 THEN 5
                                   ELSE NULL
                              END) AS s5 ,
                        COUNT(CASE WHEN b.ms_id = 6 THEN 6
                                   ELSE NULL
                              END) AS s6 ,
                        COUNT(CASE WHEN b.ms_id = 7 THEN 7
                                   ELSE NULL
                              END) AS s7 ,
                        COUNT(CASE WHEN b.ms_id = 8 THEN 8
                                   ELSE NULL
                              END) AS s8 ,
                        COUNT(CASE WHEN b.ms_id = 9 THEN 9
                                   ELSE NULL
                              END) AS s9 ,
                        COUNT(CASE WHEN b.ms_id = 10 THEN 10
                                   ELSE NULL
                              END) AS s10 ,
                        COUNT(CASE WHEN b.ms_id = 11 THEN 11
                                   ELSE NULL
                              END) AS s11 ,
                        COUNT(CASE WHEN b.ms_id = 12 THEN 12
                                   ELSE NULL
                              END) AS s12 ,
                        COUNT(CASE WHEN b.ms_id = 13 THEN 13
                                   ELSE NULL
                              END) AS s13 ,
                        COUNT(CASE WHEN b.ms_id = 14 THEN 14
                                   ELSE NULL
                              END) AS s14 ,
                        COUNT(CASE WHEN b.ms_id = 15 THEN 15
                                   ELSE NULL
                              END) AS s15 ,
                        COUNT(CASE WHEN b.ms_id = 16 THEN 16
                                   ELSE NULL
                              END) AS s16 ,
                        COUNT(CASE WHEN b.ms_id = 17 THEN 17
                                   ELSE NULL
                              END) AS s17 ,
                        COUNT(CASE WHEN b.ms_id = 18 THEN 18
                                   ELSE NULL
                              END) AS s18 ,
                        COUNT(CASE WHEN b.ms_id = 19 THEN 19
                                   ELSE NULL
                              END) AS s19 ,
                        COUNT(CASE WHEN b.ms_id = 20 THEN 20
                                   ELSE NULL
                              END) AS s20
                FROM    dbo.tab_cp_barcode b
                        INNER JOIN ( SELECT xh_bh ,
                                            xh_khxh AS khxh
                                     FROM   t_bas_xt t
                                            INNER JOIN t_Bas_xh h ON xt_xt = xh_xt
                                                                     AND xt_khh = '" + customerCode + @"'
                                   ) xh ON b.xh = xh.xh_bh
                WHERE   state IN ( '入库', '备货' )";
            if (!String.IsNullOrEmpty(shoe) && shoe != "ALL")
            {
                sql += " and xh.khxh = '" + shoe + "' ";
            }
            sql += "group by xh,khxh order by xh";

            var list = new List<Warehouse>();

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString, CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    var info = new Warehouse();
                    info.ModelNo = reader.GetString(0);
                    info.Total = reader.GetInt32(3);
                    info.Size1 = reader.GetInt32(4);
                    info.Size2 = reader.GetInt32(5);
                    info.Size3 = reader.GetInt32(6);
                    info.Size4 = reader.GetInt32(7);
                    info.Size5 = reader.GetInt32(8);
                    info.Size6 = reader.GetInt32(9);
                    info.Size7 = reader.GetInt32(10);
                    info.Size8 = reader.GetInt32(11);
                    info.Size9 = reader.GetInt32(12);
                    info.Size10 = reader.GetInt32(13);
                    info.Size11 = reader.GetInt32(14);
                    info.Size12 = reader.GetInt32(15);
                    info.Size13 = reader.GetInt32(16);
                    info.Size14 = reader.GetInt32(17);
                    info.Size15 = reader.GetInt32(18);
                    info.Size16 = reader.GetInt32(19);
                    info.Size17 = reader.GetInt32(20);
                    info.Size18 = reader.GetInt32(21);
                    info.Size19 = reader.GetInt32(22);
                    info.Size20 = reader.GetInt32(23);

                    list.Add(info);
                }
            }

            return list;
        }

        public static List<Warehouse> LoadCustomerList(string customerCode, string shoe)
        {
            string sql = @"SELECT  id ,
                        khkc_khbh ,
                        khkc_xh ,
                        khkc_sumS ,
                        ISNULL(khkc_s1, 0) AS khkc_s1 ,
                        ISNULL(khkc_s2, 0) AS khkc_s2 ,
                        ISNULL(khkc_s3, 0) AS khkc_s3 ,
                        ISNULL(khkc_s4, 0) AS khkc_s4 ,
                        ISNULL(khkc_s5, 0) AS khkc_s5 ,
                        ISNULL(khkc_s6, 0) AS khkc_s6 ,
                        ISNULL(khkc_s7, 0) AS khkc_s7 ,
                        ISNULL(khkc_s8, 0) AS khkc_s8 ,
                        ISNULL(khkc_s9, 0) AS khkc_s9 ,
                        ISNULL(khkc_s10, 0) AS khkc_s10 ,
                        ISNULL(khkc_s11, 0) AS khkc_s11 ,
                        ISNULL(khkc_s12, 0) AS khkc_s12 ,
                        ISNULL(khkc_s13, 0) AS khkc_s13 ,
                        ISNULL(khkc_s14, 0) AS khkc_s14 ,
                        ISNULL(khkc_s15, 0) AS khkc_s15 ,
                        ISNULL(khkc_s16, 0) AS khkc_s16 ,
                        ISNULL(khkc_s17, 0) AS khkc_s17 ,
                        ISNULL(khkc_s18, 0) AS khkc_s18 ,
                        ISNULL(khkc_s19, 0) AS khkc_s19 ,
                        ISNULL(khkc_s20, 0) AS khkc_s20
                FROM    t_sale_khkc
                WHERE   khkc_khbh = '" + customerCode + "'";
            if (!String.IsNullOrEmpty(shoe) && shoe != "ALL")
            {
                sql += " and khkc_xh='" + shoe + "'";
            }
            var list = new List<Warehouse>();

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString, CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    var info = new Warehouse();
                    info.Id = reader.GetInt32(0);
                    info.ModelNo = reader.GetString(2);
                    info.Total = reader.GetInt32(3);
                    info.Size1 = reader.GetInt32(4);
                    info.Size2 = reader.GetInt32(5);
                    info.Size3 = reader.GetInt32(6);
                    info.Size4 = reader.GetInt32(7);
                    info.Size5 = reader.GetInt32(8);
                    info.Size6 = reader.GetInt32(9);
                    info.Size7 = reader.GetInt32(10);
                    info.Size8 = reader.GetInt32(11);
                    info.Size9 = reader.GetInt32(12);
                    info.Size10 = reader.GetInt32(13);
                    info.Size11 = reader.GetInt32(14);
                    info.Size12 = reader.GetInt32(15);
                    info.Size13 = reader.GetInt32(16);
                    info.Size14 = reader.GetInt32(17);
                    info.Size15 = reader.GetInt32(18);
                    info.Size16 = reader.GetInt32(19);
                    info.Size17 = reader.GetInt32(20);
                    info.Size18 = reader.GetInt32(21);
                    info.Size19 = reader.GetInt32(22);
                    info.Size20 = reader.GetInt32(23);

                    list.Add(info);
                }
            }

            return list;

        }

        public static Warehouse LoadById(int id)
        {
            string sql = @"SELECT  id ,
                        khkc_khbh ,
                        khkc_xh ,
                        khkc_sumS ,
                        ISNULL(khkc_s1, 0) AS khkc_s1 ,
                        ISNULL(khkc_s2, 0) AS khkc_s2 ,
                        ISNULL(khkc_s3, 0) AS khkc_s3 ,
                        ISNULL(khkc_s4, 0) AS khkc_s4 ,
                        ISNULL(khkc_s5, 0) AS khkc_s5 ,
                        ISNULL(khkc_s6, 0) AS khkc_s6 ,
                        ISNULL(khkc_s7, 0) AS khkc_s7 ,
                        ISNULL(khkc_s8, 0) AS khkc_s8 ,
                        ISNULL(khkc_s9, 0) AS khkc_s9 ,
                        ISNULL(khkc_s10, 0) AS khkc_s10 ,
                        ISNULL(khkc_s11, 0) AS khkc_s11 ,
                        ISNULL(khkc_s12, 0) AS khkc_s12 ,
                        ISNULL(khkc_s13, 0) AS khkc_s13 ,
                        ISNULL(khkc_s14, 0) AS khkc_s14 ,
                        ISNULL(khkc_s15, 0) AS khkc_s15 ,
                        ISNULL(khkc_s16, 0) AS khkc_s16 ,
                        ISNULL(khkc_s17, 0) AS khkc_s17 ,
                        ISNULL(khkc_s18, 0) AS khkc_s18 ,
                        ISNULL(khkc_s19, 0) AS khkc_s19 ,
                        ISNULL(khkc_s20, 0) AS khkc_s20
                    FROM [jncrm].[dbo].[t_sale_khkc]
                    where id = " + id;
            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString, CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    var info = new Warehouse();
                    info.Id = reader.GetInt32(0);
                    info.ModelNo = reader.GetString(2);
                    info.Total = reader.GetInt32(3);
                    info.Size1 = reader.GetInt32(4);
                    info.Size2 = reader.GetInt32(5);
                    info.Size3 = reader.GetInt32(6);
                    info.Size4 = reader.GetInt32(7);
                    info.Size5 = reader.GetInt32(8);
                    info.Size6 = reader.GetInt32(9);
                    info.Size7 = reader.GetInt32(10);
                    info.Size8 = reader.GetInt32(11);
                    info.Size9 = reader.GetInt32(12);
                    info.Size10 = reader.GetInt32(13);
                    info.Size11 = reader.GetInt32(14);
                    info.Size12 = reader.GetInt32(15);
                    info.Size13 = reader.GetInt32(16);
                    info.Size14 = reader.GetInt32(17);
                    info.Size15 = reader.GetInt32(18);
                    info.Size16 = reader.GetInt32(19);
                    info.Size17 = reader.GetInt32(20);
                    info.Size18 = reader.GetInt32(21);
                    info.Size19 = reader.GetInt32(22);
                    info.Size20 = reader.GetInt32(23);

                    return info;
                }
            }

            return null;
        }

        public static void Insert(Warehouse info, string customerCode)
        {
            string sql = @"INSERT INTO [jncrm].[dbo].[t_sale_khkc]
                       ([khkc_xh]
                       ,[khkc_sumS]
                       ,[khkc_s1]
                       ,[khkc_s2]
                       ,[khkc_s3]
                       ,[khkc_s4]
                       ,[khkc_s5]
                       ,[khkc_s6]
                       ,[khkc_s7]
                       ,[khkc_s8]
                       ,[khkc_s9]
                       ,[khkc_s10]
                       ,[khkc_s11]
                       ,[khkc_s12]
                       ,[khkc_s13]
                       ,[khkc_s14]
                       ,[khkc_s15]
                       ,[khkc_s16]
                       ,[khkc_s17]
                       ,[khkc_s18]
                       ,[khkc_s19]
                       ,[khkc_s20]
                       ,[khkc_khbh])
                 VALUES
                       ('" + info.ModelNo + @"'
                       ,'" + info.Total + @"'
                       ,'" + info.Size1 + @"'
                       ,'" + info.Size2 + @"'
                       ,'" + info.Size3 + @"'
                       ,'" + info.Size4 + @"'
                       ,'" + info.Size5 + @"'
                      ,'" + info.Size6 + @"'
                       ,'" + info.Size7 + @"'
                       ,'" + info.Size8 + @"'
                      ,'" + info.Size9 + @"'
                       ,'" + info.Size10 + @"'
                       ,'" + info.Size11 + @"'
                       ,'" + info.Size12 + @"'
                       ,'" + info.Size13 + @"'
                       ,'" + info.Size14 + @"'
                       ,'" + info.Size15 + @"'
                       ,'" + info.Size16 + @"'
                       ,'" + info.Size17 + @"'
                       ,'" + info.Size18 + @"'
                       ,'" + info.Size19 + @"'
                       ,'" + info.Size20 + @"'
                       ,'" + customerCode + "')";

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.Text, sql);
        }

        public static void Update(Warehouse info, string customerCode)
        {
            string sql = @"UPDATE [jncrm].[dbo].[t_sale_khkc]
               SET [ID] = '" + info.Id + @"'
                  ,[khkc_xh] = '" + info.ModelNo + @"'
                  ,[khkc_sumS] = '" + info.Total + @"'
                  ,[khkc_s1] = " + info.Size1 + @"
                  ,[khkc_s2] = " + info.Size1 + @"
                  ,[khkc_s3] = " + info.Size1 + @"
                  ,[khkc_s4] = " + info.Size1 + @"
                  ,[khkc_s5] = " + info.Size1 + @"
                  ,[khkc_s6] = " + info.Size1 + @"
                  ,[khkc_s7] = " + info.Size1 + @"
                  ,[khkc_s8] = " + info.Size1 + @"
                  ,[khkc_s9] = " + info.Size1 + @"
                  ,[khkc_s10] = " + info.Size1 + @"
                  ,[khkc_s11] = " + info.Size1 + @"
                  ,[khkc_s12] = " + info.Size1 + @"
                  ,[khkc_s13] = " + info.Size1 + @"
                  ,[khkc_s14] = " + info.Size1 + @"
                  ,[khkc_s15] = " + info.Size1 + @"
                  ,[khkc_s16] = " + info.Size1 + @"
                  ,[khkc_s17] = " + info.Size1 + @"
                  ,[khkc_s18] = " + info.Size1 + @"
                  ,[khkc_s19] = " + info.Size1 + @"
                  ,[khkc_s20] = " + info.Size1 + @"
                  ,[khkc_khbh] = '" + customerCode + @"'
             WHERE id = " + info.Id;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.Text, sql);
        }

        public static void Delete(int id)
        {
            string sql = "DELETE FROM [jncrm].[dbo].[t_sale_khkc] WHERE id=" + id;
            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString, CommandType.Text, sql);
        }
    }
}
