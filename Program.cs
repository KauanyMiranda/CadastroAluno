using CadastroAlunos.DAO;
using CadastroAlunos.Data;
using CadastroAlunos.Models;
using static System.Console;
using static System.Convert;


alunos a = new alunos();
alunoDAO alunos = new alunoDAO();

do
{
    WriteLine("***** CADASTRO DE ALUNOS ****\n");
    WriteLine("[1] CADASTRO");
    WriteLine("[2] LISTA DE ALUNOS");
    WriteLine("[3] ATUALIZAR DADOS");
    WriteLine("[4] EXCLUIR ALUNO");
    int op = ToInt32(ReadLine());

    if (op == 1)
    {
        Write("**** CADASTRO DE ALUNOS ****");
        WriteLine("");
        Write("Nome: ");
        a.nome = ReadLine();
        Write("E-mail: ");
        a.email = ReadLine();
        Write("Telefone: ");
        a.telefone = ReadLine();
        Write("Data de Nascimento: ");
        a.dataNascimento = ToDateTime(ReadLine());
        alunos.Salvar(a);
        WriteLine("");
        WriteLine("Salvo com sucesso!");

    }else if (op == 2)
    {
        List<alunos> listAlunos = alunos.listarTodos();

        WriteLine("**** ALUNOS ****");

        foreach (var lista in listAlunos)
        {
            WriteLine("");
            WriteLine($"Código: {lista.id_aluno}");
            WriteLine($"Nome: {lista.nome}");
            WriteLine($"E-mail: {lista.email}");
            WriteLine($"Telefone: {lista.telefone}");
            WriteLine($"Data de Nascimento: {lista.dataNascimento}");
        }

    }
    else if (op == 3)
    {
        WriteLine("**** ATUALIZAR ALUNOS ****");
        WriteLine("");
        Write("Insira o código do aluno: ");
        a.id_aluno = ToInt32(ReadLine());
        WriteLine("");
        Write("Nome: ");
        a.nome = ReadLine();
        Write("E-mail: ");
        a.email = ReadLine();
        Write("Telefone: ");
        a.telefone = ReadLine();
        Write("Data de Nascimento: ");
        a.dataNascimento = ToDateTime(ReadLine());
        alunos.Atualizar(a);       
    }
    else if (op == 4)
    {

        WriteLine("**** EXCLUSÃO DE ALUNOS ****");
        WriteLine("");
        Write("Insira o código do aluno: ");
        int id = ToInt32(ReadLine());
        alunos.Deletar(id);
        WriteLine("");
        WriteLine("Aluno excluído com sucesso!");
    }
    else
    {
        break;
    }
}
while (true);


























// Conexao conexao = new Conexao();
//conexao.Conectar();


//alunos a = new alunos();
//a.nome = "Kauany";
//a.email = "kauany@gmail.com";
//a.telefone = "52168548456";
//a.dataNascimento = new DateTime(2004, 03, 09);


//alunoDAO alunoDAO = new alunoDAO();
//Console.Write("Qual aluno deseja excluir?");
//int id = Convert.ToInt32(Console.ReadLine());
//alunoDAO.Deletar(id);

