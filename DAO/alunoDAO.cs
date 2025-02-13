using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroAlunos.Data;
using CadastroAlunos.Models;
using MySql.Data.MySqlClient;

namespace CadastroAlunos.DAO
{
    internal class alunoDAO
    {
        public void Salvar(alunos aluno)
        {
			try
			{
                string sql = "INSERT INTO alunos (nome,email,telefone,dataNascimento) " +
                             "VALUES(@nome, @email, @telefone, @dataNascimento)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome", aluno.nome);
                comando.Parameters.AddWithValue("@email", aluno.email);
                comando.Parameters.AddWithValue("@telefone", aluno.telefone);
                comando.Parameters.AddWithValue("@dataNascimento", aluno.dataNascimento);

                comando.ExecuteNonQuery();
            }
			catch (Exception ex)
			{

				throw new Exception($"Erro ao cadastrar o aluno");
			}
        }


    }
}
