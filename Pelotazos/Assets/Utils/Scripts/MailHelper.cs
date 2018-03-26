using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class MailHelper
{
    Logger log;
    MailMessage mailMessage = new MailMessage();
    SmtpClient smtpServer;

    public MailHelper()
    {
    
        log = new Logger();
    }


    public void SetBody(string sbody, bool html = false)
    {
        mailMessage.Body = sbody;
        mailMessage.IsBodyHtml = html;
    }

    public void SetTo(string sMailTo)
    {
        mailMessage.To.Add(sMailTo);
    }

    public void SetSubject(string sSubject)
    {
        mailMessage.Subject = sSubject;
    }

    public void SetAttachment(string PathFile)
    {
        Attachment data = new Attachment(PathFile, MediaTypeNames.Application.Octet);
        // Add time stamp information for the file.
        ContentDisposition disposition = data.ContentDisposition;
        disposition.CreationDate = File.GetCreationTime(PathFile);
        disposition.ModificationDate = File.GetLastWriteTime(PathFile);
        disposition.ReadDate = File.GetLastAccessTime(PathFile);
        mailMessage.Attachments.Add(data);
        data.Dispose();
    }

    public void Send(string sTo, string sBody, string sSubject, string sPathFile)
    {
        try
        {
            SetTo(sTo);
            SetSubject(sSubject);
            SetBody(sBody);
            SetAttachment(sPathFile);
			smtpServer.Port = 587;
			smtpServer.UseDefaultCredentials = false;
			smtpServer.EnableSsl = true;
			ServicePointManager.ServerCertificateValidationCallback =
				delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
				return true;
			};
            smtpServer.Send(mailMessage);
        }
        catch (Exception e)
        {            
            log.Log(e.Message + " " + e.StackTrace, PathHelper.Log);
        }
    }

    public void Send()
    {
        try
        {
            smtpServer.Send(mailMessage);
        }
        catch (Exception e)
        {         
            log.Log(e.Message, PathHelper.Log);
        }
    }
}
