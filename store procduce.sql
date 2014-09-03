USE [jncrm]
GO

/****** Object:  Table [dbo].[t_sale_khys]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_sale_khys](
	[id] [int] NOT NULL,
	[khys_xh] [varchar](30) NULL,
	[khys_fhrq] [datetime] NULL,
	[khys_banderNo] [varchar](20) NULL,
	[khys_gz] [varchar](10) NULL,
	[khys_sl] [int] NULL,
	[khys_s1] [int] NULL,
	[khys_s2] [int] NULL,
	[khys_s3] [int] NULL,
	[khys_s4] [int] NULL,
	[khys_s5] [int] NULL,
	[khys_s6] [int] NULL,
	[khys_s7] [int] NULL,
	[khys_s8] [int] NULL,
	[khys_s9] [int] NULL,
	[khys_s10] [int] NULL,
	[khys_s11] [int] NULL,
	[khys_s12] [int] NULL,
	[khys_s13] [int] NULL,
	[khys_s14] [int] NULL,
	[khys_s15] [int] NULL,
	[khys_s16] [int] NULL,
	[khys_s17] [int] NULL,
	[khys_s18] [int] NULL,
	[khys_s19] [int] NULL,
	[khys_s20] [int] NULL,
	[khys_issh] [bit] NULL,
	[khys_shr] [varchar](12) NULL,
	[khys_shrq] [datetime] NULL,
	[khys_isjs] [bit] NULL,
	[khys_khh] [varchar](10) NULL,
	[khys_djr] [varchar](12) NULL,
	[khys_djrq] [datetime] NULL,
	[khys_bfb] [decimal](9, 2) NULL,
	[khys_htbh] [varchar](16) NULL,
	[khys_isfhwc] [bit] NULL,
	[khys_zt] [smallint] NULL,
	[khys_container] [varchar](10) NULL,
	[khys_khjq] [smalldatetime] NULL,
	[khys_xhb] [varchar](30) NULL,
	[khys_fhb] [decimal](9, 2) NULL,
	[khys_wcb] [decimal](9, 2) NULL,
	[khys_khdd] [varchar](30) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[t_sale_khys_LoadBundlerNos]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_sale_khys_LoadBundlerNos] 
( 
@khh VARCHAR(10) 
)
AS 
    BEGIN

        SET NOCOUNT ON ;

        SELECT DISTINCT
                khys_fhrq ,
                khys_banderNo ,
                khys_banderNo + '  ' + CONVERT(VARCHAR(10), khys_fhrq, 121) AS bn
        FROM    t_sale_khys WITH (NOLOCK)
        WHERE   khys_khh = @khh
                AND ISNULL(khys_fhb, 0) = 0
        UNION
        SELECT  NULL ,
                '' ,
                ''
        ORDER BY khys_fhrq ,
                khys_banderNo;

    END

GO

USE [jncrm]
GO

/****** Object:  Table [dbo].[t_bas_xh]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_bas_xh](
	[id] [int] NOT NULL,
	[Xh_xt] [varchar](100) NOT NULL,
	[Xh_bh] [varchar](100) NOT NULL,
	[Xh_zwys] [varchar](40) NOT NULL,
	[Xh_khxh] [varchar](100) NULL,
	[Xh_ywys] [varchar](40) NULL,
	[Xh_mcz] [varchar](100) NULL,
	[Xh_dcz] [varchar](100) NULL,
	[Xh_bz] [varchar](500) NULL,
	[Xh_dt] [image] NULL,
	[Xh_qt] [image] NULL,
	[Xh_issh] [bit] NULL,
	[Xh_shrq] [smalldatetime] NULL,
	[Xh_shr] [varchar](10) NULL,
	[Xh_pp] [varchar](20) NULL,
	[Xh_lcz] [varchar](40) NULL,
	[Xh_gn] [varchar](32) NULL,
	[xh_ys] [varchar](6) NULL,
	[Xh_tsxtbs] [numeric](9, 2) NULL,
	[Xh_ddys] [varchar](50) NULL,
	[Xh_zdys] [varchar](50) NULL,
	[Xh_gt] [varchar](50) NULL,
	[Xh_gb] [varchar](50) NULL,
	[Xh_tp1] [image] NULL,
	[Xh_tp2] [image] NULL,
	[Xh_tp3] [image] NULL,
	[Xh_tp4] [image] NULL,
	[Xh_tp5] [image] NULL,
	[Xh_tp6] [image] NULL,
	[xh_hz1] [varchar](10) NULL,
	[xh_hz2] [varchar](10) NULL,
	[xh_hz3] [varchar](10) NULL,
	[xh_hz4] [varchar](10) NULL,
	[xh_hz5] [varchar](10) NULL,
	[xh_hz6] [varchar](10) NULL,
	[xh_hzdt] [varchar](10) NULL,
	[hss] [int] NULL,
	[Xh_isxzjq] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [jncrm]
GO

/****** Object:  Table [dbo].[t_bas_xt]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_bas_xt](
	[id] [int] NOT NULL,
	[Xt_khh] [varchar](10) NOT NULL,
	[Xt_xt] [varchar](100) NOT NULL,
	[Xt_lb] [varchar](4) NULL,
	[Xt_xb] [varchar](4) NOT NULL,
	[Xt_xtbh] [varchar](30) NULL,
	[Xt_dbbh] [varchar](30) NULL,
	[Xt_zdbh] [varchar](30) NULL,
	[Xt_szlb] [varchar](1) NULL,
	[Xt_pp] [varchar](20) NULL,
	[Xt_khxt] [varchar](100) NULL,
	[csize1] [varchar](6) NULL,
	[csize2] [varchar](6) NULL,
	[csize3] [varchar](6) NULL,
	[csize4] [varchar](6) NULL,
	[csize5] [varchar](6) NULL,
	[csize6] [varchar](6) NULL,
	[csize7] [varchar](6) NULL,
	[csize8] [varchar](6) NULL,
	[csize9] [varchar](6) NULL,
	[csize10] [varchar](6) NULL,
	[csize11] [varchar](6) NULL,
	[csize12] [varchar](6) NULL,
	[csize13] [varchar](6) NULL,
	[csize14] [varchar](6) NULL,
	[csize15] [varchar](6) NULL,
	[csize16] [varchar](6) NULL,
	[csize17] [varchar](6) NULL,
	[csize18] [varchar](6) NULL,
	[csize19] [varchar](6) NULL,
	[csize20] [varchar](6) NULL,
	[csize21] [varchar](6) NULL,
	[csize22] [varchar](6) NULL,
	[csize23] [varchar](6) NULL,
	[csize24] [varchar](6) NULL,
	[csize25] [varchar](6) NULL,
	[csize26] [varchar](6) NULL,
	[csize27] [varchar](6) NULL,
	[csize28] [varchar](6) NULL,
	[csize29] [varchar](6) NULL,
	[csize30] [varchar](6) NULL,
	[csize31] [varchar](6) NULL,
	[csize32] [varchar](6) NULL,
	[Xt_issc] [bit] NULL,
	[Xt_zkh] [varchar](10) NULL,
	[Xt_gcmc] [varchar](40) NULL,
	[Xt_khmc] [varchar](40) NULL,
	[Xt_sjsid] [varchar](10) NULL,
	[Xt_ypxt] [varchar](30) NULL,
	[Xt_dblb] [varchar](30) NULL,
	[Xt_isx] [bit] NOT NULL,
	[Xt_bz] [varchar](100) NULL,
	[Xt_istt] [bit] NULL,
	[Xt_pm] [varchar](50) NULL,
	[xt_ms] [varchar](16) NULL,
	[xt_ms1] [varchar](16) NULL,
	[xt_lzb] [varchar](16) NULL,
	[xt_lys] [varchar](16) NULL,
	[xt_stys] [varchar](16) NULL,
	[xt_lhsj] [varchar](16) NULL,
	[xt_mjsj] [varchar](16) NULL,
	[xt_wfb] [varchar](16) NULL,
	[xt_kbgn] [varchar](16) NULL,
	[xt_ds] [varchar](16) NULL,
	[xt_dsxz] [varchar](16) NULL,
	[xt_lysxz] [varchar](16) NULL,
	[xt_stysxz] [varchar](16) NULL,
	[xt_lhsjm] [int] NULL,
	[xt_mjsjm] [int] NULL,
	[xt_sb] [varchar](16) NULL,
	[xt_mm] [varchar](32) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [jncrm]
GO

/****** Object:  Table [dbo].[t_sale_xtbj]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_sale_xtbj](
	[xt] [varchar](50) NOT NULL,
	[scjg] [decimal](18, 2) NULL,
	[cxjg] [decimal](18, 2) NULL,
	[cb] [decimal](18, 2) NULL,
	[Fplb] [int] NULL,
	[bbbh] [varchar](4) NULL,
	[Id] [int] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[t_bas_xt_LoadShoes]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_bas_xt_LoadShoes]
(
	@khbh	VARCHAR(10)
)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT  gcxh AS xh_bh ,
        xh_bh AS qxh
	FROM    ( SELECT    ISNULL(Xh_khxh, '') AS xh_bh ,
						Xh_bh AS gcxh
			  FROM      t_bas_xt WITH (NOLOCK)
						INNER JOIN t_bas_xh WITH (NOLOCK) ON Xt_xt = Xh_xt
			  WHERE     ISNULL(xt_istt, 0) = 0
						AND Xt_khh = @khbh
						AND ISNULL(Xh_khxh, '') <> ''
						AND ISNULL(Xh_issh, 0) = 1
						AND Xh_bh IN ( SELECT   xt
									   FROM     t_sale_xtbj )
			  UNION
			  SELECT    'ALL' ,
						'ALL' AS xh_bh
			) AS t
	ORDER BY ( CASE WHEN xh_bh = 'all' THEN ''
					ELSE xh_bh
			   END )


END

GO

/****** Object:  StoredProcedure [dbo].[t_sale_khys_LoadContainer]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_sale_khys_LoadContainer]
    (
      @khh VARCHAR(10) ,
      @bundleNo VARCHAR(20)
    )
AS 
    BEGIN

        SET NOCOUNT ON ;

        SELECT DISTINCT
                ISNULL(khys_gz, '')
        FROM    t_sale_khys WITH (NOLOCK)
        WHERE   khys_khh = @khh
                AND khys_banderNo = @bundleNo
    END

GO

USE [jncrm]
GO

/****** Object:  Table [dbo].[t_sale_khys_cfqr]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_sale_khys_cfqr](
	[id] [int] NOT NULL,
	[cfqr_rq] [datetime] NULL,
	[cfqr_zh] [varchar](12) NULL,
	[cfqr_khh] [varchar](10) NULL,
	[cfqr_xh] [varchar](30) NULL,
	[cfqr_jq] [datetime] NULL,
	[cfqr_htbh] [varchar](16) NULL,
	[cfqr_sl] [int] NULL,
	[cfqr_s1] [int] NULL,
	[cfqr_s2] [int] NULL,
	[cfqr_s3] [int] NULL,
	[cfqr_s4] [int] NULL,
	[cfqr_s5] [int] NULL,
	[cfqr_s6] [int] NULL,
	[cfqr_s7] [int] NULL,
	[cfqr_s8] [int] NULL,
	[cfqr_s9] [int] NULL,
	[cfqr_s10] [int] NULL,
	[cfqr_s11] [int] NULL,
	[cfqr_s12] [int] NULL,
	[cfqr_s13] [int] NULL,
	[cfqr_s14] [int] NULL,
	[cfqr_s15] [int] NULL,
	[cfqr_s16] [int] NULL,
	[cfqr_s17] [int] NULL,
	[cfqr_s18] [int] NULL,
	[cfqr_s19] [int] NULL,
	[cfqr_s20] [int] NULL,
	[cfqr_bn] [varchar](20) NULL,
	[cfqr_xhb] [varchar](30) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[t_sale_khys_LoadById]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_sale_khys_LoadById] ( @Id INT )
AS 
    BEGIN

        SET NOCOUNT ON ;
	
        WITH    CTE
                  AS ( SELECT   cfqr_htbh ,
                                cfqr_xh ,
                                SUM(cfqr_sl) AS cfsl ,
                                SUM(cfqr_s1) AS s1 ,
                                SUM(cfqr_s2) AS s2 ,
                                SUM(cfqr_s3) AS s3 ,
                                SUM(cfqr_s4) AS s4 ,
                                SUM(cfqr_s5) AS s5 ,
                                SUM(cfqr_s6) AS s6 ,
                                SUM(cfqr_s7) AS s7 ,
                                SUM(cfqr_s8) AS s8 ,
                                SUM(cfqr_s9) AS s9 ,
                                SUM(cfqr_s10) AS s10 ,
                                SUM(cfqr_s11) AS s11 ,
                                SUM(cfqr_s12) AS s12 ,
                                SUM(cfqr_s13) AS s13 ,
                                SUM(cfqr_s14) AS s14 ,
                                SUM(cfqr_s15) AS s15 ,
                                SUM(cfqr_s16) AS s16 ,
                                SUM(cfqr_s17) AS s17 ,
                                SUM(cfqr_s18) AS s18 ,
                                SUM(cfqr_s19) AS s19 ,
                                SUM(cfqr_s20) AS s20
                       FROM     t_sale_khys_cfqr AS skc WITH ( NOLOCK )
								INNER JOIN t_sale_khys y WITH ( NOLOCK )
								ON skc.cfqr_khh = y.khys_khh
                       WHERE    y.id = @Id
								AND ISNULL(skc.cfqr_htbh, '') <> ''
                       GROUP BY skc.cfqr_htbh ,
                                skc.cfqr_xh
                     )
            SELECT  id ,
                    khys_xh ,
                    khys_fhrq ,
                    khys_banderNo ,
                    khys_gz ,
                    khys_sl - ISNULL(cfsl, 0) AS khys_sl ,
                    khys_s1 - ISNULL(s1, 0) AS khys_s1 ,
                    khys_s2 - ISNULL(s2, 0) AS khys_s2 ,
                    khys_s3 - ISNULL(s3, 0) AS khys_s3 ,
                    khys_s4 - ISNULL(s4, 0) AS khys_s4 ,
                    khys_s5 - ISNULL(s5, 0) AS khys_s5 ,
                    khys_s6 - ISNULL(s6, 0) AS khys_s6 ,
                    khys_s7 - ISNULL(s7, 0) AS khys_s7 ,
                    khys_s8 - ISNULL(s8, 0) AS khys_s8 ,
                    khys_s9 - ISNULL(s9, 0) AS khys_s9 ,
                    khys_s10 - ISNULL(s10, 0) AS khys_s10 ,
                    khys_s11 - ISNULL(s11, 0) AS khys_s11 ,
                    khys_s12 - ISNULL(s12, 0) AS khys_s12 ,
                    khys_s13 - ISNULL(s13, 0) AS khys_s13 ,
                    khys_s14 - ISNULL(s14, 0) AS khys_s14 ,
                    khys_s15 - ISNULL(s15, 0) AS khys_s15 ,
                    khys_s16 - ISNULL(s16, 0) AS khys_s16 ,
                    khys_s17 - ISNULL(s17, 0) AS khys_s17 ,
                    khys_s18 - ISNULL(s18, 0) AS khys_s18 ,
                    khys_s19 - ISNULL(s19, 0) AS khys_s19 ,
                    khys_s20 - ISNULL(s20, 0) AS khys_s20 ,
                    khys_issh ,
                    khys_shr ,
                    khys_shrq ,
                    khys_isjs ,
                    khys_htbh ,
                    khys_bfb ,
                    khys_zt ,
                    khys_container ,
                    khys_khjq ,
                    ISNULL(khys_htbh, '') AS htbh ,
                    ISNULL(khys_khdd, '') AS khdd,
                    khys_khh
            FROM    t_sale_khys y WITH ( NOLOCK )
                    LEFT JOIN CTE AS  cf ON khys_htbh = cf.cfqr_htbh
                                      AND khys_xh = cf.cfqr_xh
            WHERE   y.id = @Id
            ORDER BY khys_xh

    END

GO

/****** Object:  StoredProcedure [dbo].[t_sale_khys_LoadDetail]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_sale_khys_LoadDetail]
    @fhrq DATE ,
    @khbh VARCHAR(50) ,
    @bundleNo VARCHAR(20) ,
    @khys_gz VARCHAR(10) ,
    @Container VARCHAR(10)
AS 
    BEGIN

        SET NOCOUNT ON ;
	
        SELECT  id ,
                khys_xh ,
                khys_fhrq ,
                khys_banderNo ,
                khys_gz ,
                khys_sl - ISNULL(cfsl, 0) AS khys_sl ,
                khys_s1 - ISNULL(s1, 0) AS khys_s1 ,
                khys_s2 - ISNULL(s2, 0) AS khys_s2 ,
                khys_s3 - ISNULL(s3, 0) AS khys_s3 ,
                khys_s4 - ISNULL(s4, 0) AS khys_s4 ,
                khys_s5 - ISNULL(s5, 0) AS khys_s5 ,
                khys_s6 - ISNULL(s6, 0) AS khys_s6 ,
                khys_s7 - ISNULL(s7, 0) AS khys_s7 ,
                khys_s8 - ISNULL(s8, 0) AS khys_s8 ,
                khys_s9 - ISNULL(s9, 0) AS khys_s9 ,
                khys_s10 - ISNULL(s10, 0) AS khys_s10 ,
                khys_s11 - ISNULL(s11, 0) AS khys_s11 ,
                khys_s12 - ISNULL(s12, 0) AS khys_s12 ,
                khys_s13 - ISNULL(s13, 0) AS khys_s13 ,
                khys_s14 - ISNULL(s14, 0) AS khys_s14 ,
                khys_s15 - ISNULL(s15, 0) AS khys_s15 ,
                khys_s16 - ISNULL(s16, 0) AS khys_s16 ,
                khys_s17 - ISNULL(s17, 0) AS khys_s17 ,
                khys_s18 - ISNULL(s18, 0) AS khys_s18 ,
                khys_s19 - ISNULL(s19, 0) AS khys_s19 ,
                khys_s20 - ISNULL(s20, 0) AS khys_s20 ,
                khys_issh ,
                khys_shr ,
                khys_shrq ,
                khys_isjs ,
                khys_htbh ,
                khys_bfb ,
                khys_zt ,
                khys_container ,
                khys_khjq ,
                ISNULL(khys_htbh, '') AS htbh ,
                ISNULL(khys_khdd, '') AS khdd
        FROM    t_sale_khys y WITH (NOLOCK)
                LEFT JOIN ( SELECT  cfqr_htbh ,
                                    cfqr_xh ,
                                    SUM(cfqr_sl) AS cfsl ,
                                    SUM(cfqr_s1) AS s1 ,
                                    SUM(cfqr_s2) AS s2 ,
                                    SUM(cfqr_s3) AS s3 ,
                                    SUM(cfqr_s4) AS s4 ,
                                    SUM(cfqr_s5) AS s5 ,
                                    SUM(cfqr_s6) AS s6 ,
                                    SUM(cfqr_s7) AS s7 ,
                                    SUM(cfqr_s8) AS s8 ,
                                    SUM(cfqr_s9) AS s9 ,
                                    SUM(cfqr_s10) AS s10 ,
                                    SUM(cfqr_s11) AS s11 ,
                                    SUM(cfqr_s12) AS s12 ,
                                    SUM(cfqr_s13) AS s13 ,
                                    SUM(cfqr_s14) AS s14 ,
                                    SUM(cfqr_s15) AS s15 ,
                                    SUM(cfqr_s16) AS s16 ,
                                    SUM(cfqr_s17) AS s17 ,
                                    SUM(cfqr_s18) AS s18 ,
                                    SUM(cfqr_s19) AS s19 ,
                                    SUM(cfqr_s20) AS s20
                            FROM    t_sale_khys_cfqr AS skc WITH ( NOLOCK )
                            WHERE   ISNULL(skc.cfqr_htbh, '') <> ''
                                    AND skc.cfqr_khh = @khbh
                            GROUP BY skc.cfqr_htbh ,
                                    skc.cfqr_xh
                          ) cf ON khys_htbh = cf.cfqr_htbh
                                  AND khys_xh = cf.cfqr_xh
        WHERE   khys_khh = @khbh
                AND DATEDIFF(d, khys_fhrq, @fhrq) = 0
                AND ISNULL(khys_banderNo, '') = @bundleno
                AND ISNULL(khys_gz, '') = @khys_gz
                AND ISNULL(khys_container, '') = @container
        ORDER BY khys_xh


    END

GO

/****** Object:  StoredProcedure [dbo].[t_bas_xt_LoadSize]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_bas_xt_LoadSize] 
( 
@khbh VARCHAR(10) 
)
AS 
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
        SET NOCOUNT ON ;

        DECLARE @sql VARCHAR(1000) ,
            @szlb VARCHAR(2)
        SELECT TOP 1
                @szlb = Xt_szlb
        FROM    t_bas_xt WITH (NOLOCK)
        WHERE   Xt_khh = @khbh
                AND ISNULL(xt_istt, 0) = 0
        GROUP BY Xt_szlb
        ORDER BY COUNT(id) DESC
        SET @sql = 'select Szdz_sz' + @szlb + ' from t_bas_sizedz'
        PRINT @sql
        EXEC (@sql)

    END

GO

USE [jncrm]
GO

/****** Object:  Table [dbo].[t_bas_kh]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_bas_kh](
	[id] [int] NOT NULL,
	[Kh_bh] [varchar](10) NOT NULL,
	[Kh_jc] [varchar](64) NOT NULL,
	[Kh_mc] [varchar](64) NULL,
	[Kh_ywmc] [varchar](80) NULL,
	[Kh_lb] [varchar](2) NULL,
	[Kh_lx] [varchar](1) NULL,
	[Kh_zz] [varchar](30) NULL,
	[Kh_sh] [varchar](30) NULL,
	[Kh_frdb] [varchar](10) NULL,
	[Kh_fzr] [varchar](20) NULL,
	[Kh_dqh] [varchar](6) NULL,
	[Kh_dz] [varchar](150) NULL,
	[Kh_yzbm] [varchar](20) NULL,
	[Kh_dh] [varchar](40) NULL,
	[Kh_cz] [varchar](40) NULL,
	[Kh_yx] [varchar](40) NULL,
	[Kh_wz] [varchar](40) NULL,
	[Kh_lxr] [varchar](20) NULL,
	[Kh_lxrdh] [varchar](40) NULL,
	[kh_lxryj] [varchar](40) NULL,
	[Kh_xrje] [numeric](15, 2) NULL,
	[Kh_xrqx] [smalldatetime] NULL,
	[Kh_xrye] [numeric](15, 2) NULL,
	[Kh_yh] [varchar](20) NULL,
	[Kh_zh] [varchar](40) NULL,
	[Kh_hb] [varchar](4) NULL,
	[Kh_kdgs] [varchar](60) NULL,
	[Kh_ykdgs] [varchar](60) NULL,
	[Kh_kddz] [varchar](80) NULL,
	[Kh_kdydz] [varchar](80) NULL,
	[Kh_kdgszh] [varchar](40) NULL,
	[Kh_kdgsdh] [varchar](30) NULL,
	[Kh_kdgscz] [varchar](30) NULL,
	[Kh_kdgslx] [varchar](15) NULL,
	[Kh_yjgs] [varchar](60) NULL,
	[Kh_ywyjgs] [varchar](60) NULL,
	[Kh_yjgsdz] [varchar](80) NULL,
	[Kh_ywyjgsdz] [varchar](80) NULL,
	[Kh_yjgsdh] [varchar](30) NULL,
	[Kh_yjgscz] [varchar](30) NULL,
	[Kh_yjgslxr] [varchar](15) NULL,
	[kh_type] [char](1) NULL,
	[Kh_ischeck] [bit] NULL,
	[Kh_shr] [varchar](16) NULL,
	[Kh_istt] [bit] NULL,
	[Kh_salesbh] [varchar](20) NULL,
	[T1] [bit] NULL,
	[T2] [varchar](16) NULL,
	[T13] [bit] NULL,
	[T4] [varchar](16) NULL,
	[Kh_fd1] [numeric](3, 2) NULL,
	[Kh_fd2] [numeric](3, 2) NULL,
	[Kh_fd3] [numeric](3, 2) NULL,
	[Kh_fd4] [numeric](3, 2) NULL,
	[Kh_fdnd] [numeric](3, 2) NULL,
	[Kh_shdz1] [varchar](100) NULL,
	[Kh_shdz2] [varchar](100) NULL,
	[Kh_shdz3] [varchar](100) NULL,
	[Kh_shdz4] [varchar](100) NULL,
	[Kh_shdz5] [varchar](100) NULL,
	[Kh_shr1] [varchar](20) NULL,
	[Kh_shr2] [varchar](20) NULL,
	[Kh_shr3] [varchar](20) NULL,
	[Kh_shr4] [varchar](20) NULL,
	[Kh_shr5] [varchar](20) NULL,
	[Kh_fpdz1] [varchar](100) NULL,
	[Kh_fpdz2] [varchar](100) NULL,
	[Kh_xsw] [int] NULL,
	[Kh_xzyh] [varchar](16) NULL,
	[Kh_xzsj] [datetime] NULL,
	[Kh_xgyh] [varchar](16) NULL,
	[Kh_xgsj] [datetime] NULL,
	[Kh_mt1] [varchar](50) NULL,
	[Kh_mt2] [varchar](50) NULL,
	[kh_jytj] [varchar](16) NULL,
	[kh_jsrlx] [int] NULL,
	[Kh_isdj] [bit] NULL,
	[Kh_djyy] [varchar](200) NULL,
	[cus_wx] [varchar](1) NULL,
	[web_url] [varchar](64) NULL,
	[Kh_isfp] [bit] NULL,
	[kh_dz1] [varchar](150) NULL,
	[kh_dz2] [varchar](150) NULL,
	[kh_dz3] [varchar](150) NULL,
	[kh_dz4] [varchar](150) NULL,
	[kh_dzr] [int] NULL,
	[kh_fplb] [int] NULL,
	[kh_fkfs] [varchar](16) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[t_sale_khys_Load]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_sale_khys_Load]
    (
      @khbh AS VARCHAR(50) ,
      @SendDateFrom AS DATE ,
      @SendDateTo AS DATE ,
      @banderNo AS VARCHAR(20) ,
      @container AS VARCHAR(10)
    )
AS 
    BEGIN

        SET NOCOUNT ON ;

        WITH    CTE
                  AS ( SELECT   id ,
                                khys_fhrq ,
                                khys_banderno ,
                                khys_gz ,
                                khys_container ,
                                khys_sl ,
                                khys_bfb * 100 AS khys_bfb ,
                                khys_htbh ,
                                khys_khdd ,
                                khys_wcb ,
                                khys_khh
                       FROM     dbo.t_sale_khys AS sk WITH ( NOLOCK )
                       WHERE    sk.khys_fhrq IS NOT NULL
                                AND ( @khbh = ''
                                      OR sk.khys_khh = @khbh
                                    )
                                AND ( @banderNo = ''
                                      OR sk.khys_banderNo = @banderNo
                                    )
                                AND ( @container = ''
                                      OR sk.khys_container = @container
                                    )
                                AND sk.khys_fhrq BETWEEN @SendDateFrom
                                                 AND     @SendDateTo
                                AND ( DATEDIFF(dd, sk.khys_fhrq, GETDATE()) <= 0
                                      OR sk.khys_fhb IS NULL
                                      OR sk.khys_fhb = 0
                                    )
                     )
            SELECT  khys_fhrq ,
                    khys_banderno ,
                    khys_gz ,
                    khys_container ,
                    khys_bfb ,
                    khys_khh ,
                    ISNULL(khys_wcb, 0) AS khys_fhb ,
                    ( SUM(khys_sl)
                      - ISNULL(( SELECT SUM(cfqr_sl)
                                 FROM   dbo.t_sale_khys_cfqr AS skc WITH ( NOLOCK )
                                 WHERE  skc.cfqr_htbh = MAX(CTE.khys_htbh)
                                        AND ISNULL(skc.cfqr_htbh, '') <> ''
                                 GROUP BY skc.cfqr_htbh
                               ), 0) ) AS sumS ,
                    MIN(id) AS id ,
                    CASE WHEN DATEDIFF(d, khys_fhrq,
                                       DATEADD(d, 15, DATEADD(m, 1, GETDATE()))) >= 0
                              OR DATEDIFF(d, khys_fhrq,
                                          DATEADD(d, 15,
                                                  DATEADD(m, 2, GETDATE()))) < 0
                         THEN NULL
                         ELSE DATEADD(m, -1, DATEADD(d, -16, khys_fhrq))
                    END AS changeDate ,
                    ( SELECT    ISNULL(kh_jc, '')
                      FROM      t_bas_kh
                      WHERE     Kh_bh = CTE.khys_khh
                    ) AS khjc ,
                    MAX(ISNULL(khys_khdd, '')) AS khdd ,
                    MAX(ISNULL(khys_htbh, '')) AS htbh
            FROM    CTE
            GROUP BY khys_fhrq ,
                    khys_banderno ,
                    khys_gz ,
                    khys_container ,
                    khys_bfb ,
                    ISNULL(khys_wcb, 0) ,
                    khys_khh
            ORDER BY khys_fhrq ,
                    khys_khh ,
                    khys_banderno ;

    END

GO

USE [jncrm]
GO

/****** Object:  Table [dbo].[t_UserRole]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_t_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [jncrm]
GO

/****** Object:  Table [dbo].[t_Role]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
 CONSTRAINT [PK_t_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[t_UserRole_LoadByUserId]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_UserRole_LoadByUserId] 
(
	@UserId		INT
)
AS
BEGIN
	
	SET NOCOUNT ON;
	
	SELECT r.[RoleId] ,
           [RoleName] 
	FROM [jncrm].[dbo].[t_UserRole] AS ur WITH (NOLOCK)
		INNER JOIN dbo.t_Role AS r WITH (NOLOCK)
			ON ur.RoleId = r.RoleId
	WHERE ur.UserId = @UserId;

END

GO

USE [jncrm]
GO

/****** Object:  Table [dbo].[t_RolePermission]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_RolePermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Permission] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_RolePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[t_UserRole_LoadUserPermssions]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_UserRole_LoadUserPermssions]
(
	@UserId			INT
)
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT rp.Permission
	FROM dbo.t_UserRole AS ur WITH (NOLOCK)
		INNER JOIN dbo.t_RolePermission AS rp WITH (NOLOCK)
			ON ur.RoleId = rp.RoleId
	WHERE ur.UserId = @UserId;
	
END

GO

USE [jncrm]
GO

/****** Object:  Table [dbo].[t_Sys_User]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_Sys_User](
	[UserId] [int] NOT NULL,
	[LoginName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Ygbh] [varchar](50) NULL,
	[PwdPrompt] [varchar](50) NULL,
	[State] [int] NOT NULL,
	[Bm_bh] [varchar](50) NULL,
	[Fwqx] [int] NULL,
	[Ck_bh] [varchar](64) NULL,
	[csbh] [varchar](6) NULL,
	[khbh] [varchar](10) NULL,
	[czPower] [bit] NULL,
	[htkh] [bit] NULL,
	[khEmail] [varchar](30) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[t_sys_User_LoadById]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_sys_User_LoadById] 
( 
@UserId INT 
)
AS 
    BEGIN

        SET NOCOUNT ON ;
	
        SELECT  [UserId] ,
                [LoginName] ,
                [khbh] ,
                [PwdPrompt] ,
                [htkh] ,
                [khEmail]
        FROM    dbo.t_Sys_User AS u WITH ( NOLOCK )
        WHERE   u.UserId = @UserId ;
        
    END

GO

/****** Object:  StoredProcedure [dbo].[t_UserRole_Save]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_UserRole_Save]
    (
      @UserId INT ,
      @Roles VARCHAR(MAX)
    )
AS 
    BEGIN
	
        SET NOCOUNT ON ;

        DECLARE @spot SMALLINT ;
        DECLARE @RoleId INT ;
    
        DELETE  dbo.t_UserRole
        WHERE   UserId = @UserId ;
    
        WHILE ( @Roles <> '' ) 
            BEGIN
                SET @spot = CHARINDEX(',', @Roles) ;
                IF @spot > 0 
                    BEGIN
                        SET @RoleId = CAST(LEFT(@Roles, @spot - 1) AS INT) ;
                        SET @Roles = RIGHT(@Roles, LEN(@Roles) - @spot) ;
                    END
                ELSE 
                    BEGIN 
                        SET @RoleId = CAST(@Roles AS INT) ;
                        SET @Roles = '' ;
                    END 
        
                INSERT  INTO [jncrm].[dbo].[t_UserRole]
                        ( [UserId], [RoleId] )
                VALUES  ( @UserId, @RoleId )
            END
	
    END

GO

/****** Object:  StoredProcedure [dbo].[t_Role_Update]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_Role_Update]
    (
      @RoleId INT ,
      @RoleName VARCHAR(50) ,
      @Permissions VARCHAR(MAX)
    )
AS 
    BEGIN
        SET NOCOUNT ON ;

        DECLARE @spot SMALLINT ;
        DECLARE @Permission VARCHAR(50) ;
     
        UPDATE  dbo.t_Role
        SET     RoleName = @RoleName ,
                InsertDate = GETDATE()
        WHERE   RoleId = @RoleId ;
	
        DELETE  dbo.t_RolePermission
        WHERE   RoleId = @RoleId ;
		
        WHILE @Permissions <> '' 
            BEGIN
                SET @spot = CHARINDEX(',', @Permissions) ;
                IF @spot > 0 
                    BEGIN
                        SET @Permission = LEFT(@Permissions, @spot - 1);
                        SET @Permissions = RIGHT(@Permissions,
                                                 LEN(@Permissions) - @spot) ;
                    END
                ELSE 
                    BEGIN 
                        SET @Permission = @Permissions ;
                        SET @Permissions = '' ;
                    END 

                INSERT  INTO [jncrm].[dbo].[t_RolePermission]
                        ( [RoleId], [Permission] )
                VALUES  ( @RoleId, @Permission );
            END
            
    END

GO

/****** Object:  StoredProcedure [dbo].[t_Role_Insert]    Script Date: 08/27/2014 22:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_Role_Insert]
    (
      @RoleName VARCHAR(50) ,
      @Permissions VARCHAR(MAX)
    )
AS 
    BEGIN
        SET NOCOUNT ON ;
        DECLARE @spot SMALLINT ;
        DECLARE @Permission VARCHAR(50) ;
        DECLARE @RoleId INT ;
        
        INSERT  INTO [jncrm].[dbo].[t_Role]
                ( [RoleName] )
        VALUES  ( @RoleName ) ;
        SET @RoleId = SCOPE_IDENTITY() ;
		
        WHILE @Permissions <> '' 
            BEGIN
                SET @spot = CHARINDEX(',', @Permissions) ;
                IF @spot > 0 
                    BEGIN
                        SET @Permission =LEFT(@Permissions, @spot - 1)  ;
                        SET @Permissions = RIGHT(@Permissions,
                                                 LEN(@Permissions) - @spot) ;
                    END
                ELSE 
                    BEGIN 
                        SET @Permission = @Permissions ;
                        SET @Permissions = '' ;
                    END 
                INSERT  INTO [jncrm].[dbo].[t_RolePermission]
                        ( [RoleId], [Permission] )
                VALUES  ( @RoleId, @Permission )
            END
        
    END

GO

/****** Object:  StoredProcedure [dbo].[t_Role_LoadById]    Script Date: 08/27/2014 22:44:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_Role_LoadById] 
( 
	@RoleId INT 
)
AS 
    BEGIN

        SET NOCOUNT ON ;
	
        SELECT  [RoleId] ,
                [RoleName] ,
                [InsertDate]
        FROM    [jncrm].[dbo].[t_Role] AS r WITH ( NOLOCK )
        WHERE   r.RoleId = @RoleId ;
  
        SELECT  [Permission]
        FROM    [jncrm].[dbo].[t_RolePermission] AS rp WITH ( NOLOCK )
        WHERE   rp.RoleId = @RoleId ;
  
    END

GO

/****** Object:  StoredProcedure [dbo].[t_Role_Delete]    Script Date: 08/27/2014 22:44:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_Role_Delete]
(
	@RoleId	INT
)
AS
BEGIN
	
	SET NOCOUNT ON;
	
	DELETE dbo.t_UserRole
	WHERE RoleId = @RoleId;
	
	DELETE dbo.t_RolePermission
	WHERE RoleId = @RoleId;
	
	DELETE dbo.t_Role
	WHERE RoleId = @RoleId;
	
END

GO

/****** Object:  StoredProcedure [dbo].[t_Role_LoadAll]    Script Date: 08/27/2014 22:44:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_Role_LoadAll]
AS 
    BEGIN
	
        SET NOCOUNT ON ;
	
        SELECT  [RoleId] ,
                [RoleName] ,
                [InsertDate]
        FROM    [jncrm].[dbo].[t_Role] AS r WITH ( NOLOCK )
        ORDER BY r.InsertDate DESC ;
	
    END

GO

/****** Object:  StoredProcedure [dbo].[t_Sys_User_Login]    Script Date: 08/27/2014 22:44:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_Sys_User_Login]
(
@LoginName VARCHAR(50),
@Password	VARCHAR(50)
)
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT u.UserId,
			u.LoginName,
			u.khbh,
			ISNULL(bk.Kh_jc, bk.Kh_mc) AS 'name'
	FROM dbo.t_Sys_User AS u WITH (NOLOCK)
		LEFT JOIN dbo.t_bas_kh AS bk WITH (NOLOCK)
			ON u.khbh = bk.Kh_bh
	WHERE u.LoginName = @LoginName AND u.Password = @Password
		AND u.State = 1;
	
END

GO

/****** Object:  StoredProcedure [dbo].[t_Sys_User_LoadAll]    Script Date: 08/27/2014 22:44:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[t_Sys_User_LoadAll]
AS 
    BEGIN
	
        SET NOCOUNT ON ;
	
        SELECT  [UserId]
			  ,[LoginName]
			  ,[khbh]
			  ,[PwdPrompt]
			  ,[htkh]
			  ,[khEmail]
        FROM    dbo.t_Sys_User AS u WITH ( NOLOCK )
        WHERE u.State = 1;
    END

GO

ALTER TABLE [dbo].[t_Role] ADD  CONSTRAINT [DF_t_Role_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]
GO


