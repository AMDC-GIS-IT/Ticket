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

      public void execute( string aP0_UsuarioNombre ,
                           string aP1_UsuarioGerencia ,
                           string aP2_UsuarioDepartamento ,
                           string aP3_String ,
                           string aP4_UsuarioEmail ,
                           int aP5_UsuarioTelefono ,
                           DateTime aP6_FechaHoraUsuario )
      {
         this.AV8UsuarioNombre = aP0_UsuarioNombre;
         this.AV9UsuarioGerencia = aP1_UsuarioGerencia;
         this.AV10UsuarioDepartamento = aP2_UsuarioDepartamento;
         this.AV17String = aP3_String;
         this.AV12UsuarioEmail = aP4_UsuarioEmail;
         this.AV13UsuarioTelefono = aP5_UsuarioTelefono;
         this.AV19FechaHoraUsuario = aP6_FechaHoraUsuario;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_UsuarioNombre ,
                                 string aP1_UsuarioGerencia ,
                                 string aP2_UsuarioDepartamento ,
                                 string aP3_String ,
                                 string aP4_UsuarioEmail ,
                                 int aP5_UsuarioTelefono ,
                                 DateTime aP6_FechaHoraUsuario )
      {
         pcrregistrarsolicitudusuario objpcrregistrarsolicitudusuario;
         objpcrregistrarsolicitudusuario = new pcrregistrarsolicitudusuario();
         objpcrregistrarsolicitudusuario.AV8UsuarioNombre = aP0_UsuarioNombre;
         objpcrregistrarsolicitudusuario.AV9UsuarioGerencia = aP1_UsuarioGerencia;
         objpcrregistrarsolicitudusuario.AV10UsuarioDepartamento = aP2_UsuarioDepartamento;
         objpcrregistrarsolicitudusuario.AV17String = aP3_String;
         objpcrregistrarsolicitudusuario.AV12UsuarioEmail = aP4_UsuarioEmail;
         objpcrregistrarsolicitudusuario.AV13UsuarioTelefono = aP5_UsuarioTelefono;
         objpcrregistrarsolicitudusuario.AV19FechaHoraUsuario = aP6_FechaHoraUsuario;
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
         AV16UserId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         AV18UsuarioFechaHora = DateTimeUtil.TAdd( AV19FechaHoraUsuario, 3600*(-6));
         AV21UsuarioFechaSistema = DateTimeUtil.Now( context);
         /*
            INSERT RECORD ON TABLE Usuario

         */
         /* Using cursor P005R3 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P005R3_A40000GXC1[0];
            n40000GXC1 = P005R3_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         AV15UsuarioId = (long)(A40000GXC1+1);
         A15UsuarioId = AV15UsuarioId;
         A93UsuarioNombre = AV8UsuarioNombre;
         A90UsuarioFecha = DateTimeUtil.ResetTime(context.localUtil.YMDHMSMToT( (short)(DateTimeUtil.Year( AV19FechaHoraUsuario)), (short)(DateTimeUtil.Month( AV19FechaHoraUsuario)), (short)(DateTimeUtil.Day( AV19FechaHoraUsuario)), 0, 0, 0, 0));
         A92UsuarioHora = DateTimeUtil.ResetDate(context.localUtil.YMDHMSMToT( 1900, 1, 1, (short)(DateTimeUtil.Hour( AV19FechaHoraUsuario)), (short)(DateTimeUtil.Minute( AV19FechaHoraUsuario)), (short)(DateTimeUtil.Second( AV19FechaHoraUsuario)), 0));
         A91UsuarioGerencia = AV9UsuarioGerencia;
         A88UsuarioDepartamento = AV10UsuarioDepartamento;
         A94UsuarioRequerimiento = AV17String;
         A89UsuarioEmail = AV12UsuarioEmail;
         A95UsuarioTelefono = AV13UsuarioTelefono;
         A189EstadoTicketUsuarioId = 1;
         A191UsuarioSistema = AV16UserId;
         A286UsuarioFechaHora = AV18UsuarioFechaHora;
         n286UsuarioFechaHora = false;
         A375UsuarioFechaSistema = DateTimeUtil.TAdd( AV21UsuarioFechaSistema, 3600*(-6));
         n375UsuarioFechaSistema = false;
         /* Using cursor P005R4 */
         pr_default.execute(1, new Object[] {A15UsuarioId, A93UsuarioNombre, A90UsuarioFecha, A92UsuarioHora, A91UsuarioGerencia, A88UsuarioDepartamento, A94UsuarioRequerimiento, A89UsuarioEmail, A95UsuarioTelefono, A189EstadoTicketUsuarioId, A191UsuarioSistema, n286UsuarioFechaHora, A286UsuarioFechaHora, n375UsuarioFechaSistema, A375UsuarioFechaSistema});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("Usuario");
         if ( (pr_default.getStatus(1) == 1) )
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
         pr_default.close(0);
      }

      public override void initialize( )
      {
         AV16UserId = "";
         AV18UsuarioFechaHora = (DateTime)(DateTime.MinValue);
         AV21UsuarioFechaSistema = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         P005R3_A40000GXC1 = new long[1] ;
         P005R3_n40000GXC1 = new bool[] {false} ;
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A94UsuarioRequerimiento = "";
         A89UsuarioEmail = "";
         A191UsuarioSistema = "";
         A286UsuarioFechaHora = (DateTime)(DateTime.MinValue);
         A375UsuarioFechaSistema = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcrregistrarsolicitudusuario__default(),
            new Object[][] {
                new Object[] {
               P005R3_A40000GXC1, P005R3_n40000GXC1
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A189EstadoTicketUsuarioId ;
      private int AV13UsuarioTelefono ;
      private int GX_INS10 ;
      private int A95UsuarioTelefono ;
      private long A40000GXC1 ;
      private long AV15UsuarioId ;
      private long A15UsuarioId ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime AV19FechaHoraUsuario ;
      private DateTime AV18UsuarioFechaHora ;
      private DateTime AV21UsuarioFechaSistema ;
      private DateTime A92UsuarioHora ;
      private DateTime A286UsuarioFechaHora ;
      private DateTime A375UsuarioFechaSistema ;
      private DateTime A90UsuarioFecha ;
      private bool n40000GXC1 ;
      private bool n286UsuarioFechaHora ;
      private bool n375UsuarioFechaSistema ;
      private string AV8UsuarioNombre ;
      private string AV9UsuarioGerencia ;
      private string AV10UsuarioDepartamento ;
      private string AV17String ;
      private string AV12UsuarioEmail ;
      private string AV16UserId ;
      private string A93UsuarioNombre ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A94UsuarioRequerimiento ;
      private string A89UsuarioEmail ;
      private string A191UsuarioSistema ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P005R3_A40000GXC1 ;
      private bool[] P005R3_n40000GXC1 ;
   }

   public class pcrregistrarsolicitudusuario__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005R3;
          prmP005R3 = new Object[] {
          };
          Object[] prmP005R4;
          prmP005R4 = new Object[] {
          new ParDef("@UsuarioId",GXType.Decimal,10,0) ,
          new ParDef("@UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@UsuarioFecha",GXType.Date,8,0) ,
          new ParDef("@UsuarioHora",GXType.DateTime,0,5) ,
          new ParDef("@UsuarioGerencia",GXType.NVarChar,300,0) ,
          new ParDef("@UsuarioDepartamento",GXType.NVarChar,300,0) ,
          new ParDef("@UsuarioRequerimiento",GXType.NVarChar,300,0) ,
          new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@UsuarioTelefono",GXType.Int32,9,0) ,
          new ParDef("@EstadoTicketUsuarioId",GXType.Int16,4,0) ,
          new ParDef("@UsuarioSistema",GXType.NVarChar,100,60) ,
          new ParDef("@UsuarioFechaHora",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@UsuarioFechaSistema",GXType.DateTime,10,8){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P005R3", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT MAX([UsuarioId]) AS GXC1 FROM [Usuario] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005R3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005R4", "INSERT INTO [Usuario]([UsuarioId], [UsuarioNombre], [UsuarioFecha], [UsuarioHora], [UsuarioGerencia], [UsuarioDepartamento], [UsuarioRequerimiento], [UsuarioEmail], [UsuarioTelefono], [EstadoTicketUsuarioId], [UsuarioSistema], [UsuarioFechaHora], [UsuarioFechaSistema]) VALUES(@UsuarioId, @UsuarioNombre, @UsuarioFecha, @UsuarioHora, @UsuarioGerencia, @UsuarioDepartamento, @UsuarioRequerimiento, @UsuarioEmail, @UsuarioTelefono, @EstadoTicketUsuarioId, @UsuarioSistema, @UsuarioFechaHora, @UsuarioFechaSistema)", GxErrorMask.GX_NOMASK,prmP005R4)
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
