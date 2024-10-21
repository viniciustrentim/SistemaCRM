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

namespace SistemaCRM
{
    public partial class frmClientePesquisa : Form
    {
        private MySqlConnection conexao;
        private MySqlDataAdapter mAdapater;
        private DataSet mData;


        public frmClientePesquisa()
        {
            InitializeComponent();

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            dgvProcurarCliente.DataSource = mData;
            dgvProcurarCliente.DataMember = "cliente";
            conexao = new MySqlConnection("Persist Security Info=False;SERVER=127.0.1;DATABASE=sistemacrm;UID=root;PASSWORD=''");

            string strQuery = @"
                     SELECT idcli,nomecli,datanasccli,rgcli,cepcli,endcli,
                        comp1cli,comp2cli,baicli,cidcli,estcli,obscli
                     FROM
                       cliente
                     WHERE nomecli LIKE '%" + txtNomeP.Text + "%';";
            DataTable dttCliente = new DataTable();

            try
            {
                conexao.Open();
                if (conexao.State == ConnectionState.Open)
                {
                    MySqlDataAdapter objAdapter = new MySqlDataAdapter(strQuery, conexao);
                    objAdapter.Fill(dttCliente);
                    dgvProcurarCliente.DataSource = dttCliente;
                }
                else
                {
                    MessageBox.Show("Falha na abertura da conexão", "Erro");
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha na leituraa dos dados no banco!" + ex.Message.ToString(),"Erro",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
