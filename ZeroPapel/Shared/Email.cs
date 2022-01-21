
using System.ComponentModel.DataAnnotations;



namespace ZeroPapel.Shared
{
   public class Email
    {
     
        public string ServidorSMTP { get; set; }
        public string From { get; set; }
        public bool Ssl { get; set; }
        public string Puerto { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Destinatarios { get; set; }
        public string NombreEmail { get; set; }
        public string Asunto { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Mensaje { get; set; }
        public string UrlAplicacion { get; set; }
    }
}
