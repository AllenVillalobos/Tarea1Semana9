using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tarea_1.Modelos;

namespace Tarea_1.ADO
{
    public class PersonaADO
    {
        private readonly string conexionString;

        public PersonaADO()
        {
            conexionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }
        public List<Persona> ListarPersonas()
        {
            List<Persona> perosnas = new List<Persona>();
            using (SqlConnection connection = new SqlConnection(conexionString))
            {
                using (SqlCommand command = new SqlCommand("spListarPersonas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Persona persona = new Persona()
                                {
                                    idPersona = Convert.ToInt32(dataReader["idPersona"]),
                                    Nombre = dataReader["Nombre"].ToString(),
                                    Apellido = dataReader["Apellido"].ToString(),
                                    NombreDepartamento = dataReader["NombreDepartamento"].ToString()
                                };
                                perosnas.Add(persona);
                            }
                            return perosnas;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al listar personas: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        public List<Persona> ListarPersonasPorDepartamento(int idDepartamento)
        {
            List<Persona> perosnas = new List<Persona>();
            using (SqlConnection connection = new SqlConnection(conexionString))
            {
                using (SqlCommand command = new SqlCommand("spBuscarPersonaPorDepartamento", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pidDepartamento", idDepartamento);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Persona persona = new Persona()
                                {
                                    idPersona = Convert.ToInt32(dataReader["idPersona"]),
                                    Nombre = dataReader["Nombre"].ToString(),
                                    Apellido = dataReader["Apellido"].ToString(),
                                    NombreDepartamento = dataReader["NombreDepartamento"].ToString()
                                };
                                perosnas.Add(persona);
                            }
                            return perosnas;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al listar personas: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
