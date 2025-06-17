
using System.Net.Mail;
using System.Net;
using System.Text;

namespace OptimaBank.Services.Email
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _smtpFromEmail;

        public EmailService(string smtpServer, int smtpPort)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
        }

        public void EnviarNuevaContrasena()
        {
            try
            {
                // Generar contraseña aleatoria
                string nuevaPassword = GenerarPasswordAleatoria();

                // Configurar el cliente SMTP
                using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);

                    // Crear el mensaje
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_smtpFromEmail),
                        Subject = "Nueva Contraseña",
                        Body = $"Su nueva contraseña es: {nuevaPassword}\n\nPor favor, cambie su contraseña después de iniciar sesión.",
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add("");

                    // Enviar el correo
                    await smtpClient.SendMailAsync(mailMessage);

                    // Actualizar la contraseña en la base de datos
                    //using (var scope = new TransactionScope(TransactionScopeOption.Required,
                    //    new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
                    //{
                    //    _acceso.Abrir();
                    //    string tableName = typeof(T).Name;

                    //    string updateQuery = $"UPDATE {tableName} SET Password = @Password WHERE Email = @Email";
                    //    using (var command = new SqlCommand(updateQuery, _acceso.Connection))
                    //    {
                    //        command.Parameters.Add(new SqlParameter("@Password", nuevaPassword));
                    //        command.Parameters.Add(new SqlParameter("@Email", emailDestino));
                    //        await command.ExecuteNonQueryAsync();
                    //    }

                    //    _acceso.Cerrar();
                    //    scope.Complete();
                    //}

                    return Result<string>.Success("Contraseña enviada correctamente");
                }
            }
            catch (SmtpException ex)
            {
                //_logger.LogError(ex, $"Error al enviar el correo electrónico a {emailDestino}");
                //throw new DataAccessException($"Error al enviar el correo electrónico: {ex.Message}", ex);
            }
            //catch (SqlException ex)
            //{
                //_logger.LogError(ex, $"Error de base de datos al actualizar la contraseña para {emailDestino}");
                //throw new DataAccessException($"Error al actualizar la contraseña: {ex.Message}", ex);
            //}
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Error inesperado al enviar nueva contraseña a {emailDestino}");
                //throw new DataAccessException($"Error inesperado: {ex.Message}", ex);
            }
        }

        private string GenerarPasswordAleatoria()
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=";
            var random = new Random();
            var password = new StringBuilder();

            // Generar una contraseña de 12 caracteres
            for (int i = 0; i < 12; i++)
            {
                password.Append(caracteresPermitidos[random.Next(caracteresPermitidos.Length)]);
            }

            return password.ToString();
        }

    }
}
