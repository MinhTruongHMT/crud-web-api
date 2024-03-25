namespace crud_web_api.Repositories
{
    using Dapper;
    using crud_web_api.Helpers;
    using System.Data;
    using crud_web_api.Models.Users;
    using crud_web_api.Models.Common;
    using LDCC_DOC.Common.Helpers;
    using crud_web_api.Entities;

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task Create(User user);
        Task Update(User user);
        Task Delete(int id);
    }
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Users
        """;
            return await connection.QueryAsync<User>(sql);
        }

        public async Task<User> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Users 
            WHERE Id = @id
        """;
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { id });
        }

        public async Task<User> GetByEmail(string email)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Users 
            WHERE Email = @email
        """;
            return await connection.QuerySingleOrDefaultAsync<User>(sql, new { email });
        }

        public async Task Create(User user)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            INSERT INTO Users (Title, FirstName, LastName, Email, Role, PasswordHash)
            VALUES (@Title, @FirstName, @LastName, @Email, @Role, @PasswordHash)
        """;
            await connection.ExecuteAsync(sql, user);
        }

        public async Task Update(User user)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            UPDATE Users 
            SET Title = @Title,
                FirstName = @FirstName,
                LastName = @LastName, 
                Email = @Email, 
                Role = @Role, 
                PasswordHash = @PasswordHash
            WHERE Id = @Id
        """;
            await connection.ExecuteAsync(sql, user);
        }

        public async Task Delete(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            DELETE FROM Users 
            WHERE Id = @id
        """;
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}
