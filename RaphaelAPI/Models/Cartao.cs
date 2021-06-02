/*
    Copyright: RAPHAEL RODRIGUES DE SENA - 2021
 */
using System;
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

        public bool IsInvalid ()
        {
            try
            {
                long.Parse(this.numero);
            }
            catch(FormatException)
            {
                return true;
            }
            if (numero.Length != 16)
            {
                return true;
            }
            return (data_expiracao == null) || (bandeira == null) || (cvv == null) || (titular == null);
        }
    }
}
