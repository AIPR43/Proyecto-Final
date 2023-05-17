using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app4._0
{
    public partial class reporte : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source = DESKTOP-SQ41FIC; Initial Catalog = dbleng; Integrated Security = True;");
        public reporte()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivos de texto (*.txt)|*.txt";
                saveDialog.Title = "Guardar archivo de texto";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDialog.FileName;
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            // Escribir encabezados de columnas
                            for (int i = 0; i < dgvReport.Columns.Count; i++)
                            {
                                writer.Write(dgvReport.Columns[i].HeaderText);
                                if (i < dgvReport.Columns.Count - 1)
                                    writer.Write("\t"); // Tabulador como separador de columnas
                            }
                            writer.WriteLine();

                            // Escribir datos de celdas
                            foreach (DataGridViewRow row in dgvReport.Rows)
                            {
                                for (int i = 0; i < dgvReport.Columns.Count; i++)
                                {
                                    writer.Write(row.Cells[i].Value);
                                    if (i < dgvReport.Columns.Count - 1)
                                        writer.Write("\t"); // Tabulador como separador de columnas
                                }
                                writer.WriteLine();
                            }

                            writer.Close();
                        }

                        MessageBox.Show("Los datos se han exportado correctamente.", "Exportar a TXT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se produjo un error al exportar los datos: " + ex.Message, "Exportar a TXT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay datos para exportar.", "Exportar a TXT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivo CSV (*.csv)|*.csv";
                saveDialog.Title = "Guardar archivo CSV";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDialog.FileName;

                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                        {
                            // Escribir encabezados de columnas
                            for (int i = 0; i < dgvReport.Columns.Count; i++)
                            {
                                writer.Write(dgvReport.Columns[i].HeaderText);
                                if (i < dgvReport.Columns.Count - 1)
                                    writer.Write(","); // Coma como separador de columnas
                            }
                            writer.WriteLine();

                            // Escribir datos de celdas
                            foreach (DataGridViewRow row in dgvReport.Rows)
                            {
                                for (int i = 0; i < dgvReport.Columns.Count; i++)
                                {
                                    if (row.Cells[i].Value != null)
                                    {
                                        string value = row.Cells[i].Value.ToString();
                                        // Escapar las comas dentro del valor
                                        value = value.Replace(",", "\\,");
                                        writer.Write(value);
                                    }

                                    if (i < dgvReport.Columns.Count - 1)
                                        writer.Write(","); // Coma como separador de columnas
                                }
                                writer.WriteLine();
                            }

                            writer.Close();
                        }

                        MessageBox.Show("Los datos se han exportado correctamente.", "Exportar a CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Se produjo un error al exportar los datos: " + ex.Message, "Exportar a CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay datos para exportar.", "Exportar a CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXLSX_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string consulta = "select us.usuario 'Usuario', le.nombre 'Lenguaje', re.fecha_hora 'Fecha y Hora', re.archivo_salida 'Archivo Salida' from log re INNER JOIN users us on re.id_usuario = us.id_usuario\tINNER JOIN lenguaje le\ton re.id_lenguaje = le.id_lenguaje";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvReport.DataSource = dt;
        }
    }
}
