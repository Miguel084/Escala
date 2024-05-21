namespace Escala.Api.Models;

public class Funcionario
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Unidade { get; set; }

    public required string Sexo { get; set; }

    public void Folga()
    {

    }
}




