using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using EmpresaApp.Models;

namespace EmpresaApp.Controllers
{   
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB; Initial Catalog=EmpresaDB; Integrated Security=True";
        // GET: ClienteController
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblCliente = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Clientes", sqlCon);
                sqlDa.Fill(dtblCliente);
            }

            return new JsonResult(dtblCliente);
        }


        // POST: ClienteController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(ClienteModelo clienteModelo)
        {
            const string INSERT_QUERY = "INSERT INTO Clientes " +
                "VALUES (@nombre, @rfc, @estado, @municipio, @direccion)";
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(INSERT_QUERY, sqlCon);
                sqlCmd.Parameters.AddWithValue("@nombre", clienteModelo.Nombre);
                sqlCmd.Parameters.AddWithValue("@rfc", clienteModelo.Rfc);
                sqlCmd.Parameters.AddWithValue("@estado", clienteModelo.Estado);
                sqlCmd.Parameters.AddWithValue("@municipio", clienteModelo.Municipio);
                sqlCmd.Parameters.AddWithValue("@direccion", clienteModelo.Direccion);
                sqlCmd.ExecuteNonQuery();

            }
            return Ok("Datos del cliente insertados");
        }

        // POST: ClienteController/Edit/5
        [HttpPut("{id:int}")]
        public ActionResult Edit(int id, ClienteModelo clienteModelo)
        {
            const string UPDATE_QUERY = "UPDATE Clientes SET " +
                "nombre = @nombre, rfc = @rfc, estado = @estado, municipio = @municipio, " +
                "direccion = @direccion WHERE clienteId = @clienteId ";
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(UPDATE_QUERY, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@clienteId", id);
                    sqlCmd.Parameters.AddWithValue("@nombre", clienteModelo.Nombre);
                    sqlCmd.Parameters.AddWithValue("@rfc", clienteModelo.Rfc);
                    sqlCmd.Parameters.AddWithValue("@estado", clienteModelo.Estado);
                    sqlCmd.Parameters.AddWithValue("@municipio", clienteModelo.Municipio);
                    sqlCmd.Parameters.AddWithValue("@direccion", clienteModelo.Direccion);
                    sqlCmd.ExecuteNonQuery();
                }
                return Ok("Datos del cliente actualizados ");

            } catch (Exception e)
            {
                return Ok(e);

            }

        }

        // GET: ClienteController/Delete/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            
            const string DELETE_QUERY = "DELETE FROM Clientes WHERE clienteId = @clienteId";
            
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(DELETE_QUERY, sqlCon);
                sqlCmd.Parameters.AddWithValue("@clienteId", id);
                sqlCmd.ExecuteNonQuery();
            }
            return Ok("Cliente eliminado ");
        }

    }
}
