using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ex_MaxiCristian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiarioController : ControllerBase
    {
        Modelos.Bd db = new Modelos.Bd();
        string msg = string.Empty;
        // GET: api/<BeneficiarioController>
        [HttpGet]
        public List<Modelos.Beneficiarios> Get()
        {
            Modelos.Beneficiarios emp = new Modelos.Beneficiarios();
            //jaja me abandonas :c
            emp.id = 1;
            DataSet ds = db.catalogoBeneficiarios(emp, out msg);
            List<Modelos.Beneficiarios> list = new List<Modelos.Beneficiarios>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Modelos.Beneficiarios
                {
                    id = Convert.ToInt32(dr["idBeneficiario"]),
                    Nombre = dr["Nombre"].ToString(),
                    Apellidos = dr["Apellidos"].ToString(),
                    fNacimiento = dr["FechaNacimiento"].ToString(),
                    Curp = dr["Curp"].ToString(),
                    Ssn = dr["Ssn"].ToString(),
                    Telefono = Convert.ToInt32(dr["Telefono"]),
                    Nacionalidad = dr["Nacionalidad"].ToString(),
                    Porcentaje = Convert.ToInt32(dr["PorcentajePart"]),
                    idEmpleado = Convert.ToInt32(dr["idEmpleado"]),
                }

                    );
            }
            return list;
        }

        // GET api/<BeneficiarioController>/5
        [HttpGet("{id}")]
        public List<Modelos.Beneficiarios> Get(int id)
        {
            Modelos.Beneficiarios emp = new Modelos.Beneficiarios();
            //jaja me abandonas :c
            emp.idEmpleado = id;
            DataSet ds = db.buscaBeneficiario(emp, out msg);
            List<Modelos.Beneficiarios> list = new List<Modelos.Beneficiarios>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Modelos.Beneficiarios
                {
                    id = Convert.ToInt32(dr["idBeneficiario"]),
                    Nombre = dr["Nombre"].ToString(),
                    Apellidos = dr["Apellidos"].ToString(),
                    fNacimiento = dr["FechaNacimiento"].ToString(),
                    Curp = dr["Curp"].ToString(),
                    Ssn = dr["Ssn"].ToString(),
                    Telefono = Convert.ToInt32(dr["Telefono"]),
                    Nacionalidad = dr["Nacionalidad"].ToString(),
                    Porcentaje = Convert.ToInt32(dr["PorcentajePart"]),
                    idEmpleado = Convert.ToInt32(dr["idEmpleado"]),
                }

                    );
            }
            return list;
        }

        // POST api/<BeneficiarioController>
        [HttpPost]
        public string Post([FromBody] Modelos.Beneficiarios emp)
        {
            string msg = string.Empty;
            try
            {
                msg = db.agregaBeneficiario(emp);
            }
            catch (Exception ex)
            {
                throw;
            }
            return msg;
        }

        // PUT api/<BeneficiarioController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Modelos.Beneficiarios emp)
        {
            string msg = string.Empty;
            try
            {
                msg = db.updateBeneficiarios(id,emp);
            }
            catch (Exception ex)
            {
                throw;
            }
            return msg;
        }

        // DELETE api/<BeneficiarioController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                //emp.id = id;
                msg = db.deleteBeneficiario(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return msg;
        }
    }
}
