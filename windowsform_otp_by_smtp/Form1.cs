using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace windowsform_otp_by_smtp
{
    public partial class OTPVerification : Form
    {
        String randomcode;                                               //VARIABLE FOR RANDOM OTP GENERATOR
        public OTPVerification()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string from,to,pass,messagebox;                             //VARIABLE FOR SETTING INFORMATION

            Random otp =new Random();                                      //RANDOM CLASS FOR OTP NEXT METHOD IN RANDON CLASS
            randomcode=(otp.Next(9999)).ToString();

            from = "kishore2000.kr@gmail.com";                             //SETTING DETAILS FOR VARIABLES
            to= (textBox1.Text).ToString();
            pass = "rkwi naxv ochc csju";
            messagebox = "your otp is:" + randomcode;

            MailMessage msg = new MailMessage();                          //MAILMESSAGE CLASS TO ORGANIZE MAIL
            msg.To.Add(to);
            msg.From=new MailAddress(from);
            msg.Body = messagebox;
            msg.Subject = "otp verification";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");                          //SMTP CLASS FOR SENDING MAIL AUTOMATICALLY
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try                                                         //FOR INFORMATION ABOUT MESSAGE DELIVERY
            {
                smtp.Send(msg);
                MessageBox.Show("otp sended successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (randomcode == (textBox2.Text).ToString())                   //CHECK OTP NUMBER AND ENTERED OTP NUMBER IS EQUAL
            {
                MessageBox.Show("otp verified");
            }
            else
            {
                MessageBox.Show("OTP incorrect");
            }
        }

    }
}
