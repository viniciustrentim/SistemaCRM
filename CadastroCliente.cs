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
    public partial class frmCadastroCliente : Form
    {
        public frmCadastroCliente()
        {
            InitializeComponent();

            dtpDataNasc.Format = DateTimePickerFormat.Custom;
            dtpDataNasc.CustomFormat = "dd/MM/yyyy";
        }

        //Botão de Limpar Componentes
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            dtpDataNasc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtRG.Clear();
            txtEndereco.Clear();
            txtComplemento1.Clear();
            txtComplemento2.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            txtEstado.Clear();
            mtbCEP.Clear();
            txtObservacao.Clear();
        }

        //Botão de Buscar CEP
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var ws = new WSCorreios.AtendeClienteClient())
            {
                try
                {
                    var resultado = ws.consultaCEP(mtbCEP.Text);
                    txtEndereco.Text = resultado.end;
                    //txtComplemento1.Text = resultado.complemento;
                    txtComplemento2.Text = resultado.complemento2;
                    txtCidade.Text = resultado.cidade;
                    txtBairro.Text = resultado.bairro;
                    txtEstado.Text = resultado.uf;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Construtor cadcli = new Construtor();
            DAL da = new DAL();

            //gravar o valor da TextBox
            cadcli.nmcli  = txtNome.Text;
            cadcli.dncli  = dtpDataNasc.Text;
            cadcli.rgcli  = txtRG.Text;
            cadcli.cepcli = mtbCEP.Text;
            cadcli.endcli = txtEndereco.Text;
            cadcli.cp1cli = txtComplemento1.Text;
            cadcli.cp2cli = txtComplemento2.Text;
            cadcli.baicli = txtBairro.Text;
            cadcli.cidcli = txtCidade.Text;
            cadcli.estcli = txtEstado.Text;
            cadcli.obscli = txtObservacao.Text;

            da.AdicionarCli(cadcli);
            MessageBox.Show("Dados gravados com sucesso");

            //Limpar os campos
            txtNome.Clear();
            dtpDataNasc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            mtbCEP.Clear();
            txtRG.Clear();
            txtEndereco.Clear();
            txtComplemento1.Clear();
            txtComplemento2.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtObservacao.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
