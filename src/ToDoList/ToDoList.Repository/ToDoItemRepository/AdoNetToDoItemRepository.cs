using Microsoft.Data.SqlClient;
using ToDoList.Dal.Entity;
using ToDoList.Repository.Settings;


namespace ToDoList.Repository.ToDoItemRepository;

public class AdoNetToDoItemRepository : IToDoItemRepository
{

    private readonly string ConnectionString;

    public AdoNetToDoItemRepository(SqlDBConeectionString sqlDBConeectionString)
    {
        ConnectionString = sqlDBConeectionString.ConnectionString;
    }
    public async Task DeleteToDoItemByIdAsync(long id)
    {
        string sql = "DELETE FROM ToDoItems WHERE ToDoItemId = @Id;";

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }

    public Task<ICollection<ToDoItem>> GetUpcomingDeadlinesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<long> InsertToDoItemAsync(ToDoItem toDoItem)
    {
        string sql = @"
        INSERT INTO ToDoItems (Title, Description, IsCompleted, CreatedAt, DueDate)
        OUTPUT INSERTED.ToDoItemId
        VALUES (@Title, @Description, @IsCompleted, @CreatedAt, @DueDate);";

        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            await con.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Title", toDoItem.Title);
                cmd.Parameters.AddWithValue("@Description", toDoItem.Description);
                cmd.Parameters.AddWithValue("@IsCompleted", toDoItem.IsCompleted);
                cmd.Parameters.AddWithValue("@CreatedAt", toDoItem.CreatedAt);
                cmd.Parameters.AddWithValue("@DueDate", toDoItem.DueDate);

                var insertedId = await cmd.ExecuteScalarAsync();
                return (long)insertedId;
            }
        }
    }

    public Task<ICollection<ToDoItem>> SearchToDoItemsAsync(string keyword)
    {
        throw new NotImplementedException();
    }

    public IQueryable<ToDoItem> SelectAll()
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take)
    {
        var items = new List<ToDoItem>();

        string sql = @"
        SELECT ToDoItemId, Title, Description, IsCompleted, CreatedAt, DueDate
        FROM ToDoItems
        ORDER BY CreatedAt DESC
        OFFSET @Skip ROWS
        FETCH NEXT @Take ROWS ONLY;";

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Skip", skip);
                cmd.Parameters.AddWithValue("@Take", take);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var item = new ToDoItem
                        {
                            ToDoItemId = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5)
                        };

                        items.Add(item);
                    }
                }
            }
        }

        return items;
    }

    public async Task<ICollection<ToDoItem>> SelectByDueDateAsync(DateTime dueDate)
    {
        var items = new List<ToDoItem>();

        string sql = @"
        SELECT ToDoItemId, Title, Description, IsCompleted, CreatedAt, DueDate
        FROM ToDoItems
        WHERE CAST(DueDate AS DATE) = @DueDate";

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DueDate", dueDate.Date);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var item = new ToDoItem
                        {
                            ToDoItemId = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5)
                        };

                        items.Add(item);
                    }
                }
            }
        }

        return items;
    }

    public async Task<ICollection<ToDoItem>> SelectCompletedAsync(int skip, int take)
    {
        var items = new List<ToDoItem>();

        string sql = @"
        SELECT ToDoItemId, Title, Description, IsCompleted, CreatedAt, DueDate
        FROM ToDoItems
        WHERE IsCompleted = 1
        ORDER BY ToDoItemId
        OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Skip", skip);
                cmd.Parameters.AddWithValue("@Take", take);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var item = new ToDoItem
                        {
                            ToDoItemId = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5)
                        };

                        items.Add(item);
                    }
                }
            }
        }

        return items;
    }

    public async Task<ICollection<ToDoItem>> SelectIncompleteAsync(int skip, int take)
    {
        var items = new List<ToDoItem>();

        string sql = @"
        SELECT ToDoItemId, Title, Description, IsCompleted, CreatedAt, DueDate
        FROM ToDoItems
        WHERE IsCompleted = 0
        ORDER BY ToDoItemId
        OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Skip", skip);
                cmd.Parameters.AddWithValue("@Take", take);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var item = new ToDoItem
                        {
                            ToDoItemId = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5)
                        };

                        items.Add(item);
                    }
                }
            }
        }

        return items;
    }

    public Task<ICollection<ToDoItem>> SelectOverdueItemsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ToDoItem> SelectToDoItemByIdAsync(long id)
    {
        string sql = @"
        SELECT ToDoItemId, Title, Description, IsCompleted, CreatedAt, DueDate
        FROM ToDoItems
        WHERE ToDoItemId = @Id";

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new ToDoItem
                        {
                            ToDoItemId = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5)
                        };
                    }
                }
            }
        }

        return null;
    }

    public async Task UpdateToDoItemAsync(ToDoItem toDoItem)
    {
        string sql = @"
        UPDATE ToDoItems
        SET Title = @Title,
            Description = @Description,
            IsCompleted = @IsCompleted,
            DueDate = @DueDate
        WHERE ToDoItemId = @ToDoItemId;";

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Title", toDoItem.Title);
                cmd.Parameters.AddWithValue("@Description", toDoItem.Description);
                cmd.Parameters.AddWithValue("@IsCompleted", toDoItem.IsCompleted);
                cmd.Parameters.AddWithValue("@DueDate", toDoItem.DueDate);
                cmd.Parameters.AddWithValue("@ToDoItemId", toDoItem.ToDoItemId);

                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
