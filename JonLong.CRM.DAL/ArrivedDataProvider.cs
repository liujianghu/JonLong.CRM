using System;
using System.Collections.Generic;
using System.Linq;
using JonLong.CRM.Models;
using JonLong.CRM.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace JonLong.CRM.DAL
{
    public static class ArrivedDataProvider
    {
        public static List<ArrivedModel> LoadList(string customerCode, DateTime startETD
            , DateTime endETD, string bundleNo, string container)
        {
            string sql = @"SELECT  CAST(CONVERT(VARCHAR(10), fhzs_fhrq, 121) AS DATETIME) AS fhzs_fhrq ,
                        khys_banderno ,
                        khys_gz ,
                        khys_container ,
                        fhzs_bnBfb * 100 AS bfb ,
                        SUM(fh.fhs) AS sumS ,
                        yid AS id ,
                        ( SELECT    ISNULL(kh_jc, '')
                          FROM      t_bas_kh
                          WHERE     Kh_bh = khys.khys_khh
                        ) AS khjc ,
                        shqrr ,
                        shqrrq ,
                        fhzs_dh ,
                        fhzs_invoiceNo ,
                        khdd ,
                        fhzs_invoiceF ,
                        fhzs_plF ,
                        fhzs_blF
                FROM    ( SELECT    khys_khh ,
                                    khys_banderno ,
                                    khys_gz ,
                                    khys_container ,
                                    MAX(ISNULL(khys_khdd, '')) AS khdd
                          FROM      t_sale_khys
                          WHERE     khys_khh = '" + customerCode + @"'
                          GROUP BY  khys_khh ,
                                    khys_banderno ,
                                    khys_gz ,
                                    khys_container
                        ) AS khys
                        RIGHT JOIN ( SELECT z.id AS yid ,
                                            z.fhzs_dh ,
                                            z.fhzs_invoiceNo ,
                                            CASE WHEN ISNULL(fhzs_invoiceF, '') = '' THEN ''
                                                 ELSE '~/Base_Form/KhDownLoading.aspx?Fhdh='
                                                      + fhzs_dh + '&'
                                                      + 'lxmc=Invoice&Invoice='
                                                      + fhzs_invoiceNo + '&path='
                                                      + REPLACE(fhzs_invoiceF,
                                                                '\\10.10.10.6\DownImage\', '')
                                            END AS fhzs_invoiceF ,
                                            CASE WHEN ISNULL(fhzs_plF, '') = '' THEN ''
                                                 ELSE '~/Base_Form/KhDownLoading.aspx?Fhdh='
                                                      + fhzs_dh + '&'
                                                      + 'lxmc=PackingList&Invoice='
                                                      + fhzs_invoiceNo + '&path='
                                                      + REPLACE(fhzs_plF,
                                                                '\\10.10.10.6\DownImage\', '')
                                            END AS fhzs_plF ,
                                            CASE WHEN ISNULL(fhzs_blF, '') = '' THEN ''
                                                 ELSE '~/Base_Form/KhDownLoading.aspx?Fhdh='
                                                      + fhzs_dh + '&' + 'lxmc=BL&Invoice='
                                                      + fhzs_invoiceNo + '&path='
                                                      + REPLACE(fhzs_blF,
                                                                '\\10.10.10.6\DownImage\', '')
                                            END AS fhzs_blF ,
                                            ISNULL(fhzs_shqr, 0) AS shqr ,
                                            ISNULL(fhzs_shqrr, '') AS shqrr ,
                                            fhzs_shqrrq AS shqrrq ,
                                            fhzs_fhrq ,
                                            fhzs_bn ,
                                            fhzs_bnBfb ,
                                            khddm_khbh ,
                                            ( SELECT    Xh_khxh
                                              FROM      t_bas_xh xh
                                                        INNER JOIN t_bas_xt xt ON Xh_xt = Xt_xt
                                              WHERE     ISNULL(xt_istt, 0) = 0
                                                        AND Xt_khh = m.khddm_khbh
                                                        AND Xh_bh = khddfhs_xh
                                            ) AS xh ,
                                            SUM(ISNULL(khddfhs_qr1, 0))
                                            + SUM(ISNULL(khddfhs_qr2, 0))
                                            + SUM(ISNULL(khddfhs_qr3, 0))
                                            + SUM(ISNULL(khddfhs_qr4, 0))
                                            + SUM(ISNULL(khddfhs_qr5, 0))
                                            + SUM(ISNULL(khddfhs_qr6, 0))
                                            + SUM(ISNULL(khddfhs_qr7, 0))
                                            + SUM(ISNULL(khddfhs_qr8, 0))
                                            + SUM(ISNULL(khddfhs_qr9, 0))
                                            + SUM(ISNULL(khddfhs_qr10, 0))
                                            + SUM(ISNULL(khddfhs_qr11, 0))
                                            + SUM(ISNULL(khddfhs_qr12, 0))
                                            + SUM(ISNULL(khddfhs_qr13, 0))
                                            + SUM(ISNULL(khddfhs_qr14, 0))
                                            + SUM(ISNULL(khddfhs_qr15, 0))
                                            + SUM(ISNULL(khddfhs_qr16, 0))
                                            + SUM(ISNULL(khddfhs_qr17, 0))
                                            + SUM(ISNULL(khddfhs_qr18, 0))
                                            + SUM(ISNULL(khddfhs_qr19, 0))
                                            + SUM(ISNULL(khddfhs_qr20, 0)) AS fhs
                                     FROM   t_sale_khddfhs fhs
                                            INNER JOIN tab_dep_fhzs z ON khddfhs_fhzsd = fhzs_dh
                                            INNER JOIN t_sale_khddm m ON khddfhs_Ddh = khddm_ddh
                                     WHERE  ISNULL(fhzs_isfh, 0) = 1
                                            AND khddm_khbh = '" + customerCode + @"'
                                            AND ISNULL(fhzs_bn, '') <> ''
                                     GROUP BY z.id ,
                                            z.fhzs_dh ,
                                            z.fhzs_invoiceNo ,
                                            ISNULL(fhzs_shqr, 0) ,
                                            ISNULL(fhzs_shqrr, '') ,
                                            fhzs_shqrrq ,
                                            fhzs_fhrq ,
                                            fhzs_bn ,
                                            fhzs_bnBfb ,
                                            khddfhs_xh ,
                                            khddm_khbh ,
                                            fhzs_invoiceF ,
                                            fhzs_plF ,
                                            fhzs_blF
                                   ) AS fh ON khys_khh = fh.khddm_khbh
                                              AND khys_banderno = fh.fhzs_bn
                WHERE   ( ISNULL(shqr, 0) = 1
                          OR DATEDIFF(dd, DATEADD(m, 1, fhzs_fhrq), GETDATE()) >= 0
                        )
                        AND fhzs_fhrq BETWEEN '" + startETD + @"' AND '" + endETD + @"'";
            if (!String.IsNullOrEmpty(bundleNo))
            {
                sql += "and khys_banderno ='" + bundleNo + "')";
            }
            if (!String.IsNullOrEmpty(container))
            {
                sql += "and khys_container = '" + container + @"')";
            }
            sql += @"GROUP BY shqr ,
                        shqrr ,
                        shqrrq ,
                        fhzs_fhrq ,
                        khys_banderno ,
                        khys_gz ,
                        khys_container ,
                        fhzs_bnBfb ,
                        yid ,
                        khys_khh ,
                        fhzs_dh ,
                        fhzs_invoiceNo ,
                        khdd ,
                        fhzs_invoiceF ,
                        fhzs_plF ,
                        fhzs_blF
                HAVING  SUM(fh.fhs) > 0
                ORDER BY fhzs_fhrq ,
                        khys_banderno";

            var list = new List<ArrivedModel>();

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString, CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    var info = new ArrivedModel();

                    info.SendDate = reader.GetDateTime(0);
                    info.BundleNo = reader.GetString(1);
                    info.ContainerNo = reader.GetString(2);
                    info.Container = reader.GetString(3);
                    info.Filled = reader.GetDecimal(4);
                    info.SumPairs = reader.GetInt32(5);
                    info.Id = reader.GetInt32(6);
                    info.CustomerName = reader.GetString(7);
                    info.Confirm = reader.IsDBNull(8) ? "" : reader.GetString(8);
                    if (!reader.IsDBNull(9))
                    {
                        info.ConfirmDate = reader.GetDateTime(9);
                    }
                    info.InvoiceName = reader.IsDBNull(11) ? "" : reader.GetString(11);
                    info.ContractNo = reader.IsDBNull(12) ? "" : reader.GetString(12);
                    info.Invoice = reader.IsDBNull(13) ? "" : reader.GetString(13);
                    info.PackingList = reader.IsDBNull(14) ? "" : reader.GetString(14);
                    info.BL = reader.IsDBNull(15) ? "" : reader.GetString(15);

                    list.Add(info);
                }
            }
            return list;
        }

        public static List<ArrivedDetail> LoadDetail(string customerCode,
            DateTime sendDate
            , string bundleNo
            , string containerNo
            , string container)
        {
            string sql = @"SELECT  yid ,
                            fh.xh ,
                            fhzs_fhrq ,
                            khys_banderNo ,
                            khys_gz ,
                            fh.s1 + fh.s2 + fh.s3 + fh.s4 + fh.s5 + fh.s6 + fh.s7 + fh.s8 + fh.s9
                            + fh.s10 + fh.s11 + fh.s12 + fh.s13 + fh.s14 + fh.s15 + fh.s16
                            + fh.s17 + fh.s18 + fh.s19 + fh.s20 AS sumS ,
                            fh.s1 ,
                            fh.s2 ,
                            fh.s3 ,
                            fh.s4 ,
                            fh.s5 ,
                            fh.s6 ,
                            fh.s7 ,
                            fh.s8 ,
                            fh.s9 ,
                            fh.s10 ,
                            fh.s11 ,
                            fh.s12 ,
                            fh.s13 ,
                            fh.s14 ,
                            fh.s15 ,
                            fh.s16 ,
                            fh.s17 ,
                            fh.s18 ,
                            fh.s19 ,
                            fh.s20 ,
                            fhzs_bnBfb ,
                            1 AS khys_zt ,
                            khys_container ,
                            khddm_khjq ,
                            fh.htbh
                    FROM    ( SELECT    khys_khh ,
                                        khys_banderno ,
                                        khys_gz ,
                                        khys_container ,
                                        MIN(id) AS yid
                                FROM      t_sale_khys
                                WHERE     khys_khh = '" + customerCode + @"'
                                GROUP BY  khys_khh ,
                                        khys_banderno ,
                                        khys_gz ,
                                        khys_container
                            ) AS khys
                            RIGHT JOIN ( SELECT fhzs_fhrq ,
                                                fhzs_bn ,
                                                fhzs_bnBfb ,
                                                khddm_khbh ,
                                                khddm_khjq ,
                                                ( CASE WHEN ISNULL(khddm_qgdh, '') = ''
                                                            OR ISNULL(khddm_qgdh, '') = 'YS'
                                                        THEN khddm_ddh
                                                        ELSE khddm_qgdh
                                                    END ) AS htbh ,
                                                ( SELECT    Xh_khxh
                                                    FROM      t_bas_xh xh
                                                            INNER JOIN t_bas_xt xt ON Xh_xt = Xt_xt
                                                    WHERE     ISNULL(xt_istt, 0) = 0
                                                            AND Xt_khh = m.khddm_khbh
                                                            AND Xh_bh = khddfhs_xh
                                                ) AS xh ,
                                                SUM(ISNULL(khddfhs_qr1, 0))
                                                + SUM(ISNULL(khddfhs_qr2, 0))
                                                + SUM(ISNULL(khddfhs_qr3, 0))
                                                + SUM(ISNULL(khddfhs_qr4, 0))
                                                + SUM(ISNULL(khddfhs_qr5, 0))
                                                + SUM(ISNULL(khddfhs_qr6, 0))
                                                + SUM(ISNULL(khddfhs_qr7, 0))
                                                + SUM(ISNULL(khddfhs_qr8, 0))
                                                + SUM(ISNULL(khddfhs_qr9, 0))
                                                + SUM(ISNULL(khddfhs_qr10, 0))
                                                + SUM(ISNULL(khddfhs_qr11, 0))
                                                + SUM(ISNULL(khddfhs_qr12, 0))
                                                + SUM(ISNULL(khddfhs_qr13, 0))
                                                + SUM(ISNULL(khddfhs_qr14, 0))
                                                + SUM(ISNULL(khddfhs_qr15, 0))
                                                + SUM(ISNULL(khddfhs_qr16, 0))
                                                + SUM(ISNULL(khddfhs_qr17, 0))
                                                + SUM(ISNULL(khddfhs_qr18, 0))
                                                + SUM(ISNULL(khddfhs_qr19, 0))
                                                + SUM(ISNULL(khddfhs_qr20, 0)) AS fhs ,
                                                SUM(ISNULL(khddfhs_qr1, 0)) AS s1 ,
                                                SUM(ISNULL(khddfhs_qr2, 0)) AS s2 ,
                                                SUM(ISNULL(khddfhs_qr3, 0)) AS s3 ,
                                                SUM(ISNULL(khddfhs_qr4, 0)) AS s4 ,
                                                SUM(ISNULL(khddfhs_qr5, 0)) AS s5 ,
                                                SUM(ISNULL(khddfhs_qr6, 0)) AS s6 ,
                                                SUM(ISNULL(khddfhs_qr7, 0)) AS s7 ,
                                                SUM(ISNULL(khddfhs_qr8, 0)) AS s8 ,
                                                SUM(ISNULL(khddfhs_qr9, 0)) AS s9 ,
                                                SUM(ISNULL(khddfhs_qr10, 0)) AS s10 ,
                                                SUM(ISNULL(khddfhs_qr11, 0)) AS s11 ,
                                                SUM(ISNULL(khddfhs_qr12, 0)) AS s12 ,
                                                SUM(ISNULL(khddfhs_qr13, 0)) AS s13 ,
                                                SUM(ISNULL(khddfhs_qr14, 0)) AS s14 ,
                                                SUM(ISNULL(khddfhs_qr15, 0)) AS s15 ,
                                                SUM(ISNULL(khddfhs_qr16, 0)) AS s16 ,
                                                SUM(ISNULL(khddfhs_qr17, 0)) AS s17 ,
                                                SUM(ISNULL(khddfhs_qr18, 0)) AS s18 ,
                                                SUM(ISNULL(khddfhs_qr19, 0)) AS s19 ,
                                                SUM(ISNULL(khddfhs_qr20, 0)) AS s20
                                            FROM   t_sale_khddfhs fhs
                                                INNER JOIN tab_dep_fhzs z ON khddfhs_fhzsd = fhzs_dh
                                                INNER JOIN t_sale_khddm m ON khddfhs_Ddh = khddm_ddh
                                            WHERE  ISNULL(fhzs_isfh, 0) = 1
                                                AND khddm_khbh = '" + customerCode + @"'
                                                AND DATEDIFF(d, fhzs_fhrq, '" + sendDate + @"') = 0
                                                AND ISNULL(fhzs_bn, '') = '" + bundleNo + @"'
                                            GROUP BY fhzs_fhrq ,
                                                fhzs_bn ,
                                                fhzs_bnBfb ,
                                                khddm_khbh ,
                                                khddfhs_xh ,
                                                khddm_khjq ,
                                                ( CASE WHEN ISNULL(khddm_qgdh, '') = ''
                                                            OR ISNULL(khddm_qgdh, '') = 'YS'
                                                        THEN khddm_ddh
                                                        ELSE khddm_qgdh
                                                    END )
                                        ) AS fh ON khys_khh = fh.khddm_khbh
                                                    AND khys_banderno = fh.fhzs_bn
                    WHERE   ISNULL(khys_gz, '') = '" + containerNo + @"'
                            AND ISNULL(khys_container, '') = '" + container + @"'
                    ORDER BY fh.xh";

            var list = new List<ArrivedDetail>();

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString, CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    var detail = new ArrivedDetail();
                    detail.ModelNo = reader.GetString(1);

                    detail.Total = reader.GetInt32(5);
                    detail.Size1 = reader.GetInt32(6);
                    detail.Size2 = reader.GetInt32(7);
                    detail.Size3 = reader.GetInt32(8);
                    detail.Size4 = reader.GetInt32(9);
                    detail.Size5 = reader.GetInt32(10);
                    detail.Size6 = reader.GetInt32(11);
                    detail.Size7 = reader.GetInt32(12);
                    detail.Size8 = reader.GetInt32(13);
                    detail.Size9 = reader.GetInt32(14);
                    detail.Size10 = reader.GetInt32(15);
                    detail.Size11 = reader.GetInt32(16);
                    detail.Size12 = reader.GetInt32(17);
                    detail.Size13 = reader.GetInt32(18);
                    detail.Size14 = reader.GetInt32(19);
                    detail.Size15 = reader.GetInt32(20);
                    detail.Size16 = reader.GetInt32(21);
                    detail.Size17 = reader.GetInt32(22);
                    detail.Size18 = reader.GetInt32(23);
                    detail.Size19 = reader.GetInt32(24);
                    detail.Size20 = reader.GetInt32(25);

                    detail.SendDate = reader.GetDateTime(29);
                    detail.ContractNumber = reader.IsDBNull(30) ? "" : reader.GetString(30);

                    list.Add(detail);
                }
            }

            return list;
        }
    }
}
