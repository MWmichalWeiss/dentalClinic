CREATE TABLE [dbo].[EmployeeList] (
    [Id]            INT            IDENTITY (1, 1),
    [FirstName]     NVARCHAR (MAX) NULL DEFAULT 'aaa',
    [LastName]      NVARCHAR (MAX) NULL DEFAULT 'וייס',
    [Tz]            NVARCHAR (MAX) NULL DEFAULT 202587462,
    [DateOfBirth]   DATETIME2 (7)  NULL DEFAULT 20/11/2020,
    [DateStartWork] DATETIME2 (7)  NULL DEFAULT 02/03/2022,
    [Gander]        INT            NULL DEFAULT 0,
    [Status]        BIT            NULL DEFAULT 1,
    CONSTRAINT [PK_EmployeeList] PRIMARY KEY CLUSTERED ([Id] ASC)
);

