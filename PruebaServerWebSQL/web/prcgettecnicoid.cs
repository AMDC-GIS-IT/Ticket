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
   public class prcgettecnicoid : GXProcedure
   {
      public prcgettecnicoid( )
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

      public prcgettecnicoid( IGxContext context )
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

      public void execute( string aP0_ResponsableUsuario ,
                           out short aP1_ResponsableId ,
                           out string aP2_ResponsableIdentidad ,
                           out string aP3_ResponsableNombre ,
                           out string aP4_ResponsableEmail ,
                           out string aP5_ResponsableCargo )
      {
         this.AV11ResponsableUsuario = aP0_ResponsableUsuario;
         this.AV8ResponsableId = 0 ;
         this.AV9ResponsableIdentidad = "" ;
         this.AV10ResponsableNombre = "" ;
         this.AV12ResponsableEmail = "" ;
         this.AV13ResponsableCargo = "" ;
         initialize();
         executePrivate();
         aP1_ResponsableId=this.AV8ResponsableId;
         aP2_ResponsableIdentidad=this.AV9ResponsableIdentidad;
         aP3_ResponsableNombre=this.AV10ResponsableNombre;
         aP4_ResponsableEmail=this.AV12ResponsableEmail;
         aP5_ResponsableCargo=this.AV13ResponsableCargo;
      }

      public string executeUdp( string aP0_ResponsableUsuario ,
                                out short aP1_ResponsableId ,
                                out string aP2_ResponsableIdentidad ,
                                out string aP3_ResponsableNombre ,
                                out string aP4_ResponsableEmail )
      {
         execute(aP0_ResponsableUsuario, out aP1_ResponsableId, out aP2_ResponsableIdentidad, out aP3_ResponsableNombre, out aP4_ResponsableEmail, out aP5_ResponsableCargo);
         return AV13ResponsableCargo ;
      }

      public void executeSubmit( string aP0_ResponsableUsuario ,
                                 out short aP1_ResponsableId ,
                                 out string aP2_ResponsableIdentidad ,
                                 out string aP3_ResponsableNombre ,
                                 out string aP4_ResponsableEmail ,
                                 out string aP5_ResponsableCargo )
      {
         prcgettecnicoid objprcgettecnicoid;
         objprcgettecnicoid = new prcgettecnicoid();
         objprcgettecnicoid.AV11ResponsableUsuario = aP0_ResponsableUsuario;
         objprcgettecnicoid.AV8ResponsableId = 0 ;
         objprcgettecnicoid.AV9ResponsableIdentidad = "" ;
         objprcgettecnicoid.AV10ResponsableNombre = "" ;
         objprcgettecnicoid.AV12ResponsableEmail = "" ;
         objprcgettecnicoid.AV13ResponsableCargo = "" ;
         objprcgettecnicoid.context.SetSubmitInitialConfig(context);
         objprcgettecnicoid.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprcgettecnicoid);
         aP1_ResponsableId=this.AV8ResponsableId;
         aP2_ResponsableIdentidad=this.AV9ResponsableIdentidad;
         aP3_ResponsableNombre=this.AV10ResponsableNombre;
         aP4_ResponsableEmail=this.AV12ResponsableEmail;
         aP5_ResponsableCargo=this.AV13ResponsableCargo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcgettecnicoid)stateInfo).executePrivate();
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
         /* Using cursor P005H2 */
         pr_default.execute(0, new Object[] {AV11ResponsableUsuario});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A96ResponsableUsuario = P005H2_A96ResponsableUsuario[0];
            A6ResponsableId = P005H2_A6ResponsableId[0];
            A29ResponsableIdentidad = P005H2_A29ResponsableIdentidad[0];
            A30ResponsableNombre = P005H2_A30ResponsableNombre[0];
            A28ResponsableEmail = P005H2_A28ResponsableEmail[0];
            A27ResponsableCargo = P005H2_A27ResponsableCargo[0];
            AV8ResponsableId = A6ResponsableId;
            AV9ResponsableIdentidad = A29ResponsableIdentidad;
            AV10ResponsableNombre = A30ResponsableNombre;
            AV12ResponsableEmail = A28ResponsableEmail;
            AV13ResponsableCargo = A27ResponsableCargo;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV9ResponsableIdentidad = "";
         AV10ResponsableNombre = "";
         AV12ResponsableEmail = "";
         AV13ResponsableCargo = "";
         scmdbuf = "";
         P005H2_A96ResponsableUsuario = new string[] {""} ;
         P005H2_A6ResponsableId = new short[1] ;
         P005H2_A29ResponsableIdentidad = new string[] {""} ;
         P005H2_A30ResponsableNombre = new string[] {""} ;
         P005H2_A28ResponsableEmail = new string[] {""} ;
         P005H2_A27ResponsableCargo = new string[] {""} ;
         A96ResponsableUsuario = "";
         A29ResponsableIdentidad = "";
         A30ResponsableNombre = "";
         A28ResponsableEmail = "";
         A27ResponsableCargo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prcgettecnicoid__default(),
            new Object[][] {
                new Object[] {
               P005H2_A96ResponsableUsuario, P005H2_A6ResponsableId, P005H2_A29ResponsableIdentidad, P005H2_A30ResponsableNombre, P005H2_A28ResponsableEmail, P005H2_A27ResponsableCargo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8ResponsableId ;
      private short A6ResponsableId ;
      private string scmdbuf ;
      private string AV11ResponsableUsuario ;
      private string AV9ResponsableIdentidad ;
      private string AV10ResponsableNombre ;
      private string AV12ResponsableEmail ;
      private string AV13ResponsableCargo ;
      private string A96ResponsableUsuario ;
      private string A29ResponsableIdentidad ;
      private string A30ResponsableNombre ;
      private string A28ResponsableEmail ;
      private string A27ResponsableCargo ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005H2_A96ResponsableUsuario ;
      private short[] P005H2_A6ResponsableId ;
      private string[] P005H2_A29ResponsableIdentidad ;
      private string[] P005H2_A30ResponsableNombre ;
      private string[] P005H2_A28ResponsableEmail ;
      private string[] P005H2_A27ResponsableCargo ;
      private short aP1_ResponsableId ;
      private string aP2_ResponsableIdentidad ;
      private string aP3_ResponsableNombre ;
      private string aP4_ResponsableEmail ;
      private string aP5_ResponsableCargo ;
   }

   public class prcgettecnicoid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005H2;
          prmP005H2 = new Object[] {
          new ParDef("@AV11ResponsableUsuario",GXType.NVarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P005H2", "SELECT [ResponsableUsuario], [ResponsableId], [ResponsableIdentidad], [ResponsableNombre], [ResponsableEmail], [ResponsableCargo] FROM [Responsable] WHERE [ResponsableUsuario] = @AV11ResponsableUsuario ORDER BY [ResponsableId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005H2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
