using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZeroPapel.Server.Data;
using ZeroPapel.Shared;

namespace ZeroPapel.Server.Helper
{
    public class EmailHelper
    {
        ParametrosDA parametroDA = new ParametrosDA();
        ProcesosLogDA procesoLogDA = new ProcesosLogDA();

        public bool EnviarEmail(Email model)
        {
            ProcesoLog proclog = new ProcesoLog();
            List<Parametro> lstParametros = parametroDA.ParametrosObtener(-1,-1, "-1");
            try
            {

                model.ServidorSMTP = lstParametros.Where(x => x.Nombre == "MailSmtp").FirstOrDefault().Valor;
                model.Ssl = Convert.ToBoolean(lstParametros.Where(x => x.Nombre == "MailSsl").FirstOrDefault().Valor);
                model.Puerto = lstParametros.Where(x => x.Nombre == "MailPort").FirstOrDefault().Valor;
                model.From = lstParametros.Where(x => x.Nombre == "MailFrom").FirstOrDefault().Valor;
                model.Clave = lstParametros.Where(x => x.Nombre == "MailPassword").FirstOrDefault().Valor;
                model.UrlAplicacion = lstParametros.Where(x => x.Nombre == "UrlAplicacion").FirstOrDefault().Valor;

                string mensajeCompleto = string.Format(@"
                 {0}
                 <br>
                 <br>
                 Para ingresar a la aplicación <strong>ZeroPapel</strong>, presione click <strong><a href={1}>AQUI.</a></strong> 
                 <br>
                 ", model.Mensaje, model.UrlAplicacion);


                SmtpClient smtp = new SmtpClient(model.ServidorSMTP);
                smtp.Port = int.Parse(model.Puerto);
                smtp.EnableSsl = model.Ssl;
                smtp.Credentials = new NetworkCredential(model.From, model.Clave);

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Timeout = 30000;

                MailAddress fromAddress = new MailAddress(model.From, model.NombreEmail);
                string subject = model.Asunto;
                string body = mensajeCompleto;

                MailMessage message = new MailMessage();

                message.To.Add(model.Destinatarios);
                message.From = fromAddress;
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;


                //Log del Proceso  
                proclog.EmpresaId = model.EmpresaId;
                proclog.ProcesoCodigo = 1; //Envio de email
                proclog.Campo1 = "ASUNTO: " + model.Asunto;
                proclog.Campo2 = "DESTINATARIOS: " + model.Destinatarios;
                proclog.Campo3 = "MENSAJE: " + body;
                proclog.Campo4 = "FROM: " + fromAddress;
                proclog.Estado = 1;//OK
                proclog.UsuarioRegistroId = model.UsuarioId;
                smtp.Send(message);       
            }
            catch (Exception ex)
            {
                proclog.Campo5 = "EXCEPTION-MESSAGE: " + ex.Message;
                proclog.Campo6 = "EXCEPTION-STACKTRACE: " + ex.StackTrace;
                proclog.Campo7 = "EXCEPTION-SOURCE: " + ex.Source;
                proclog.Campo8 = "EXCEPTION-DATA: " + ex.Data;
                proclog.Estado = 0;//ERROR
                procesoLogDA.ProcesosLogIngresar(proclog);
                parametroDA.LogEventosIngresar(ex);
                return false;
            }
            procesoLogDA.ProcesosLogIngresar(proclog);
            return true;
        }

        public bool ValidarEmail(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
