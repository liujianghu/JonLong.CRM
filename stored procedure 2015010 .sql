USE [jncrm]
GO

/****** Object:  StoredProcedure [dbo].[t_UserRole_LoadUserPermssions]    Script Date: 05/10/2015 09:28:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_UserRole_LoadUserPermssions]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[t_UserRole_LoadUserPermssions]
GO

/****** Object:  StoredProcedure [dbo].[t_Permission_LoadAll]    Script Date: 05/10/2015 09:28:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[t_Permission_LoadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[t_Permission_LoadAll]
GO

USE [jncrm]
GO

/****** Object:  StoredProcedure [dbo].[t_UserRole_LoadUserPermssions]    Script Date: 05/10/2015 09:28:53 ******/
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
	
	SELECT p.PermissionId, p.Controller,p.Action
	FROM dbo.t_UserRole AS ur WITH (NOLOCK)
		INNER JOIN dbo.t_RolePermission AS rp WITH (NOLOCK)
			ON ur.RoleId = rp.RoleId
		INNER JOIN dbo.t_Permission AS p WITH (NOLOCK)
			ON rp.PermissionId = p.PermissionId
	WHERE ur.UserId = @UserId;
	
END



GO

/****** Object:  StoredProcedure [dbo].[t_Permission_LoadAll]    Script Date: 05/10/2015 09:28:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[t_Permission_LoadAll]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.t_Permission AS p WITH (NOLOCK);
END

GO


