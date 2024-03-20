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
   public class prcgetdatosusuario : GXProcedure
   {
      public prcgetdatosusuario( )
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

      public prcgetdatosusuario( IGxContext context )
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

      public void execute( string aP0_UsuarioSistemaId ,
                           out string aP1_UsuarioSistemaIdentidad ,
                           out string aP2_UsuarioSistemaNombre ,
                           out string aP3_UsuarioSistemaGerencia ,
                           out string aP4_UsuarioSistemaDepartamento ,
                           out string aP5_UsuarioSistemaEmail ,
                           out int aP6_UsuarioSistemaTelefono )
      {
         this.AV8UsuarioSistemaId = aP0_UsuarioSistemaId;
         this.AV9UsuarioSistemaIdentidad = "" ;
         this.AV10UsuarioSistemaNombre = "" ;
         this.AV15UsuarioSistemaGerencia = "" ;
         this.AV13UsuarioSistemaDepartamento = "" ;
         this.AV14UsuarioSistemaEmail = "" ;
         this.AV12UsuarioSistemaTelefono = 0 ;
         initialize();
         executePrivate();
         aP1_UsuarioSistemaIdentidad=this.AV9UsuarioSistemaIdentidad;
         aP2_UsuarioSistemaNombre=this.AV10UsuarioSistemaNombre;
         aP3_UsuarioSistemaGerencia=this.AV15UsuarioSistemaGerencia;
         aP4_UsuarioSistemaDepartamento=this.AV13UsuarioSistemaDepartamento;
         aP5_UsuarioSistemaEmail=this.AV14UsuarioSistemaEmail;
         aP6_UsuarioSistemaTelefono=this.AV12UsuarioSistemaTelefono;
      }

      public int executeUdp( string aP0_UsuarioSistemaId ,
                             out string aP1_UsuarioSistemaIdentidad ,
                             out string aP2_UsuarioSistemaNombre ,
                             out string aP3_UsuarioSistemaGerencia ,
                             out string aP4_UsuarioSistemaDepartamento ,
                             out string aP5_UsuarioSistemaEmail )
      {
         execute(aP0_UsuarioSistemaId, out aP1_UsuarioSistemaIdentidad, out aP2_UsuarioSistemaNombre, out aP3_UsuarioSistemaGerencia, out aP4_UsuarioSistemaDepartamento, out aP5_UsuarioSistemaEmail, out aP6_UsuarioSistemaTelefono);
         return AV12UsuarioSistemaTelefono ;
      }

      public void executeSubmit( string aP0_UsuarioSistemaId ,
                                 out string aP1_UsuarioSistemaIdentidad ,
                                 out string aP2_UsuarioSistemaNombre ,
                                 out string aP3_UsuarioSistemaGerencia ,
                                 out string aP4_UsuarioSistemaDepartamento ,
                                 out string aP5_UsuarioSistemaEmail ,
                                 out int aP6_UsuarioSistemaTelefono )
      {
         prcgetdatosusuario objprcgetdatosusuario;
         objprcgetdatosusuario = new prcgetdatosusuario();
         objprcgetdatosusuario.AV8UsuarioSistemaId = aP0_UsuarioSistemaId;
         objprcgetdatosusuario.AV9UsuarioSistemaIdentidad = "" ;
         objprcgetdatosusuario.AV10UsuarioSistemaNombre = "" ;
         objprcgetdatosusuario.AV15UsuarioSistemaGerencia = "" ;
         objprcgetdatosusuario.AV13UsuarioSistemaDepartamento = "" ;
         objprcgetdatosusuario.AV14UsuarioSistemaEmail = "" ;
         objprcgetdatosusuario.AV12UsuarioSistemaTelefono = 0 ;
         objprcgetdatosusuario.context.SetSubmitInitialConfig(context);
         objprcgetdatosusuario.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprcgetdatosusuario);
         aP1_UsuarioSistemaIdentidad=this.AV9UsuarioSistemaIdentidad;
         aP2_UsuarioSistemaNombre=this.AV10UsuarioSistemaNombre;
         aP3_UsuarioSistemaGerencia=this.AV15UsuarioSistemaGerencia;
         aP4_UsuarioSistemaDepartamento=this.AV13UsuarioSistemaDepartamento;
         aP5_UsuarioSistemaEmail=this.AV14UsuarioSistemaEmail;
         aP6_UsuarioSistemaTelefono=this.AV12UsuarioSistemaTelefono;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcgetdatosusuario)stateInfo).executePrivate();
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
         /* Using cursor P005E2 */
         pr_default.execute(0, new Object[] {AV8UsuarioSistemaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A99UsuarioSistemaId = P005E2_A99UsuarioSistemaId[0];
            A101UsuarioSistemaIdentidad = P005E2_A101UsuarioSistemaIdentidad[0];
            A100UsuarioSistemaNombre = P005E2_A100UsuarioSistemaNombre[0];
            A263UsuarioSistemaGerencia = P005E2_A263UsuarioSistemaGerencia[0];
            n263UsuarioSistemaGerencia = P005E2_n263UsuarioSistemaGerencia[0];
            A257UsuarioSistemaDepartamento = P005E2_A257UsuarioSistemaDepartamento[0];
            n257UsuarioSistemaDepartamento = P005E2_n257UsuarioSistemaDepartamento[0];
            A265UsuarioSistemaEmail = P005E2_A265UsuarioSistemaEmail[0];
            A264UsuarioSistemaTelefono = P005E2_A264UsuarioSistemaTelefono[0];
            AV9UsuarioSistemaIdentidad = A101UsuarioSistemaIdentidad;
            AV10UsuarioSistemaNombre = A100UsuarioSistemaNombre;
            AV15UsuarioSistemaGerencia = A263UsuarioSistemaGerencia;
            AV13UsuarioSistemaDepartamento = A257UsuarioSistemaDepartamento;
            AV14UsuarioSistemaEmail = A265UsuarioSistemaEmail;
            AV12UsuarioSistemaTelefono = A264UsuarioSistemaTelefono;
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV9UsuarioSistemaIdentidad = "";
         AV10UsuarioSistemaNombre = "";
         AV15UsuarioSistemaGerencia = "";
         AV13UsuarioSistemaDepartamento = "";
         AV14UsuarioSistemaEmail = "";
         scmdbuf = "";
         P005E2_A99UsuarioSistemaId = new string[] {""} ;
         P005E2_A101UsuarioSistemaIdentidad = new string[] {""} ;
         P005E2_A100UsuarioSistemaNombre = new string[] {""} ;
         P005E2_A263UsuarioSistemaGerencia = new string[] {""} ;
         P005E2_n263UsuarioSistemaGerencia = new bool[] {false} ;
         P005E2_A257UsuarioSistemaDepartamento = new string[] {""} ;
         P005E2_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         P005E2_A265UsuarioSistemaEmail = new string[] {""} ;
         P005E2_A264UsuarioSistemaTelefono = new int[1] ;
         A99UsuarioSistemaId = "";
         A101UsuarioSistemaIdentidad = "";
         A100UsuarioSistemaNombre = "";
         A263UsuarioSistemaGerencia = "";
         A257UsuarioSistemaDepartamento = "";
         A265UsuarioSistemaEmail = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prcgetdatosusuario__default(),
            new Object[][] {
                new Object[] {
               P005E2_A99UsuarioSistemaId, P005E2_A101UsuarioSistemaIdentidad, P005E2_A100UsuarioSistemaNombre, P005E2_A263UsuarioSistemaGerencia, P005E2_n263UsuarioSistemaGerencia, P005E2_A257UsuarioSistemaDepartamento, P005E2_n257UsuarioSistemaDepartamento, P005E2_A265UsuarioSistemaEmail, P005E2_A264UsuarioSistemaTelefono
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12UsuarioSistemaTelefono ;
      private int A264UsuarioSistemaTelefono ;
      private string scmdbuf ;
      private bool n263UsuarioSistemaGerencia ;
      private bool n257UsuarioSistemaDepartamento ;
      private string AV8UsuarioSistemaId ;
      private string AV9UsuarioSistemaIdentidad ;
      private string AV10UsuarioSistemaNombre ;
      private string AV15UsuarioSistemaGerencia ;
      private string AV13UsuarioSistemaDepartamento ;
      private string AV14UsuarioSistemaEmail ;
      private string A99UsuarioSistemaId ;
      private string A101UsuarioSistemaIdentidad ;
      private string A100UsuarioSistemaNombre ;
      private string A263UsuarioSistemaGerencia ;
      private string A257UsuarioSistemaDepartamento ;
      private string A265UsuarioSistemaEmail ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005E2_A99UsuarioSistemaId ;
      private string[] P005E2_A101UsuarioSistemaIdentidad ;
      private string[] P005E2_A100UsuarioSistemaNombre ;
      private string[] P005E2_A263UsuarioSistemaGerencia ;
      private bool[] P005E2_n263UsuarioSistemaGerencia ;
      private string[] P005E2_A257UsuarioSistemaDepartamento ;
      private bool[] P005E2_n257UsuarioSistemaDepartamento ;
      private string[] P005E2_A265UsuarioSistemaEmail ;
      private int[] P005E2_A264UsuarioSistemaTelefono ;
      private string aP1_UsuarioSistemaIdentidad ;
      private string aP2_UsuarioSistemaNombre ;
      private string aP3_UsuarioSistemaGerencia ;
      private string aP4_UsuarioSistemaDepartamento ;
      private string aP5_UsuarioSistemaEmail ;
      private int aP6_UsuarioSistemaTelefono ;
   }

   public class prcgetdatosusuario__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005E2;
          prmP005E2 = new Object[] {
          new ParDef("@AV8UsuarioSistemaId",GXType.NVarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P005E2", "SELECT [UsuarioSistemaId], [UsuarioSistemaIdentidad], [UsuarioSistemaNombre], [UsuarioSistemaGerencia], [UsuarioSistemaDepartamento], [UsuarioSistemaEmail], [UsuarioSistemaTelefono] FROM [UsuarioSistema] WHERE [UsuarioSistemaId] = @AV8UsuarioSistemaId ORDER BY [UsuarioSistemaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005E2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
