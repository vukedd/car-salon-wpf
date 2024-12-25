using Core.Data;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.DBRepositories
{
    internal class CarImageRepository : ICarImageRepository
    {
        public List<byte[]> GetImagesByCarId(int id)
        {
            List<byte[]> images = new List<byte[]>();
            using (var connection = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = @"SELECT * FROM CarImages WHERE CarId = @CarId;";
                using (var command = new SqlCommand())
                {
                    command.CommandText = commandText;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("CarId", id));

                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        byte[] image = (byte[])reader["ImageData"];
                        images.Add(image);
                    }
                }
            }

            return images;
        }
    }
}
