using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCRM
{
    class DAL
    {
        //Cadastrar Usuário de Sistema
        public void Adicionar(Construtor caduser)
        {
            String caminhodb = "Server=127.0.0.1;Database=sistemacrm;UID=root;PASSWORD=''";
            try
            {
                MySqlConnection conexao = new MySqlConnection(caminhodb);
                conexao.Open();

                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, caduser.senha);


                    string adicionar = "insert into usuario(nomeuser, loginuser, senhauser)" +
                    "values('" + caduser.nome + "','" + caduser.login + "','" + hash + "')";


                    MySqlCommand command = new MySqlCommand(adicionar, conexao);
                    MySqlDataReader myreader;
                    myreader = command.ExecuteReader();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos" + ex.Message);
            }
        }

        //Criar Hash MD5
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        //Verificar o Hash MD5
        public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Cadastrar o cliente
        public void AdicionarCli(Construtor cadcli)
        {
            String caminhodb = "Server=127.0.0.1;Database=sistemacrm;UID=root;PASSWORD=''";
            try
            {
                MySqlConnection conexao = new MySqlConnection(caminhodb);
                conexao.Open();
                MySqlCommand comm = new MySqlCommand();
                comm.Connection = conexao;
                comm.CommandText = "insert into cliente(nomecli, datanasccli, rgcli, cepcli, " +
                    "endcli, comp1cli, comp2cli, baicli, cidcli, estcli, obscli)" +
                    "values (@nomecli, @datanasccli, @rgcli, @cepcli, @endcli, @comp1cli," +
                    "@comp2cli, @baicli, @cidcli, @estcli, @obscli)";

                comm.Parameters.AddWithValue("@nomecli",cadcli.nmcli);
                comm.Parameters.AddWithValue("@datanasccli",cadcli.dncli);
                comm.Parameters.AddWithValue("@rgcli",cadcli.rgcli);
                comm.Parameters.AddWithValue("@cepcli",cadcli.cepcli);
                comm.Parameters.AddWithValue("@endcli",cadcli.endcli);
                comm.Parameters.AddWithValue("@comp1cli",cadcli.cp1cli);
                comm.Parameters.AddWithValue("@comp2cli",cadcli.cp1cli);
                comm.Parameters.AddWithValue("@baicli",cadcli.baicli);
                comm.Parameters.AddWithValue("@cidcli",cadcli.cidcli);
                comm.Parameters.AddWithValue("@estcli",cadcli.estcli);
                comm.Parameters.AddWithValue("@obscli",cadcli.obscli);

                comm.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos" + ex.Message);
            }
        }

    }
}
