// -----------------------------------------------------------------------
// <copyright file="FormBase.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Net;
using System.Net.Mail;
using UmbracoFramework.Diagnostics;

namespace SHBusinessLogic.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class FormBase
    {
        /// <summary>
        /// Method to send email
        /// </summary>
        /// <param name="from">Email from</param>
        /// <param name="to">Email to</param>
        /// <param name="subject">Email subject</param>
        /// <param name="password">Account password</param>
        /// <param name="body">Email body</param>
        /// <returns>Returns wether message has been sent successfully</returns>
        public virtual bool SendMail(string from, string to, string subject, string password, string body)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.IsBodyHtml = false;
                mail.Body = body;

                var smtp = new SmtpClient { Host = "smtp.gmail.com", Port = 587, EnableSsl = true };
                smtp.EnableSsl = true;
                var networkCred = new NetworkCredential(mail.From.Address, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(this.GetType(), ex);
                throw;
            }
        }
    }
}
