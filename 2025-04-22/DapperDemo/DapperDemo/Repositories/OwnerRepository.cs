using Dapper;
using DapperDemo.Model;
using MySqlConnector;

namespace DapperDemo.Repositories
{
    internal class OwnerRepository : IOwnerRepository
    {
        private string ConnectionString = "server=127.0.0.1;port=3307;database=gevorderd2dapperdemo;user=dapperuser;password=dapperuser";

        public void Create(Owner owner)
        {
            throw new NotImplementedException();
        }

        public List<Owner> GetAll()
        {
            const string query = "SELECT * FROM Owners";
            using var connection = new MySqlConnection(ConnectionString);
            var result = connection.Query<Owner>(query);
            return result.ToList();
        }

        public Owner GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Owner GetByIdIncludePets(int id)
        {
            throw new NotImplementedException();
        }
    }
}
