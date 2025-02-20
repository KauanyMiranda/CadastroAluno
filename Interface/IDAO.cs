using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroAlunos.Models;

namespace CadastroAlunos.Interface
{
    internal interface IDAO<T>
    {
        void Salvar(T entidades);
        void Deletar(int id);
        void Atualizar(T entidades);
    }
}
