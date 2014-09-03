USE jncrm
GO

DECLARE @UserId AS INT ;
SET @UserId = 'any userId your want' ;

DECLARE @RoleId AS INT ;
INSERT  INTO [jncrm].[dbo].[t_Role]
        ( [RoleName] )
VALUES  ( 'SuperAdmin' ) ;

SET @RoleId = SCOPE_IDENTITY() ;

INSERT  INTO [jncrm].[dbo].[t_RolePermission]
        ( [RoleId], [Permission] )
VALUES  ( @RoleId, 'superadmin' ) ;

INSERT  INTO [jncrm].[dbo].[t_UserRole]
        ( [UserId], [RoleId] )
VALUES  ( @UserId, @RoleId ) ;

GO

                
