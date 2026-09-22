using System;
using System.IO;


public class ArquivoConfigException : Exception
{
    public ArquivoConfigException()
        : base("O arquivo de configuração não foi encontrado no diretório especificado.")
    {
    }
    public ArquivoConfigException(string message)
        : base(message)
    {
    }
    public ArquivoConfigException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
public class Program
{

    public static void CarregarConfiguracao(string caminhoDoArquivo)
    {

        if (!File.Exists(caminhoDoArquivo))
        {
            throw new ArquivoConfigException(
                $"Falha ao carregar: O arquivo não foi encontrado no diretório ({caminhoDoArquivo})."
            );
        }

        Console.WriteLine("Arquivo de configuração carregado com sucesso!");
    }

    public static void Main()
    {
        string caminhoInvalido = @"C:\diretorio_falso\configuracao.json";

        try
        {
            CarregarConfiguracao(caminhoInvalido);
        }
        catch (ArquivoConfigException ex)
        {

            Console.WriteLine("Erro do Sistema: " + ex.Message);
        }
    }
}
