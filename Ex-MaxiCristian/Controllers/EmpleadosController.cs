using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ex_MaxiCristian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        //llamada a clase de conexion
        Modelos.Bd db = new Modelos.Bd();
        string msg = string.Empty;
        // GET: api/<EmpleadosController>
        [HttpGet]
        public List<Modelos.Empleados> Get()
        {
            Modelos.Empleados emp = new Modelos.Empleados();
            //jaja me abandonas :c
            emp.Id = 1;
            DataSet ds = db.catalogoEmpleado(emp, out msg);
            List<Modelos.Empleados> list = new List<Modelos.Empleados>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Modelos.Empleados
                {
                    Id = Convert.ToInt32(dr["idEmpleado"]),
                    Nombre = dr["Nombre"].ToString(),
                    Apellidos = dr["Apellidos"].ToString(),
                    fNacimiento = dr["FechaNacimiento"].ToString(),
                    Curp = dr["Curp"].ToString(),
                    Ssn = dr["Ssn"].ToString(),
                    Telefono = Convert.ToInt32(dr["Telefono"]),
                    Nacionalidad = dr["Nacionalidad"].ToString(),
                    nEmpleado = Convert.ToInt32(dr["NEmpleado"]),
                }

                    );
            }
            return list;
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public List<Modelos.Empleados> Get(int id)
        {
            Modelos.Empleados emp = new Modelos.Empleados();
            //jaja me abandonas :c
            emp.Id = id;
            DataSet ds = db.buscaEmpleado(emp, out msg);
            List<Modelos.Empleados> list = new List<Modelos.Empleados>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Modelos.Empleados
                {
                    Id = Convert.ToInt32(dr["idEmpleado"]),
                    Nombre = dr["Nombre"].ToString(),
                    Apellidos = dr["Apellidos"].ToString(),
                    fNacimiento = dr["FechaNacimiento"].ToString(),
                    Curp = dr["Curp"].ToString(),
                    Ssn = dr["Ssn"].ToString(),
                    Telefono = Convert.ToInt32(dr["Telefono"]),
                    Nacionalidad = dr["Nacionalidad"].ToString(),
                    nEmpleado = Convert.ToInt32(dr["NEmpleado"]),
                }

                    );
            }
            return list;
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        //[Route ("crearEmpleado")]
        public string Post([FromBody] Modelos.Empleados emp)
        {
            string msg = string.Empty;
            try
            {
              msg =  db.agregaEmpleado(emp);
            }
            catch(Exception ex)
            {
                throw;
            }
            return msg;
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Modelos.Empleados emp)
        {
            string msg = string.Empty;
            try
            {
                emp.Id = id;
                msg = db.updateEmpleado(id,emp);
            }
            catch (Exception ex)
            {
                throw;
            }
            return msg;
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                
                msg = db.deleteEmpleado(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return msg;
        }
    }
}
