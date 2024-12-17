using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using Frontend.Usecases;
using FrabalhoFinal._3_Entidade;
using Frontend.Models;

public class Sistema
{
    private readonly AssinaturaUC _assinaturaUC;
    private readonly AvaliacaoUC _avaliacaoUC;
    private readonly CategoriaUC _categoriaUC;
    private readonly ConteudoUC _conteudoUC;
    private readonly PessoaUC _pessoaUC;
    private Pessoa usuarioLogado;

    public Sistema(HttpClient cliente)
    {
        _assinaturaUC = new AssinaturaUC(cliente);
        _avaliacaoUC = new AvaliacaoUC(cliente);
        _categoriaUC = new CategoriaUC(cliente);
        _conteudoUC = new ConteudoUC(cliente);
        _pessoaUC = new PessoaUC(cliente);
        usuarioLogado = null; // Inicialmente, o usuário não está logado
    }

    public void IniciarSistema()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo ao sistema!");
            Console.WriteLine("1 - Fazer Login");
            Console.WriteLine("2 - Cadastrar-se");
            Console.WriteLine("0 - Sair");

            int opcao = LerEntradaNumerica(0, 2);

            if (opcao == 1)
            {
                Login();
            }
            else if (opcao == 2)
            {
                Cadastrar();
            }
            else if (opcao == 0)
            {
                Console.WriteLine("Encerrando o sistema...");
                break;
            }
        }
    }

    public void MenuPrincipal()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Bem-vindo, {usuarioLogado.Nome}!");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Listar Assinaturas");
            Console.WriteLine("2 - Criar Avaliação");
            Console.WriteLine("3 - Listar Categorias");
            Console.WriteLine("4 - Listar Conteúdos");
            Console.WriteLine("5 - Atualizar Assinatura");
            Console.WriteLine("6 - Logout");

            int opcao = LerEntradaNumerica(1, 6);

            switch (opcao)
            {
                case 1:
                    ListarAssinaturas();
                    break;
                case 2:
                    CriarAvaliacao();
                    break;
                case 3:
                    ListarCategorias();
                    break;
                case 4:
                    ListarConteudos();
                    break;
                case 5:
                    AtualizarAssinatura();
                    break;
                case 6:
                    Logout();
                    return;
            }
        }
    }

    // Cadastro de novos usuários
    private void Cadastrar()
    {
        Console.Clear();
        Console.WriteLine("Cadastro de novo usuário:");
        Console.WriteLine("Digite seu nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite sua idade:");
        int idade = LerEntradaNumerica(1, 150);

        Console.WriteLine("Digite seu CPF (apenas números):");
        string cpf = Console.ReadLine();
        while (!ValidarCPF(cpf))
        {
            Console.WriteLine("CPF inválido. Digite novamente:");
            cpf = Console.ReadLine();
        }

        Console.WriteLine("Digite seu email:");
        string email = Console.ReadLine();

        Console.WriteLine("Digite sua senha:");
        string senha = Console.ReadLine();

        var pessoa = new Pessoa
        {
            Nome = nome,
            Idade = idade,
            CPF = int.Parse(cpf),
            Email = email,
            Senha = senha
        };

        usuarioLogado = _pessoaUC.CadastroPessoa(pessoa);

        if (usuarioLogado != null)
        {
            Console.WriteLine($"Cadastro realizado com sucesso! Bem-vindo, {usuarioLogado.Nome}.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            MenuPrincipal();
        }
        else
        {
            Console.WriteLine("Erro ao realizar o cadastro. Tente novamente.");
        }
    }

    // Login de usuários existentes
    private void Login()
    {
        Console.Clear();
        Console.WriteLine("Digite seu email:");
        string email = Console.ReadLine();

        Console.WriteLine("Digite sua senha:");
        string senha = Console.ReadLine();

        usuarioLogado = _pessoaUC.Login(email, senha);

        if (usuarioLogado != null)
        {
            Console.WriteLine($"Login realizado com sucesso! Bem-vindo, {usuarioLogado.Nome}.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            MenuPrincipal();
        }
        else
        {
            Console.WriteLine("Email ou senha incorretos. Tente novamente.");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private void ListarAssinaturas()
    {
        Console.Clear();
        var assinaturas = _assinaturaUC.ListarAssinaturas(usuarioLogado.Id);

        if (assinaturas.Count > 0)
        {
            Console.WriteLine("Suas assinaturas:");
            foreach (var assinatura in assinaturas)
            {
                Console.WriteLine(assinatura);
            }
        }
        else
        {
            Console.WriteLine("Você não possui nenhuma assinatura.");
        }

        RetornarMenu();
    }

    private void CriarAvaliacao()
    {
        Console.Clear();
        var assinaturas = _assinaturaUC.ListarAssinaturas(usuarioLogado.Id);
        if (assinaturas.All(a => a.Status != "premium"))
        {
            Console.WriteLine("Você precisa de uma assinatura Premium para avaliar conteúdos.");
            RetornarMenu();
            return;
        }

        Console.WriteLine("Digite o ID do conteúdo que deseja avaliar:");
        int conteudoId = LerEntradaNumerica();

        Console.WriteLine("Digite sua nota (0 a 5):");
        int nota = LerEntradaNumerica(0, 5);

        Console.WriteLine("Digite seu comentário:");
        string comentario = Console.ReadLine();

        var avaliacao = new Avaliacao
        {
            ConteudoId = conteudoId,
            PessoaId = usuarioLogado.Id,
            Nota = nota,
            Comentario = comentario
        };

        _avaliacaoUC.CadastroAvaliacao(avaliacao);
        Console.WriteLine("Avaliação criada com sucesso!");
        RetornarMenu();
    }

    private void ListarCategorias()
    {
        Console.Clear();
        var categorias = _categoriaUC.ListarCategoria(usuarioLogado.Id);
        if (categorias.Count > 0)
        {
            Console.WriteLine("Categorias disponíveis:");
            foreach (var categoria in categorias)
            {
                Console.WriteLine(categoria);
            }
        }
        else
        {
            Console.WriteLine("Nenhuma categoria encontrada.");
        }
        RetornarMenu();
    }

    private void ListarConteudos()
    {
        Console.Clear();
        var conteudos = _conteudoUC.ListarCategoria(usuarioLogado.Id);
        if (conteudos.Count > 0)
        {
            Console.WriteLine("Conteúdos disponíveis:");
            foreach (var conteudo in conteudos)
            {
                Console.WriteLine(conteudo);
            }
        }
        else
        {
            Console.WriteLine("Nenhum conteúdo encontrado.");
        }
        RetornarMenu();
    }

    private void AtualizarAssinatura()
    {
        Console.Clear();
        Console.WriteLine("Escolha o tipo de assinatura:");
        Console.WriteLine("1 - Básico (R$9,99)");
        Console.WriteLine("2 - Premium (R$29,99)");

        int opcao = LerEntradaNumerica(1, 2);
        string status = opcao == 1 ? "basico" : "premium";

        var assinatura = new Assinatura
        {
            Pessoaid = usuarioLogado.Id,
            Status = status,
            DataInicio = DateTime.Now,
            Valor = opcao == 1 ? 9.99m : 29.99m
        };

        _assinaturaUC.CadastroAssinatura(assinatura);
        Console.WriteLine("Assinatura atualizada com sucesso!");
        RetornarMenu();
    }

    private void Logout()
    {
        usuarioLogado = null;
        Console.WriteLine("Logout realizado com sucesso.");
        IniciarSistema();
    }

    private void RetornarMenu()
    {
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        MenuPrincipal();
    }

    private int LerEntradaNumerica(int min = int.MinValue, int max = int.MaxValue)
    {
        int valor;
        while (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
        {
            Console.WriteLine($"Digite um número válido entre {min} e {max}:");
        }
        return valor;
    }

    private bool ValidarCPF(string cpf)
    {
        return cpf.Length == 11 && cpf.All(char.IsDigit); // Simplificação
    }
}
