using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace conexionDB_DataGridView
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "database=prueba;datasource=localhost;port=3308;username=root;password=";

            MySqlConnection conexionDB;
            DataTable dataTable = new DataTable();
            MySqlDataReader resultado;

            try
            {
                conexionDB = new MySqlConnection(cadenaConexion);

                MySqlCommand command = new MySqlCommand("SELECT * FROM usuario;", conexionDB);

                command.CommandType = CommandType.Text;

                conexionDB.Open();

                resultado = command.ExecuteReader();

                dataTable.Load(resultado);
            }catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            DGVUsuarios.DataSource = dataTable;

        }

        }

    }

    

