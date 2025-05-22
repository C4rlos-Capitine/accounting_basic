namespace Acounting_basic.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; } // Receita ou Despesa
        public decimal Saldo_Atual { get; set; }

        // Relacionamentos

    }
}
