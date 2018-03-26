using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(SceneController))]
public class UserFeedbakc : MonoBehaviour {
    /*En determinado momento leer los log 
	 * del dispositivo movil y comprobar 
	 * coneccion a internet por medio de 
	 * wifi y enviar log y devolucion del 
	 * usuario en caso de que deje alguna*/
	public string smtpClient = "smtp.gmail.com";
	public string sFrom = "Your Name or E-mail";
	public string to = "tiricanorbyariel@gmail.com";
	public string user = "tiricanorbyariel@gmail.com";
	public string password = "Tiricafjei20fjei20";
    public Button btnSend;
    public InputField inputName;
    public InputField inputSubject;
    public InputField inputBody;
    public Text textWait;
    
    private string sBody = "Body Message";
    private string sSubject = "User Feedback Pelotazos";
    private SceneController sceneController;
	private Logger logger;
	void Start () {
        textWait.enabled = false;
		logger = new Logger ();
        sceneController = GetComponent<SceneController>();
        btnSend.onClick.AddListener(ActionBtnSend);
        inputBody.text = sBody;
        inputSubject.text = sSubject;
        inputName.text = sFrom;
    }

   
    void ActionBtnSend()
    {
        textWait.enabled = true;

        if (!string.IsNullOrEmpty(inputName.text))
        {
            if (inputName.text.Contains("@"))
                sFrom = inputName.text;
            else
                sFrom = inputName.text.Trim().Split(' ')[0] + "@caca.com";
        }
        else
            sFrom = "NoCargoNada@caca.com";
        
        if (!string.IsNullOrEmpty(inputSubject.text))
            sSubject = inputSubject.text;

        if(!string.IsNullOrEmpty(inputBody.text))
            sBody = inputBody.text;
        
		StartCoroutine(SendMail());
    }
	void Update () {
           
	}

    private void GoMenu()
    {
        sceneController.GoMenu();
    }

	private IEnumerator SendMail()
	{	
		yield return new WaitForSeconds (0.0f);	
		string AttachmentName = PathHelper.Log;
        if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {			
			try
			{
				MailMessage mailMessage = new MailMessage();
				mailMessage.Subject = sSubject;
				mailMessage.Body = sBody;
				mailMessage.IsBodyHtml = true;
				mailMessage.From = new MailAddress(sFrom);
				mailMessage.To.Add(to);
				File.Copy(PathHelper.Log, PathHelper.Mail, true);

				if(File.Exists(PathHelper.Log))
				{
					Attachment file = null;
					file = new Attachment(PathHelper.Mail);
					mailMessage.Attachments.Add(file);
				}

				SmtpClient smtpServer = new SmtpClient(smtpClient);
				smtpServer.Port = 587;


				smtpServer.Credentials = new NetworkCredential(user, password) as ICredentialsByHost;
				smtpServer.EnableSsl = true;
				ServicePointManager.ServerCertificateValidationCallback =
					delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
					return true;
				};

				smtpServer.Send(mailMessage);
			}
			catch (Exception e)
			{  				
				logger.Log(e.Message + " " + e.StackTrace, PathHelper.Log);
			}

        }
        else
            PlayerPrefs.SetInt(KeyNames.SendUserFeedback, 1);

		Destroy (gameObject);
    }


}
