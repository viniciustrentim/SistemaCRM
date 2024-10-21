using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCRM
{
    public partial class frmCadastroUsuario : Form
    {
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Construtor caduser = new Construtor();
            DAL da = new DAL();

            //gravar o valor da TextBox
            caduser.nome = txtNome.Text;
            caduser.login = txtLogin.Text;
            caduser.senha = txtSenha.Text;

            da.Adicionar(caduser);
            MessageBox.Show("Dados gravados com sucesso");

            txtNome.Clear();
            txtLogin.Clear();
            txtSenha.Clear();

        }
    }
}
