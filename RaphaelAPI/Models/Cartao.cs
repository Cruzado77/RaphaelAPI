/*
    Copyright: RAPHAEL RODRIGUES DE SENA - 2021
 */

using System.ComponentModel.DataAnnotations;

namespace RaphaelAPI.Models
{
    public class Cartao
    {
        [Key]
        public string numero { get; set; }
        public string data_expiracao { get; set; }
        public string bandeira { get; set; }
        public string cvv { get; set; }
        public string titular { get; set; }
    }
}
