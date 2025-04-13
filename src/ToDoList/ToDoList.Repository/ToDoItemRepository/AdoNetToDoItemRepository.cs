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

    public Task<long> InsertToDoItemAsync(ToDoItem toDoItem)
    {
        throw new NotImplementedException();
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
