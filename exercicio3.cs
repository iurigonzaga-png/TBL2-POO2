using System;

public class UsuarioNaoAutenticadoException : Exception
{

    public UsuarioNaoAutenticadoException()
        : base("Acesso negado: O usuário não está autenticado no sistema.")
    {
    }


    public UsuarioNaoAutenticadoException(string message)
        : base(message)
    {
    }


    public UsuarioNaoAutenticadoException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

public class SistemaSeguro
{
    // Simula o estado de autenticação do usuário
    private bool estaAutenticado = false;

    public void FazerLogin()
    {
        estaAutenticado = true;
        Console.WriteLine("Login realizado com sucesso!");
    }

    public void FazerLogout()
    {
        estaAutenticado = false;
        Console.WriteLine("Logout realizado.");
    }

    public void AcessarDadosSigilosos()
    {
        if (!estaAutenticado)
        {
            throw new UsuarioNaoAutenticadoException(
                "Tentativa de acesso bloqueada: Você precisa fazer login para visualizar estes dados."
            );
        }

        Console.WriteLine("Acesso liberado. Exibindo dados sigilosos...");
    }
}

public class Program
{
    public static void Main()
    {
        SistemaSeguro sistema = new SistemaSeguro();

        Console.WriteLine("--- Tentativa 1 (Sem login) ---");
        try
        {
            sistema.AcessarDadosSigilosos();
        }
        catch (UsuarioNaoAutenticadoException ex)
        {
            Console.WriteLine("Erro de Segurança: " + ex.Message);
        }

        Console.WriteLine("\n--- Tentativa 2 (Com login) ---");

        sistema.FazerLogin();

        try
        {
            sistema.AcessarDadosSigilosos();
        }
        catch (UsuarioNaoAutenticadoException ex)
        {
            Console.WriteLine("Erro de Segurança: " + ex.Message);
        }
    }
}
