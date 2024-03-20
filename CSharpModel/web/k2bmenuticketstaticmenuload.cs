using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class k2bmenuticketstaticmenuload : GXProcedure
   {
      public k2bmenuticketstaticmenuload( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bmenuticketstaticmenuload( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuLevel0 )
      {
         this.AV10MenuLevel0 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket") ;
         initialize();
         executePrivate();
         aP0_MenuLevel0=this.AV10MenuLevel0;
      }

      public GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> executeUdp( )
      {
         execute(out aP0_MenuLevel0);
         return AV10MenuLevel0 ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuLevel0 )
      {
         k2bmenuticketstaticmenuload objk2bmenuticketstaticmenuload;
         objk2bmenuticketstaticmenuload = new k2bmenuticketstaticmenuload();
         objk2bmenuticketstaticmenuload.AV10MenuLevel0 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket") ;
         objk2bmenuticketstaticmenuload.context.SetSubmitInitialConfig(context);
         objk2bmenuticketstaticmenuload.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bmenuticketstaticmenuload);
         aP0_MenuLevel0=this.AV10MenuLevel0;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bmenuticketstaticmenuload)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'CHECKSECURITYFORWPUSUARIO' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPREGISTRARTICKET' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPASIGNACIONADMIN' */
         S171 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPASIGNARTICKETDESARROLLO' */
         S181 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPASIGNACION' */
         S191 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPASIGNACIONDESARROLLO' */
         S201 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPSATISFACCION' */
         S211 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPBUSCARTDAPLICACIONES' */
         S221 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPBUSCARTDDESARROLLO' */
         S231 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPBUSCARTDSOPORTE' */
         S241 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWUSUARIO' */
         S251 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWTICKET' */
         S261 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWSATISFACCION' */
         S271 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWDETALLE_INFOTEC' */
         S281 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWETAPASDESARROLLO' */
         S291 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWCATEGORIADETALLETAREA' */
         S301 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWESTADOTECNICOS' */
         S311 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWESTADOTICKET' */
         S321 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWESTADOSATISFACCION' */
         S331 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWRESPONSABLE' */
         S341 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWUSUARIOSISTEMA' */
         S351 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWAREASATENCION' */
         S361 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWLISTAREQUERIMIENTOS' */
         S371 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELTICKETSASIGNADOS' */
         S381 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELQUERYTICKET' */
         S391 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPDBSATISFACCION' */
         S401 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELTAREASEMPLEADO' */
         S411 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELGRAFICOTICKETEMPLEADO' */
         S421 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELQUERYTIEMPOASIGNAR' */
         S431 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELQUERYTIEMPORESOLVER' */
         S441 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELTRABAJODIARIO' */
         S451 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELTRABAJODIARIOADMIN' */
         S461 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPDBSATISFACCIONDESARROLLO' */
         S471 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         new k2bisauthorizedactivitylist(context ).execute( ref  AV8ActivityList) ;
         GXt_boolean1 = true;
         new k2bmenuaddprogram(context ).execute(  "WPUsuario",  "Abrir Ticket",  context.convertURL( (string)(context.GetImagePath( "fa6a193b-ecef-4338-a67f-8b555c6b57b2", "", context.GetTheme( )))),  "",  formatLink("wpusuario.aspx") ,  1,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean1, ref  AV10MenuLevel0) ;
         GXt_boolean2 = true;
         new k2bmenuaddprogram(context ).execute(  "Asignar Ticket",  "Asignación Ticket",  context.convertURL( (string)(context.GetImagePath( "25fa2834-2954-45d4-a217-7246113b0c49", "", context.GetTheme( )))),  "",  formatLink("wpregistrarticket.aspx") ,  2,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean2, ref  AV10MenuLevel0) ;
         GXt_boolean3 = true;
         new k2bmenuaddprogram(context ).execute(  "WPAsignacionAdmin",  "Orden de Trabajo",  context.convertURL( (string)(context.GetImagePath( "bc80c103-5523-45a1-b084-18e21da26d5e", "", context.GetTheme( )))),  "",  formatLink("wpasignacionadmin.aspx") ,  3,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean3, ref  AV10MenuLevel0) ;
         GXt_boolean4 = true;
         new k2bmenuaddprogram(context ).execute(  "WPAsignarTicketDesarrollo",  "Asignar Ticket Desarrollo",  context.convertURL( (string)(context.GetImagePath( "25fa2834-2954-45d4-a217-7246113b0c49", "", context.GetTheme( )))),  "",  formatLink("wpasignarticketdesarrollo.aspx") ,  4,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean4, ref  AV10MenuLevel0) ;
         GXt_boolean5 = true;
         new k2bmenuaddprogram(context ).execute(  "WPAsignacion",  "Solución Ticket ",  context.convertURL( (string)(context.GetImagePath( "d9b8b1a3-2d2c-4f51-961b-a13b4377c63b", "", context.GetTheme( )))),  "",  formatLink("wpasignacion.aspx") ,  5,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean5, ref  AV10MenuLevel0) ;
         GXt_boolean6 = true;
         new k2bmenuaddprogram(context ).execute(  "WPAsignacionDesarrollo",  "Solución Desarrollo",  context.convertURL( (string)(context.GetImagePath( "d9b8b1a3-2d2c-4f51-961b-a13b4377c63b", "", context.GetTheme( )))),  "",  formatLink("wpasignaciondesarrollo.aspx") ,  6,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean6, ref  AV10MenuLevel0) ;
         GXt_boolean7 = true;
         new k2bmenuaddprogram(context ).execute(  "WPSatisfaccion",  "Encuesta Satisfacción",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wpsatisfaccion.aspx") ,  7,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean7, ref  AV10MenuLevel0) ;
         /* Execute user subroutine: 'ADDSMTRABAJODIARIO' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'ADDSMTRANSACCION' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'ADDSMMANTENIMIENTO' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'ADDSMREPORTE' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDSMTRABAJODIARIO' Routine */
         returnInSub = false;
         AV12MenuLevel1 = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         AV12MenuLevel1.gxTpr_Code = "smTrabajoDiario";
         AV12MenuLevel1.gxTpr_Title = "Registro Trabajo Diario";
         GXt_boolean7 = true;
         new k2bmenusetshowin(context ).execute(  true,  true,  true, ref  GXt_boolean7, ref  AV12MenuLevel1) ;
         AV12MenuLevel1.gxTpr_Items = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         AV12MenuLevel1.gxTpr_Imageurl = context.convertURL( (string)(context.GetImagePath( "c7b69fd4-63be-4d84-8005-0bd75b75b6b1", "", context.GetTheme( ))));
         GXt_boolean7 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WpBuscarTdAplicaciones",  "Aplicaciones",  "",  "",  formatLink("wpbuscartdaplicaciones.aspx") ,  8,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean7, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8;
         GXt_boolean6 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WpBuscarTdDesarrollo",  "Desarrollo - Base de Datos",  "",  "",  formatLink("wpbuscartddesarrollo.aspx") ,  9,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean6, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9;
         GXt_boolean5 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WpBuscarTdSoporte",  "Soporte Técnico",  "",  "",  formatLink("wpbuscartdsoporte.aspx") ,  10,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean5, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10;
         if ( AV12MenuLevel1.gxTpr_Items.Count > 0 )
         {
            AV10MenuLevel0.Add(AV12MenuLevel1, 0);
         }
      }

      protected void S121( )
      {
         /* 'ADDSMTRANSACCION' Routine */
         returnInSub = false;
         AV12MenuLevel1 = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         AV12MenuLevel1.gxTpr_Code = "smTransaccion";
         AV12MenuLevel1.gxTpr_Title = "Transacción";
         GXt_boolean7 = true;
         new k2bmenusetshowin(context ).execute(  true,  true,  true, ref  GXt_boolean7, ref  AV12MenuLevel1) ;
         AV12MenuLevel1.gxTpr_Items = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         AV12MenuLevel1.gxTpr_Imageurl = context.convertURL( (string)(context.GetImagePath( "c7b69fd4-63be-4d84-8005-0bd75b75b6b1", "", context.GetTheme( ))));
         GXt_boolean7 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWUsuario",  "Usuario",  context.convertURL( (string)(context.GetImagePath( "fa6a193b-ecef-4338-a67f-8b555c6b57b2", "", context.GetTheme( )))),  "",  formatLink("wwusuario.aspx") ,  11,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean7, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10;
         GXt_boolean6 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWTicket",  "Tickets",  context.convertURL( (string)(context.GetImagePath( "d9b8b1a3-2d2c-4f51-961b-a13b4377c63b", "", context.GetTheme( )))),  "",  formatLink("wwticket.aspx") ,  12,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean6, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9;
         GXt_boolean5 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWSatisfaccion",  "Encuesta de Satisfacción",  context.convertURL( (string)(context.GetImagePath( "25fa2834-2954-45d4-a217-7246113b0c49", "", context.GetTheme( )))),  "",  formatLink("wwsatisfaccion.aspx") ,  13,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean5, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8;
         GXt_boolean4 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWdetalle_infotec",  "Infotec",  "",  "",  formatLink("wwdetalle_infotec.aspx") ,  14,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean4, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11;
         if ( AV12MenuLevel1.gxTpr_Items.Count > 0 )
         {
            AV10MenuLevel0.Add(AV12MenuLevel1, 0);
         }
      }

      protected void S131( )
      {
         /* 'ADDSMMANTENIMIENTO' Routine */
         returnInSub = false;
         AV12MenuLevel1 = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         AV12MenuLevel1.gxTpr_Code = "smMantenimiento";
         AV12MenuLevel1.gxTpr_Title = "Mantenimiento";
         GXt_boolean7 = true;
         new k2bmenusetshowin(context ).execute(  true,  true,  true, ref  GXt_boolean7, ref  AV12MenuLevel1) ;
         AV12MenuLevel1.gxTpr_Items = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         AV12MenuLevel1.gxTpr_Imageurl = context.convertURL( (string)(context.GetImagePath( "c7b69fd4-63be-4d84-8005-0bd75b75b6b1", "", context.GetTheme( ))));
         GXt_boolean7 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWEtapasDesarrollo",  "Etapas de Desarrollo",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wwetapasdesarrollo.aspx") ,  15,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean7, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11;
         GXt_boolean6 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWCategoriaDetalleTarea",  "Categoría Detalle Tarea",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wwcategoriadetalletarea.aspx") ,  16,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean6, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10;
         GXt_boolean5 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWEstadoTecnicos",  "Estado Técnicos",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wwestadotecnicos.aspx") ,  17,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean5, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9;
         GXt_boolean4 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWEstadoTicket",  "Estado Ticket",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wwestadoticket.aspx") ,  18,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean4, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8;
         GXt_boolean3 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWEstadoSatisfaccion",  "Estado Satisfacción",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wwestadosatisfaccion.aspx") ,  19,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean3, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12;
         GXt_boolean2 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem13 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWResponsable",  "Técnicos GIS",  context.convertURL( (string)(context.GetImagePath( "8aadadc7-1113-4f45-84ab-4b6f760dbecf", "", context.GetTheme( )))),  "",  formatLink("wwresponsable.aspx") ,  20,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean2, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem13) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem13;
         GXt_boolean1 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWUsuarioSistema",  "Usuario Sistema",  context.convertURL( (string)(context.GetImagePath( "c0707835-6985-42c0-bf24-54b2679c24dd", "", context.GetTheme( )))),  "",  formatLink("wwusuariosistema.aspx") ,  21,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean1, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14;
         GXt_boolean15 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWAreasAtencion",  "Áreas de Atención",  "",  "",  formatLink("wwareasatencion.aspx") ,  22,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean15, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16;
         GXt_boolean17 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WWListaRequerimientos",  "Lista Requerimientos",  "",  "",  formatLink("wwlistarequerimientos.aspx") ,  23,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean17, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18;
         if ( AV12MenuLevel1.gxTpr_Items.Count > 0 )
         {
            AV10MenuLevel0.Add(AV12MenuLevel1, 0);
         }
      }

      protected void S141( )
      {
         /* 'ADDSMREPORTE' Routine */
         returnInSub = false;
         AV12MenuLevel1 = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         AV12MenuLevel1.gxTpr_Code = "smReporte";
         AV12MenuLevel1.gxTpr_Title = "Reportes";
         GXt_boolean17 = true;
         new k2bmenusetshowin(context ).execute(  true,  true,  true, ref  GXt_boolean17, ref  AV12MenuLevel1) ;
         AV12MenuLevel1.gxTpr_Items = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         AV12MenuLevel1.gxTpr_Imageurl = context.convertURL( (string)(context.GetImagePath( "c7b69fd4-63be-4d84-8005-0bd75b75b6b1", "", context.GetTheme( ))));
         GXt_boolean17 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelTicketsAsignados",  "Ticket Asignados",  "",  "",  formatLink("webpanelticketsasignados.aspx") ,  24,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean17, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18;
         GXt_boolean15 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelQueryTicket",  "Consulta Ticket",  "",  "",  formatLink("webpanelqueryticket.aspx") ,  25,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean15, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16;
         GXt_boolean7 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WpDbSatisfaccion",  "Consulta Encuesta Satisfacción Soporte",  "",  "",  formatLink("wpdbsatisfaccion.aspx") ,  26,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean7, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14;
         GXt_boolean6 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem13 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelTareasEmpleado",  "Tareas Empleados",  "",  "",  formatLink("webpaneltareasempleado.aspx") ,  27,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean6, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem13) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem13;
         GXt_boolean5 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelGraficoTicketEmpleado",  "Gráfico Tickets Empleado",  "",  "",  formatLink("webpanelgraficoticketempleado.aspx") ,  28,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean5, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12;
         GXt_boolean4 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelQueryTiempoAsignar",  "Tiempo Asignar Ticket",  "",  "",  formatLink("webpanelquerytiempoasignar.aspx") ,  29,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean4, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11;
         GXt_boolean3 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelQueryTiempoResolver",  "Tiempo Resolver Ticket",  "",  "",  formatLink("webpanelquerytiemporesolver.aspx") ,  30,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean3, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10;
         GXt_boolean2 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelTrabajoDiario",  "Trabajo Diario Empleado",  "",  "",  formatLink("webpaneltrabajodiario.aspx") ,  31,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean2, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9;
         GXt_boolean1 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelTrabajoDiarioAdmin",  "Reporte Trabajo Diario",  "",  "",  formatLink("webpaneltrabajodiarioadmin.aspx") ,  32,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean1, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8;
         GXt_boolean19 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem20 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WpDbSatisfaccionDesarrollo",  "Consulta Encuesta Satisfacción Desarrollo",  "",  "",  formatLink("wpdbsatisfacciondesarrollo.aspx") ,  33,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean19, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem20) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem20;
         if ( AV12MenuLevel1.gxTpr_Items.Count > 0 )
         {
            AV10MenuLevel0.Add(AV12MenuLevel1, 0);
         }
      }

      protected void S151( )
      {
         /* 'CHECKSECURITYFORWPUSUARIO' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WPUsuario";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WPUsuario";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S161( )
      {
         /* 'CHECKSECURITYFORWPREGISTRARTICKET' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WPRegistrarTicket";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WPRegistrarTicket";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S171( )
      {
         /* 'CHECKSECURITYFORWPASIGNACIONADMIN' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WPAsignacionAdmin";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WPAsignacionAdmin";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S181( )
      {
         /* 'CHECKSECURITYFORWPASIGNARTICKETDESARROLLO' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WPAsignarTicketDesarrollo";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WPAsignarTicketDesarrollo";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S191( )
      {
         /* 'CHECKSECURITYFORWPASIGNACION' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WPAsignacion";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WPAsignacion";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S201( )
      {
         /* 'CHECKSECURITYFORWPASIGNACIONDESARROLLO' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WPAsignacionDesarrollo";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WPAsignacionDesarrollo";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S211( )
      {
         /* 'CHECKSECURITYFORWPSATISFACCION' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WPSatisfaccion";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WPSatisfaccion";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S221( )
      {
         /* 'CHECKSECURITYFORWPBUSCARTDAPLICACIONES' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WpBuscarTdAplicaciones";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WpBuscarTdAplicaciones";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S231( )
      {
         /* 'CHECKSECURITYFORWPBUSCARTDDESARROLLO' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WpBuscarTdDesarrollo";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WpBuscarTdDesarrollo";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S241( )
      {
         /* 'CHECKSECURITYFORWPBUSCARTDSOPORTE' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WpBuscarTdSoporte";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WpBuscarTdSoporte";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S251( )
      {
         /* 'CHECKSECURITYFORWWUSUARIO' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "Usuario";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "Usuario";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWUsuario";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S261( )
      {
         /* 'CHECKSECURITYFORWWTICKET' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "Ticket";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "Ticket";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWTicket";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S271( )
      {
         /* 'CHECKSECURITYFORWWSATISFACCION' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "Satisfaccion";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "Satisfaccion";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWSatisfaccion";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S281( )
      {
         /* 'CHECKSECURITYFORWWDETALLE_INFOTEC' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "detalle_infotec";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "detalle_infotec";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWdetalle_infotec";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S291( )
      {
         /* 'CHECKSECURITYFORWWETAPASDESARROLLO' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "EtapasDesarrollo";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "EtapasDesarrollo";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWEtapasDesarrollo";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S301( )
      {
         /* 'CHECKSECURITYFORWWCATEGORIADETALLETAREA' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "CategoriaDetalleTarea";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "CategoriaDetalleTarea";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWCategoriaDetalleTarea";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S311( )
      {
         /* 'CHECKSECURITYFORWWESTADOTECNICOS' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTecnicos";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTecnicos";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWEstadoTecnicos";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S321( )
      {
         /* 'CHECKSECURITYFORWWESTADOTICKET' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "EstadoTicket";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoTicket";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWEstadoTicket";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S331( )
      {
         /* 'CHECKSECURITYFORWWESTADOSATISFACCION' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "EstadoSatisfaccion";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "EstadoSatisfaccion";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWEstadoSatisfaccion";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S341( )
      {
         /* 'CHECKSECURITYFORWWRESPONSABLE' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "Responsable";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "Responsable";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWResponsable";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S351( )
      {
         /* 'CHECKSECURITYFORWWUSUARIOSISTEMA' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWUsuarioSistema";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S361( )
      {
         /* 'CHECKSECURITYFORWWAREASATENCION' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "AreasAtencion";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "AreasAtencion";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWAreasAtencion";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S371( )
      {
         /* 'CHECKSECURITYFORWWLISTAREQUERIMIENTOS' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "ListaRequerimientos";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "ListaRequerimientos";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WWListaRequerimientos";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S381( )
      {
         /* 'CHECKSECURITYFORWEBPANELTICKETSASIGNADOS' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WebPanelTicketsAsignados";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WebPanelTicketsAsignados";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S391( )
      {
         /* 'CHECKSECURITYFORWEBPANELQUERYTICKET' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WebPanelQueryTicket";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WebPanelQueryTicket";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S401( )
      {
         /* 'CHECKSECURITYFORWPDBSATISFACCION' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WpDbSatisfaccion";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WpDbSatisfaccion";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S411( )
      {
         /* 'CHECKSECURITYFORWEBPANELTAREASEMPLEADO' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WebPanelTareasEmpleado";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WebPanelTareasEmpleado";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S421( )
      {
         /* 'CHECKSECURITYFORWEBPANELGRAFICOTICKETEMPLEADO' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WebPanelGraficoTicketEmpleado";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WebPanelGraficoTicketEmpleado";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S431( )
      {
         /* 'CHECKSECURITYFORWEBPANELQUERYTIEMPOASIGNAR' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WebPanelQueryTiempoAsignar";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WebPanelQueryTiempoAsignar";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S441( )
      {
         /* 'CHECKSECURITYFORWEBPANELQUERYTIEMPORESOLVER' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WebPanelQueryTiempoResolver";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WebPanelQueryTiempoResolver";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S451( )
      {
         /* 'CHECKSECURITYFORWEBPANELTRABAJODIARIO' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WebPanelTrabajoDiario";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WebPanelTrabajoDiario";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S461( )
      {
         /* 'CHECKSECURITYFORWEBPANELTRABAJODIARIOADMIN' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WebPanelTrabajoDiarioAdmin";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WebPanelTrabajoDiarioAdmin";
         AV8ActivityList.Add(AV9ActivityItem, 0);
      }

      protected void S471( )
      {
         /* 'CHECKSECURITYFORWPDBSATISFACCIONDESARROLLO' Routine */
         returnInSub = false;
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV9ActivityItem.gxTpr_Activity.gxTpr_Entityname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Transactionname = "";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Standardactivitytype = "None";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Useractivitytype = "WpDbSatisfaccionDesarrollo";
         AV9ActivityItem.gxTpr_Activity.gxTpr_Pgmname = "WpDbSatisfaccionDesarrollo";
         AV8ActivityList.Add(AV9ActivityItem, 0);
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
         AV10MenuLevel0 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         AV8ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV12MenuLevel1 = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem13 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem20 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool returnInSub ;
      private bool GXt_boolean17 ;
      private bool GXt_boolean15 ;
      private bool GXt_boolean7 ;
      private bool GXt_boolean6 ;
      private bool GXt_boolean5 ;
      private bool GXt_boolean4 ;
      private bool GXt_boolean3 ;
      private bool GXt_boolean2 ;
      private bool GXt_boolean1 ;
      private bool GXt_boolean19 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuLevel0 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV8ActivityList ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> AV10MenuLevel0 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem14 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem13 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem12 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem11 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem10 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem9 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem8 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem20 ;
      private SdtK2BActivityList_K2BActivityListItem AV9ActivityItem ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem AV12MenuLevel1 ;
   }

}
