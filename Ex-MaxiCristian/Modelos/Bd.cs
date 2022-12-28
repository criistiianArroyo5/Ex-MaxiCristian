using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
namespace Ex_MaxiCristian.Modelos
{
    public class Bd
    {
        //cadena de conexion a SQL
        SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=ExamenMaxi;Integrated Security=True");

        //Metodo para buscar empleado por ID
        public DataSet buscaEmpleado( Empleados emp, out string msg)
        {
            DataSet ds = new DataSet();

            try
            {
                //llamada al stored procedure en SQL
                SqlCommand con = new SqlCommand("buscaEmpleado", conexion);
                con.CommandType = CommandType.StoredProcedure;
                con.Parameters.AddWithValue("@id", emp.Id);
                SqlDataAdapter da = new SqlDataAdapter(con);
                da.Fill(ds);
                //Mensaje en el servicio REST
                msg = "SUCCESS";
            }
            catch (Exception err)
            {
                msg = err.Message;
            }

           

            return ds;
        }

        //Metodo para agregar empleado
        public string agregaEmpleado(Empleados emp)
        {

            string msg = string.Empty;
            try
            {
                //llamada al stored procedure en SQL
                SqlCommand con = new SqlCommand("insertEmpleado", conexion);
                con.CommandType = CommandType.StoredProcedure;
                con.Parameters.AddWithValue("@Nombre", emp.Nombre);
                con.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                if (emp.fNacimiento == null)emp.fNacimiento = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
                con.Parameters.AddWithValue("@FechaNacimiento", emp.fNacimiento);
                con.Parameters.AddWithValue("@NEmpleado", emp.nEmpleado);
                if (emp.Curp == null) emp.Curp = "";
                con.Parameters.AddWithValue("@Curp", emp.Curp);
                if (emp.Ssn == null) emp.Ssn = "";
                con.Parameters.AddWithValue("@Ssn", emp.Ssn);
                con.Parameters.AddWithValue("@Telefono", emp.Telefono);
                if (emp.Nacionalidad == null) emp.Nacionalidad = "";
                con.Parameters.AddWithValue("@Nacionalidad", emp.Nacionalidad);
                
                conexion.Open();
                con.ExecuteNonQuery();
                conexion.Close();
                //Mensaje en el servicio REST
                msg = "SUCCESS";
                
            }
            catch (Exception err)
            {
                msg = err.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return msg;
        }

        //Metodo para buscar empleado por ID
        public DataSet catalogoEmpleado(Empleados emp, out string msg)
        {
            DataSet ds = new DataSet();

            try
            {
                //llamada al stored procedure en SQL
                SqlCommand con = new SqlCommand("catalogoEmpleados", conexion);
                con.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(con);
                da.Fill(ds);
                //Mensaje en el servicio REST
                msg = "SUCCESS";
            }
            catch (Exception err)
            {
                msg = err.Message;
            }



            return ds;
        }
        //Metodo para agregar empleado
        public string updateEmpleado(int id,Empleados emp)
        {

            string msg = string.Empty;
            try
            {
                //llamada al stored procedure en SQL
                SqlCommand con = new SqlCommand("updateEmpleado", conexion);
                con.CommandType = CommandType.StoredProcedure;
                con.Parameters.AddWithValue("@id", id);
                con.Parameters.AddWithValue("@Nombre", emp.Nombre);
                con.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                con.Parameters.AddWithValue("@FechaNacimiento", emp.fNacimiento);
                con.Parameters.AddWithValue("@NEmpleado", emp.nEmpleado);
                con.Parameters.AddWithValue("@Curp", emp.Curp);
                con.Parameters.AddWithValue("@Ssn", emp.Ssn);
                con.Parameters.AddWithValue("@Telefono", emp.Telefono);
                con.Parameters.AddWithValue("@Nacionalidad", emp.Nacionalidad);

                conexion.Open();
                con.ExecuteNonQuery();
                conexion.Close();
                //Mensaje en el servicio REST
                msg = "SUCCESS";

            }
            catch (Exception err)
            {
                msg = err.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return msg;
        }

        public string deleteEmpleado(int id)
        {

            string msg = string.Empty;
            try
            {
                //llamada al stored procedure en SQL
                SqlCommand con = new SqlCommand("deleteEmpleado", conexion);
                con.CommandType = CommandType.StoredProcedure;
                con.Parameters.AddWithValue("@id", id);

                conexion.Open();
                con.ExecuteNonQuery();
                conexion.Close();
                //Mensaje en el servicio REST
                msg = "SUCCESS";

            }
            catch (Exception err)
            {
                msg = err.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return msg;
        }

        /**********************************************************************************************************/

        public DataSet buscaBeneficiario(Beneficiarios ben, out string msg)
        {
            DataSet ds = new DataSet();

            try
            {
                //llamada al stored procedure en SQL
                SqlCommand con = new SqlCommand("buscaBeneficiario", conexion);
                con.CommandType = CommandType.StoredProcedure;
                con.Parameters.AddWithValue("@id", ben.idEmpleado);
                SqlDataAdapter da = new SqlDataAdapter(con);
                da.Fill(ds);
                //Mensaje en el servicio REST
                msg = "SUCCESS";
            }
            catch (Exception err)
            {
                msg = err.Message;
            }



            return ds;
        }

        //Metodo para agregar empleado
        public string agregaBeneficiario(Beneficiarios ben)
        {

            string msg = string.Empty;
            try
            {
                //llamada al stored procedure en SQL
                SqlCommand con = new SqlCommand("insertBeneficiario", conexion);
                con.CommandType = CommandType.StoredProcedure;
                con.Parameters.AddWithValue("@Nombre", ben.Nombre);
                con.Parameters.AddWithValue("@Apellidos", ben.Apellidos);
                con.Parameters.AddWithValue("@FechaNacimiento", ben.fNacimiento);
                con.Parameters.AddWithValue("@Curp", ben.Curp);
                con.Parameters.AddWithValue("@Ssn", ben.Ssn);
                con.Parameters.AddWithValue("@Telefono", ben.Telefono);
                con.Parameters.AddWithValue("@Nacionalidad", ben.Nacionalidad);
                con.Parameters.AddWithValue("@idEmpleado", ben.idEmpleado);
                con.Parameters.AddWithValue("@Porcentaje", ben.Porcentaje);
                conexion.Open();
                con.ExecuteNonQuery();
                conexion.Close();
                //Mensaje en el servicio REST
                msg = "SUCCESS";

            }
            catch (Exception err)
            {
                msg = err.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return msg;
        }

        //Metodo para buscar empleado por ID
        public DataSet catalogoBeneficiarios(Beneficiarios emp, out string msg)
        {
            DataSet ds = new DataSet();

            try
            {
                //llamada al stored procedure en SQL
                SqlCommand con = new SqlCommand("catalogoBeneficiarios", conexion);
                con.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(con);
                da.Fill(ds);
                //Mensaje en el servicio REST
                msg = "SUCCESS";
            }
            catch (Exception err)
            {
                msg = err.Message;
            }



            return ds;
        }
        //Metodo para agregar empleado
        public string updateBeneficiarios(int id,Beneficiarios emp)
        {

            string msg = string.Empty;
            try
            {
                //llamada al stored procedure en SQL
                SqlCommand con = new SqlCommand("updateBeneficiario", conexion);
                con.CommandType = CommandType.StoredProcedure;
                con.Parameters.AddWithValue("@id", emp.id);
                con.Parameters.AddWithValue("@idEmpleado", id);
                con.Parameters.AddWithValue("@Nombre", emp.Nombre);
                con.Parameters.AddWithValue("@Apellidos", emp.Apellidos);
                con.Parameters.AddWithValue("@FechaNacimiento", emp.fNacimiento);
                con.Parameters.AddWithValue("@Curp", emp.Curp);
                con.Parameters.AddWithValue("@Ssn", emp.Ssn);
                con.Parameters.AddWithValue("@Telefono", emp.Telefono);
                con.Parameters.AddWithValue("@Nacionalidad", emp.Nacionalidad);
                con.Parameters.AddWithValue("@Porcentaje", emp.Porcentaje);
                conexion.Open();
                con.ExecuteNonQuery();
                conexion.Close();
                //Mensaje en el servicio REST
                msg = "SUCCESS";

            }
            catch (Exception err)
            {
                msg = err.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return msg;
        }

        public string deleteBeneficiario(int id)
        {

            string msg = string.Empty;
            try
            {
                //llamada al stored procedure en SQL
                SqlCommand con = new SqlCommand("deleteBeneficiario", conexion);
                con.CommandType = CommandType.StoredProcedure;
                con.Parameters.AddWithValue("@id", id);

                conexion.Open();
                con.ExecuteNonQuery();
                conexion.Close();
                //Mensaje en el servicio REST
                msg = "SUCCESS";

            }
            catch (Exception err)
            {
                msg = err.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return msg;
        }

    }
}
