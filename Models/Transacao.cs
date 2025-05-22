namespace Acounting_basic.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public int ID_Conta { get; set; }
        public int? ID_Cliente { get; set; } // FK opcional
        public int? ID_Fornecedor { get; set; } // FK opcional
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; } // Entrada ou Saída
        public string Descrição { get; set; }

        // Navegação
        public Conta Conta { get; set; }
        public Cliente Cliente { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
