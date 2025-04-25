Create Table ToDoItem(
    ToDoItemId BigInt Identity(1, 1) Primary Key,
	Title NVarchar(100) not null,
	Description NVarchar(250) not null,
	IsCompleted Bit not null,
	CreatedAt DateTime not null,
	DueDate DateTime not null
);


CREATE PROCEDURE sp_InsertToDoItem
    @Title NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @IsCompleted BIT,
    @DueDate DATETIME
AS
BEGIN
    INSERT INTO ToDoItems (Title, Description, IsCompleted, CreatedAt, DueDate)
    VALUES (@Title, @Description, @IsCompleted, GETDATE(), @DueDate);

    SELECT SCOPE_IDENTITY() AS NewId;
END;

CREATE PROCEDURE sp_DeleteToDoItemById
    @ToDoItemId BIGINT
AS
BEGIN
    DELETE FROM ToDoItems WHERE ToDoItemId = @ToDoItemId;
END;

CREATE PROCEDURE sp_UpdateToDoItem
    @ToDoItemId BIGINT,
    @Title NVARCHAR(255),
    @Description NVARCHAR(MAX),
    @IsCompleted BIT,
    @DueDate DATETIME
AS
BEGIN
    UPDATE ToDoItems
    SET Title = @Title,
        Description = @Description,
        IsCompleted = @IsCompleted,
        DueDate = @DueDate
    WHERE ToDoItemId = @ToDoItemId;
END;

CREATE FUNCTION fn_GetToDoItemById(@ToDoItemId BIGINT)
RETURNS TABLE
AS
RETURN (
    SELECT * FROM ToDoItems WHERE ToDoItemId = @ToDoItemId
);

CREATE PROCEDURE sp_SelectAllToDoItemsPaged
    @Skip INT,
    @Take INT
AS
BEGIN
    SELECT * FROM ToDoItems
    ORDER BY CreatedAt DESC
    OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;
END;

CREATE FUNCTION fn_GetToDoItemsByDueDate(@DueDate DATE)
RETURNS TABLE
AS
RETURN (
    SELECT * FROM ToDoItems
    WHERE CAST(DueDate AS DATE) = @DueDate
);

CREATE PROCEDURE sp_GetCompletedToDoItemsPaged
    @Skip INT,
    @Take INT
AS
BEGIN
    SELECT * FROM ToDoItems
    WHERE IsCompleted = 1
    ORDER BY CreatedAt DESC
    OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;
END;

CREATE PROCEDURE sp_GetIncompleteToDoItemsPaged
    @Skip INT,
    @Take INT
AS
BEGIN
    SELECT * FROM ToDoItems
    WHERE IsCompleted = 0
    ORDER BY CreatedAt DESC
    OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;
END;
