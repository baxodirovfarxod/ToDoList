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
        string sql = "DELETE FROM ToDoList WHERE ToDoListId = @Id;";

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

    public async Task<long> InsertToDoItemAsync(ToDoItem toDoItem)
    {
        string sql = @"
        INSERT INTO ToDoList (Title, Description, IsCompleted, CreatedAt, DueDate)
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

                var insertedId = (long)await cmd.ExecuteScalarAsync();
                return insertedId;
            }
        }
    }

    public Task<ICollection<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectByDueDateAsync(DateTime dueDate)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectCompletedAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectIncompleteAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItem> SelectToDoItemByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateToDoItemAsync(ToDoItem toDoItem)
    {
        throw new NotImplementedException();
    }
}
