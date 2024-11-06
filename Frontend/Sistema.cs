using FrabalhoFinal._3_Entidade;
using Frontend.Models;
using Frontend.Usecases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    public class Sistema
    {
        private readonly AssinaturaUC _assinaturaUC;
        private readonly AvaliacaoUC _avaliacaoUC;
        private readonly CategoriaUC _categoriaUC;
        private readonly ConteudoUC _conteudoUC;
        private readonly PessoaUC _pessoaUC;

       
        public Sistema(HttpClient  cliente) 
        { 
            _assinaturaUC = new AssinaturaUC(cliente);
            _avaliacaoUC = new AvaliacaoUC(cliente);
            _categoriaUC= new CategoriaUC(cliente);
            _conteudoUC = new ConteudoUC(cliente);
            _pessoaUC = new PessoaUC(cliente);
        }

        public void IniciarSistema() 
        {
            
        }
        public void MenuPrincipal()
        {

        }
        public void Login( ) 
        {
            Pessoa pessoa = new Pessoa();

            Console.WriteLine("digite seu nome");
            pessoa.Nome = Console.ReadLine();

            Console.WriteLine("digite a sua idade");
            pessoa.Idade =int.Parse(Console.ReadLine());

            Console.WriteLine("digite seu CPF");
            pessoa.CPF = int.Parse(Console.ReadLine());

            Console.WriteLine("digite seu Email");
            pessoa.Email = Console.ReadLine();

            Console.WriteLine("digite a sua senha");
            pessoa.Senha = Console.ReadLine();
        }

        public void CriarAvaliacao()
        {
            Avaliacao avaliacao= new Avaliacao();



        }
    }
}
