using CadastroAlunos.DAO;
using CadastroAlunos.Data;
using CadastroAlunos.Models;

// Conexao conexao = new Conexao();
//conexao.Conectar();

alunos a = new alunos();
a.nome = "Kauany";
a.email = "kauany@gmail.com";
a.telefone = "52168548456";
a.dataNascimento = new DateTime(2004, 03, 09);

alunoDAO alunoDAO1 = new alunoDAO();
alunoDAO1.Salvar(a);