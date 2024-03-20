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
   public class pcrregistrarinfotec : GXProcedure
   {
      public pcrregistrarinfotec( )
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

      public pcrregistrarinfotec( IGxContext context )
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
                           string aP13_Cargo )
      {
         this.AV43categoria_tareaid_tipo_categoria = aP0_categoria_tareaid_tipo_categoria;
         this.AV44id_actividad_categoria = aP1_id_actividad_categoria;
         this.AV41UsuarioNombre = aP2_UsuarioNombre;
         this.AV38UsuarioDepartamento = aP3_UsuarioDepartamento;
         this.AV42UsuarioEmail = aP4_UsuarioEmail;
         this.AV37detalle_infotecid_unidad = aP5_detalle_infotecid_unidad;
         this.AV36detalle_tarea = aP6_detalle_tarea;
         this.AV35prioridad = aP7_prioridad;
         this.AV39UsuarioFecha = aP8_UsuarioFecha;
         this.AV46EstadoTicketTicketId = aP9_EstadoTicketTicketId;
         this.AV47EtapaDesarrolloId = aP10_EtapaDesarrolloId;
         this.AV22TicketResponsableObservacion = aP11_TicketResponsableObservacion;
         this.AV48Empleado = aP12_Empleado;
         this.AV49Cargo = aP13_Cargo;
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
                                 string aP13_Cargo )
      {
         pcrregistrarinfotec objpcrregistrarinfotec;
         objpcrregistrarinfotec = new pcrregistrarinfotec();
         objpcrregistrarinfotec.AV43categoria_tareaid_tipo_categoria = aP0_categoria_tareaid_tipo_categoria;
         objpcrregistrarinfotec.AV44id_actividad_categoria = aP1_id_actividad_categoria;
         objpcrregistrarinfotec.AV41UsuarioNombre = aP2_UsuarioNombre;
         objpcrregistrarinfotec.AV38UsuarioDepartamento = aP3_UsuarioDepartamento;
         objpcrregistrarinfotec.AV42UsuarioEmail = aP4_UsuarioEmail;
         objpcrregistrarinfotec.AV37detalle_infotecid_unidad = aP5_detalle_infotecid_unidad;
         objpcrregistrarinfotec.AV36detalle_tarea = aP6_detalle_tarea;
         objpcrregistrarinfotec.AV35prioridad = aP7_prioridad;
         objpcrregistrarinfotec.AV39UsuarioFecha = aP8_UsuarioFecha;
         objpcrregistrarinfotec.AV46EstadoTicketTicketId = aP9_EstadoTicketTicketId;
         objpcrregistrarinfotec.AV47EtapaDesarrolloId = aP10_EtapaDesarrolloId;
         objpcrregistrarinfotec.AV22TicketResponsableObservacion = aP11_TicketResponsableObservacion;
         objpcrregistrarinfotec.AV48Empleado = aP12_Empleado;
         objpcrregistrarinfotec.AV49Cargo = aP13_Cargo;
         objpcrregistrarinfotec.context.SetSubmitInitialConfig(context);
         objpcrregistrarinfotec.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcrregistrarinfotec);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcrregistrarinfotec)stateInfo).executePrivate();
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
            INSERT RECORD ON TABLE DETALLE_INFOTEC

         */
         A239nombre_emp = AV48Empleado;
         n239nombre_emp = false;
         A240cargo_emp = AV49Cargo;
         n240cargo_emp = false;
         A241fecha_registro = DateTimeUtil.Today( context);
         n241fecha_registro = false;
         A243estatus = "SOLICITADO";
         n243estatus = false;
         A244trabajo = "ABIERTO";
         n244trabajo = false;
         A245nombre_usuario = AV41UsuarioNombre;
         n245nombre_usuario = false;
         A246depto_usuario = AV38UsuarioDepartamento;
         n246depto_usuario = false;
         A247correo_usuario = AV42UsuarioEmail;
         n247correo_usuario = false;
         A248detalle_infotecid_unidad = (int)(NumberUtil.Val( AV50WebSession.Get("id_unidad_tecnico"), "."));
         n248detalle_infotecid_unidad = false;
         A249id_categoria = AV43categoria_tareaid_tipo_categoria;
         n249id_categoria = false;
         A250id_actividad = AV44id_actividad_categoria;
         n250id_actividad = false;
         A251detalle_tarea = AV36detalle_tarea;
         n251detalle_tarea = false;
         A252prioridad = AV35prioridad;
         n252prioridad = false;
         A253observaciones = AV22TicketResponsableObservacion;
         n253observaciones = false;
         A254fecha_solicitud = context.localUtil.DToC( AV39UsuarioFecha, 2, "/");
         n254fecha_solicitud = false;
         /* Using cursor P00792 */
         pr_datastore1.execute(0, new Object[] {n239nombre_emp, A239nombre_emp, n240cargo_emp, A240cargo_emp, n241fecha_registro, A241fecha_registro, n243estatus, A243estatus, n244trabajo, A244trabajo, n245nombre_usuario, A245nombre_usuario, n246depto_usuario, A246depto_usuario, n247correo_usuario, A247correo_usuario, n248detalle_infotecid_unidad, A248detalle_infotecid_unidad, n249id_categoria, A249id_categoria, n250id_actividad, A250id_actividad, n251detalle_tarea, A251detalle_tarea, n252prioridad, A252prioridad, n253observaciones, A253observaciones, n254fecha_solicitud, A254fecha_solicitud});
         A238correlativo = P00792_A238correlativo[0];
         pr_datastore1.close(0);
         dsDataStore1.SmartCacheProvider.SetUpdated("DETALLE_INFOTEC");
         if ( (pr_datastore1.getStatus(0) == 1) )
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
         context.CommitDataStores("pcrregistrarinfotec",pr_default);
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
         A239nombre_emp = "";
         A240cargo_emp = "";
         A241fecha_registro = DateTime.MinValue;
         A243estatus = "";
         A244trabajo = "";
         A245nombre_usuario = "";
         A246depto_usuario = "";
         A247correo_usuario = "";
         AV50WebSession = context.GetSession();
         A251detalle_tarea = "";
         A252prioridad = "";
         A253observaciones = "";
         A254fecha_solicitud = "";
         P00792_A238correlativo = new int[1] ;
         Gx_emsg = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.pcrregistrarinfotec__datastore1(),
            new Object[][] {
                new Object[] {
               P00792_A238correlativo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV46EstadoTicketTicketId ;
      private short AV47EtapaDesarrolloId ;
      private int AV43categoria_tareaid_tipo_categoria ;
      private int AV44id_actividad_categoria ;
      private int AV37detalle_infotecid_unidad ;
      private int GX_INS17 ;
      private int A248detalle_infotecid_unidad ;
      private int A249id_categoria ;
      private int A250id_actividad ;
      private int A238correlativo ;
      private string Gx_emsg ;
      private DateTime AV39UsuarioFecha ;
      private DateTime A241fecha_registro ;
      private bool n239nombre_emp ;
      private bool n240cargo_emp ;
      private bool n241fecha_registro ;
      private bool n243estatus ;
      private bool n244trabajo ;
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
      private string AV41UsuarioNombre ;
      private string AV38UsuarioDepartamento ;
      private string AV42UsuarioEmail ;
      private string AV36detalle_tarea ;
      private string AV35prioridad ;
      private string AV22TicketResponsableObservacion ;
      private string AV48Empleado ;
      private string AV49Cargo ;
      private string A239nombre_emp ;
      private string A240cargo_emp ;
      private string A243estatus ;
      private string A244trabajo ;
      private string A245nombre_usuario ;
      private string A246depto_usuario ;
      private string A247correo_usuario ;
      private string A251detalle_tarea ;
      private string A252prioridad ;
      private string A253observaciones ;
      private string A254fecha_solicitud ;
      private IGxSession AV50WebSession ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] P00792_A238correlativo ;
      private IDataStoreProvider pr_default ;
   }

   public class pcrregistrarinfotec__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00792;
          prmP00792 = new Object[] {
          new ParDef("@nombre_emp",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@cargo_emp",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@fecha_registro",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@estatus",GXType.NVarChar,30,0){Nullable=true} ,
          new ParDef("@trabajo",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@nombre_usuario",GXType.NVarChar,300,0){Nullable=true} ,
          new ParDef("@depto_usuario",GXType.NVarChar,150,0){Nullable=true} ,
          new ParDef("@correo_usuario",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@detalle_infotecid_unidad",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@id_categoria",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@id_actividad",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@detalle_tarea",GXType.NVarChar,250,0){Nullable=true} ,
          new ParDef("@prioridad",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@observaciones",GXType.NVarChar,500,0){Nullable=true} ,
          new ParDef("@fecha_solicitud",GXType.NVarChar,300,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00792", "INSERT INTO dbo.[detalle_infotec]([nombre_emp], [cargo_emp], [fecha_registro], [estatus], [trabajo], [nombre_usuario], [depto_usuario], [correo_usuario], [id_unidad], [id_categoria], [id_actividad], [detalle_tarea], [prioridad], [observaciones], [fecha_solicitud], [hora_registro], [fecha_ciere], [hora_cierra]) VALUES(@nombre_emp, @cargo_emp, @fecha_registro, @estatus, @trabajo, @nombre_usuario, @depto_usuario, @correo_usuario, @detalle_infotecid_unidad, @id_categoria, @id_actividad, @detalle_tarea, @prioridad, @observaciones, @fecha_solicitud, convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 ), convert( DATETIME, '17530101', 112 )); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmP00792)
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
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}
