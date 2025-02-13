using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CadastroAlunos.Data
{
    internal static class Conexao
    {
        static MySqlConnection? _conexao;
        // server: servidor; uid: usuario do mysql; pwd: senha do mysql; database: banco de dados que vai ser usado
        static string strconexao = "server=localhost;Port=3360;uid=root;pwd=root;database=aulaPOO";

        public static MySqlConnection Conectar()
        {
            try
            {
                _conexao = new MySqlConnection(strconexao);
                _conexao.Open();
                Console.WriteLine("Conexão realizada com sucesso!");
                return _conexao;
            }
            catch (Exception ex)
            {
                throw new Exception ($"Erro ao conectar {ex.Message}");
            }
        }
    }
}
