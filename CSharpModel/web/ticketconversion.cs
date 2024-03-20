using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class ticketconversion : GXProcedure
   {
      public ticketconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public ticketconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
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
         ticketconversion objticketconversion;
         objticketconversion = new ticketconversion();
         objticketconversion.context.SetSubmitInitialConfig(context);
         objticketconversion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objticketconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ticketconversion)stateInfo).executePrivate();
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
         cmdBuffer=" SET IDENTITY_INSERT [GXA0007] ON "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor TICKETCONV2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5EstadoTicketId = TICKETCONV2_A5EstadoTicketId[0];
            A57TicketOtros = TICKETCONV2_A57TicketOtros[0];
            A52TicketInstalarDataShow = TICKETCONV2_A52TicketInstalarDataShow[0];
            A41TicketApoyoUsuario = TICKETCONV2_A41TicketApoyoUsuario[0];
            A87TicketUps = TICKETCONV2_A87TicketUps[0];
            A58TicketPerifericos = TICKETCONV2_A58TicketPerifericos[0];
            A43TicketDiscoDuroExterno = TICKETCONV2_A43TicketDiscoDuroExterno[0];
            A51TicketIngenieria = TICKETCONV2_A51TicketIngenieria[0];
            A44TicketDisenio = TICKETCONV2_A44TicketDisenio[0];
            A40TicketAplicacion = TICKETCONV2_A40TicketAplicacion[0];
            A39TicketAntivirus = TICKETCONV2_A39TicketAntivirus[0];
            A56TicketOffice = TICKETCONV2_A56TicketOffice[0];
            A60TicketSistemaOperativo = TICKETCONV2_A60TicketSistemaOperativo[0];
            A59TicketRouter = TICKETCONV2_A59TicketRouter[0];
            A45TicketEscaner = TICKETCONV2_A45TicketEscaner[0];
            A50TicketImpresora = TICKETCONV2_A50TicketImpresora[0];
            A55TicketMonitor = TICKETCONV2_A55TicketMonitor[0];
            A42TicketDesktop = TICKETCONV2_A42TicketDesktop[0];
            A53TicketLaptop = TICKETCONV2_A53TicketLaptop[0];
            A54TicketLastId = TICKETCONV2_A54TicketLastId[0];
            A15UsuarioId = TICKETCONV2_A15UsuarioId[0];
            A48TicketHora = TICKETCONV2_A48TicketHora[0];
            A46TicketFecha = TICKETCONV2_A46TicketFecha[0];
            A14TicketId = TICKETCONV2_A14TicketId[0];
            A5EstadoTicketId = TICKETCONV2_A5EstadoTicketId[0];
            /*
               INSERT RECORD ON TABLE GXA0007

            */
            AV2TicketId = A14TicketId;
            AV3TicketFecha = A46TicketFecha;
            AV4TicketHora = A48TicketHora;
            AV5UsuarioId = A15UsuarioId;
            AV6TicketLastId = A54TicketLastId;
            AV7TicketLaptop = A53TicketLaptop;
            AV8TicketDesktop = A42TicketDesktop;
            AV9TicketMonitor = A55TicketMonitor;
            AV10TicketImpresora = A50TicketImpresora;
            AV11TicketEscaner = A45TicketEscaner;
            AV12TicketRouter = A59TicketRouter;
            AV13TicketSistemaOperativo = A60TicketSistemaOperativo;
            AV14TicketOffice = A56TicketOffice;
            AV15TicketAntivirus = A39TicketAntivirus;
            AV16TicketAplicacion = A40TicketAplicacion;
            AV17TicketDisenio = A44TicketDisenio;
            AV18TicketIngenieria = A51TicketIngenieria;
            AV19TicketDiscoDuroExterno = A43TicketDiscoDuroExterno;
            AV20TicketPerifericos = A58TicketPerifericos;
            AV21TicketUps = A87TicketUps;
            AV22TicketApoyoUsuario = A41TicketApoyoUsuario;
            AV23TicketInstalarDataShow = A52TicketInstalarDataShow;
            AV24TicketOtros = A57TicketOtros;
            if ( TICKETCONV2_n5EstadoTicketId[0] )
            {
               AV25EstadoTicketTicketId = 0;
            }
            else
            {
               AV25EstadoTicketTicketId = A5EstadoTicketId;
            }
            /* Using cursor TICKETCONV3 */
            pr_default.execute(1, new Object[] {AV2TicketId, AV3TicketFecha, AV4TicketHora, AV5UsuarioId, AV6TicketLastId, AV7TicketLaptop, AV8TicketDesktop, AV9TicketMonitor, AV10TicketImpresora, AV11TicketEscaner, AV12TicketRouter, AV13TicketSistemaOperativo, AV14TicketOffice, AV15TicketAntivirus, AV16TicketAplicacion, AV17TicketDisenio, AV18TicketIngenieria, AV19TicketDiscoDuroExterno, AV20TicketPerifericos, AV21TicketUps, AV22TicketApoyoUsuario, AV23TicketInstalarDataShow, AV24TicketOtros, AV25EstadoTicketTicketId});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("GXA0007");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
         cmdBuffer=" SET IDENTITY_INSERT [GXA0007] OFF "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
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
         cmdBuffer = "";
         scmdbuf = "";
         TICKETCONV2_A5EstadoTicketId = new short[1] ;
         TICKETCONV2_A57TicketOtros = new bool[] {false} ;
         TICKETCONV2_A52TicketInstalarDataShow = new bool[] {false} ;
         TICKETCONV2_A41TicketApoyoUsuario = new bool[] {false} ;
         TICKETCONV2_A87TicketUps = new bool[] {false} ;
         TICKETCONV2_A58TicketPerifericos = new bool[] {false} ;
         TICKETCONV2_A43TicketDiscoDuroExterno = new bool[] {false} ;
         TICKETCONV2_A51TicketIngenieria = new bool[] {false} ;
         TICKETCONV2_A44TicketDisenio = new bool[] {false} ;
         TICKETCONV2_A40TicketAplicacion = new bool[] {false} ;
         TICKETCONV2_A39TicketAntivirus = new bool[] {false} ;
         TICKETCONV2_A56TicketOffice = new bool[] {false} ;
         TICKETCONV2_A60TicketSistemaOperativo = new bool[] {false} ;
         TICKETCONV2_A59TicketRouter = new bool[] {false} ;
         TICKETCONV2_A45TicketEscaner = new bool[] {false} ;
         TICKETCONV2_A50TicketImpresora = new bool[] {false} ;
         TICKETCONV2_A55TicketMonitor = new bool[] {false} ;
         TICKETCONV2_A42TicketDesktop = new bool[] {false} ;
         TICKETCONV2_A53TicketLaptop = new bool[] {false} ;
         TICKETCONV2_A54TicketLastId = new long[1] ;
         TICKETCONV2_A15UsuarioId = new short[1] ;
         TICKETCONV2_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         TICKETCONV2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         TICKETCONV2_A14TicketId = new long[1] ;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A46TicketFecha = DateTime.MinValue;
         AV3TicketFecha = DateTime.MinValue;
         AV4TicketHora = (DateTime)(DateTime.MinValue);
         TICKETCONV2_n5EstadoTicketId = new bool[] {false} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ticketconversion__default(),
            new Object[][] {
                new Object[] {
               TICKETCONV2_A5EstadoTicketId, TICKETCONV2_A57TicketOtros, TICKETCONV2_A52TicketInstalarDataShow, TICKETCONV2_A41TicketApoyoUsuario, TICKETCONV2_A87TicketUps, TICKETCONV2_A58TicketPerifericos, TICKETCONV2_A43TicketDiscoDuroExterno, TICKETCONV2_A51TicketIngenieria, TICKETCONV2_A44TicketDisenio, TICKETCONV2_A40TicketAplicacion,
               TICKETCONV2_A39TicketAntivirus, TICKETCONV2_A56TicketOffice, TICKETCONV2_A60TicketSistemaOperativo, TICKETCONV2_A59TicketRouter, TICKETCONV2_A45TicketEscaner, TICKETCONV2_A50TicketImpresora, TICKETCONV2_A55TicketMonitor, TICKETCONV2_A42TicketDesktop, TICKETCONV2_A53TicketLaptop, TICKETCONV2_A54TicketLastId,
               TICKETCONV2_A15UsuarioId, TICKETCONV2_A48TicketHora, TICKETCONV2_A46TicketFecha, TICKETCONV2_A14TicketId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A5EstadoTicketId ;
      private short A15UsuarioId ;
      private short AV5UsuarioId ;
      private short AV25EstadoTicketTicketId ;
      private int GIGXA0007 ;
      private long A54TicketLastId ;
      private long A14TicketId ;
      private long AV2TicketId ;
      private long AV6TicketLastId ;
      private string cmdBuffer ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A48TicketHora ;
      private DateTime AV4TicketHora ;
      private DateTime A46TicketFecha ;
      private DateTime AV3TicketFecha ;
      private bool A57TicketOtros ;
      private bool A52TicketInstalarDataShow ;
      private bool A41TicketApoyoUsuario ;
      private bool A87TicketUps ;
      private bool A58TicketPerifericos ;
      private bool A43TicketDiscoDuroExterno ;
      private bool A51TicketIngenieria ;
      private bool A44TicketDisenio ;
      private bool A40TicketAplicacion ;
      private bool A39TicketAntivirus ;
      private bool A56TicketOffice ;
      private bool A60TicketSistemaOperativo ;
      private bool A59TicketRouter ;
      private bool A45TicketEscaner ;
      private bool A50TicketImpresora ;
      private bool A55TicketMonitor ;
      private bool A42TicketDesktop ;
      private bool A53TicketLaptop ;
      private bool AV7TicketLaptop ;
      private bool AV8TicketDesktop ;
      private bool AV9TicketMonitor ;
      private bool AV10TicketImpresora ;
      private bool AV11TicketEscaner ;
      private bool AV12TicketRouter ;
      private bool AV13TicketSistemaOperativo ;
      private bool AV14TicketOffice ;
      private bool AV15TicketAntivirus ;
      private bool AV16TicketAplicacion ;
      private bool AV17TicketDisenio ;
      private bool AV18TicketIngenieria ;
      private bool AV19TicketDiscoDuroExterno ;
      private bool AV20TicketPerifericos ;
      private bool AV21TicketUps ;
      private bool AV22TicketApoyoUsuario ;
      private bool AV23TicketInstalarDataShow ;
      private bool AV24TicketOtros ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
      private short[] TICKETCONV2_A5EstadoTicketId ;
      private bool[] TICKETCONV2_A57TicketOtros ;
      private bool[] TICKETCONV2_A52TicketInstalarDataShow ;
      private bool[] TICKETCONV2_A41TicketApoyoUsuario ;
      private bool[] TICKETCONV2_A87TicketUps ;
      private bool[] TICKETCONV2_A58TicketPerifericos ;
      private bool[] TICKETCONV2_A43TicketDiscoDuroExterno ;
      private bool[] TICKETCONV2_A51TicketIngenieria ;
      private bool[] TICKETCONV2_A44TicketDisenio ;
      private bool[] TICKETCONV2_A40TicketAplicacion ;
      private bool[] TICKETCONV2_A39TicketAntivirus ;
      private bool[] TICKETCONV2_A56TicketOffice ;
      private bool[] TICKETCONV2_A60TicketSistemaOperativo ;
      private bool[] TICKETCONV2_A59TicketRouter ;
      private bool[] TICKETCONV2_A45TicketEscaner ;
      private bool[] TICKETCONV2_A50TicketImpresora ;
      private bool[] TICKETCONV2_A55TicketMonitor ;
      private bool[] TICKETCONV2_A42TicketDesktop ;
      private bool[] TICKETCONV2_A53TicketLaptop ;
      private long[] TICKETCONV2_A54TicketLastId ;
      private short[] TICKETCONV2_A15UsuarioId ;
      private DateTime[] TICKETCONV2_A48TicketHora ;
      private DateTime[] TICKETCONV2_A46TicketFecha ;
      private long[] TICKETCONV2_A14TicketId ;
      private bool[] TICKETCONV2_n5EstadoTicketId ;
   }

   public class ticketconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTICKETCONV2;
          prmTICKETCONV2 = new Object[] {
          };
          Object[] prmTICKETCONV3;
          prmTICKETCONV3 = new Object[] {
          new ParDef("@AV2TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV3TicketFecha",GXType.Date,8,0) ,
          new ParDef("@AV4TicketHora",GXType.DateTime,0,5) ,
          new ParDef("@AV5UsuarioId",GXType.Int16,4,0) ,
          new ParDef("@AV6TicketLastId",GXType.Decimal,10,0) ,
          new ParDef("@AV7TicketLaptop",GXType.Boolean,4,0) ,
          new ParDef("@AV8TicketDesktop",GXType.Boolean,4,0) ,
          new ParDef("@AV9TicketMonitor",GXType.Boolean,4,0) ,
          new ParDef("@AV10TicketImpresora",GXType.Boolean,4,0) ,
          new ParDef("@AV11TicketEscaner",GXType.Boolean,4,0) ,
          new ParDef("@AV12TicketRouter",GXType.Boolean,4,0) ,
          new ParDef("@AV13TicketSistemaOperativo",GXType.Boolean,4,0) ,
          new ParDef("@AV14TicketOffice",GXType.Boolean,4,0) ,
          new ParDef("@AV15TicketAntivirus",GXType.Boolean,4,0) ,
          new ParDef("@AV16TicketAplicacion",GXType.Boolean,4,0) ,
          new ParDef("@AV17TicketDisenio",GXType.Boolean,4,0) ,
          new ParDef("@AV18TicketIngenieria",GXType.Boolean,4,0) ,
          new ParDef("@AV19TicketDiscoDuroExterno",GXType.Boolean,4,0) ,
          new ParDef("@AV20TicketPerifericos",GXType.Boolean,4,0) ,
          new ParDef("@AV21TicketUps",GXType.Boolean,4,0) ,
          new ParDef("@AV22TicketApoyoUsuario",GXType.Boolean,4,0) ,
          new ParDef("@AV23TicketInstalarDataShow",GXType.Boolean,4,0) ,
          new ParDef("@AV24TicketOtros",GXType.Boolean,4,0) ,
          new ParDef("@AV25EstadoTicketTicketId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("TICKETCONV2", "SELECT T2.[EstadoTicketId], T1.[TicketOtros], T1.[TicketInstalarDataShow], T1.[TicketApoyoUsuario], T1.[TicketUps], T1.[TicketPerifericos], T1.[TicketDiscoDuroExterno], T1.[TicketIngenieria], T1.[TicketDisenio], T1.[TicketAplicacion], T1.[TicketAntivirus], T1.[TicketOffice], T1.[TicketSistemaOperativo], T1.[TicketRouter], T1.[TicketEscaner], T1.[TicketImpresora], T1.[TicketMonitor], T1.[TicketDesktop], T1.[TicketLaptop], T1.[TicketLastId], T1.[UsuarioId], T1.[TicketHora], T1.[TicketFecha], T1.[TicketId] FROM ([Ticket] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[UsuarioId]) ORDER BY T1.[TicketId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTICKETCONV2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TICKETCONV3", "INSERT INTO [GXA0007]([TicketId], [TicketFecha], [TicketHora], [UsuarioId], [TicketLastId], [TicketLaptop], [TicketDesktop], [TicketMonitor], [TicketImpresora], [TicketEscaner], [TicketRouter], [TicketSistemaOperativo], [TicketOffice], [TicketAntivirus], [TicketAplicacion], [TicketDisenio], [TicketIngenieria], [TicketDiscoDuroExterno], [TicketPerifericos], [TicketUps], [TicketApoyoUsuario], [TicketInstalarDataShow], [TicketOtros], [EstadoTicketTicketId]) VALUES(@AV2TicketId, @AV3TicketFecha, @AV4TicketHora, @AV5UsuarioId, @AV6TicketLastId, @AV7TicketLaptop, @AV8TicketDesktop, @AV9TicketMonitor, @AV10TicketImpresora, @AV11TicketEscaner, @AV12TicketRouter, @AV13TicketSistemaOperativo, @AV14TicketOffice, @AV15TicketAntivirus, @AV16TicketAplicacion, @AV17TicketDisenio, @AV18TicketIngenieria, @AV19TicketDiscoDuroExterno, @AV20TicketPerifericos, @AV21TicketUps, @AV22TicketApoyoUsuario, @AV23TicketInstalarDataShow, @AV24TicketOtros, @AV25EstadoTicketTicketId)", GxErrorMask.GX_NOMASK,prmTICKETCONV3)
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((bool[]) buf[10])[0] = rslt.getBool(11);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                ((bool[]) buf[13])[0] = rslt.getBool(14);
                ((bool[]) buf[14])[0] = rslt.getBool(15);
                ((bool[]) buf[15])[0] = rslt.getBool(16);
                ((bool[]) buf[16])[0] = rslt.getBool(17);
                ((bool[]) buf[17])[0] = rslt.getBool(18);
                ((bool[]) buf[18])[0] = rslt.getBool(19);
                ((long[]) buf[19])[0] = rslt.getLong(20);
                ((short[]) buf[20])[0] = rslt.getShort(21);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(23);
                ((long[]) buf[23])[0] = rslt.getLong(24);
                return;
       }
    }

 }

}
