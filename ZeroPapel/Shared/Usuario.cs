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
		public string IdentificacionTipoId { get; set; }
		public string EstadoCivilTipoId { get; set; }

		public string MunicipioNacimientoId { get; set; }
		public string MunicipioExpedicionId { get; set; }

		public string MunicipioDireccionId { get; set; }

		public string EmpresaNombre { get; set; }
		public string EmpresaLogo { get; set; }
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

		public string TipoSangre { get; set; }

		public string Estrato { get; set; }

		public string Telefono { get; set; }

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

		public string PersonaContactoNombre { get; set; }
		public string PersonaContactoCelular { get; set; }
		public string PersonaContactoTelefono { get; set; }

		public string PersonaContactoEmail { get; set; }

		public string PersonaContactoParentescoId { get; set; }


		public string EpsId { get; set; }
		public string CajaCompensacionId { get; set; }
		public string FondoPensionId { get; set; }
		public string FondoCesantiaId { get; set; }
		public string ArlId { get; set; }

		public string BancoId { get; set; }
		public string TipoCuentaId { get; set; }
		public string NumeroCuenta { get; set; }

		public string TallaCamisa { get; set; }
		public string TallaPantalon { get; set; }

		public string TallaZapatos { get; set; }
		public string TallaOverol { get; set; }

		public string TallaBata { get; set; }


		public int UsuarioCreacionId { get; set; }

		public int UsuarioActualizacionId { get; set; }
		public DateTime FechaCreacion { get; set; }

	}
}
