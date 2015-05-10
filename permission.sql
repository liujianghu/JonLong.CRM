USE jncrm
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_RolePermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Permission] [varchar](50) NULL,
	[PermissionId] [int] NULL,
 CONSTRAINT [PK_t_RolePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


ALTER TABLE dbo.t_RolePermission
ALTER COLUMN Permission VARCHAR(50) NULL;
ALTER TABLE dbo.t_RolePermission
ADD PermissionId INT NULL;

GO

INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Order & Forecast' ,
          'Order' ,
          'Index'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'New Bundle for order' ,
          'Order' ,
          'Create'
        ) ;
        
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'edit Order' ,
          'Order' ,
          'Edit'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'delete Order' ,
          'Order' ,
          'Delete'
        ) ;
        
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'convert to Order' ,
          'Order' ,
          'ConvertToOrder'
        ) ;        
        
GO

INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Role list' ,
          'Role' ,
          'Index'
        ) ;
        
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Create Role' ,
          'Role' ,
          'Create'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Edit list' ,
          'Role' ,
          'Edit'
        ) ;
        
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Delete Role' ,
          'Role' ,
          'Delete'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'User list' ,
          'User' ,
          'Index'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Edit User' ,
          'User' ,
          'Edit'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Edit profile' ,
          'User' ,
          'Edit'
        ) ;
        
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Edit Password' ,
          'User' ,
          'UpdatePassword'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Super admin' ,
          'SuperAdmin' ,
          NULL
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Container Preload' ,
          'PreLoadCabinet' ,
          'Index'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Save Container Preload' ,
          'PreLoadCabinet' ,
          'Save'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Finish Container Preload' ,
          'PreLoadCabinet' ,
          'Confirm'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'En Route' ,
          'Enroute' ,
          'Index'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'En Route Receive' ,
          'Enroute' ,
          'Receive'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'En Route Detail' ,
          'Enroute' ,
          'Detail'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Arrived' ,
          'Arrived' ,
          'Index'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Arrived Detail' ,
          'Arrived' ,
          'Detail'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Order Variance Reconciliation' ,
          'OrderVariance' ,
          'Index'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Order Variance Detail' ,
          'OrderVariance' ,
          'VarianceDetail'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Edit Order Variance' ,
          'OrderVariance' ,
          'Edit'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Cancel Order Variance' ,
          'OrderVariance' ,
          'Cancel'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Confirm Order Variance' ,
          'OrderVariance' ,
          'Confirm'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'JONLONG warehouse' ,
          'JLWarehouse' ,
          'Index'
        ) ;
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Customer warehouse' ,
          'CustomerWarehouse' ,
          'Index'
        ) ;        
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Create Customer warehouse' ,
          'CustomerWarehouse' ,
          'Create'
        ) ;  
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Edit Customer warehouse' ,
          'CustomerWarehouse' ,
          'Edit'
        ) ; 
INSERT  INTO [jncrm].[dbo].[t_Permission]
        ( [PermissionName] ,
          [Controller] ,
          [Action]
        )
VALUES  ( 'Delete Customer warehouse' ,
          'CustomerWarehouse' ,
          'Delete'
        ) ; 


GO



DECLARE @RoleId AS INT ;
SET @RoleId = ( SELECT TOP 1
                        t.RoleId
                FROM    dbo.t_Role AS t WITH ( NOLOCK )
                WHERE   t.RoleName = 'SuperAdmin'
              ) ;

DECLARE @num AS INT ;
SET @num = 5 ;
WHILE ( @num <= 14 ) 
    BEGIN
        INSERT  INTO [dbo].[t_RolePermission]
                ( [RoleId], [PermissionId] )
        VALUES  ( @RoleId, @num ) ;
        SET @num = @num + 1
    END

GO

