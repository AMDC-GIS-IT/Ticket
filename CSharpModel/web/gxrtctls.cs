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
   public class gxrtctls : GXProcedure
   {
      public gxrtctls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public gxrtctls( IGxContext context )
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

      public void execute( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         initialize();
         executePrivate();
         aP0_Status=this.AV2Status;
      }

      public short executeUdp( )
      {
         execute(out aP0_Status);
         return AV2Status ;
      }

      public void executeSubmit( out short aP0_Status )
      {
         gxrtctls objgxrtctls;
         objgxrtctls = new gxrtctls();
         objgxrtctls.AV2Status = 0 ;
         objgxrtctls.context.SetSubmitInitialConfig(context);
         objgxrtctls.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgxrtctls);
         aP0_Status=this.AV2Status;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gxrtctls)stateInfo).executePrivate();
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
         AV2Status = 0;
         Console.WriteLine( "=== Starting run time controls" );
         Console.WriteLine( "Checking that table Satisfaccion does NOT contain records." );
         AV3NotFound = 0;
         AV6GXLvl5 = 0;
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A6ResponsableId = LTCTLS2_A6ResponsableId[0];
            A14TicketId = LTCTLS2_A14TicketId[0];
            A7SatisfaccionId = LTCTLS2_A7SatisfaccionId[0];
            AV6GXLvl5 = 1;
            AV7GXLvl8 = 0;
            /* Using cursor LTCTLS3 */
            pr_default.execute(1, new Object[] {A14TicketId, A6ResponsableId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A198TicketTecnicoResponsableId = LTCTLS3_A198TicketTecnicoResponsableId[0];
               A16TicketResponsableId = LTCTLS3_A16TicketResponsableId[0];
               AV7GXLvl8 = 1;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            if ( AV7GXLvl8 == 0 )
            {
               AV2Status = 1;
               Console.WriteLine( "Fail: Table Satisfaccion has records but referenced key value in table TicketResponsable does _not_ exist." );
               Console.WriteLine( "Recovery: See recovery information for reorganization message rgz0029." );
               AV3NotFound = 1;
            }
            if ( AV3NotFound == 1 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV6GXLvl5 == 0 )
         {
            Console.WriteLine( "Success: Table Satisfaccion does NOT have records." );
            AV3NotFound = 1;
         }
         if ( AV3NotFound == 0 )
         {
            Console.WriteLine( "Success: Table Satisfaccionhas records but all referenced key values in table TicketResponsable exist." );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( "=== End of run time controls" );
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
         LTCTLS2_A6ResponsableId = new short[1] ;
         LTCTLS2_A14TicketId = new long[1] ;
         LTCTLS2_A7SatisfaccionId = new short[1] ;
         LTCTLS3_A14TicketId = new long[1] ;
         LTCTLS3_A198TicketTecnicoResponsableId = new short[1] ;
         LTCTLS3_A16TicketResponsableId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A6ResponsableId, LTCTLS2_A14TicketId, LTCTLS2_A7SatisfaccionId
               }
               , new Object[] {
               LTCTLS3_A14TicketId, LTCTLS3_A198TicketTecnicoResponsableId, LTCTLS3_A16TicketResponsableId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV2Status ;
      private short AV3NotFound ;
      private short AV6GXLvl5 ;
      private short A6ResponsableId ;
      private short A7SatisfaccionId ;
      private short AV7GXLvl8 ;
      private short A198TicketTecnicoResponsableId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private string scmdbuf ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] LTCTLS2_A6ResponsableId ;
      private long[] LTCTLS2_A14TicketId ;
      private short[] LTCTLS2_A7SatisfaccionId ;
      private long[] LTCTLS3_A14TicketId ;
      private short[] LTCTLS3_A198TicketTecnicoResponsableId ;
      private long[] LTCTLS3_A16TicketResponsableId ;
      private short aP0_Status ;
   }

   public class gxrtctls__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmLTCTLS2;
          prmLTCTLS2 = new Object[] {
          };
          Object[] prmLTCTLS3;
          prmLTCTLS3 = new Object[] {
          new ParDef("@TicketId",GXType.Decimal,10,0) ,
          new ParDef("@ResponsableId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT DISTINCT [ResponsableId], [TicketId], [SatisfaccionId] FROM [Satisfaccion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("LTCTLS3", "SELECT [TicketId], [TicketTecnicoResponsableId], [TicketResponsableId] FROM [TicketResponsable] WHERE ([TicketId] = @TicketId) AND ([TicketTecnicoResponsableId] = @ResponsableId) AND ([TicketResponsableId] = 0) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS3,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
