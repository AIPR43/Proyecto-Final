using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app4._0
{
    public partial class login : Form
    {

        private const string cadenaConexion = "Data Source = DESKTOP-SQ41FIC; Initial Catalog = dbleng; Integrated Security = True;"; // Cambia esto por tu cadena de conexión a SQL Server
        string usuario;
        //private const string cadenaConexion = "Data Source=SERVIDOR;Initial Catalog=BaseDeDatos;User ID=Usuario;Password=Contraseña;"; // Cambia esto por tu cadena de conexión a SQL Server
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;

            string contraseñaEncriptada = Encriptar(contraseña);

            // Insertar los datos del nuevo usuario en la tabla de la base de datos
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "INSERT INTO users (NombreUsuario, Contraseña) VALUES (@NombreUsuario, @Contraseña)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                //comando.Parameters.AddWithValue("@Contraseña", contraseña);
                comando.Parameters.AddWithValue("@Contraseña", contraseñaEncriptada);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro exitoso");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;

            // Obtener la contraseña encriptada del usuario de la tabla de la base de datos
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "SELECT Contraseña FROM users WHERE NombreUsuario = @NombreUsuario";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                try
                {
                    conexion.Open();
                    object resultado = comando.ExecuteScalar();

                    if (resultado != null) // Si se encontró el usuario en la base de datos
                    {
                        string contraseñaEncriptadaAlmacenada = resultado.ToString();
                        string contraseñaEncriptadaIngresada = Encriptar(contraseña);

                        if (contraseñaEncriptadaIngresada == contraseñaEncriptadaAlmacenada)
                        {
                            // Inicio de sesión exitoso
                            usuario = txtNombreUsuario.Text;
                            MessageBox.Show("Inicio de sesión exitoso");
                            compilador form2 = new compilador(usuario);
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Las credenciales de inicio de sesión no coinciden
                            MessageBox.Show("Credenciales de inicio de sesión incorrectas");
                        }
                    }
                    else
                    {
                        // El usuario no existe en la base de datos
                        MessageBox.Show("Usuario no encontrado");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al iniciar sesión: " + ex.Message);
                }
            }
        }
        private string Encriptar(string texto)
        {
            byte[] bytesTextoPlano = Encoding.UTF8.GetBytes(texto);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(bytesTextoPlano);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
