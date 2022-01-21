using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroPapel.Shared
{
    public class Usuario
    {

		public int Id { get; set; }
		public int EmpresaId { get; set; }
		public int CargoId { get; set; }

		public string CargoNombre { get; set; }
		public int JefeUsuarioId { get; set; }
		public string JefeUsuarioNombre { get; set; }
		public int UsuarioNivelId { get; set; }
		public string UsuarioNivelDescripcion { get; set; }

		

		public string RolNombre { get; set; }
		public string RolIds { get; set; }

		public string Apellidos { get; set; }
		public string Nombres { get; set; }

		public string NombreCompleto { get; set; }
		public string Identificacion { get; set; }
		public DateTime FechaNacimiento { get; set; }

		public string CodigoInterno { get; set; }
		public string Sexo { get; set; }

		public string SexoDescripcion { get; set; }
		public bool Estado { get; set; }
		public string EstadoDescripcion { get; set; }
	
		public string FotoUrl { get; set; }
		public string Celular { get; set; }
		public string Email { get; set; }
		public string Clave { get; set; }
		public string Direccion { get; set; }
		public string Observacion { get; set; }
		public DateTime FechaIngreso { get; set; }
		public DateTime FechaRetiro { get; set; }
		public decimal Salario { get; set; }
		public int UsuarioRegistroId { get; set; }
		public DateTime FechaRegistro { get; set; }

	}
}
