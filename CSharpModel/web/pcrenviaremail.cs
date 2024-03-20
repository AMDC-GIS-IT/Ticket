using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pcrenviaremail : GXProcedure
   {
      public pcrenviaremail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public pcrenviaremail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         pcrenviaremail objpcrenviaremail;
         objpcrenviaremail = new pcrenviaremail();
         objpcrenviaremail.context.SetSubmitInitialConfig(context);
         objpcrenviaremail.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrenviaremail);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrenviaremail)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV51MailRecipient.From.Address = "barahona.sybs.saira@gmail.com";
         AV51MailRecipient.From.Name = "Saira Barahona";
         AV51MailRecipient.Subject = "Encuesta Satisfacción";
         AV51MailRecipient.Text = "Encuesta Satisfacción";
         AV51MailRecipient.HTMLText = "<b> ¡Encuesta Satisfacción! </b>";
         AV48smtp.Host = "smtp.gmail.com";
         AV48smtp.Sender.Address = "barahona.sybs.saira@gmail.com";
         AV48smtp.Sender.Name = "Saira Barahona";
         AV48smtp.ErrDisplay = 1;
         AV48smtp.Login();
         AV47Mail.Clear();
         AV47Mail.To.New("Saira Barahona", "barahona.sybs.saira@gmail.com") ;
         AV47Mail.Subject = "Prueba Encuesta";
         AV47Mail.Text = "Encuesta Satisfacción";
         AV48smtp.Send(AV47Mail);
         AV48smtp.Logout();
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV51MailRecipient = new GeneXus.Mail.GXMailMessage();
         AV48smtp = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV47Mail = new GeneXus.Mail.GXMailMessage();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GeneXus.Mail.GXMailMessage AV51MailRecipient ;
      private GeneXus.Mail.GXMailMessage AV47Mail ;
      private GeneXus.Mail.GXSMTPSession AV48smtp ;
   }

}
