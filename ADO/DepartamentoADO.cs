using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using Tarea_1.Modelos;

namespace Tarea_1.ADO
{
    public class DepartamentoADO
    {
        private readonly string conexionString;

        public DepartamentoADO()
        {
            conexionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }
        public List<Departamento> ListarDepartamento()
        {
            List<Departamento> departamentos = new List<Departamento>();
            using (SqlConnection connection = new SqlConnection(conexionString))
            {
                using (SqlCommand command = new SqlCommand("spListarDepartamentos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();

                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Departamento departamento = new Departamento()
                                {
                                    idDepartamento = Convert.ToInt32(dataReader["idDepartamento"]),
                                    Nombre = dataReader["Nombre"].ToString()
                                };
                                departamentos.Add(departamento);
                            }
                            return departamentos;

                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al listar departamentos: " + ex.Message);
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
