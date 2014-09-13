using System;
using System.Collections.Generic;
using System.Linq;
using JonLong.CRM.Models;
using JonLong.CRM.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace JonLong.CRM.DAL
{
    public static class OrderVarianceDataProvider
    {
        public static List<OrderVarianceModel> LoadOrderVariance(bool isSuperAdmin, string customerCode = "")
        {
            string tGuid = Guid.NewGuid().ToString();
            var list = new List<OrderVarianceModel>();

            string sql = String.Empty;
            if (isSuperAdmin)
            {
                sql = @"declare @kh varchar(30) declare khCur cursor for 
                    select distinct khbh from t_Sys_User where ISNULL(khbh,'')<>'' 
                    and khbh in (select kh_bh from t_Bas_kh where isnull(kh_lx,'')='1' 
                    or kh_bh in ('U0005','U0034','U0035','U0036','U0037'))
                    open khCur
                    fetch next from khCur into @kh
                    while @@FETCH_STATUS=0
                    begin
                      exec spr_ys_yq1 '" + tGuid + @"',@kh
                      fetch next from khCur into @kh
                    end
                    close khCur
                    deallocate khCur
                    select khys_fhrq,khys_banderno,khys_gz,khys_container,cast((case when max(isnull(ysl,0))=0 
                    then 0 else cast(sum(khys_sl) 
                                        as decimal(12,4))/max(isnull(ysl,0))*100 end) as decimal(12,2)) as bfb ,sum(khys_sl) as sumS,''
                    ,MIN(id) as id, max(isnull(khdd,'')) as khdd,(select ISNULL(kh_jc,'') from t_bas_kh where Kh_bh=t.khys_khh) as khjc
                    ,t.khys_khh from t_tmp_ysyq t inner join (select khys_khh,khys_banderno as bn,sum(khys_sl) as ysl 
                    from t_sale_khys group by khys_khh,khys_banderno) as y
                    on t.khys_banderno=y.bn and t.khys_khh=y.khys_khh
                    where sta=1 and tGuid=(select top 1 tGuid from t_tmp_ysyq order by rq desc)
                    group by t.khys_khh,khys_fhrq,khys_banderno,khys_gz,khys_container order by t.khys_khh,khys_fhrq,khys_banderno";

            }
            else
            {
                sql = @"exec spr_ys_yq1  '" + tGuid + @"', '" + customerCode + @"'
                        select khys_fhrq,khys_banderno,khys_gz,khys_container,
                        cast((case when max(isnull(ysl,0))=0 then 0 else cast(sum(khys_sl) as decimal(12,4))/max(isnull(ysl,0))*100 end)
                        as decimal(12,2))  as bfb,sum(khys_sl) as sumS,'',MIN(id) as id, max(isnull(khdd,'')) as khdd,(select ISNULL(kh_jc,'') 
                        from t_bas_kh where Kh_bh=t.khys_khh) as khjc,t.khys_khh from t_tmp_ysyq t inner join (select khys_banderno as bn,
                        sum(khys_sl) as ysl from t_sale_khys where khys_khh='" + customerCode + @"' group by khys_banderno) as y on t.khys_banderno=y.bn
                        where sta=1 
                        and tGuid=(select top 1 tGuid from t_tmp_ysyq where khys_khh='" + customerCode + @"' order by rq desc)  
                        and khys_khh='" + customerCode + @"' 
                        group by t.khys_khh,khys_fhrq,khys_banderno,khys_gz,khys_container order by t.khys_khh,khys_fhrq,khys_banderno
                        ";
            }

            using (var reader = SqlHelper.ExecuteReader(
                ConnectionHelper.ConnectionString
                , CommandType.Text
                , sql))
            {
                while (reader.Read())
                {
                    var info = new OrderVarianceModel();

                    info.ETD = reader.GetDateTime(0);
                    info.BundleNo = reader.GetString(1);
                    info.ContainerType = reader.GetString(2);
                    info.ContainerNo = reader.GetString(3);
                    info.Variance = reader.GetDecimal(4);
                    info.SumPairs = reader.GetInt32(5);
                    info.Id = reader.GetInt32(7);
                    info.ContractNo = reader.GetString(8);
                    info.TGuid = tGuid;
                    info.KHJC = reader.IsDBNull(9) ? "" : reader.GetString(9);
                    info.CustomerCode = reader.GetString(10);

                    list.Add(info);
                }
            }

            return list;
        }

        public static List<VarianceDetail> LoadDetail(
            string customerCode,
            DateTime sendDate,
            string bundleNo,
            string containerNo,
            string container)
        {
            var list = new List<VarianceDetail>();
            string sql = @"select id,khys_xh,khys_fhrq,khys_banderNo,khys_gz,khys_sl,khys_s1,khys_s2,khys_s3,khys_s4,khys_s5
                        ,khys_s6,khys_s7,khys_s8,khys_s9,khys_s10,khys_s11,khys_s12,
                        khys_s13,khys_s14,khys_s15,khys_s16,khys_s17,khys_s18,khys_s19,khys_s20,
                        khys_htbh,khys_bfb,1,khys_container,khys_fhrq as yfhrq,isnull(oldHtbh,'') as oldHtbh,isnull(cylx,0) as cylx
                        ,isnull(khdd,'') as khdd
                        from t_tmp_ysyq where sta=1 
                        and tGuid=(select top 1 tGuid from t_tmp_ysyq where khys_khh='" + customerCode + @"'order by rq desc)"
                        + @"and khys_khh= '" + customerCode + @"' and datediff(d,khys_fhrq, '" + sendDate.ToShortDateString() + @"')=0 and 
                        isnull(khys_banderNo,'')='" + bundleNo + @"' and isnull(khys_gz,'')='" + containerNo + @"' 
                        and isnull(khys_container,'')='" + container + @"'
                        order by khys_xh";

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
                , CommandType.Text
                , sql))
            {
                while (reader.Read())
                {
                    var detail = new VarianceDetail();
                    detail.Id = reader.GetInt32(0);
                    detail.ModelNo = reader.GetString(1);
                    detail.SendDate = reader.GetDateTime(2);
                    detail.BundleNo = reader.GetString(3);
                    detail.ContainerType = reader.GetString(4);
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
                    detail.ContractNo = reader.GetString(26);
                    detail.OldHtbh = reader.GetString(31);
                    detail.CYLX = reader.GetInt16(32);

                    list.Add(detail);
                }
            }

            return list;
        }

        public static VarianceDetail LoadById(int id)
        {
            string sql = @"select id,khys_xh,khys_fhrq,khys_banderNo,khys_gz,khys_sl,khys_s1,khys_s2,khys_s3,khys_s4,khys_s5
                        ,khys_s6,khys_s7,khys_s8,khys_s9,khys_s10,khys_s11,khys_s12,
                        khys_s13,khys_s14,khys_s15,khys_s16,khys_s17,khys_s18,khys_s19,khys_s20,
                        khys_htbh,khys_bfb,1,khys_container,khys_fhrq as yfhrq,isnull(oldHtbh,'') as oldHtbh,isnull(cylx,0) as cylx
                        ,isnull(khdd,'') as khdd
                FROM dbo.t_tmp_ysyq
                WHERE id = " + id;

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
                , CommandType.Text
                , sql))
            {
                if (reader.Read())
                {
                    var detail = new VarianceDetail();
                    detail.Id = reader.GetInt32(0);
                    detail.ModelNo = reader.GetString(1);
                    detail.SendDate = reader.GetDateTime(2);
                    detail.BundleNo = reader.GetString(3);
                    detail.ContainerType = reader.GetString(4);
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
                    detail.OldHtbh = reader.GetString(26);
                    detail.ContractNo = reader.GetString(33);

                    return detail;
                }
            }
            return null;

        }
        public static string Edit(VarianceEditModel model)
        {
            SqlParameter[] parameters = new SqlParameter[31];
            parameters[0] = new SqlParameter("@lx", SqlDbType.SmallInt);
            parameters[0].Value = model.EditType;
            parameters[1] = new SqlParameter("@tGuid", SqlDbType.VarChar);
            parameters[1].Value = model.TGuid;
            parameters[2] = new SqlParameter("@khh", SqlDbType.VarChar);
            parameters[2].Value = model.CustomerCode;
            parameters[3] = new SqlParameter("@xh", SqlDbType.VarChar);
            parameters[3].Value = model.ModelNo;
            parameters[4] = new SqlParameter("@htbh", SqlDbType.VarChar);
            parameters[4].Value = model.OldHtbh;
            parameters[5] = new SqlParameter("@czr", SqlDbType.VarChar);
            parameters[5].Value = model.LoginName;
            parameters[6] = new SqlParameter("@fhrq", SqlDbType.Date);
            parameters[6].Value = model.SendDate;
            parameters[7] = new SqlParameter("@bundleNo", SqlDbType.VarChar);
            parameters[7].Value = model.BundleNo;
            parameters[8] = new SqlParameter("@bn", SqlDbType.VarChar);
            parameters[8].Value = model.OldBundleNo;
            parameters[9] = new SqlParameter("@id", SqlDbType.Int);
            parameters[9].Value = model.Id;
            parameters[10] = new SqlParameter("@s1", SqlDbType.Int);
            parameters[10].Value = model.Size1;
            parameters[11] = new SqlParameter("@s2", SqlDbType.Int);
            parameters[11].Value = model.Size2;
            parameters[12] = new SqlParameter("@s3", SqlDbType.Int);
            parameters[12].Value = model.Size3;
            parameters[13] = new SqlParameter("@s4", SqlDbType.Int);
            parameters[13].Value = model.Size4;
            parameters[14] = new SqlParameter("@s5", SqlDbType.Int);
            parameters[14].Value = model.Size5;
            parameters[15] = new SqlParameter("@s6", SqlDbType.Int);
            parameters[15].Value = model.Size6;
            parameters[16] = new SqlParameter("@s7", SqlDbType.Int);
            parameters[16].Value = model.Size7;
            parameters[17] = new SqlParameter("@s8", SqlDbType.Int);
            parameters[17].Value = model.Size8;
            parameters[18] = new SqlParameter("@s9", SqlDbType.Int);
            parameters[18].Value = model.Size9;
            parameters[19] = new SqlParameter("@s10", SqlDbType.Int);
            parameters[19].Value = model.Size10;
            parameters[20] = new SqlParameter("@s11", SqlDbType.Int);
            parameters[20].Value = model.Size11;
            parameters[21] = new SqlParameter("@s12", SqlDbType.Int);
            parameters[21].Value = model.Size12;
            parameters[22] = new SqlParameter("@s13", SqlDbType.Int);
            parameters[22].Value = model.Size13;
            parameters[23] = new SqlParameter("@s14", SqlDbType.Int);
            parameters[23].Value = model.Size14;
            parameters[24] = new SqlParameter("@s15", SqlDbType.Int);
            parameters[24].Value = model.Size15;
            parameters[25] = new SqlParameter("@s16", SqlDbType.Int);
            parameters[25].Value = model.Size16;
            parameters[26] = new SqlParameter("@s17", SqlDbType.Int);
            parameters[26].Value = model.Size17;
            parameters[27] = new SqlParameter("@s18", SqlDbType.Int);
            parameters[27].Value = model.Size18;
            parameters[28] = new SqlParameter("@s19", SqlDbType.Int);
            parameters[28].Value = model.Size19;
            parameters[29] = new SqlParameter("@s20", SqlDbType.Int);
            parameters[29].Value = model.Size20;
            parameters[30] = new SqlParameter("@message", SqlDbType.VarChar);
            parameters[30].Size = 500;
            parameters[30].Direction = ParameterDirection.InputOutput;

            SqlHelper.ExecuteNonQuery(ConnectionHelper.ConnectionString
               , CommandType.StoredProcedure
               , "spr_khys_ovrN"
               , parameters);

            return parameters[30].Value.ToString();

        }

        public static List<VarianceOrderModel> LoadOrder(string customerCode)
        {
            string sql = @"select khys_fhrq,khys_banderno,khys_gz,khys_container,
            cast((case when sum(khys_bfb)=0 then 0 else cast(sum(khys_sl) as decimal(12,4))/sum(khys_bfb)*100 end) as decimal(12,2)) as bfb 
            ,sum(khys_sl) as sumS,'',MIN(id) as id,
            max(isnull(khys_khdd,'')) as khdd,(select ISNULL(kh_jc,'') 
            from t_bas_kh where Kh_bh=t_sale_khys.khys_khh) as khjc,khys_khh 
            from t_sale_khys where khys_khh= '" + customerCode + @"' and khys_banderno in (select khys_banderno from t_tmp_ysyq 
            where tGuid=(select top 1 tGuid from t_tmp_ysyq where khys_khh='" + customerCode + @"' order by rq desc)  
            and khys_khh='" + customerCode + @"')
            group by khys_khh,khys_fhrq,khys_banderno,khys_gz,khys_container order by khys_khh,khys_fhrq,khys_banderno
            ";

            var list = new List<VarianceOrderModel>();

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
               , CommandType.Text
               , sql))
            {
                while (reader.Read())
                {
                    var model = new VarianceOrderModel
                    {
                        ETD = reader.GetDateTime(0),
                        BundleNo = reader.GetString(1),
                        ContainerType = reader.GetString(2),
                        ContainerNo = reader.GetString(3),
                        SumPairs = reader.GetInt32(5),
                        Id = reader.GetInt32(7),
                        ContractNo = reader.GetString(8),
                        CustomerCode = reader.GetString(10)
                    };

                    list.Add(model);
                }
            }

            return list;
        }

        public static List<VarianceDetail> LoadOrderDetail(string customerCode,
            DateTime sendDate,
            string bundleNo,
            string containerNo,
            string container)
        {
            string sql = @"SELECT  id ,
                khys_xh ,
                khys_fhrq ,
                khys_banderNo ,
                khys_gz ,
                khys_sl ,
                khys_s1 ,
                khys_s2 ,
                khys_s3 ,
                khys_s4 ,
                khys_s5 ,
                khys_s6 ,
                khys_s7 ,
                khys_s8 ,
                khys_s9 ,
                khys_s10 ,
                khys_s11 ,
                khys_s12 ,
                khys_s13 ,
                khys_s14 ,
                khys_s15 ,
                khys_s16 ,
                khys_s17 ,
                khys_s18 ,
                khys_s19 ,
                khys_s20 ,
                khys_htbh ,
                khys_bfb ,
                1 ,
                khys_container ,
                khys_fhrq AS yfhrq ,
                ISNULL(khys_htbh, '') AS htbh ,
                ISNULL(khys_khdd, '') AS khdd
        FROM    t_sale_khys
        WHERE   khys_khh = '" + customerCode + @"'
                AND DATEDIFF(d, khys_fhrq, '" + sendDate.ToShortDateString() + @"') = 0
                AND ISNULL(khys_banderNo, '') = '" + bundleNo + @"'
                AND ISNULL(khys_gz, '') = '" + containerNo + @"'
                AND ISNULL(khys_container, '') = '" + container + @"'
        ORDER BY khys_xh";

            var list = new List<VarianceDetail>();

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
                , CommandType.Text
                , sql))
            {
                while (reader.Read())
                {
                    var detail = new VarianceDetail();
                    detail.Id = reader.GetInt32(0);
                    detail.ModelNo = reader.GetString(1);
                    detail.SendDate = reader.GetDateTime(2);
                    detail.BundleNo = reader.GetString(3);
                    detail.ContainerType = reader.GetString(4);
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
                    detail.OldHtbh = reader.GetString(26);
                    detail.ContractNo = reader.GetString(31);

                    list.Add(detail);
                }
            }

            return list;
        }

        public static List<Shipment> LoadShipments(string customerCode)
        {
            string sql = @"SELECT  khys_fhrq ,
                        khys_banderno ,
                        khys_gz ,
                        khys_container ,
                        CAST(( CASE WHEN SUM(khys_bfb) = 0 THEN 0
                                    ELSE CAST(SUM(khys_sl) AS DECIMAL(12, 4)) / SUM(khys_bfb)
                                         * 100
                               END ) AS DECIMAL(12, 2)) ,
                        SUM(khys_sl) AS sumS ,
                        '' ,
                        MIN(id) AS id ,
                        MAX(ISNULL(khdd, '')) AS khdd ,
                        ( SELECT    ISNULL(kh_jc, '')
                          FROM      t_bas_kh
                          WHERE     Kh_bh = t_tmp_ysyq.khys_khh
                        ) AS khjc ,
                        khys_khh
                FROM    t_tmp_ysyq
                WHERE   sta = 2
                        AND tGuid = ( SELECT TOP 1
                                                tGuid
                                      FROM      t_tmp_ysyq
                                      WHERE     khys_khh = '" + customerCode + @"'
                                      ORDER BY  rq DESC
                                    )
                        AND khys_khh = '" + customerCode + @"'
                GROUP BY khys_khh ,
                        khys_fhrq ,
                        khys_banderno ,
                        khys_gz ,
                        khys_container
                ORDER BY khys_khh ,
                        khys_fhrq ,
                        khys_banderno";

            var list = new List<Shipment>();

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
               , CommandType.Text
               , sql))
            {
                while (reader.Read())
                {
                    var model = new Shipment
                    {
                        ETD = reader.GetDateTime(0),
                        BundleNo = reader.IsDBNull(1) ? "" : reader.GetString(1),
                        ContainerType = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        ContainerNo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        SumPairs = reader.GetInt32(5),
                        Id = reader.GetInt32(7),
                        ContractNo = reader.IsDBNull(8) ? "" : reader.GetString(8),
                        CustomerCode = reader.IsDBNull(10) ? "" : reader.GetString(10)
                    };

                    list.Add(model);
                }
            }

            return list;
        }

        public static List<VarianceDetail> LoadShipmentDetail(
            string customerCode,
            DateTime sendDate,
            string bundleNo,
            string containerNo,
            string container)
        {
            string sql = @"SELECT  id ,
                        khys_xh ,
                        khys_fhrq ,
                        khys_banderNo ,
                        khys_gz ,
                        khys_sl ,
                        khys_s1 ,
                        khys_s2 ,
                        khys_s3 ,
                        khys_s4 ,
                        khys_s5 ,
                        khys_s6 ,
                        khys_s7 ,
                        khys_s8 ,
                        khys_s9 ,
                        khys_s10 ,
                        khys_s11 ,
                        khys_s12 ,
                        khys_s13 ,
                        khys_s14 ,
                        khys_s15 ,
                        khys_s16 ,
                        khys_s17 ,
                        khys_s18 ,
                        khys_s19 ,
                        khys_s20 ,
                        khys_htbh ,
                        khys_bfb ,
                        1 ,
                        khys_container ,
                        khys_khjq ,
                        ISNULL(khys_htbh, '') ,
                        ISNULL(khdd, '') AS khdd
                FROM    t_tmp_ysyq
                WHERE   sta = 2
                        AND tGuid = ( SELECT TOP 1
                                                tGuid
                                      FROM      t_tmp_ysyq
                                      WHERE     khys_khh = '" + customerCode + @"'
                                      ORDER BY  rq DESC
                                    )
                        AND khys_khh = '" + customerCode + @"'
                        AND DATEDIFF(d, khys_fhrq, '" + sendDate + @"') = 0
                        AND ISNULL(khys_banderNo, '') = '" + bundleNo + @"'
                        AND ISNULL(khys_gz, '') = '" + containerNo + @"'
                        AND ISNULL(khys_container, '') = '" + container + @"'
                ORDER BY khys_xh";

            var list = new List<VarianceDetail>();

            using (var reader = SqlHelper.ExecuteReader(ConnectionHelper.ConnectionString
                , CommandType.Text
                , sql))
            {
                while (reader.Read())
                {
                    var detail = new VarianceDetail();
                    detail.Id = reader.GetInt32(0);
                    detail.ModelNo = reader.GetString(1);
                    detail.SendDate = reader.GetDateTime(2);
                    detail.BundleNo = reader.GetString(3);
                    detail.ContainerType = reader.GetString(4);
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
                    detail.OldHtbh = reader.GetString(26);
                    detail.ContractNo = reader.GetString(31);

                    list.Add(detail);
                }
            }

            return list;
        }

    }
}
