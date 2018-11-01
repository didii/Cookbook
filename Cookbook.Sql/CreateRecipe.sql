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
