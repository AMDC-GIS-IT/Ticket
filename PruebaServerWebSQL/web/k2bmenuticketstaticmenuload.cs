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

      public void release( )
      {
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
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPREGISTRARTICKET' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPASIGNARTICKETDESARROLLO' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPASIGNACION' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPASIGNACIONDESARROLLO' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWUSUARIO' */
         S171 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWTICKET' */
         S181 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWSATISFACCION' */
         S191 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPSATISFACCION' */
         S201 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWRESPONSABLE' */
         S211 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWUSUARIOSISTEMA' */
         S221 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWESTADOSATISFACCION' */
         S231 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWESTADOTICKET' */
         S241 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWETAPASDESARROLLO' */
         S251 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWWESTADOTECNICOS' */
         S261 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELTICKETSASIGNADOS' */
         S271 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELQUERYTICKET' */
         S281 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWPDBSATISFACCION' */
         S291 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELTAREASEMPLEADO' */
         S301 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELGRAFICOTICKETEMPLEADO' */
         S311 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELQUERYTIEMPOASIGNAR' */
         S321 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CHECKSECURITYFORWEBPANELQUERYTIEMPORESOLVER' */
         S331 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         new k2bisauthorizedactivitylist(context ).execute( ref  AV8ActivityList) ;
         GXt_boolean1 = true;
         new k2bmenuaddprogram(context ).execute(  "WPUsuario",  "Solicitud Soporte Técnico",  context.convertURL( (string)(context.GetImagePath( "fa6a193b-ecef-4338-a67f-8b555c6b57b2", "", context.GetTheme( )))),  "",  formatLink("wpusuario.aspx") ,  1,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean1, ref  AV10MenuLevel0) ;
         GXt_boolean2 = true;
         new k2bmenuaddprogram(context ).execute(  "Asignar Ticket",  "Asignación Ticket",  context.convertURL( (string)(context.GetImagePath( "25fa2834-2954-45d4-a217-7246113b0c49", "", context.GetTheme( )))),  "",  formatLink("wpregistrarticket.aspx") ,  2,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean2, ref  AV10MenuLevel0) ;
         GXt_boolean3 = true;
         new k2bmenuaddprogram(context ).execute(  "WPAsignarTicketDesarrollo",  "Asignar Ticket Desarrollo",  context.convertURL( (string)(context.GetImagePath( "25fa2834-2954-45d4-a217-7246113b0c49", "", context.GetTheme( )))),  "",  formatLink("wpasignarticketdesarrollo.aspx") ,  3,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean3, ref  AV10MenuLevel0) ;
         GXt_boolean4 = true;
         new k2bmenuaddprogram(context ).execute(  "WPAsignacion",  "Solución Ticket ",  context.convertURL( (string)(context.GetImagePath( "d9b8b1a3-2d2c-4f51-961b-a13b4377c63b", "", context.GetTheme( )))),  "",  formatLink("wpasignacion.aspx") ,  4,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean4, ref  AV10MenuLevel0) ;
         GXt_boolean5 = true;
         new k2bmenuaddprogram(context ).execute(  "WPAsignacionDesarrollo",  "Solución Desarrollo",  context.convertURL( (string)(context.GetImagePath( "d9b8b1a3-2d2c-4f51-961b-a13b4377c63b", "", context.GetTheme( )))),  "",  formatLink("wpasignaciondesarrollo.aspx") ,  5,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean5, ref  AV10MenuLevel0) ;
         GXt_boolean6 = true;
         new k2bmenuaddprogram(context ).execute(  "WWUsuario",  "Transacción Usuario",  context.convertURL( (string)(context.GetImagePath( "fa6a193b-ecef-4338-a67f-8b555c6b57b2", "", context.GetTheme( )))),  "",  formatLink("wwusuario.aspx") ,  6,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean6, ref  AV10MenuLevel0) ;
         GXt_boolean7 = true;
         new k2bmenuaddprogram(context ).execute(  "WWTicket",  "Transacción Ticket",  context.convertURL( (string)(context.GetImagePath( "25fa2834-2954-45d4-a217-7246113b0c49", "", context.GetTheme( )))),  "",  formatLink("wwticket.aspx") ,  7,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean7, ref  AV10MenuLevel0) ;
         GXt_boolean8 = true;
         new k2bmenuaddprogram(context ).execute(  "WWSatisfaccion",  "Transacción Encuesta Satisfacción",  context.convertURL( (string)(context.GetImagePath( "25fa2834-2954-45d4-a217-7246113b0c49", "", context.GetTheme( )))),  "",  formatLink("wwsatisfaccion.aspx") ,  8,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean8, ref  AV10MenuLevel0) ;
         GXt_boolean9 = true;
         new k2bmenuaddprogram(context ).execute(  "WPSatisfaccion",  "Encuesta Satisfacción",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wpsatisfaccion.aspx") ,  9,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean9, ref  AV10MenuLevel0) ;
         GXt_boolean10 = true;
         new k2bmenuaddprogram(context ).execute(  "WWResponsable",  "Técnicos GIS",  context.convertURL( (string)(context.GetImagePath( "8aadadc7-1113-4f45-84ab-4b6f760dbecf", "", context.GetTheme( )))),  "",  formatLink("wwresponsable.aspx") ,  10,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean10, ref  AV10MenuLevel0) ;
         GXt_boolean11 = true;
         new k2bmenuaddprogram(context ).execute(  "WWUsuarioSistema",  "Usuario Sistema",  context.convertURL( (string)(context.GetImagePath( "c0707835-6985-42c0-bf24-54b2679c24dd", "", context.GetTheme( )))),  "",  formatLink("wwusuariosistema.aspx") ,  11,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean11, ref  AV10MenuLevel0) ;
         GXt_boolean12 = true;
         new k2bmenuaddprogram(context ).execute(  "WWEstadoSatisfaccion",  "Estado Satisfacción",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wwestadosatisfaccion.aspx") ,  12,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean12, ref  AV10MenuLevel0) ;
         GXt_boolean13 = true;
         new k2bmenuaddprogram(context ).execute(  "WWEstadoTicket",  "Estado Ticket",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wwestadoticket.aspx") ,  13,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean13, ref  AV10MenuLevel0) ;
         GXt_boolean14 = true;
         new k2bmenuaddprogram(context ).execute(  "WWEtapasDesarrollo",  "Etapas desarrollos",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wwetapasdesarrollo.aspx") ,  14,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean14, ref  AV10MenuLevel0) ;
         GXt_boolean15 = true;
         new k2bmenuaddprogram(context ).execute(  "WWEstadoTecnicos",  "Estado Técnicos",  context.convertURL( (string)(context.GetImagePath( "5649fbb8-8ce0-4810-a5ce-bd649ea83c3a", "", context.GetTheme( )))),  "",  formatLink("wwestadotecnicos.aspx") ,  15,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean15, ref  AV10MenuLevel0) ;
         /* Execute user subroutine: 'ADDSMREPORTE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDSMREPORTE' Routine */
         returnInSub = false;
         AV12MenuLevel1 = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         AV12MenuLevel1.gxTpr_Code = "smReporte";
         AV12MenuLevel1.gxTpr_Title = "Reportes";
         GXt_boolean15 = true;
         new k2bmenusetshowin(context ).execute(  true,  true,  true, ref  GXt_boolean15, ref  AV12MenuLevel1) ;
         AV12MenuLevel1.gxTpr_Items = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         AV12MenuLevel1.gxTpr_Imageurl = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         GXt_boolean15 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelTicketsAsignados",  "Ticket Asignados",  "",  "",  formatLink("webpanelticketsasignados.aspx") ,  16,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean15, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16;
         GXt_boolean14 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem17 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelQueryTicket",  "Consulta Ticket",  "",  "",  formatLink("webpanelqueryticket.aspx") ,  17,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean14, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem17) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem17;
         GXt_boolean13 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WpDbSatisfaccion",  "Consulta Encuesta Satisfacción",  "",  "",  formatLink("wpdbsatisfaccion.aspx") ,  18,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean13, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18;
         GXt_boolean12 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem19 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelTareasEmpleado",  "Tareas Empleados",  "",  "",  formatLink("webpaneltareasempleado.aspx") ,  19,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean12, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem19) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem19;
         GXt_boolean11 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem20 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelGraficoTicketEmpleado",  "Gráfico Tickets Empleado",  "",  "",  formatLink("webpanelgraficoticketempleado.aspx") ,  20,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean11, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem20) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem20;
         GXt_boolean10 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem21 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelQueryTiempoAsignar",  "Tiempo Asignar Ticket",  "",  "",  formatLink("webpanelquerytiempoasignar.aspx") ,  21,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean10, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem21) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem21;
         GXt_boolean9 = true;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem22 = AV12MenuLevel1.gxTpr_Items;
         new k2bmenuaddprogram(context ).execute(  "WebPanelQueryTiempoResolver",  "Tiempo Resolver Ticket",  "",  "",  formatLink("webpanelquerytiemporesolver.aspx") ,  22,  AV8ActivityList,  true,  true,  true, ref  GXt_boolean9, ref  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem22) ;
         AV12MenuLevel1.gxTpr_Items = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem22;
         if ( AV12MenuLevel1.gxTpr_Items.Count > 0 )
         {
            AV10MenuLevel0.Add(AV12MenuLevel1, 0);
         }
      }

      protected void S121( )
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

      protected void S131( )
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

      protected void S141( )
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

      protected void S151( )
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

      protected void S161( )
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

      protected void S171( )
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

      protected void S181( )
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

      protected void S191( )
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

      protected void S201( )
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

      protected void S211( )
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

      protected void S221( )
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

      protected void S231( )
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

      protected void S241( )
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

      protected void S251( )
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

      protected void S261( )
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

      protected void S271( )
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

      protected void S281( )
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

      protected void S291( )
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

      protected void S301( )
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

      protected void S311( )
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

      protected void S321( )
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

      protected void S331( )
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
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem17 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem19 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem20 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem21 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem22 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "kb_ticket");
         AV9ActivityItem = new SdtK2BActivityList_K2BActivityListItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool GXt_boolean2 ;
      private bool GXt_boolean3 ;
      private bool GXt_boolean4 ;
      private bool GXt_boolean5 ;
      private bool GXt_boolean6 ;
      private bool GXt_boolean7 ;
      private bool GXt_boolean8 ;
      private bool GXt_boolean15 ;
      private bool GXt_boolean14 ;
      private bool GXt_boolean13 ;
      private bool GXt_boolean12 ;
      private bool GXt_boolean11 ;
      private bool GXt_boolean10 ;
      private bool GXt_boolean9 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuLevel0 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV8ActivityList ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> AV10MenuLevel0 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem16 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem17 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem18 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem19 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem20 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem21 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem22 ;
      private SdtK2BActivityList_K2BActivityListItem AV9ActivityItem ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem AV12MenuLevel1 ;
   }

}
