using BE_327LG;
using Microsoft.Data.SqlClient;
using Services_327LG;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALDigitoVerificador_327LG : DALAbstracta_327LG
    {


        public string CalcularDigitoVerificadorHorizontal_327LG(BEDigitoVerificador_327LG dv)
        {
            BigInteger sumaTotal = 0;
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                string consulta = $"SELECT * FROM {dv.NombreTabla_327LG}";
                SqlCommand cmd = new SqlCommand(consulta, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    object[] datos = new object[rdr.FieldCount];
                    rdr.GetValues(datos);
                    BigInteger sumaParcial = 0;
                    foreach (object o in datos)
                    {
                        string hex = Encriptador_327LG.Encriptar_327LG(o.ToString());
                        BigInteger num = BigInteger.Parse("00" + hex, NumberStyles.HexNumber);
                        sumaParcial += num;
                    }
                    string hex2 = Encriptador_327LG.Encriptar_327LG(sumaParcial.ToString());
                    sumaParcial = BigInteger.Parse("00" + hex2, NumberStyles.HexNumber);
                    sumaTotal += sumaParcial;
                }
            }
            return sumaTotal.ToString("X");
        }
        public string CalcularDigitoVerificadorVertical_327LG(BEDigitoVerificador_327LG dv)
        {
            BigInteger sumaTotal = 0;
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                string consulta = $"SELECT * FROM {dv.NombreTabla_327LG}";
                SqlCommand cmd = new SqlCommand(consulta, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<object[]> registros = new List<object[]>();
                while (rdr.Read())
                {
                    object[] fila = new object[rdr.FieldCount];
                    rdr.GetValues(fila);
                    registros.Add(fila);
                }
                rdr.Close();
                if (registros.Count > 0)
                {
                    for (int col = 0; col < registros[0].Length; col++)
                    {
                        BigInteger sumaColumna = 0;

                        foreach (var fila in registros)
                        {
                            string texto = fila[col]?.ToString() ?? "";
                            string hex = Encriptador_327LG.Encriptar_327LG(texto);

                            try
                            {
                                BigInteger valor = BigInteger.Parse("00" + hex, NumberStyles.HexNumber);
                                sumaColumna += valor;
                            }
                            catch
                            {

                            }
                        }
                        string hexCol = Encriptador_327LG.Encriptar_327LG(sumaColumna.ToString());
                        sumaColumna = BigInteger.Parse("00" + hexCol, NumberStyles.HexNumber);

                        sumaTotal += sumaColumna;
                    }
                }
            }
            return sumaTotal.ToString("X");
        }
        public void GuardarDigitoVerificador_327LG(BEDigitoVerificador_327LG dv)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                string consulta = "SELECT COUNT(*) FROM DigitoVerificador_327LG WHERE NombreTabla_327LG = @nombre";
                SqlCommand cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@nombre", dv.NombreTabla_327LG);
                con.Open();
                int existe = (int)cmd.ExecuteScalar();
                if (existe > 0)
                {
                    string queryUpdate = @"UPDATE DigitoVerificador_327LG SET DigitoHorizontal_327LG = @horizontal, DigitoVertical_327LG = @vertical WHERE NombreTabla_327LG = @nombre";

                    cmd = new SqlCommand(queryUpdate, con);
                    cmd.Parameters.AddWithValue("@horizontal", dv.DigitoVerificadorHorizontal_327LG);
                    cmd.Parameters.AddWithValue("@vertical", dv.DigitoVerificadorVertical_327LG);
                    cmd.Parameters.AddWithValue("@nombre", dv.NombreTabla_327LG);

                    cmd.ExecuteNonQuery();
                }
            }

        }
        public List<BEDigitoVerificador_327LG> ObtenerTodos_327LG()
        {
            List<BEDigitoVerificador_327LG> lista = new List<BEDigitoVerificador_327LG>();

            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM DigitoVerificador_327LG", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEDigitoVerificador_327LG dv = new BEDigitoVerificador_327LG(reader["NombreTabla_327LG"].ToString(), reader["DigitoHorizontal_327LG"].ToString()
                        , reader["DigitoVertical_327LG"].ToString());

                    lista.Add(dv);
                }
            }
            return lista;
        }
    }
}
