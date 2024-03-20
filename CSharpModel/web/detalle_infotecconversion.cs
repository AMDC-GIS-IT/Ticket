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
   public class detalle_infotecconversion : GXProcedure
   {
      public detalle_infotecconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public detalle_infotecconversion( IGxContext context )
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
         detalle_infotecconversion objdetalle_infotecconversion;
         objdetalle_infotecconversion = new detalle_infotecconversion();
         objdetalle_infotecconversion.context.SetSubmitInitialConfig(context);
         objdetalle_infotecconversion.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdetalle_infotecconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((detalle_infotecconversion)stateInfo).executePrivate();
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
         cmdBuffer=" SET IDENTITY_INSERT dbo.[GXA0017] ON "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor DETALLE_IN2 */
         pr_datastore1.execute(0);
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            A256hora_cierra = DETALLE_IN2_A256hora_cierra[0];
            n256hora_cierra = DETALLE_IN2_n256hora_cierra[0];
            A255fecha_ciere = DETALLE_IN2_A255fecha_ciere[0];
            n255fecha_ciere = DETALLE_IN2_n255fecha_ciere[0];
            A254fecha_solicitud = DETALLE_IN2_A254fecha_solicitud[0];
            n254fecha_solicitud = DETALLE_IN2_n254fecha_solicitud[0];
            A253observaciones = DETALLE_IN2_A253observaciones[0];
            n253observaciones = DETALLE_IN2_n253observaciones[0];
            A252prioridad = DETALLE_IN2_A252prioridad[0];
            n252prioridad = DETALLE_IN2_n252prioridad[0];
            A251detalle_tarea = DETALLE_IN2_A251detalle_tarea[0];
            n251detalle_tarea = DETALLE_IN2_n251detalle_tarea[0];
            A250id_actividad = DETALLE_IN2_A250id_actividad[0];
            n250id_actividad = DETALLE_IN2_n250id_actividad[0];
            A249id_categoria = DETALLE_IN2_A249id_categoria[0];
            n249id_categoria = DETALLE_IN2_n249id_categoria[0];
            A248detalle_infotecid_unidad = DETALLE_IN2_A248detalle_infotecid_unidad[0];
            n248detalle_infotecid_unidad = DETALLE_IN2_n248detalle_infotecid_unidad[0];
            A247correo_usuario = DETALLE_IN2_A247correo_usuario[0];
            n247correo_usuario = DETALLE_IN2_n247correo_usuario[0];
            A246depto_usuario = DETALLE_IN2_A246depto_usuario[0];
            n246depto_usuario = DETALLE_IN2_n246depto_usuario[0];
            A245nombre_usuario = DETALLE_IN2_A245nombre_usuario[0];
            n245nombre_usuario = DETALLE_IN2_n245nombre_usuario[0];
            A244trabajo = DETALLE_IN2_A244trabajo[0];
            n244trabajo = DETALLE_IN2_n244trabajo[0];
            A243estatus = DETALLE_IN2_A243estatus[0];
            n243estatus = DETALLE_IN2_n243estatus[0];
            A242hora_registro = DETALLE_IN2_A242hora_registro[0];
            n242hora_registro = DETALLE_IN2_n242hora_registro[0];
            A241fecha_registro = DETALLE_IN2_A241fecha_registro[0];
            n241fecha_registro = DETALLE_IN2_n241fecha_registro[0];
            A240cargo_emp = DETALLE_IN2_A240cargo_emp[0];
            n240cargo_emp = DETALLE_IN2_n240cargo_emp[0];
            A239nombre_emp = DETALLE_IN2_A239nombre_emp[0];
            n239nombre_emp = DETALLE_IN2_n239nombre_emp[0];
            A238correlativo = DETALLE_IN2_A238correlativo[0];
            A40000GXC1 = DETALLE_IN2_A40000GXC1[0];
            A40001GXC2 = DETALLE_IN2_A40001GXC2[0];
            /*
               INSERT RECORD ON TABLE GXA0017

            */
            AV2correlativo = A238correlativo;
            if ( DETALLE_IN2_n239nombre_emp[0] )
            {
               AV3nombre_emp = "";
               nV3nombre_emp = false;
               nV3nombre_emp = true;
            }
            else
            {
               AV3nombre_emp = A239nombre_emp;
               nV3nombre_emp = false;
            }
            if ( DETALLE_IN2_n240cargo_emp[0] )
            {
               AV4cargo_emp = "";
               nV4cargo_emp = false;
               nV4cargo_emp = true;
            }
            else
            {
               AV4cargo_emp = A240cargo_emp;
               nV4cargo_emp = false;
            }
            if ( DETALLE_IN2_n241fecha_registro[0] )
            {
               AV5fecha_registro = DateTime.MinValue;
               nV5fecha_registro = false;
               nV5fecha_registro = true;
            }
            else
            {
               AV5fecha_registro = A241fecha_registro;
               nV5fecha_registro = false;
            }
            if ( DETALLE_IN2_n242hora_registro[0] )
            {
               AV6hora_registro = (DateTime)(DateTime.MinValue);
               nV6hora_registro = false;
               nV6hora_registro = true;
            }
            else
            {
               AV6hora_registro = A40000GXC1;
               nV6hora_registro = false;
            }
            if ( DETALLE_IN2_n243estatus[0] )
            {
               AV7estatus = "";
               nV7estatus = false;
               nV7estatus = true;
            }
            else
            {
               AV7estatus = A243estatus;
               nV7estatus = false;
            }
            if ( DETALLE_IN2_n244trabajo[0] )
            {
               AV8trabajo = "";
               nV8trabajo = false;
               nV8trabajo = true;
            }
            else
            {
               AV8trabajo = A244trabajo;
               nV8trabajo = false;
            }
            if ( DETALLE_IN2_n245nombre_usuario[0] )
            {
               AV9nombre_usuario = "";
               nV9nombre_usuario = false;
               nV9nombre_usuario = true;
            }
            else
            {
               AV9nombre_usuario = A245nombre_usuario;
               nV9nombre_usuario = false;
            }
            if ( DETALLE_IN2_n246depto_usuario[0] )
            {
               AV10depto_usuario = "";
               nV10depto_usuario = false;
               nV10depto_usuario = true;
            }
            else
            {
               AV10depto_usuario = A246depto_usuario;
               nV10depto_usuario = false;
            }
            if ( DETALLE_IN2_n247correo_usuario[0] )
            {
               AV11correo_usuario = "";
               nV11correo_usuario = false;
               nV11correo_usuario = true;
            }
            else
            {
               AV11correo_usuario = A247correo_usuario;
               nV11correo_usuario = false;
            }
            if ( DETALLE_IN2_n248detalle_infotecid_unidad[0] )
            {
               AV12detalle_infotecid_unidad = 0;
               nV12detalle_infotecid_unidad = false;
               nV12detalle_infotecid_unidad = true;
            }
            else
            {
               AV12detalle_infotecid_unidad = A248detalle_infotecid_unidad;
               nV12detalle_infotecid_unidad = false;
            }
            if ( DETALLE_IN2_n249id_categoria[0] )
            {
               AV13id_categoria = 0;
               nV13id_categoria = false;
               nV13id_categoria = true;
            }
            else
            {
               AV13id_categoria = A249id_categoria;
               nV13id_categoria = false;
            }
            if ( DETALLE_IN2_n250id_actividad[0] )
            {
               AV14id_actividad = 0;
               nV14id_actividad = false;
               nV14id_actividad = true;
            }
            else
            {
               AV14id_actividad = A250id_actividad;
               nV14id_actividad = false;
            }
            if ( DETALLE_IN2_n251detalle_tarea[0] )
            {
               AV15detalle_tarea = "";
               nV15detalle_tarea = false;
               nV15detalle_tarea = true;
            }
            else
            {
               AV15detalle_tarea = A251detalle_tarea;
               nV15detalle_tarea = false;
            }
            if ( DETALLE_IN2_n252prioridad[0] )
            {
               AV16prioridad = "";
               nV16prioridad = false;
               nV16prioridad = true;
            }
            else
            {
               AV16prioridad = A252prioridad;
               nV16prioridad = false;
            }
            if ( DETALLE_IN2_n253observaciones[0] )
            {
               AV17observaciones = "";
               nV17observaciones = false;
               nV17observaciones = true;
            }
            else
            {
               AV17observaciones = A253observaciones;
               nV17observaciones = false;
            }
            if ( DETALLE_IN2_n254fecha_solicitud[0] )
            {
               AV18fecha_solicitud = "";
               nV18fecha_solicitud = false;
               nV18fecha_solicitud = true;
            }
            else
            {
               AV18fecha_solicitud = A254fecha_solicitud;
               nV18fecha_solicitud = false;
            }
            if ( DETALLE_IN2_n255fecha_ciere[0] )
            {
               AV19fecha_ciere = DateTime.MinValue;
               nV19fecha_ciere = false;
               nV19fecha_ciere = true;
            }
            else
            {
               AV19fecha_ciere = A255fecha_ciere;
               nV19fecha_ciere = false;
            }
            if ( DETALLE_IN2_n256hora_cierra[0] )
            {
               AV20hora_cierra = (DateTime)(DateTime.MinValue);
               nV20hora_cierra = false;
               nV20hora_cierra = true;
            }
            else
            {
               AV20hora_cierra = A40001GXC2;
               nV20hora_cierra = false;
            }
            /* Using cursor DETALLE_IN3 */
            pr_default.execute(0, new Object[] {AV2correlativo, nV3nombre_emp, AV3nombre_emp, nV4cargo_emp, AV4cargo_emp, nV5fecha_registro, AV5fecha_registro, nV6hora_registro, AV6hora_registro, nV7estatus, AV7estatus, nV8trabajo, AV8trabajo, nV9nombre_usuario, AV9nombre_usuario, nV10depto_usuario, AV10depto_usuario, nV11correo_usuario, AV11correo_usuario, nV12detalle_infotecid_unidad, AV12detalle_infotecid_unidad, nV13id_categoria, AV13id_categoria, nV14id_actividad, AV14id_actividad, nV15detalle_tarea, AV15detalle_tarea, nV16prioridad, AV16prioridad, nV17observaciones, AV17observaciones, nV18fecha_solicitud, AV18fecha_solicitud, nV19fecha_ciere, AV19fecha_ciere, nV20hora_cierra, AV20hora_cierra});
            pr_default.close(0);
            dsDefault.SmartCacheProvider.SetUpdated("GXA0017");
            if ( (pr_default.getStatus(0) == 1) )
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
            pr_datastore1.readNext(0);
         }
         pr_datastore1.close(0);
         cmdBuffer=" SET IDENTITY_INSERT dbo.[GXA0017] OFF "
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
         DETALLE_IN2_A256hora_cierra = new int[1] ;
         DETALLE_IN2_n256hora_cierra = new bool[] {false} ;
         DETALLE_IN2_A255fecha_ciere = new DateTime[] {DateTime.MinValue} ;
         DETALLE_IN2_n255fecha_ciere = new bool[] {false} ;
         DETALLE_IN2_A254fecha_solicitud = new string[] {""} ;
         DETALLE_IN2_n254fecha_solicitud = new bool[] {false} ;
         DETALLE_IN2_A253observaciones = new string[] {""} ;
         DETALLE_IN2_n253observaciones = new bool[] {false} ;
         DETALLE_IN2_A252prioridad = new string[] {""} ;
         DETALLE_IN2_n252prioridad = new bool[] {false} ;
         DETALLE_IN2_A251detalle_tarea = new string[] {""} ;
         DETALLE_IN2_n251detalle_tarea = new bool[] {false} ;
         DETALLE_IN2_A250id_actividad = new int[1] ;
         DETALLE_IN2_n250id_actividad = new bool[] {false} ;
         DETALLE_IN2_A249id_categoria = new int[1] ;
         DETALLE_IN2_n249id_categoria = new bool[] {false} ;
         DETALLE_IN2_A248detalle_infotecid_unidad = new int[1] ;
         DETALLE_IN2_n248detalle_infotecid_unidad = new bool[] {false} ;
         DETALLE_IN2_A247correo_usuario = new string[] {""} ;
         DETALLE_IN2_n247correo_usuario = new bool[] {false} ;
         DETALLE_IN2_A246depto_usuario = new string[] {""} ;
         DETALLE_IN2_n246depto_usuario = new bool[] {false} ;
         DETALLE_IN2_A245nombre_usuario = new string[] {""} ;
         DETALLE_IN2_n245nombre_usuario = new bool[] {false} ;
         DETALLE_IN2_A244trabajo = new string[] {""} ;
         DETALLE_IN2_n244trabajo = new bool[] {false} ;
         DETALLE_IN2_A243estatus = new string[] {""} ;
         DETALLE_IN2_n243estatus = new bool[] {false} ;
         DETALLE_IN2_A242hora_registro = new int[1] ;
         DETALLE_IN2_n242hora_registro = new bool[] {false} ;
         DETALLE_IN2_A241fecha_registro = new DateTime[] {DateTime.MinValue} ;
         DETALLE_IN2_n241fecha_registro = new bool[] {false} ;
         DETALLE_IN2_A240cargo_emp = new string[] {""} ;
         DETALLE_IN2_n240cargo_emp = new bool[] {false} ;
         DETALLE_IN2_A239nombre_emp = new string[] {""} ;
         DETALLE_IN2_n239nombre_emp = new bool[] {false} ;
         DETALLE_IN2_A238correlativo = new int[1] ;
         DETALLE_IN2_A40000GXC1 = new DateTime[] {DateTime.MinValue} ;
         DETALLE_IN2_A40001GXC2 = new DateTime[] {DateTime.MinValue} ;
         A255fecha_ciere = DateTime.MinValue;
         A254fecha_solicitud = "";
         A253observaciones = "";
         A252prioridad = "";
         A251detalle_tarea = "";
         A247correo_usuario = "";
         A246depto_usuario = "";
         A245nombre_usuario = "";
         A244trabajo = "";
         A243estatus = "";
         A241fecha_registro = DateTime.MinValue;
         A240cargo_emp = "";
         A239nombre_emp = "";
         A40000GXC1 = (DateTime)(DateTime.MinValue);
         A40001GXC2 = (DateTime)(DateTime.MinValue);
         AV3nombre_emp = "";
         AV4cargo_emp = "";
         AV5fecha_registro = DateTime.MinValue;
         AV6hora_registro = (DateTime)(DateTime.MinValue);
         AV7estatus = "";
         AV8trabajo = "";
         AV9nombre_usuario = "";
         AV10depto_usuario = "";
         AV11correo_usuario = "";
         AV15detalle_tarea = "";
         AV16prioridad = "";
         AV17observaciones = "";
         AV18fecha_solicitud = "";
         AV19fecha_ciere = DateTime.MinValue;
         AV20hora_cierra = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.detalle_infotecconversion__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.detalle_infotecconversion__datastore1(),
            new Object[][] {
                new Object[] {
               DETALLE_IN2_A256hora_cierra, DETALLE_IN2_n256hora_cierra, DETALLE_IN2_A255fecha_ciere, DETALLE_IN2_n255fecha_ciere, DETALLE_IN2_A254fecha_solicitud, DETALLE_IN2_n254fecha_solicitud, DETALLE_IN2_A253observaciones, DETALLE_IN2_n253observaciones, DETALLE_IN2_A252prioridad, DETALLE_IN2_n252prioridad,
               DETALLE_IN2_A251detalle_tarea, DETALLE_IN2_n251detalle_tarea, DETALLE_IN2_A250id_actividad, DETALLE_IN2_n250id_actividad, DETALLE_IN2_A249id_categoria, DETALLE_IN2_n249id_categoria, DETALLE_IN2_A248detalle_infotecid_unidad, DETALLE_IN2_n248detalle_infotecid_unidad, DETALLE_IN2_A247correo_usuario, DETALLE_IN2_n247correo_usuario,
               DETALLE_IN2_A246depto_usuario, DETALLE_IN2_n246depto_usuario, DETALLE_IN2_A245nombre_usuario, DETALLE_IN2_n245nombre_usuario, DETALLE_IN2_A244trabajo, DETALLE_IN2_n244trabajo, DETALLE_IN2_A243estatus, DETALLE_IN2_n243estatus, DETALLE_IN2_A242hora_registro, DETALLE_IN2_n242hora_registro,
               DETALLE_IN2_A241fecha_registro, DETALLE_IN2_n241fecha_registro, DETALLE_IN2_A240cargo_emp, DETALLE_IN2_n240cargo_emp, DETALLE_IN2_A239nombre_emp, DETALLE_IN2_n239nombre_emp, DETALLE_IN2_A238correlativo, DETALLE_IN2_A40000GXC1, DETALLE_IN2_A40001GXC2
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A256hora_cierra ;
      private int A250id_actividad ;
      private int A249id_categoria ;
      private int A248detalle_infotecid_unidad ;
      private int A242hora_registro ;
      private int A238correlativo ;
      private int GIGXA0017 ;
      private int AV2correlativo ;
      private int AV12detalle_infotecid_unidad ;
      private int AV13id_categoria ;
      private int AV14id_actividad ;
      private string cmdBuffer ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A40000GXC1 ;
      private DateTime A40001GXC2 ;
      private DateTime AV6hora_registro ;
      private DateTime AV20hora_cierra ;
      private DateTime A255fecha_ciere ;
      private DateTime A241fecha_registro ;
      private DateTime AV5fecha_registro ;
      private DateTime AV19fecha_ciere ;
      private bool n256hora_cierra ;
      private bool n255fecha_ciere ;
      private bool n254fecha_solicitud ;
      private bool n253observaciones ;
      private bool n252prioridad ;
      private bool n251detalle_tarea ;
      private bool n250id_actividad ;
      private bool n249id_categoria ;
      private bool n248detalle_infotecid_unidad ;
      private bool n247correo_usuario ;
      private bool n246depto_usuario ;
      private bool n245nombre_usuario ;
      private bool n244trabajo ;
      private bool n243estatus ;
      private bool n242hora_registro ;
      private bool n241fecha_registro ;
      private bool n240cargo_emp ;
      private bool n239nombre_emp ;
      private bool nV3nombre_emp ;
      private bool nV4cargo_emp ;
      private bool nV5fecha_registro ;
      private bool nV6hora_registro ;
      private bool nV7estatus ;
      private bool nV8trabajo ;
      private bool nV9nombre_usuario ;
      private bool nV10depto_usuario ;
      private bool nV11correo_usuario ;
      private bool nV12detalle_infotecid_unidad ;
      private bool nV13id_categoria ;
      private bool nV14id_actividad ;
      private bool nV15detalle_tarea ;
      private bool nV16prioridad ;
      private bool nV17observaciones ;
      private bool nV18fecha_solicitud ;
      private bool nV19fecha_ciere ;
      private bool nV20hora_cierra ;
      private string A254fecha_solicitud ;
      private string A253observaciones ;
      private string A252prioridad ;
      private string A251detalle_tarea ;
      private string A247correo_usuario ;
      private string A246depto_usuario ;
      private string A245nombre_usuario ;
      private string A244trabajo ;
      private string A243estatus ;
      private string A240cargo_emp ;
      private string A239nombre_emp ;
      private string AV3nombre_emp ;
      private string AV4cargo_emp ;
      private string AV7estatus ;
      private string AV8trabajo ;
      private string AV9nombre_usuario ;
      private string AV10depto_usuario ;
      private string AV11correo_usuario ;
      private string AV15detalle_tarea ;
      private string AV16prioridad ;
      private string AV17observaciones ;
      private string AV18fecha_solicitud ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] DETALLE_IN2_A256hora_cierra ;
      private bool[] DETALLE_IN2_n256hora_cierra ;
      private DateTime[] DETALLE_IN2_A255fecha_ciere ;
      private bool[] DETALLE_IN2_n255fecha_ciere ;
      private string[] DETALLE_IN2_A254fecha_solicitud ;
      private bool[] DETALLE_IN2_n254fecha_solicitud ;
      private string[] DETALLE_IN2_A253observaciones ;
      private bool[] DETALLE_IN2_n253observaciones ;
      private string[] DETALLE_IN2_A252prioridad ;
      private bool[] DETALLE_IN2_n252prioridad ;
      private string[] DETALLE_IN2_A251detalle_tarea ;
      private bool[] DETALLE_IN2_n251detalle_tarea ;
      private int[] DETALLE_IN2_A250id_actividad ;
      private bool[] DETALLE_IN2_n250id_actividad ;
      private int[] DETALLE_IN2_A249id_categoria ;
      private bool[] DETALLE_IN2_n249id_categoria ;
      private int[] DETALLE_IN2_A248detalle_infotecid_unidad ;
      private bool[] DETALLE_IN2_n248detalle_infotecid_unidad ;
      private string[] DETALLE_IN2_A247correo_usuario ;
      private bool[] DETALLE_IN2_n247correo_usuario ;
      private string[] DETALLE_IN2_A246depto_usuario ;
      private bool[] DETALLE_IN2_n246depto_usuario ;
      private string[] DETALLE_IN2_A245nombre_usuario ;
      private bool[] DETALLE_IN2_n245nombre_usuario ;
      private string[] DETALLE_IN2_A244trabajo ;
      private bool[] DETALLE_IN2_n244trabajo ;
      private string[] DETALLE_IN2_A243estatus ;
      private bool[] DETALLE_IN2_n243estatus ;
      private int[] DETALLE_IN2_A242hora_registro ;
      private bool[] DETALLE_IN2_n242hora_registro ;
      private DateTime[] DETALLE_IN2_A241fecha_registro ;
      private bool[] DETALLE_IN2_n241fecha_registro ;
      private string[] DETALLE_IN2_A240cargo_emp ;
      private bool[] DETALLE_IN2_n240cargo_emp ;
      private string[] DETALLE_IN2_A239nombre_emp ;
      private bool[] DETALLE_IN2_n239nombre_emp ;
      private int[] DETALLE_IN2_A238correlativo ;
      private DateTime[] DETALLE_IN2_A40000GXC1 ;
      private DateTime[] DETALLE_IN2_A40001GXC2 ;
      private IDataStoreProvider pr_default ;
   }

   public class detalle_infotecconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmDETALLE_IN3;
          prmDETALLE_IN3 = new Object[] {
          new ParDef("@AV2correlativo",GXType.Int32,9,0) ,
          new ParDef("@AV3nombre_emp",GXType.VarChar,300,0){Nullable=true} ,
          new ParDef("@AV4cargo_emp",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV5fecha_registro",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@AV6hora_registro",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("@AV7estatus",GXType.VarChar,30,0){Nullable=true} ,
          new ParDef("@AV8trabajo",GXType.VarChar,300,0){Nullable=true} ,
          new ParDef("@AV9nombre_usuario",GXType.VarChar,300,0){Nullable=true} ,
          new ParDef("@AV10depto_usuario",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("@AV11correo_usuario",GXType.VarChar,200,0){Nullable=true} ,
          new ParDef("@AV12detalle_infotecid_unidad",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV13id_categoria",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV14id_actividad",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV15detalle_tarea",GXType.VarChar,250,0){Nullable=true} ,
          new ParDef("@AV16prioridad",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("@AV17observaciones",GXType.VarChar,500,0){Nullable=true} ,
          new ParDef("@AV18fecha_solicitud",GXType.VarChar,300,0){Nullable=true} ,
          new ParDef("@AV19fecha_ciere",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@AV20hora_cierra",GXType.DateTime,8,5){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("DETALLE_IN3", "INSERT INTO [GXA0017]([correlativo], [nombre_emp], [cargo_emp], [fecha_registro], [hora_registro], [estatus], [trabajo], [nombre_usuario], [depto_usuario], [correo_usuario], [detalle_infotecid_unidad], [id_categoria], [id_actividad], [detalle_tarea], [prioridad], [observaciones], [fecha_solicitud], [fecha_ciere], [hora_cierra]) VALUES(@AV2correlativo, @AV3nombre_emp, @AV4cargo_emp, @AV5fecha_registro, @AV6hora_registro, @AV7estatus, @AV8trabajo, @AV9nombre_usuario, @AV10depto_usuario, @AV11correo_usuario, @AV12detalle_infotecid_unidad, @AV13id_categoria, @AV14id_actividad, @AV15detalle_tarea, @AV16prioridad, @AV17observaciones, @AV18fecha_solicitud, @AV19fecha_ciere, @AV20hora_cierra)", GxErrorMask.GX_NOMASK,prmDETALLE_IN3)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

 public class detalle_infotecconversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmDETALLE_IN2;
        prmDETALLE_IN2 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("DETALLE_IN2", "SELECT [hora_cierra], [fecha_ciere], [fecha_solicitud], [observaciones], [prioridad], [detalle_tarea], [id_actividad], [id_categoria], [id_unidad], [correo_usuario], [depto_usuario], [nombre_usuario], [trabajo], [estatus], [hora_registro], [fecha_registro], [cargo_emp], [nombre_emp], [correlativo], convert(int, 0) AS GXC1, convert(int, 0) AS GXC2 FROM dbo.[detalle_infotec] ORDER BY [correlativo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmDETALLE_IN2,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getVarchar(3);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              ((string[]) buf[6])[0] = rslt.getVarchar(4);
              ((bool[]) buf[7])[0] = rslt.wasNull(4);
              ((string[]) buf[8])[0] = rslt.getVarchar(5);
              ((bool[]) buf[9])[0] = rslt.wasNull(5);
              ((string[]) buf[10])[0] = rslt.getVarchar(6);
              ((bool[]) buf[11])[0] = rslt.wasNull(6);
              ((int[]) buf[12])[0] = rslt.getInt(7);
              ((bool[]) buf[13])[0] = rslt.wasNull(7);
              ((int[]) buf[14])[0] = rslt.getInt(8);
              ((bool[]) buf[15])[0] = rslt.wasNull(8);
              ((int[]) buf[16])[0] = rslt.getInt(9);
              ((bool[]) buf[17])[0] = rslt.wasNull(9);
              ((string[]) buf[18])[0] = rslt.getVarchar(10);
              ((bool[]) buf[19])[0] = rslt.wasNull(10);
              ((string[]) buf[20])[0] = rslt.getVarchar(11);
              ((bool[]) buf[21])[0] = rslt.wasNull(11);
              ((string[]) buf[22])[0] = rslt.getVarchar(12);
              ((bool[]) buf[23])[0] = rslt.wasNull(12);
              ((string[]) buf[24])[0] = rslt.getVarchar(13);
              ((bool[]) buf[25])[0] = rslt.wasNull(13);
              ((string[]) buf[26])[0] = rslt.getVarchar(14);
              ((bool[]) buf[27])[0] = rslt.wasNull(14);
              ((int[]) buf[28])[0] = rslt.getInt(15);
              ((bool[]) buf[29])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[30])[0] = rslt.getGXDate(16);
              ((bool[]) buf[31])[0] = rslt.wasNull(16);
              ((string[]) buf[32])[0] = rslt.getVarchar(17);
              ((bool[]) buf[33])[0] = rslt.wasNull(17);
              ((string[]) buf[34])[0] = rslt.getVarchar(18);
              ((bool[]) buf[35])[0] = rslt.wasNull(18);
              ((int[]) buf[36])[0] = rslt.getInt(19);
              ((DateTime[]) buf[37])[0] = rslt.getGXDateTime(20);
              ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(21);
              return;
     }
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

}
