using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroAlunos.Data;
using CadastroAlunos.Interface;
using CadastroAlunos.Models;
using MySql.Data.MySqlClient;
using static System.Console;

namespace CadastroAlunos.DAO
{
    internal class alunoDAO:IDAO<alunos>
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

                WriteLine("Cadastrado com sucesso!");
            }
			catch (Exception ex)
			{

				throw new Exception($"Erro ao cadastrar! {ex.Message}");
			}
        }

        public void Deletar(int id)
        {
            try
            {
                string sql = "DELETE FROM alunos WHERE id_aluno = @id_aluno";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_aluno", id);            
                comando.ExecuteNonQuery();

                WriteLine("Aluno excluído com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar o aluno{ex.Message}");
            }
        }

        public void Atualizar(alunos aluno)
        {
            try
            {
                string sql = "UPDATE alunos SET nome = @nome, email = @email" +
                      "telefone = @telefone, dataNascimento = @dataNascimento" +
                      "WHERE id_aluno = @id_aluno";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_aluno", aluno.id_aluno);
                comando.Parameters.AddWithValue("@nome", aluno.nome);
                comando.Parameters.AddWithValue("@email", aluno.email);
                comando.Parameters.AddWithValue("@telefone", aluno.telefone);
                comando.Parameters.AddWithValue("@dataNascimento", aluno.dataNascimento);
                comando.ExecuteNonQuery();

                WriteLine("Aluno atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao atualizar o aluno{ex.Message}");
            }

        }

        public List<alunos> listarTodos() 
        {
            try
            {
                List<alunos> alunos = new List<alunos>();
                var sql = "SELECT * FROM alunos ORDER BY nome";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        alunos aluno = new alunos();
                        aluno.id_aluno = dr.GetInt32("id_aluno");
                        aluno.nome = dr.GetString("nome");
                        aluno.email = dr.GetString("email");
                        aluno.telefone = dr.GetString("telefone");
                        aluno.dataNascimento = dr.GetDateTime("dataNascimento");
                        alunos.Add(aluno);
                    }
                    return alunos;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao listar alunos {ex.Message}");
            }
        }


    }
}
