public class Boleto {
    public string NossoNumero { get; set; }
    public string NumeroDocumento { get; set; }
    public decimal Valor { get; set; }
    public string Vencimento { get; set; }
    public string Pagador { get; set; }
    public string Endereco { get; set; }
    public string CPF { get; set; }

    public Boleto(string nossoNumero, string numeroDocumento,
        decimal valor, string vencimento, string pagador,
        string endereco, string cpf) {
        this.NossoNumero = nossoNumero;
        this.NumeroDocumento = numeroDocumento;
        this.Valor = valor;
        this.Vencimento = vencimento;
        this.Pagador = pagador;
        this.Endereco = endereco;
        this.CPF = cpf;
    }
}