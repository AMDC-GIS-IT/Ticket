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
   public class pcrmodificarinfotec : GXProcedure
   {
      public pcrmodificarinfotec( )
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

      public pcrmodificarinfotec( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_categoria_tareaid_tipo_categoria ,
                           int aP1_id_actividad_categoria ,
                           string aP2_UsuarioNombre ,
                           string aP3_UsuarioDepartamento ,
                           string aP4_UsuarioEmail ,
                           int aP5_detalle_infotecid_unidad ,
                           string aP6_detalle_tarea ,
                           string aP7_prioridad ,
                           DateTime aP8_UsuarioFecha ,
                           short aP9_EstadoTicketTicketId ,
                           short aP10_EtapaDesarrolloId ,
                           string aP11_TicketResponsableObservacion ,
                           string aP12_Empleado ,
                           string aP13_Cargo ,
                           int aP14_correlativo )
      {
         this.AV8categoria_tareaid_tipo_categoria = aP0_categoria_tareaid_tipo_categoria;
         this.AV13id_actividad_categoria = aP1_id_actividad_categoria;
         this.AV19UsuarioNombre = aP2_UsuarioNombre;
         this.AV16UsuarioDepartamento = aP3_UsuarioDepartamento;
         this.AV17UsuarioEmail = aP4_UsuarioEmail;
         this.AV9detalle_infotecid_unidad = aP5_detalle_infotecid_unidad;
         this.AV10detalle_tarea = aP6_detalle_tarea;
         this.AV14prioridad = aP7_prioridad;
         this.AV18UsuarioFecha = aP8_UsuarioFecha;
         this.AV11EstadoTicketTicketId = aP9_EstadoTicketTicketId;
         this.AV12EtapaDesarrolloId = aP10_EtapaDesarrolloId;
         this.AV15TicketResponsableObservacion = aP11_TicketResponsableObservacion;
         this.AV21Empleado = aP12_Empleado;
         this.AV20Cargo = aP13_Cargo;
         this.AV23correlativo = aP14_correlativo;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_categoria_tareaid_tipo_categoria ,
                                 int aP1_id_actividad_categoria ,
                                 string aP2_UsuarioNombre ,
                                 string aP3_UsuarioDepartamento ,
                                 string aP4_UsuarioEmail ,
                                 int aP5_detalle_infotecid_unidad ,
                                 string aP6_detalle_tarea ,
                                 string aP7_prioridad ,
                                 DateTime aP8_UsuarioFecha ,
                                 short aP9_EstadoTicketTicketId ,
                                 short aP10_EtapaDesarrolloId ,
                                 string aP11_TicketResponsableObservacion ,
                                 string aP12_Empleado ,
                                 string aP13_Cargo ,
                                 int aP14_correlativo )
      {
         pcrmodificarinfotec objpcrmodificarinfotec;
         objpcrmodificarinfotec = new pcrmodificarinfotec();
         objpcrmodificarinfotec.AV8categoria_tareaid_tipo_categoria = aP0_categoria_tareaid_tipo_categoria;
         objpcrmodificarinfotec.AV13id_actividad_categoria = aP1_id_actividad_categoria;
         objpcrmodificarinfotec.AV19UsuarioNombre = aP2_UsuarioNombre;
         objpcrmodificarinfotec.AV16UsuarioDepartamento = aP3_UsuarioDepartamento;
         objpcrmodificarinfotec.AV17UsuarioEmail = aP4_UsuarioEmail;
         objpcrmodificarinfotec.AV9detalle_infotecid_unidad = aP5_detalle_infotecid_unidad;
         objpcrmodificarinfotec.AV10detalle_tarea = aP6_detalle_tarea;
         objpcrmodificarinfotec.AV14prioridad = aP7_prioridad;
         objpcrmodificarinfotec.AV18UsuarioFecha = aP8_UsuarioFecha;
         objpcrmodificarinfotec.AV11EstadoTicketTicketId = aP9_EstadoTicketTicketId;
         objpcrmodificarinfotec.AV12EtapaDesarrolloId = aP10_EtapaDesarrolloId;
         objpcrmodificarinfotec.AV15TicketResponsableObservacion = aP11_TicketResponsableObservacion;
         objpcrmodificarinfotec.AV21Empleado = aP12_Empleado;
         objpcrmodificarinfotec.AV20Cargo = aP13_Cargo;
         objpcrmodificarinfotec.AV23correlativo = aP14_correlativo;
         objpcrmodificarinfotec.context.SetSubmitInitialConfig(context);
         objpcrmodificarinfotec.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrmodificarinfotec);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrmodificarinfotec)stateInfo).executePrivate();
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
         /* Using cursor P007C2 */
         pr_datastore1.execute(0, new Object[] {AV23correlativo});
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            A238correlativo = P007C2_A238correlativo[0];
            A245nombre_usuario = P007C2_A245nombre_usuario[0];
            n245nombre_usuario = P007C2_n245nombre_usuario[0];
            A246depto_usuario = P007C2_A246depto_usuario[0];
            n246depto_usuario = P007C2_n246depto_usuario[0];
            A247correo_usuario = P007C2_A247correo_usuario[0];
            n247correo_usuario = P007C2_n247correo_usuario[0];
            A248detalle_infotecid_unidad = P007C2_A248detalle_infotecid_unidad[0];
            n248detalle_infotecid_unidad = P007C2_n248detalle_infotecid_unidad[0];
            A249id_categoria = P007C2_A249id_categoria[0];
            n249id_categoria = P007C2_n249id_categoria[0];
            A250id_actividad = P007C2_A250id_actividad[0];
            n250id_actividad = P007C2_n250id_actividad[0];
            A251detalle_tarea = P007C2_A251detalle_tarea[0];
            n251detalle_tarea = P007C2_n251detalle_tarea[0];
            A252prioridad = P007C2_A252prioridad[0];
            n252prioridad = P007C2_n252prioridad[0];
            A253observaciones = P007C2_A253observaciones[0];
            n253observaciones = P007C2_n253observaciones[0];
            A254fecha_solicitud = P007C2_A254fecha_solicitud[0];
            n254fecha_solicitud = P007C2_n254fecha_solicitud[0];
            A245nombre_usuario = AV19UsuarioNombre;
            n245nombre_usuario = false;
            A246depto_usuario = AV16UsuarioDepartamento;
            n246depto_usuario = false;
            A247correo_usuario = AV17UsuarioEmail;
            n247correo_usuario = false;
            A248detalle_infotecid_unidad = (int)(NumberUtil.Val( AV24WebSession.Get("id_unidad_tecnico"), "."));
            n248detalle_infotecid_unidad = false;
            A249id_categoria = AV8categoria_tareaid_tipo_categoria;
            n249id_categoria = false;
            A250id_actividad = AV13id_actividad_categoria;
            n250id_actividad = false;
            A251detalle_tarea = AV10detalle_tarea;
            n251detalle_tarea = false;
            A252prioridad = AV14prioridad;
            n252prioridad = false;
            A253observaciones = AV15TicketResponsableObservacion;
            n253observaciones = false;
            A254fecha_solicitud = context.localUtil.DToC( AV18UsuarioFecha, 2, "/");
            n254fecha_solicitud = false;
            /* Using cursor P007C3 */
            pr_datastore1.execute(1, new Object[] {n245nombre_usuario, A245nombre_usuario, n246depto_usuario, A246depto_usuario, n247correo_usuario, A247correo_usuario, n248detalle_infotecid_unidad, A248detalle_infotecid_unidad, n249id_categoria, A249id_categoria, n250id_actividad, A250id_actividad, n251detalle_tarea, A251detalle_tarea, n252prioridad, A252prioridad, n253observaciones, A253observaciones, n254fecha_solicitud, A254fecha_solicitud, A238correlativo});
            pr_datastore1.close(1);
            dsDataStore1.SmartCacheProvider.SetUpdated("DETALLE_INFOTEC");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_datastore1.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("pcrmodificarinfotec",pr_default);
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
         P007C2_A238correlativo = new int[1] ;
         P007C2_A245nombre_usuario = new string[] {""} ;
         P007C2_n245nombre_usuario = new bool[] {false} ;
         P007C2_A246depto_usuario = new string[] {""} ;
         P007C2_n246depto_usuario = new bool[] {false} ;
         P007C2_A247correo_usuario = new string[] {""} ;
         P007C2_n247correo_usuario = new bool[] {false} ;
         P007C2_A248detalle_infotecid_unidad = new int[1] ;
         P007C2_n248detalle_infotecid_unidad = new bool[] {false} ;
         P007C2_A249id_categoria = new int[1] ;
         P007C2_n249id_categoria = new bool[] {false} ;
         P007C2_A250id_actividad = new int[1] ;
         P007C2_n250id_actividad = new bool[] {false} ;
         P007C2_A251detalle_tarea = new string[] {""} ;
         P007C2_n251detalle_tarea = new bool[] {false} ;
         P007C2_A252prioridad = new string[] {""} ;
         P007C2_n252prioridad = new bool[] {false} ;
         P007C2_A253observaciones = new string[] {""} ;
         P007C2_n253observaciones = new bool[] {false} ;
         P007C2_A254fecha_solicitud = new string[] {""} ;
         P007C2_n254fecha_solicitud = new bool[] {false} ;
         A245nombre_usuario = "";
         A246depto_usuario = "";
         A247correo_usuario = "";
         A251detalle_tarea = "";
         A252prioridad = "";
         A253observaciones = "";
         A254fecha_solicitud = "";
         AV24WebSession = context.GetSession();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.pcrmodificarinfotec__datastore1(),
            new Object[][] {
                new Object[] {
               P007C2_A238correlativo, P007C2_A245nombre_usuario, P007C2_n245nombre_usuario, P007C2_A246depto_usuario, P007C2_n246depto_usuario, P007C2_A247correo_usuario, P007C2_n247correo_usuario, P007C2_A248detalle_infotecid_unidad, P007C2_n248detalle_infotecid_unidad, P007C2_A249id_categoria,
               P007C2_n249id_categoria, P007C2_A250id_actividad, P007C2_n250id_actividad, P007C2_A251detalle_tarea, P007C2_n251detalle_tarea, P007C2_A252prioridad, P007C2_n252prioridad, P007C2_A253observaciones, P007C2_n253observaciones, P007C2_A254fecha_solicitud,
               P007C2_n254fecha_solicitud
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11EstadoTicketTicketId ;
      private short AV12EtapaDesarrolloId ;
      private int AV8categoria_tareaid_tipo_categoria ;
      private int AV13id_actividad_categoria ;
      private int AV9detalle_infotecid_unidad ;
      private int AV23correlativo ;
      private int A238correlativo ;
      private int A248detalle_infotecid_unidad ;
      private int A249id_categoria ;
      private int A250id_actividad ;
      private string scmdbuf ;
      private DateTime AV18UsuarioFecha ;
      private bool n245nombre_usuario ;
      private bool n246depto_usuario ;
      private bool n247correo_usuario ;
      private bool n248detalle_infotecid_unidad ;
      private bool n249id_categoria ;
      private bool n250id_actividad ;
      private bool n251detalle_tarea ;
      private bool n252prioridad ;
      private bool n253observaciones ;
      private bool n254fecha_solicitud ;
      private string AV19UsuarioNombre ;
      private string AV16UsuarioDepartamento ;
      private string AV17UsuarioEmail ;
      private string AV10detalle_tarea ;
      private string AV14prioridad ;
      private string AV15TicketResponsableObservacion ;
      private string AV21Empleado ;
      private string AV20Cargo ;
      private string A245nombre_usuario ;
      private string A246depto_usuario ;
      private string A247correo_usuario ;
      private string A251detalle_tarea ;
      private string A252prioridad ;
      private string A253observaciones ;
      private string A254fecha_solicitud ;
      private IGxSession AV24WebSession ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] P007C2_A238correlativo ;
      private string[] P007C2_A245nombre_usuario ;
      private bool[] P007C2_n245nombre_usuario ;
      private string[] P007C2_A246depto_usuario ;
      private bool[] P007C2_n246depto_usuario ;
      private string[] P007C2_A247correo_usuario ;
      private bool[] P007C2_n247correo_usuario ;
      private int[] P007C2_A248detalle_infotecid_unidad ;
      private bool[] P007C2_n248detalle_infotecid_unidad ;
      private int[] P007C2_A249id_categoria ;
      private bool[] P007C2_n249id_categoria ;
      private int[] P007C2_A250id_actividad ;
      private bool[] P007C2_n250id_actividad ;
      private string[] P007C2_A251detalle_tarea ;
      private bool[] P007C2_n251detalle_tarea ;
      private string[] P007C2_A252prioridad ;
      private bool[] P007C2_n252prioridad ;
      private string[] P007C2_A253observaciones ;
      private bool[] P007C2_n253observaciones ;
      private string[] P007C2_A254fecha_solicitud ;
      private bool[] P007C2_n254fecha_solicitud ;
      private IDataStoreProvider pr_default ;
   }

   public class pcrmodificarinfotec__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007C2;
          prmP007C2 = new Object[] {
          new ParDef("@AV23correlativo",GXType.Int32,9,0)
          };
          Object[] prmP007C3;
          prmP007C3 = new Object[] {
          new ParDef("@nombre_usuario",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@depto_usuario",GXType.NVarChar,150,0){Nullable=true} ,
          new ParDef("@correo_usuario",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@detalle_infotecid_unidad",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@id_categoria",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@id_actividad",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@detalle_tarea",GXType.NVarChar,250,0){Nullable=true} ,
          new ParDef("@prioridad",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@observaciones",GXType.NVarChar,500,0){Nullable=true} ,
          new ParDef("@fecha_solicitud",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@correlativo",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007C2", "SELECT [correlativo], [nombre_usuario], [depto_usuario], [correo_usuario], [id_unidad], [id_categoria], [id_actividad], [detalle_tarea], [prioridad], [observaciones], [fecha_solicitud] FROM dbo.[detalle_infotec] WITH (UPDLOCK) WHERE [correlativo] = @AV23correlativo ORDER BY [correlativo] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007C2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P007C3", "UPDATE dbo.[detalle_infotec] SET [nombre_usuario]=@nombre_usuario, [depto_usuario]=@depto_usuario, [correo_usuario]=@correo_usuario, [id_unidad]=@detalle_infotecid_unidad, [id_categoria]=@id_categoria, [id_actividad]=@id_actividad, [detalle_tarea]=@detalle_tarea, [prioridad]=@prioridad, [observaciones]=@observaciones, [fecha_solicitud]=@fecha_solicitud  WHERE [correlativo] = @correlativo", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP007C3)
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}
