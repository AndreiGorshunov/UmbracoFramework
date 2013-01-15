// -----------------------------------------------------------------------
// <copyright file="OrderPresentationFormModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Mail;
using UmbracoFramework.Diagnostics;

namespace SHBusinessLogic.Forms
{
    using System.Collections.Generic;
    using System.Collections.Specialized;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class OrderPresentationFormModel
    {
        /// <summary>
        /// Initializes a new instance of the OrderPresentationFormModel class
        /// </summary>
        public OrderPresentationFormModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the OrderPresentationFormModel class from the query string or form variables
        /// </summary>
        /// <param name="request">The name value collection</param>
        public OrderPresentationFormModel(NameValueCollection request)
        {
            this.Name = request["name"];
            this.Phone = request["phone"];
            this.Phone0 = request["phone0"];
            this.City = request["city"];
            this.University = request["university"];
            //this.Group = request["group"];
            //this.PersonsCount = request["personscount"];
            //this.Date = request["date"];
            //this.TimeHours = request["timehours"];
            //this.TimeMinutes = request["timeminutes"];
            this.Comment = request["comment"];
            //this.HoneyPot = request["honeybear"];
        }

        public string Name { get; private set; }
        public string Phone0 { get; private set; }
        public string Phone { get; private set; }
        public string City { get; private set; }
        public string University { get; private set; }
        //public string Group { get; private set; }
        //public string PersonsCount { get; private set; }
        //public string Date { get; private set; }
        //public string TimeHours { get; private set; }
        //public string TimeMinutes { get; private set; }
        public string Comment { get; private set; }
        //public string HoneyPot { get; private set; }
        public const string SessionKey = "SH.Form.Submitted";

        /// <summary>
        /// Validates the model
        /// </summary>
        /// <returns>An empty list if valid otherwise a list of error messages</returns>
        public List<string> Validate()
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(this.Name))
            {
                errors.Add("Пожалуйста, заполните поле Ваше имя");
            }

            if (string.IsNullOrEmpty(this.Phone0))
            {
                errors.Add("Пожалуйста, заполните поле Телефон");
            }

            if (string.IsNullOrEmpty(this.Phone))
            {
                errors.Add("Пожалуйста, заполните поле Телефон");
            }

            if (string.IsNullOrEmpty(this.City))
            {
                errors.Add("Пожалуйста, заполните поле Город");
            }

            //if (!string.IsNullOrEmpty(this.HoneyPot))
            //{
            //    errors.Add(
            //        "Пожалуйста, не заполняйте поле с пометкой IGNORE. Это для проверки, что Вы человек, а не спам бот.");
            //}

            return errors;
        }

        /// <summary>
        /// Method to send email
        /// </summary>
        /// <param name="from">Email from</param>
        /// <param name="to">Email to</param>
        /// <param name="subject">Email subject</param>
        /// <param name="password">Account password</param>
        /// <returns>Returns wether message has been sent successfully</returns>
        public bool SendMessage(string from, string to, string subject, string password)
        {
            try
            {
                Log.Info(this.GetType(), "Start sending email:");
                var mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.IsBodyHtml = false;
                Log.Info(this.GetType(), "From email: " + mail.From);
                Log.Info(this.GetType(), "To email: " + mail.To);
                Log.Info(this.GetType(), "Subject email: " + mail.Subject);
                mail.Body = "Была отправлена заявка на презентацию:\n\n"
                            + "Name: " + this.Name + "\n"
                            + "Phone: " + "+375 " + this.Phone0 + " " + this.Phone + "\n"
                            + "City: " + this.City + "\n"
                            + "University: " + this.University + "\n"
                            //+ "Group: " + this.Group + "\n"
                            //+ "PersonsCount: " + this.PersonsCount + "\n"
                            //+ "Date: " + this.Date + "\n"
                            //+ "Time: " + this.TimeHours + ":" + this.TimeMinutes + "\n"
                            + "Comment: " + this.Comment + "\n";
                Log.Info(this.GetType(), "Email body: " + mail.Body);

                var smtp = new SmtpClient { Host = "smtp.gmail.com", Port = 587, EnableSsl = true };
                smtp.EnableSsl = true;
                var networkCred = new NetworkCredential(mail.From.Address, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred; 

                smtp.Send(mail);
                Log.Info(this.GetType(), "End sending email: success");
                return true;
            }
            catch (Exception ex)
            {
                Log.Info(this.GetType(), "End sending email: failure");
                Log.Error(this.GetType(), ex);
                return false;
            }
        }
    }
}
