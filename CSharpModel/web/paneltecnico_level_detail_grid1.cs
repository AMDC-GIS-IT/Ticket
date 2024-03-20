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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class paneltecnico_level_detail_grid1 : GXProcedure
   {
      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "paneltecnico_Execute" ;
         }

      }

      public paneltecnico_level_detail_grid1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public paneltecnico_level_detail_grid1( IGxContext context )
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

      public void execute( long aP0_start ,
                           long aP1_count ,
                           int aP2_gxid ,
                           out GXBaseCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item> aP3_GXM2RootCol )
      {
         this.AV19start = aP0_start;
         this.AV20count = aP1_count;
         this.AV18gxid = aP2_gxid;
         this.AV21GXM2RootCol = new GXBaseCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item>( context, "PanelTecnico_Level_Detail_Grid1Sdt.Item", "") ;
         initialize();
         executePrivate();
         aP3_GXM2RootCol=this.AV21GXM2RootCol;
      }

      public GXBaseCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item> executeUdp( long aP0_start ,
                                                                                      long aP1_count ,
                                                                                      int aP2_gxid )
      {
         execute(aP0_start, aP1_count, aP2_gxid, out aP3_GXM2RootCol);
         return AV21GXM2RootCol ;
      }

      public void executeSubmit( long aP0_start ,
                                 long aP1_count ,
                                 int aP2_gxid ,
                                 out GXBaseCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item> aP3_GXM2RootCol )
      {
         paneltecnico_level_detail_grid1 objpaneltecnico_level_detail_grid1;
         objpaneltecnico_level_detail_grid1 = new paneltecnico_level_detail_grid1();
         objpaneltecnico_level_detail_grid1.AV19start = aP0_start;
         objpaneltecnico_level_detail_grid1.AV20count = aP1_count;
         objpaneltecnico_level_detail_grid1.AV18gxid = aP2_gxid;
         objpaneltecnico_level_detail_grid1.AV21GXM2RootCol = new GXBaseCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item>( context, "PanelTecnico_Level_Detail_Grid1Sdt.Item", "") ;
         objpaneltecnico_level_detail_grid1.context.SetSubmitInitialConfig(context);
         objpaneltecnico_level_detail_grid1.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpaneltecnico_level_detail_grid1);
         aP3_GXM2RootCol=this.AV21GXM2RootCol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((paneltecnico_level_detail_grid1)stateInfo).executePrivate();
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
         GXPagingFrom2 = (int)(AV19start);
         GXPagingTo2 = (int)(AV20count);
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {GXPagingFrom2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A187EstadoTicketTicketId = P00002_A187EstadoTicketTicketId[0];
            A14TicketId = P00002_A14TicketId[0];
            A16TicketResponsableId = P00002_A16TicketResponsableId[0];
            A15UsuarioId = P00002_A15UsuarioId[0];
            A93UsuarioNombre = P00002_A93UsuarioNombre[0];
            A90UsuarioFecha = P00002_A90UsuarioFecha[0];
            A92UsuarioHora = P00002_A92UsuarioHora[0];
            A88UsuarioDepartamento = P00002_A88UsuarioDepartamento[0];
            A199TicketTecnicoResponsableNombre = P00002_A199TicketTecnicoResponsableNombre[0];
            A188EstadoTicketTicketNombre = P00002_A188EstadoTicketTicketNombre[0];
            A175TicketResponsableFechaResuelve = P00002_A175TicketResponsableFechaResuelve[0];
            n175TicketResponsableFechaResuelve = P00002_n175TicketResponsableFechaResuelve[0];
            A176TicketResponsableHoraResuelve = P00002_A176TicketResponsableHoraResuelve[0];
            n176TicketResponsableHoraResuelve = P00002_n176TicketResponsableHoraResuelve[0];
            A25EstadoTicketTecnicoNombre = P00002_A25EstadoTicketTecnicoNombre[0];
            A198TicketTecnicoResponsableId = P00002_A198TicketTecnicoResponsableId[0];
            A17EstadoTicketTecnicoId = P00002_A17EstadoTicketTecnicoId[0];
            A187EstadoTicketTicketId = P00002_A187EstadoTicketTicketId[0];
            A15UsuarioId = P00002_A15UsuarioId[0];
            A188EstadoTicketTicketNombre = P00002_A188EstadoTicketTicketNombre[0];
            A93UsuarioNombre = P00002_A93UsuarioNombre[0];
            A90UsuarioFecha = P00002_A90UsuarioFecha[0];
            A92UsuarioHora = P00002_A92UsuarioHora[0];
            A88UsuarioDepartamento = P00002_A88UsuarioDepartamento[0];
            A199TicketTecnicoResponsableNombre = P00002_A199TicketTecnicoResponsableNombre[0];
            A25EstadoTicketTecnicoNombre = P00002_A25EstadoTicketTecnicoNombre[0];
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt = new SdtPanelTecnico_Level_Detail_Grid1Sdt_Item(context);
            AV21GXM2RootCol.Add(AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt, 0);
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Ticketid = A14TicketId;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Ticketresponsableid = A16TicketResponsableId;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Usuarioid = A15UsuarioId;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Usuarionombre = A93UsuarioNombre;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Usuariofecha = A90UsuarioFecha;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Usuariohora = A92UsuarioHora;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Usuariodepartamento = A88UsuarioDepartamento;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Tickettecnicoresponsablenombre = A199TicketTecnicoResponsableNombre;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Estadoticketticketnombre = A188EstadoTicketTicketNombre;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Ticketresponsablefecharesuelve = A175TicketResponsableFechaResuelve;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Ticketresponsablehoraresuelve = A176TicketResponsableHoraResuelve;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Estadotickettecniconombre = A25EstadoTicketTecnicoNombre;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Tickettecnicoresponsableid = A198TicketTecnicoResponsableId;
            AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt.gxTpr_Estadotickettecnicoid = A17EstadoTicketTecnicoId;
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
         AV21GXM2RootCol = new GXBaseCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item>( context, "PanelTecnico_Level_Detail_Grid1Sdt.Item", "");
         scmdbuf = "";
         P00002_A187EstadoTicketTicketId = new short[1] ;
         P00002_A14TicketId = new long[1] ;
         P00002_A16TicketResponsableId = new long[1] ;
         P00002_A15UsuarioId = new short[1] ;
         P00002_A93UsuarioNombre = new string[] {""} ;
         P00002_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         P00002_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         P00002_A88UsuarioDepartamento = new string[] {""} ;
         P00002_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         P00002_A188EstadoTicketTicketNombre = new string[] {""} ;
         P00002_A175TicketResponsableFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         P00002_n175TicketResponsableFechaResuelve = new bool[] {false} ;
         P00002_A176TicketResponsableHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         P00002_n176TicketResponsableHoraResuelve = new bool[] {false} ;
         P00002_A25EstadoTicketTecnicoNombre = new string[] {""} ;
         P00002_A198TicketTecnicoResponsableId = new short[1] ;
         P00002_A17EstadoTicketTecnicoId = new short[1] ;
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         A88UsuarioDepartamento = "";
         A199TicketTecnicoResponsableNombre = "";
         A188EstadoTicketTicketNombre = "";
         A175TicketResponsableFechaResuelve = DateTime.MinValue;
         A176TicketResponsableHoraResuelve = (DateTime)(DateTime.MinValue);
         A25EstadoTicketTecnicoNombre = "";
         AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt = new SdtPanelTecnico_Level_Detail_Grid1Sdt_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.paneltecnico_level_detail_grid1__default(),
            new Object[][] {
                new Object[] {
               P00002_A187EstadoTicketTicketId, P00002_A14TicketId, P00002_A16TicketResponsableId, P00002_A15UsuarioId, P00002_A93UsuarioNombre, P00002_A90UsuarioFecha, P00002_A92UsuarioHora, P00002_A88UsuarioDepartamento, P00002_A199TicketTecnicoResponsableNombre, P00002_A188EstadoTicketTicketNombre,
               P00002_A175TicketResponsableFechaResuelve, P00002_n175TicketResponsableFechaResuelve, P00002_A176TicketResponsableHoraResuelve, P00002_n176TicketResponsableHoraResuelve, P00002_A25EstadoTicketTecnicoNombre, P00002_A198TicketTecnicoResponsableId, P00002_A17EstadoTicketTecnicoId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A187EstadoTicketTicketId ;
      private short A15UsuarioId ;
      private short A198TicketTecnicoResponsableId ;
      private short A17EstadoTicketTecnicoId ;
      private int AV18gxid ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private long AV19start ;
      private long AV20count ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private string scmdbuf ;
      private DateTime A92UsuarioHora ;
      private DateTime A176TicketResponsableHoraResuelve ;
      private DateTime A90UsuarioFecha ;
      private DateTime A175TicketResponsableFechaResuelve ;
      private bool n175TicketResponsableFechaResuelve ;
      private bool n176TicketResponsableHoraResuelve ;
      private string A93UsuarioNombre ;
      private string A88UsuarioDepartamento ;
      private string A199TicketTecnicoResponsableNombre ;
      private string A188EstadoTicketTicketNombre ;
      private string A25EstadoTicketTecnicoNombre ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00002_A187EstadoTicketTicketId ;
      private long[] P00002_A14TicketId ;
      private long[] P00002_A16TicketResponsableId ;
      private short[] P00002_A15UsuarioId ;
      private string[] P00002_A93UsuarioNombre ;
      private DateTime[] P00002_A90UsuarioFecha ;
      private DateTime[] P00002_A92UsuarioHora ;
      private string[] P00002_A88UsuarioDepartamento ;
      private string[] P00002_A199TicketTecnicoResponsableNombre ;
      private string[] P00002_A188EstadoTicketTicketNombre ;
      private DateTime[] P00002_A175TicketResponsableFechaResuelve ;
      private bool[] P00002_n175TicketResponsableFechaResuelve ;
      private DateTime[] P00002_A176TicketResponsableHoraResuelve ;
      private bool[] P00002_n176TicketResponsableHoraResuelve ;
      private string[] P00002_A25EstadoTicketTecnicoNombre ;
      private short[] P00002_A198TicketTecnicoResponsableId ;
      private short[] P00002_A17EstadoTicketTecnicoId ;
      private GXBaseCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item> aP3_GXM2RootCol ;
      private GXBaseCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item> AV21GXM2RootCol ;
      private SdtPanelTecnico_Level_Detail_Grid1Sdt_Item AV22GXM1PanelTecnico_Level_Detail_Grid1Sdt ;
   }

   public class paneltecnico_level_detail_grid1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00002;
          prmP00002 = new Object[] {
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT T2.[EstadoTicketTicketId] AS EstadoTicketTicketId, T1.[TicketId], T1.[TicketResponsableId], T2.[UsuarioId], T4.[UsuarioNombre], T4.[UsuarioFecha], T4.[UsuarioHora], T4.[UsuarioDepartamento], T5.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T3.[EstadoTicketNombre] AS EstadoTicketTicketNombre, T1.[TicketResponsableFechaResuelve], T1.[TicketResponsableHoraResuelve], T6.[EstadoTicketNombre] AS EstadoTicketTecnicoNombre, T1.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId, T1.[EstadoTicketTecnicoId] AS EstadoTicketTecnicoId FROM ((((([TicketResponsable] T1 INNER JOIN [Ticket] T2 ON T2.[TicketId] = T1.[TicketId]) INNER JOIN [EstadoTicket] T3 ON T3.[EstadoTicketId] = T2.[EstadoTicketTicketId]) INNER JOIN [Usuario] T4 ON T4.[UsuarioId] = T2.[UsuarioId]) INNER JOIN [Responsable] T5 ON T5.[ResponsableId] = T1.[TicketTecnicoResponsableId]) INNER JOIN [EstadoTicket] T6 ON T6.[EstadoTicketId] = T1.[EstadoTicketTecnicoId]) ORDER BY T1.[TicketId], T1.[TicketResponsableId]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((string[]) buf[14])[0] = rslt.getVarchar(13);
                ((short[]) buf[15])[0] = rslt.getShort(14);
                ((short[]) buf[16])[0] = rslt.getShort(15);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.paneltecnico_level_detail_grid1_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class paneltecnico_level_detail_grid1_services : GxRestService
 {
    protected override bool IntegratedSecurityEnabled
    {
       get {
          return true ;
       }

    }

    protected override GAMSecurityLevel IntegratedSecurityLevel
    {
       get {
          return GAMSecurityLevel.SecurityHigh ;
       }

    }

    [OperationContract(Name = "PanelTecnico_Level_Detail_Grid1" )]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/?start={start}&count={count}&gxid={gxid}")]
    public GxGenericCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_RESTInterface> execute( string start ,
                                                                                                  string count ,
                                                                                                  string gxid )
    {
       GxGenericCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_RESTInterface> GXM2RootCol = new GxGenericCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_RESTInterface>();
       try
       {
          permissionPrefix = "paneltecnico_Execute";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("paneltecnico_level_detail_grid1") )
          {
             return null ;
          }
          paneltecnico_level_detail_grid1 worker = new paneltecnico_level_detail_grid1(context);
          worker.IsMain = RunAsMain ;
          long gxrstart = 0;
          gxrstart = (long)(NumberUtil.Val( (string)(start), "."));
          long gxrcount = 0;
          gxrcount = (long)(NumberUtil.Val( (string)(count), "."));
          int gxrgxid = 0;
          gxrgxid = (int)(NumberUtil.Val( (string)(gxid), "."));
          GXBaseCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item> gxrGXM2RootCol = new GXBaseCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item>();
          worker.execute(gxrstart,gxrcount,gxrgxid,out gxrGXM2RootCol );
          worker.cleanup( );
          GXM2RootCol = new GxGenericCollection<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_RESTInterface>(gxrGXM2RootCol) ;
          return GXM2RootCol ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

 }

}
