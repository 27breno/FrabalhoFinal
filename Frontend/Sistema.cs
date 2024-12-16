using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    // Inicia o sistema e verifica se o usuário está logado ou precisa se cadastrar
    public void IniciarSistema()
    {
        Console.Clear();
        Console.WriteLine("Bem-vindo ao sistema! Você já possui uma conta?");

        if (usuarioLogado == null)
        {
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            int resposta;
            if (!int.TryParse(Console.ReadLine(), out resposta) || (resposta != 1 && resposta != 2))
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            if (resposta == 1)
            {
                Login();
            }
            else
            {
                Cadastrar();
                Login();
            }
        }
        else
        {
            MenuPrincipal();
        }
    }

    // Exibe o menu principal e permite que o usuário escolha suas opções
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

            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida.");
                continue;
            }

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
                    return;  // Sair do sistema
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    // Método para listar as assinaturas do usuário
    public void ListarAssinaturas()
    {
        var assinaturas = _assinaturaUC.ListarAssinaturas(usuarioLogado.Id);

        if (assinaturas.Count > 0)
        {
            Console.WriteLine("Suas assinaturas:");
            foreach (var assinatura in assinaturas)
            {
                Console.WriteLine(assinatura.ToString());
            }
        }
        else
        {
            Console.WriteLine("Você não possui nenhuma assinatura.");
        }

        RetornarMenu();
    }

    // Método para criar uma avaliação
    public void CriarAvaliacao()
    {
        var assinaturas = _assinaturaUC.ListarAssinaturas(usuarioLogado.Id);
        if (assinaturas.All(a => a.Status != "premium"))
        {
            Console.WriteLine("Você precisa ter uma assinatura Premium para avaliar conteúdos.");
            RetornarMenu();
            return;
        }

        Console.WriteLine("Digite o ID do conteúdo que você deseja avaliar:");
        int conteudoId;
        if (!int.TryParse(Console.ReadLine(), out conteudoId))
        {
            Console.WriteLine("ID inválido.");
            RetornarMenu();
            return;
        }

        Console.WriteLine("Digite sua nota (0 a 5):");
        int nota;
        if (!int.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 5)
        {
            Console.WriteLine("Nota inválida.");
            RetornarMenu();
            return;
        }

        Console.WriteLine("Digite seu comentário:");
        string comentario = Console.ReadLine();

        Avaliacao avaliacao = new Avaliacao
        {
            ConteudoId = conteudoId,
            PessoaId = usuarioLogado.Id,
            Nota = nota,
            Comentario = comentario
        };

        var resultado = _avaliacaoUC.CadastroAvaliacao(avaliacao);
        Console.WriteLine("Avaliação criada com sucesso!");
        Console.WriteLine(resultado.ToString());

        RetornarMenu();
    }

    // Método para listar categorias
    public void ListarCategorias()
    {
        var categorias = _categoriaUC.ListarCategoria(usuarioLogado.Id);

        if (categorias.Count > 0)
        {
            Console.WriteLine("Categorias disponíveis:");
            foreach (var categoria in categorias)
            {
                Console.WriteLine(categoria.ToString());
            }
        }
        else
        {
            Console.WriteLine("Nenhuma categoria encontrada.");
        }

        RetornarMenu();
    }

    // Método para listar conteúdos
    public void ListarConteudos()
    {
        var conteudos = _conteudoUC.ListarCategoria(usuarioLogado.Id);

        if (conteudos.Count > 0)
        {
            Console.WriteLine("Conteúdos disponíveis:");
            foreach (var conteudo in conteudos)
            {
                Console.WriteLine(conteudo.ToString());
            }
        }
        else
        {
            Console.WriteLine("Nenhum conteúdo encontrado.");
        }

        RetornarMenu();
    }

    // Método para atualizar assinatura (por exemplo, mudar para um plano diferente)
    public void AtualizarAssinatura()
    {
        Console.WriteLine("Escolha o tipo de assinatura:");
        Console.WriteLine("1 - Básico");
        Console.WriteLine("2 - Premium");

        int opcao;
        if (!int.TryParse(Console.ReadLine(), out opcao) || (opcao != 1 && opcao != 2))
        {
            Console.WriteLine("Opção inválida.");
            return;
        }

        string status = opcao == 1 ? "basico" : "premium";

        Assinatura novaAssinatura = new Assinatura
        {
            Pessoaid = usuarioLogado.Id,
            Status = status,
            DataInicio = DateTime.Now,
            Valor = status == "premium" ? 29.99m : 9.99m // Definindo valores fictícios para as assinaturas
        };

        var assinaturaAtualizada = _assinaturaUC.CadastroAssinatura(novaAssinatura);
        Console.WriteLine($"Assinatura {status} atualizada com sucesso!");

        RetornarMenu();
    }

    // Método de logout
    public void Logout()
    {
        usuarioLogado = null;
        Console.WriteLine("Você foi desconectado.");
        IniciarSistema();
    }

    // Método de login
    public void Login()
    {
        Console.Clear();
        Console.WriteLine("Digite seu nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite sua senha:");
        string senha = Console.ReadLine();

        usuarioLogado = _pessoaUC.Login(nome, senha);

        if (usuarioLogado != null)
        {
            Console.WriteLine($"Bem-vindo, {usuarioLogado.Nome}!");
            MenuPrincipal();
        }
        else
        {
            Console.WriteLine("Usuário ou senha inválidos.");
            RetornarMenu();
        }
    }

    // Método de cadastro
    public void Cadastrar()
    {
        Pessoa pessoa = new Pessoa();

        Console.Clear();
        Console.WriteLine("Digite seu nome:");
        pessoa.Nome = Console.ReadLine();

        Console.WriteLine("Digite sua idade:");
        pessoa.Idade = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite seu CPF (Somente números):");
        string cpf = Console.ReadLine();

        if (!ValidarCPF(cpf))
        {
            Console.WriteLine("CPF inválido. Tente novamente.");
            return;
        }

        pessoa.CPF = int.Parse(cpf);

        Console.WriteLine("Digite seu email:");
        pessoa.Email = Console.ReadLine();

        Console.WriteLine("Digite sua senha:");
        pessoa.Senha = Console.ReadLine();

        usuarioLogado = _pessoaUC.CadastroPessoa(pessoa);

        Console.WriteLine($"Cadastro realizado com sucesso! Bem-vindo, {usuarioLogado.Nome}.");
        RetornarMenu();
    }

    // Método de validação de CPF
    public bool ValidarCPF(string cpf)
    {
        if (cpf.Length != 11 || !cpf.All(char.IsDigit)) return false;

        // Lógica de validação de CPF pode ser melhorada conforme a regra
        return true;
    }

    // Método para voltar ao menu principal
    public void RetornarMenu()
    {
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        MenuPrincipal();
    }
}
