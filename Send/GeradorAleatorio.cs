using System;
using System.Text;

public class GeradorAleatorio {
    public static Boleto GerarBoleto() {
        var rand = new Random();
        var dtVencimento = DateTime.Now.AddDays(rand.Next(100));
        var dataVencimento = $"{dtVencimento.Day:00}/{dtVencimento.Month:00}/{dtVencimento.Year:0000}";
        
        return new Boleto(
            nossoNumero: $"{rand.Next(10000000, 20000000)}",
            numeroDocumento: $"14/900000{rand.Next(999)}",
            valor: (rand.Next(500, 999) * (rand.Next(99)/100M)),
            vencimento: dataVencimento,
            pagador: $"Jose {rand.Next(100)} Joao da Silva",
            endereco: $"Rua da Esquina, {rand.Next(1000)}, Centro",
            cpf: GerarCPF()
        );
    }

    private static String GerarCPF(bool formatar = true)
    {
        int soma = 0, resto = 0;
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        Random rnd = new Random();
        string semente = rnd.Next(100000000, 999999999).ToString();

        for (int i = 0; i < 9; i++)
            soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        semente = semente + resto;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

        resto = soma % 11;

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        semente = semente + resto;

        if (formatar) {
            semente = $"{semente.Substring(0, 3)}.{semente.Substring(3, 3)}.{semente.Substring(6, 3)}-{semente.Substring(9, 2)}";
        }
        return semente;
    }
}