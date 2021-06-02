/*
    Copyright: RAPHAEL RODRIGUES DE SENA - 2021
 */


namespace RaphaelAPI.Pagamentos.Models
{
    public class Pagamento
    {
        public float valor { get; set; }
        public string estado { get; set; }

        public Pagamento () { }

        public Pagamento(float valor, string estado)
        {
            this.valor = valor;
            this.estado = estado;
        }
    }
}
