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
   public class prcgetusuarioid : GXProcedure
   {
      public prcgetusuarioid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public prcgetusuarioid( IGxContext context )
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

      public void execute( string aP0_NameUser ,
                           out short aP1_ResponsableId )
      {
         this.AV9NameUser = aP0_NameUser;
         this.AV8ResponsableId = 0 ;
         initialize();
         executePrivate();
         aP1_ResponsableId=this.AV8ResponsableId;
      }

      public short executeUdp( string aP0_NameUser )
      {
         execute(aP0_NameUser, out aP1_ResponsableId);
         return AV8ResponsableId ;
      }

      public void executeSubmit( string aP0_NameUser ,
                                 out short aP1_ResponsableId )
      {
         prcgetusuarioid objprcgetusuarioid;
         objprcgetusuarioid = new prcgetusuarioid();
         objprcgetusuarioid.AV9NameUser = aP0_NameUser;
         objprcgetusuarioid.AV8ResponsableId = 0 ;
         objprcgetusuarioid.context.SetSubmitInitialConfig(context);
         objprcgetusuarioid.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprcgetusuarioid);
         aP1_ResponsableId=this.AV8ResponsableId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcgetusuarioid)stateInfo).executePrivate();
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
         /* Using cursor P005O2 */
         pr_default.execute(0, new Object[] {AV9NameUser});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A96ResponsableUsuario = P005O2_A96ResponsableUsuario[0];
            A6ResponsableId = P005O2_A6ResponsableId[0];
            AV8ResponsableId = A6ResponsableId;
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
         scmdbuf = "";
         P005O2_A96ResponsableUsuario = new string[] {""} ;
         P005O2_A6ResponsableId = new short[1] ;
         A96ResponsableUsuario = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prcgetusuarioid__default(),
            new Object[][] {
                new Object[] {
               P005O2_A96ResponsableUsuario, P005O2_A6ResponsableId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8ResponsableId ;
      private short A6ResponsableId ;
      private string scmdbuf ;
      private string AV9NameUser ;
      private string A96ResponsableUsuario ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005O2_A96ResponsableUsuario ;
      private short[] P005O2_A6ResponsableId ;
      private short aP1_ResponsableId ;
   }

   public class prcgetusuarioid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005O2;
          prmP005O2 = new Object[] {
          new ParDef("@AV9NameUser",GXType.NVarChar,100,60)
          };
          def= new CursorDef[] {
              new CursorDef("P005O2", "SELECT [ResponsableUsuario], [ResponsableId] FROM [Responsable] WHERE [ResponsableUsuario] = @AV9NameUser ORDER BY [ResponsableId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005O2,100, GxCacheFrequency.OFF ,false,false )
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
                return;
       }
    }

 }

}
