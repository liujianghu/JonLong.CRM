
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[t_sale_yzk_Save]
	@tGuid varchar(64),
	@fhrq datetime,
	@bn varchar(30),
	@xh varchar(30),
	@xhb varchar(30),
	@sumS int,
	@s1 int,
	@s2 int,
	@s3 int,
	@s4 int,
	@s5 int,
	@s6 int,
	@s7 int,
	@s8 int,
	@s9 int,
	@s10 int,
	@s11 int,
	@s12 int,
	@s13 int,
	@s14 int,
	@s15 int,
	@s16 int,
	@s17 int,
	@s18 int,
	@s19 int,
	@s20 int,
	@khdd varchar(30),
	@khjq datetime
AS

SET NOCOUNT ON

IF EXISTS(SELECT [id] FROM [dbo].[t_sale_yzk] WHERE [xhb] = @xhb AND tGuid = @tGuid)
BEGIN
	UPDATE [dbo].[t_sale_yzk] SET
		[sumS] = @sumS,
		[s1] = @s1,
		[s2] = @s2,
		[s3] = @s3,
		[s4] = @s4,
		[s5] = @s5,
		[s6] = @s6,
		[s7] = @s7,
		[s8] = @s8,
		[s9] = @s9,
		[s10] = @s10,
		[s11] = @s11,
		[s12] = @s12,
		[s13] = @s13,
		[s14] = @s14,
		[s15] = @s15,
		[s16] = @s16,
		[s17] = @s17,
		[s18] = @s18,
		[s19] = @s19,
		[s20] = @s20
	WHERE
		[xhb] = @xhb AND tGuid=@tGuid;
END
ELSE
BEGIN
	INSERT INTO [dbo].[t_sale_yzk] (
		[tGuid],
		[fhrq],
		[bn],
		[xh],
		[xhb],
		[sumS],
		[s1],
		[s2],
		[s3],
		[s4],
		[s5],
		[s6],
		[s7],
		[s8],
		[s9],
		[s10],
		[s11],
		[s12],
		[s13],
		[s14],
		[s15],
		[s16],
		[s17],
		[s18],
		[s19],
		[s20],
		[khdd],
		[khjq]
	) VALUES (
		@tGuid,
		@fhrq,
		@bn,
		@xh,
		@xhb,
		@sumS,
		@s1,
		@s2,
		@s3,
		@s4,
		@s5,
		@s6,
		@s7,
		@s8,
		@s9,
		@s10,
		@s11,
		@s12,
		@s13,
		@s14,
		@s15,
		@s16,
		@s17,
		@s18,
		@s19,
		@s20,
		@khdd,
		@khjq
	)
END
GO
