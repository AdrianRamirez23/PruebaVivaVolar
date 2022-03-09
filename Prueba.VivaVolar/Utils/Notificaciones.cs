using Microsoft.Extensions.Configuration;
using Prueba.VivaVolar.Models;
using Prueba.VivaVolar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Utils
{
    public class Notificaciones
    {
        private readonly UserCRUD _userCRUD;
        private readonly VuelosCRUD _vuelosCRUD;
        private readonly IConfiguration _config;
        public Notificaciones(UserCRUD userCRUD, VuelosCRUD vuelos, IConfiguration configuration) 
        {
            _userCRUD = userCRUD;
            _vuelosCRUD = vuelos;
            _config = configuration;
        }
        public void EnviarNotificacion(Reservas reservas) 
        {
            Usuarios usuarioRerserva = _userCRUD.ConsultarUsuario(reservas);
            Vuelos vueloReserva = _vuelosCRUD.ConsultarVuelos(reservas);
            if (usuarioRerserva != null && vueloReserva != null) 
            {

                var correoDesde = _config.GetSection("CorreoConfig").GetSection("emailForm").Value;
                var credentials = _config.GetSection("CorreoConfig").GetSection("credentials").Value;
                var smtpCorreo = _config.GetSection("CorreoConfig").GetSection("smtp").Value;
                var puerto = _config.GetSection("CorreoConfig").GetSection("puerto").Value;
                

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(correoDesde, "Notificacion de Reserva", System.Text.Encoding.UTF8);//Correo de salida


                correo.To.Add(usuarioRerserva.Email);

                
                correo.Subject = "Notificacion reserva vuelo: "+vueloReserva.NumeroVuelo; //Asunto
                correo.Body = "Sr(a): "+usuarioRerserva.NombreUsuario+ " su vuelo número "+vueloReserva.NumeroVuelo+" ha sido reservado con éxito"; //Mensaje del correo
                correo.IsBodyHtml = true;
                //correo.Attachments.Add(new Attachment(correoClass.archivoContacto));
                correo.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = smtpCorreo; //Host del servidor de correo
                smtp.Port = Convert.ToInt32(puerto); //Puerto de salida
                smtp.Credentials = new System.Net.NetworkCredential(correoDesde, credentials);//Cuenta de correo
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                smtp.Send(correo);
               
            }
        
        }
    }
}
