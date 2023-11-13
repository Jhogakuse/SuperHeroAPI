using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
using RepositoryContracts;
using System.Data;

namespace Repository
{
    public class TypeFileRepository : ITypeFileRepository
    {
        private readonly IConfiguration _configuration;
        public TypeFileRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<TypeFileEntity> GetTypeFile(int id)
        {
            //SqlParameter[] parameters = new SqlParameter[] {
            //    new SqlParameter("@PersonID", id)
            //};

            //var result = _db.SuperHeroes.FromSqlRaw("EXECUTE [test].[dbo].[InsertPerson] @descripcion", parameters);

            return null;
        }

        public Task<IEnumerable<TypeFileEntity>> GetTypeFiles()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SetTypeFile(SetTypeFile typeFile)
        {
            string newId = string.Empty;
            try
            {
                //SqlParameter[] parameters = new SqlParameter[] {
                //    new SqlParameter("@descripcion", typeFile.Descripcion)
                //};
                //var result = await _db.Database.ExecuteSqlRawAsync("EXECUTE [test].[dbo].[InsertPerson] @descripcion", parameters);
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:TestConnection"]);
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("CreateTypeFile", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", typeFile.Descripcion);
                    SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            newId = sqlDataReader[0].ToString() ?? "-1";
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                //
            }
            return newId;
        }
    }
}