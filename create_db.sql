/*CREATE SCHEMA RecipeFinder;
GO*/


CREATE TABLE [RecipeFinder].[Meal]
(
    [ID] INT PRIMARY KEY,
    [Name] VARCHAR(255) NOT NULL,
    [Category] VARCHAR(255) NOT NULL,
    [Area] VARCHAR(255) NOT NULL,
    [Instructions] VARCHAR(255) NOT NULL,
    [Meal_thumb] VARCHAR(255),
    [Tags] VARCHAR(255),
    [Youtube] VARCHAR(255),
    [Ingredient1] VARCHAR(255) NOT NULL,
    [Ingredient2] VARCHAR(255),
    [Ingredient3] VARCHAR(255),
    [Ingredient4] VARCHAR(255),
    [Ingredient5] VARCHAR(255),
    [Ingredient6] VARCHAR(255),
    [Ingredient7] VARCHAR(255),
    [Ingredient8] VARCHAR(255),
    [Ingredient9] VARCHAR(255),
    [Ingredient10] VARCHAR(255),
    [Ingredient11] VARCHAR(255),
    [Ingredient12] VARCHAR(255),
    [Ingredient13] VARCHAR(255),
    [Ingredient14] VARCHAR(255),
    [Ingredient15] VARCHAR(255),
    [Measure1] VARCHAR(255) NOT NULL,
    [Measure2] VARCHAR(255),
    [Measure3] VARCHAR(255),
    [Measure4] VARCHAR(255),
    [Measure5] VARCHAR(255),
    [Measure6] VARCHAR(255),
    [Measure7] VARCHAR(255),
    [Measure8] VARCHAR(255),
    [Measure9] VARCHAR(255),
    [Measure10] VARCHAR(255),
    [Measure11] VARCHAR(255),
    [Measure12] VARCHAR(255),
    [Measure13] VARCHAR(255),
    [Measure14] VARCHAR(255),
    [Measure15] VARCHAR(255),
);
GO

CREATE TABLE [RecipeFinder].[User]
(
    [ID] INT PRIMARY KEY,
    [Username] VARCHAR(255) NOT NULL,
    [Password] VARCHAR(255) NOT NULL,
    [First_name] VARCHAR(255) NOT NULL,
    [Last_name] VARCHAR(255) NOT NULL,
    [Email] VARCHAR(255) NOT NULL,
);

CREATE TABLE [RecipeFinder].[Ingredient1]
(
    [ID] INT PRIMARY KEY,
    [Name] VARCHAR(255),
);

