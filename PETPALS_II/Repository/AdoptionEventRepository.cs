using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETPALS_II.Repository
{
    
        internal class AdoptionEventRepository : IAdoptionEventRepository
        {
            private readonly string _connectionString;

            public AdoptionEventRepository(string connectionString)
            {
                _connectionString = connectionString;
            }

            public List<AdoptionEvent> GetAll()
            {
                var adoptionEvents = new List<AdoptionEvent>();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT * FROM AdoptionEvents";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    adoptionEvents.Add(new AdoptionEvent
                                    {
                                        EventId = (int)reader["EventId"],
                                        EventDate = (DateTime)reader["EventDate"],
                                        Location = reader["Location"].ToString(),
                                        Status = reader["Status"].ToString()
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }

                return adoptionEvents;
            }

            public Adopt

        }
    }
