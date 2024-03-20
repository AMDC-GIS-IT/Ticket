using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pcrregistrarsolicitudusuario : GXProcedure
   {
      public pcrregistrarsolicitudusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public pcrregistrarsolicitudusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_UsuarioNombre ,
                           string aP1_UsuarioGerencia ,
                           string aP2_UsuarioDepartamento ,
                           string aP3_UsuarioRequerimiento ,
                           string aP4_UsuarioEmail ,
                           int aP5_UsuarioTelefono )
      {
         this.AV8UsuarioNombre = aP0_UsuarioNombre;
         this.AV9UsuarioGerencia = aP1_UsuarioGerencia;
         this.AV10UsuarioDepartamento = aP2_UsuarioDepartamento;
         this.AV11UsuarioRequerimiento = aP3_UsuarioRequerimiento;
         this.AV12UsuarioEmail = aP4_UsuarioEmail;
         this.AV13UsuarioTelefono = aP5_UsuarioTelefono;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_UsuarioNombre ,
                                 string aP1_UsuarioGerencia ,
                                 string aP2_UsuarioDepartamento ,
                                 string aP3_UsuarioRequerimiento ,
                                 string aP4_UsuarioEmail ,
                                 int aP5_UsuarioTelefono )
      {
         pcrregistrarsolicitudusuario objpcrregistrarsolicitudusuario;
         objpcrregistrarsolicitudusuario = new pcrregistrarsolicitudusuario();
         objpcrregistrarsolicitudusuario.AV8UsuarioNombre = aP0_UsuarioNombre;
         objpcrregistrarsolicitudusuario.AV9UsuarioGerencia = aP1_UsuarioGerencia;
         objpcrregistrarsolicitudusuario.AV10UsuarioDepartamento = aP2_UsuarioDepartamento;
         objpcrregistrarsolicitudusuario.AV11UsuarioRequerimiento = aP3_UsuarioRequerimiento;
         objpcrregistrarsolicitudusuario.AV12UsuarioEmail = aP4_UsuarioEmail;
         objpcrregistrarsolicitudusuario.AV13UsuarioTelefono = aP5_UsuarioTelefono;
         objpcrregistrarsolicitudusuario.context.SetSubmitInitialConfig(context);
         objpcrregistrarsolicitudusuario.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrregistrarsolicitudusuario);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrregistrarsolicitudusuario)stateInfo).executePrivate();
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
         /*
            INSERT RECORD ON TABLE Usuario

         */
         A93UsuarioNombre = AV8UsuarioNombre;
         A90UsuarioFecha = DateTimeUtil.Today( context);
         A92UsuarioHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A91UsuarioGerencia = AV9UsuarioGerencia;
         A88UsuarioDepartamento = AV10UsuarioDepartamento;
         A94UsuarioRequerimiento = AV11UsuarioRequerimiento;
         A89UsuarioEmail = AV12UsuarioEmail;
         A95UsuarioTelefono = AV13UsuarioTelefono;
         A189EstadoTicketUsuarioId = 1;
         A191UsuarioSistema = AV14WebSession.Get("UsuarioConectado");
         /* Using cursor P005R2 */
         pr_default.execute(0, new Object[] {A93UsuarioNombre, A90UsuarioFecha, A92UsuarioHora, A91UsuarioGerencia, A88UsuarioDepartamento, A94UsuarioRequerimiento, A89UsuarioEmail, A95UsuarioTelefono, A189EstadoTicketUsuarioId, A191UsuarioSistema});
         A15UsuarioId = P005R2_A15UsuarioId[0];
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("Usuario");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pcrregistrarsolicitudusuario",pr_default);
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
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A94UsuarioRequerimiento = "";
         A89UsuarioEmail = "";
         A191UsuarioSistema = "";
         AV14WebSession = context.GetSession();
         P005R2_A15UsuarioId = new short[1] ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrregistrarsolicitudusuario__default(),
            new Object[][] {
                new Object[] {
               P005R2_A15UsuarioId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A189EstadoTicketUsuarioId ;
      private short A15UsuarioId ;
      private int AV13UsuarioTelefono ;
      private int GX_INS10 ;
      private int A95UsuarioTelefono ;
      private string Gx_emsg ;
      private DateTime A92UsuarioHora ;
      private DateTime A90UsuarioFecha ;
      private string AV8UsuarioNombre ;
      private string AV9UsuarioGerencia ;
      private string AV10UsuarioDepartamento ;
      private string AV11UsuarioRequerimiento ;
      private string AV12UsuarioEmail ;
      private string A93UsuarioNombre ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A94UsuarioRequerimiento ;
      private string A89UsuarioEmail ;
      private string A191UsuarioSistema ;
      private IGxSession AV14WebSession ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005R2_A15UsuarioId ;
   }

   public class pcrregistrarsolicitudusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005R2;
          prmP005R2 = new Object[] {
          new ParDef("@UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@UsuarioFecha",GXType.Date,8,0) ,
          new ParDef("@UsuarioHora",GXType.DateTime,0,5) ,
          new ParDef("@UsuarioGerencia",GXType.NVarChar,300,0) ,
          new ParDef("@UsuarioDepartamento",GXType.NVarChar,300,0) ,
          new ParDef("@UsuarioRequerimiento",GXType.NVarChar,300,0) ,
          new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@UsuarioTelefono",GXType.Int32,9,0) ,
          new ParDef("@EstadoTicketUsuarioId",GXType.Int16,4,0) ,
          new ParDef("@UsuarioSistema",GXType.NVarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P005R2", "INSERT INTO [Usuario]([UsuarioNombre], [UsuarioFecha], [UsuarioHora], [UsuarioGerencia], [UsuarioDepartamento], [UsuarioRequerimiento], [UsuarioEmail], [UsuarioTelefono], [EstadoTicketUsuarioId], [UsuarioSistema], [UsuarioFechaHora]) VALUES(@UsuarioNombre, @UsuarioFecha, @UsuarioHora, @UsuarioGerencia, @UsuarioDepartamento, @UsuarioRequerimiento, @UsuarioEmail, @UsuarioTelefono, @EstadoTicketUsuarioId, @UsuarioSistema, convert( DATETIME, '17530101', 112 )); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP005R2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
