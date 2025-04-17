using Microsoft.Data.SqlClient;
using System.Data;
using ToDoList.Dal.Entity;
using ToDoList.Repository.Settings;

namespace ToDoList.Repository.ToDoItemRepository;

public class AdoNetWithSpAndFn : IToDoItemRepository
{
    private readonly string _connectionString;

    public AdoNetWithSpAndFn(SqlDBConeectionString sqlDBConeectionString)
    {
        _connectionString = sqlDBConeectionString.ConnectionString;
    }

    public async Task DeleteToDoItemByIdAsync(long id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand("sp_DeleteToDoItemById", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ToDoItemId", id);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }


    public async Task<long> InsertToDoItemAsync(ToDoItem toDoItem)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand("sp_InsertToDoItem", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", toDoItem.Title);
            command.Parameters.AddWithValue("@Description", toDoItem.Description);
            command.Parameters.AddWithValue("@IsCompleted", toDoItem.IsCompleted);
            command.Parameters.AddWithValue("@DueDate", toDoItem.DueDate);

            await connection.OpenAsync();
            object result = await command.ExecuteScalarAsync();
            return Convert.ToInt64(result);
        }
    }


    public async Task<ICollection<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take)
    {
        var items = new List<ToDoItem>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand("sp_SelectAllToDoItemsPaged", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Skip", skip);
            command.Parameters.AddWithValue("@Take", take);

            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    items.Add(MapToDoItem(reader));
                }
            }
        }

        return items;
    }


    public async Task<ICollection<ToDoItem>> SelectByDueDateAsync(DateTime dueDate)
    {
        var items = new List<ToDoItem>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand("SELECT * FROM fn_GetToDoItemsByDueDate(@DueDate)", connection))
        {
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@DueDate", dueDate.Date);

            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                    items.Add(MapToDoItem(reader));
            }
        }

        return items;
    }


    public async Task<ICollection<ToDoItem>> SelectCompletedAsync(int skip, int take)
    {
        return await SelectWithPaging("sp_GetCompletedToDoItemsPaged", skip, take);
    }

    public async Task<ICollection<ToDoItem>> SelectIncompleteAsync(int skip, int take)
    {
        return await SelectWithPaging("sp_GetIncompleteToDoItemsPaged", skip, take);
    }

    public async Task<ToDoItem> SelectToDoItemByIdAsync(long id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand("SELECT * FROM fn_GetToDoItemById(@ToDoItemId)", connection))
        {
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@ToDoItemId", id);

            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                    return MapToDoItem(reader);

                return null;
            }
        }
    }


    public async Task UpdateToDoItemAsync(ToDoItem toDoItem)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand("sp_UpdateToDoItem", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ToDoItemId", toDoItem.ToDoItemId);
            command.Parameters.AddWithValue("@Title", toDoItem.Title);
            command.Parameters.AddWithValue("@Description", toDoItem.Description);
            command.Parameters.AddWithValue("@IsCompleted", toDoItem.IsCompleted);
            command.Parameters.AddWithValue("@DueDate", toDoItem.DueDate);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }

    private async Task<ICollection<ToDoItem>> SelectWithPaging(string storedProcedure, int skip, int take)
    {
        var items = new List<ToDoItem>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand(storedProcedure, connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Skip", skip);
            command.Parameters.AddWithValue("@Take", take);

            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                    items.Add(MapToDoItem(reader));
            }
        }

        return items;
    }

    private ToDoItem MapToDoItem(SqlDataReader reader)
    {
        return new ToDoItem
        {
            ToDoItemId = reader.GetInt64(reader.GetOrdinal("ToDoItemId")),
            Title = reader.GetString(reader.GetOrdinal("Title")),
            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
            IsCompleted = reader.GetBoolean(reader.GetOrdinal("IsCompleted")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate"))
        };
    }

    public async Task<ICollection<ToDoItem>> SearchToDoItemsAsync(string keyword)
    {
        var items = new List<ToDoItem>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand("sp_SearchToDoItems", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Keyword", keyword);

            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    items.Add(MapToDoItem(reader));
                }
            }
        }

        return items;
    }


    public async Task<ICollection<ToDoItem>> SelectOverdueItemsAsync()
    {
        var items = new List<ToDoItem>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand("sp_GetOverdueToDoItems", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    items.Add(MapToDoItem(reader));
                }
            }
        }

        return items;
    }


    public async Task<ICollection<ToDoItem>> GetUpcomingDeadlinesAsync()
    {
        var items = new List<ToDoItem>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        using (SqlCommand command = new SqlCommand("sp_GetUpcomingDeadlines", connection))
        {
            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    items.Add(MapToDoItem(reader));
                }
            }
        }

        return items;
    }

}
