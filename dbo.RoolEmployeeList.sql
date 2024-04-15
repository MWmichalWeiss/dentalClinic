CREATE TABLE [dbo].[RoolEmployeeList] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeId] INT           NOT NULL,
    [RoolId]     INT           NOT NULL,
    [EntryDate]  DATETIME2 (7) NOT NULL,
    [Status]     BIT           NULL,
    CONSTRAINT [PK_RoolEmployeeList] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RoolEmployeeList_EmployeeList_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[EmployeeList] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RoolEmployeeList_RoolList_RoolId] FOREIGN KEY ([RoolId]) REFERENCES [dbo].[RoolList] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RoolEmployeeList_EmployeeId]
    ON [dbo].[RoolEmployeeList]([EmployeeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoolEmployeeList_RoolId]
    ON [dbo].[RoolEmployeeList]([RoolId] ASC);

