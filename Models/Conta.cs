namespace Acounting_basic.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public decimal Saldo_Atual { get; set; }
        public TipoConta tipo_conta { get; set; } // Receita ou Despesa

        // Relacionamentos
    }
}
