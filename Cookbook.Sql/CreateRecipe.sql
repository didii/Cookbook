SET IDENTITY_INSERT dbo.Recipes ON
INSERT INTO dbo.Recipes
           (Id
		   ,[Name]
           ,[Description]
           ,Servings
           ,Duration
           ,EstimatedPrice
           ,Difficulty
           ,CreatedOn
           ,UpdatedOn)
     VALUES
           (1
		   ,'This is recipe'
           ,'This is longer description of recipe'
           ,4
           ,'00:01:00'
           ,5.50
           ,1
           ,GETDATE()
           ,GETDATE())
SET IDENTITY_INSERT dbo.Recipes OFF

SET IDENTITY_INSERT dbo.Tag ON
INSERT INTO dbo.Tag
           (Id, [Name], CreatedOn, UpdatedOn)
     VALUES
           (1, 'tag1', GETDATE(), GETDATE()),
		   (2, 'tag2', GETDATE(), GETDATE()),
		   (3, 'tagWithlongerName', GETDATE(), GETDATE())
SET IDENTITY_INSERT dbo.Tag OFF
GO

INSERT INTO [dbo].[AppliedTag]
           ([RecipeId], [TagId], [CreatedOn], [UpdatedOn])
     VALUES
           (1, 1, GETDATE(), GETDATE()),
           (1, 2, GETDATE(), GETDATE()),
           (1, 3, GETDATE(), GETDATE())
GO

SET IDENTITY_INSERT dbo.QuantityType ON
INSERT INTO [dbo].[QuantityType]
           ([Id], [Name], [CreatedOn], [UpdatedOn])
     VALUES
           (1, 'Massa', GetDate(), GetDate()),
		   (2, 'Volume', GetDate(), GetDate()),
		   (3, 'Eenheid', GetDate(), GetDate())
GO
SET IDENTITY_INSERT dbo.QuantityType OFF

SET IDENTITY_INSERT dbo.Quantity ON
INSERT INTO [dbo].[Quantity]
           ([Id], [Name], [ShortName], [Multiplier], [QuantityTypeId], [IsBaseQuantity], [CreatedOn], [UpdatedOn])
     VALUES
           (1, 'een snufje', NULL, 1, 3, 0, GetDate(), GetDate()),
           (2, NULL, NULL, 1, 3, 1, GetDate(), GetDate()),
           (3, 'gram', 'g', 1, 1, 1, GetDate(), GetDate())
GO
SET IDENTITY_INSERT dbo.Quantity OFF

SET IDENTITY_INSERT dbo.Food ON
INSERT INTO [dbo].[Food]
           ([Id], [Name], [NamePlural], [Description], [CreatedOn], [UpdatedOn])
     VALUES
           (1, 'Zout', 'Zout', NULL, GetDate(), GetDate()),
		   (2, 'Peper', 'Peper', 'Te veel peper kan het gerecht pikant maken', GetDate(), GetDate()),
		   (3, 'Spirelli', 'Spirelli', 'De normale lange slierten spaghetti', GetDate(), GetDate()),
		   (4, 'Ei', 'Eieren', 'Nevenproduct van een kip', GetDate(), GetDate()),
		   (5, 'Parmazaanse kaas', 'Parmazaanse kaas', 'Echte Italiaanse kaas', GetDate(), GetDate())
GO
SET IDENTITY_INSERT dbo.Food OFF

SET IDENTITY_INSERT dbo.Ingredient ON
INSERT INTO [dbo].[Ingredient]
           ([Id], [FoodId], [QuantityId], [QuantityValue], [CreatedOn], [UpdatedOn], [RecipeId])
     VALUES
           (1, 1, 1, NULL, GetDate(), GetDate(), 1),
           (2, 2, 1, NULL, GetDate(), GetDate(), 1),
           (3, 3, 3, 500, GetDate(), GetDate(), 1),
           (4, 4, 2, 2, GetDate(), GetDate(), 1),
           (5, 5, 3, 200, GetDate(), GetDate(), 1)
GO
SET IDENTITY_INSERT dbo.Ingredient OFF
