using System;

[Serializable]
public class IdadeInvalidaException : Exception
{
    public int Idade { get; }

    public IdadeInvalidaException() { }

    public IdadeInvalidaException(string message)
        : base(message) { }

    public IdadeInvalidaException(string message, Exception inner)
        : base(message, inner) { }

    public IdadeInvalidaException(int idade)
        : base($"A idade informada ({idade}) é inválida. A idade deve estar entre 0 e 100 anos.")
    {
        Idade = idade;
    }
}

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa(string nome, int idade)
    {
        if (idade < 0 || idade > 100)
        {
            throw new IdadeInvalidaException(idade);
        }

        Nome = nome;
        Idade = idade;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Pessoa pessoa = new Pessoa("Ana", 130);
            Console.WriteLine($"Pessoa cadastrada: {pessoa.Nome}, {pessoa.Idade} anos.");
        }
        catch (IdadeInvalidaException ex)
        {
            Console.WriteLine("ERRO DE VALIDAÇÃO:");
            Console.WriteLine(ex.Message);
            Console.WriteLine($"Idade rejeitada: {ex.Idade}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro inesperado: " + ex.Message);
        }
    }
}
