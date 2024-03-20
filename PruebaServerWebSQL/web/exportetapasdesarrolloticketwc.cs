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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class exportetapasdesarrolloticketwc : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("K2BOrion");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "EtapaDesarrolloId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8EtapaDesarrolloId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11TicketFecha_From = context.localUtil.ParseDateParm( GetPar( "TicketFecha_From"));
                  AV12TicketFecha_To = context.localUtil.ParseDateParm( GetPar( "TicketFecha_To"));
                  AV14TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_From")));
                  AV15TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_To")));
                  AV16UsuarioNombre = GetPar( "UsuarioNombre");
                  AV17EstadoTicketTicketNombre = GetPar( "EstadoTicketTicketNombre");
                  AV19TicketFechaHora_From = context.localUtil.ParseDTimeParm( GetPar( "TicketFechaHora_From"));
                  AV20TicketFechaHora_To = context.localUtil.ParseDTimeParm( GetPar( "TicketFechaHora_To"));
                  AV9K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV21OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               }
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public exportetapasdesarrolloticketwc( )
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

      public exportetapasdesarrolloticketwc( IGxContext context )
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

      public void execute( short aP0_EtapaDesarrolloId ,
                           DateTime aP1_TicketFecha_From ,
                           DateTime aP2_TicketFecha_To ,
                           DateTime aP3_TicketHora_From ,
                           DateTime aP4_TicketHora_To ,
                           string aP5_UsuarioNombre ,
                           string aP6_EstadoTicketTicketNombre ,
                           DateTime aP7_TicketFechaHora_From ,
                           DateTime aP8_TicketFechaHora_To ,
                           string aP9_K2BToolsGenericSearchField ,
                           ref short aP10_OrderedBy )
      {
         this.AV8EtapaDesarrolloId = aP0_EtapaDesarrolloId;
         this.AV11TicketFecha_From = aP1_TicketFecha_From;
         this.AV12TicketFecha_To = aP2_TicketFecha_To;
         this.AV14TicketHora_From = aP3_TicketHora_From;
         this.AV15TicketHora_To = aP4_TicketHora_To;
         this.AV16UsuarioNombre = aP5_UsuarioNombre;
         this.AV17EstadoTicketTicketNombre = aP6_EstadoTicketTicketNombre;
         this.AV19TicketFechaHora_From = aP7_TicketFechaHora_From;
         this.AV20TicketFechaHora_To = aP8_TicketFechaHora_To;
         this.AV9K2BToolsGenericSearchField = aP9_K2BToolsGenericSearchField;
         this.AV21OrderedBy = aP10_OrderedBy;
         initialize();
         executePrivate();
         aP10_OrderedBy=this.AV21OrderedBy;
      }

      public short executeUdp( short aP0_EtapaDesarrolloId ,
                               DateTime aP1_TicketFecha_From ,
                               DateTime aP2_TicketFecha_To ,
                               DateTime aP3_TicketHora_From ,
                               DateTime aP4_TicketHora_To ,
                               string aP5_UsuarioNombre ,
                               string aP6_EstadoTicketTicketNombre ,
                               DateTime aP7_TicketFechaHora_From ,
                               DateTime aP8_TicketFechaHora_To ,
                               string aP9_K2BToolsGenericSearchField )
      {
         execute(aP0_EtapaDesarrolloId, aP1_TicketFecha_From, aP2_TicketFecha_To, aP3_TicketHora_From, aP4_TicketHora_To, aP5_UsuarioNombre, aP6_EstadoTicketTicketNombre, aP7_TicketFechaHora_From, aP8_TicketFechaHora_To, aP9_K2BToolsGenericSearchField, ref aP10_OrderedBy);
         return AV21OrderedBy ;
      }

      public void executeSubmit( short aP0_EtapaDesarrolloId ,
                                 DateTime aP1_TicketFecha_From ,
                                 DateTime aP2_TicketFecha_To ,
                                 DateTime aP3_TicketHora_From ,
                                 DateTime aP4_TicketHora_To ,
                                 string aP5_UsuarioNombre ,
                                 string aP6_EstadoTicketTicketNombre ,
                                 DateTime aP7_TicketFechaHora_From ,
                                 DateTime aP8_TicketFechaHora_To ,
                                 string aP9_K2BToolsGenericSearchField ,
                                 ref short aP10_OrderedBy )
      {
         exportetapasdesarrolloticketwc objexportetapasdesarrolloticketwc;
         objexportetapasdesarrolloticketwc = new exportetapasdesarrolloticketwc();
         objexportetapasdesarrolloticketwc.AV8EtapaDesarrolloId = aP0_EtapaDesarrolloId;
         objexportetapasdesarrolloticketwc.AV11TicketFecha_From = aP1_TicketFecha_From;
         objexportetapasdesarrolloticketwc.AV12TicketFecha_To = aP2_TicketFecha_To;
         objexportetapasdesarrolloticketwc.AV14TicketHora_From = aP3_TicketHora_From;
         objexportetapasdesarrolloticketwc.AV15TicketHora_To = aP4_TicketHora_To;
         objexportetapasdesarrolloticketwc.AV16UsuarioNombre = aP5_UsuarioNombre;
         objexportetapasdesarrolloticketwc.AV17EstadoTicketTicketNombre = aP6_EstadoTicketTicketNombre;
         objexportetapasdesarrolloticketwc.AV19TicketFechaHora_From = aP7_TicketFechaHora_From;
         objexportetapasdesarrolloticketwc.AV20TicketFechaHora_To = aP8_TicketFechaHora_To;
         objexportetapasdesarrolloticketwc.AV9K2BToolsGenericSearchField = aP9_K2BToolsGenericSearchField;
         objexportetapasdesarrolloticketwc.AV21OrderedBy = aP10_OrderedBy;
         objexportetapasdesarrolloticketwc.context.SetSubmitInitialConfig(context);
         objexportetapasdesarrolloticketwc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportetapasdesarrolloticketwc);
         aP10_OrderedBy=this.AV21OrderedBy;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportetapasdesarrolloticketwc)stateInfo).executePrivate();
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
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Ticket",  "Ticket",  "List",  "",  "EtapasDesarrolloTicketWC") )
         {
            AV27Filename = "";
            AV28ErrorMessage = "You are not authorized to do activity";
            AV28ErrorMessage += "EntityName:" + "Ticket";
            AV28ErrorMessage += "TransactionName:" + "Ticket";
            AV28ErrorMessage += "ActivityType:" + "";
            AV28ErrorMessage += "PgmName:" + AV70Pgmname;
            AV29HttpResponse.AddString(AV28ErrorMessage);
            context.nUserReturn = 1;
            this.cleanup();
            if (true) return;
         }
         new k2bgetcontext(context ).execute( out  AV67Context) ;
         AV25Random = (int)(NumberUtil.Random( )*10000);
         AV27Filename = GxDirectory.TemporaryFilesPath + AV30File.Separator + "ExportEtapasDesarrolloTicketWC-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV25Random), 8, 0)) + ".xlsx";
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV22ExcelDocument.Open(AV27Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV22ExcelDocument.Clear();
         AV22ExcelDocument.AutoFit = 1;
         AV23CellRow = 1;
         AV24FirstColumn = 1;
         AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn, 1, 1).Size = 15;
         AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn, 1, 1).Bold = 1;
         AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn, 1, 1).Text = "Ticketes";
         AV23CellRow = (int)(AV23CellRow+4);
         /* Using cursor P00712 */
         pr_default.execute(0, new Object[] {AV8EtapaDesarrolloId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A290EtapaDesarrolloId = P00712_A290EtapaDesarrolloId[0];
            A291EtapaDesarrolloNombre = P00712_A291EtapaDesarrolloNombre[0];
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Desarrollo Nombre";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = StringUtil.RTrim( A291EtapaDesarrolloNombre);
            AV23CellRow = (int)(AV23CellRow+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = AV9K2BToolsGenericSearchField;
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV11TicketFecha_From) || ! (DateTime.MinValue==AV12TicketFecha_To) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Fecha:";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV11TicketFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV12TicketFecha_To, 2, "/");
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV14TicketHora_From) || ! (DateTime.MinValue==AV15TicketHora_To) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Hora:";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = context.localUtil.TToC( AV14TicketHora_From, 0, 5, 0, 3, "/", ":", " ")+" - "+context.localUtil.TToC( AV15TicketHora_To, 0, 5, 0, 3, "/", ":", " ");
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16UsuarioNombre)) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Usuario";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV16UsuarioNombre);
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17EstadoTicketTicketNombre)) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Estado Ticket";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV17EstadoTicketTicketNombre);
            AV23CellRow = (int)(AV23CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV19TicketFechaHora_From) || ! (DateTime.MinValue==AV20TicketFechaHora_To) )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+0, 1, 1).Text = "Ticket ";
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+1, 1, 1).Text = context.localUtil.TToC( AV19TicketFechaHora_From, 10, 8, 0, 3, "/", ":", " ")+" - "+context.localUtil.TToC( AV20TicketFechaHora_To, 10, 8, 0, 3, "/", ":", " ");
            AV23CellRow = (int)(AV23CellRow+1);
         }
         AV23CellRow = (int)(AV23CellRow+3);
         AV26ColumnIndex = 0;
         if ( AV35GridColumnVisible_TicketId )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "RST No.";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV36GridColumnVisible_TicketFecha )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Fecha:";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV37GridColumnVisible_TicketHora )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Hora:";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV38GridColumnVisible_UsuarioId )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Id Usuario";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_UsuarioNombre )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Usuario";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV40GridColumnVisible_UsuarioRequerimiento )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Requerimiento";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV41GridColumnVisible_UsuarioGerencia )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Gerencia";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV42GridColumnVisible_UsuarioDepartamento )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Departamento";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV43GridColumnVisible_EstadoTicketTicketId )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Estado Id";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV44GridColumnVisible_EstadoTicketTicketNombre )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Estado Ticket";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV45GridColumnVisible_TicketLastId )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Last Id";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV46GridColumnVisible_TicketHoraCaracter )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Hora Caracter";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV47GridColumnVisible_TicketLaptop )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "aptop";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV48GridColumnVisible_TicketDesktop )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Desktop";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV49GridColumnVisible_TicketMonitor )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Monitor";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV50GridColumnVisible_TicketImpresora )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Impresora";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV51GridColumnVisible_TicketEscaner )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Escaner";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV52GridColumnVisible_TicketRouter )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Internet/Router/Access Point";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV53GridColumnVisible_TicketSistemaOperativo )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Operativo";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV54GridColumnVisible_TicketOffice )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Office";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV55GridColumnVisible_TicketAntivirus )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Antivirus";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV56GridColumnVisible_TicketAplicacion )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Aplicación";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV57GridColumnVisible_TicketDisenio )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Diseño";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV58GridColumnVisible_TicketIngenieria )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Ingeniería";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV59GridColumnVisible_TicketDiscoDuroExterno )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Duro ";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV60GridColumnVisible_TicketPerifericos )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Periféricos";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV61GridColumnVisible_TicketUps )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "UPS";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV62GridColumnVisible_TicketApoyoUsuario )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Usuario";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV63GridColumnVisible_TicketInstalarDataShow )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Data Show";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV64GridColumnVisible_TicketOtros )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Otros";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV65GridColumnVisible_TicketUsuarioAsigno )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Usuario Asigno";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         if ( AV66GridColumnVisible_TicketFechaHora )
         {
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Bold = 1;
            AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = "Ticket ";
            AV26ColumnIndex = (short)(AV26ColumnIndex+1);
         }
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV12TicketFecha_To ,
                                              AV11TicketFecha_From ,
                                              AV15TicketHora_To ,
                                              AV14TicketHora_From ,
                                              AV16UsuarioNombre ,
                                              AV17EstadoTicketTicketNombre ,
                                              AV20TicketFechaHora_To ,
                                              AV19TicketFechaHora_From ,
                                              AV9K2BToolsGenericSearchField ,
                                              A46TicketFecha ,
                                              A48TicketHora ,
                                              A93UsuarioNombre ,
                                              A188EstadoTicketTicketNombre ,
                                              A289TicketFechaHora ,
                                              A14TicketId ,
                                              A15UsuarioId ,
                                              A94UsuarioRequerimiento ,
                                              A91UsuarioGerencia ,
                                              A88UsuarioDepartamento ,
                                              A187EstadoTicketTicketId ,
                                              A54TicketLastId ,
                                              A285TicketHoraCaracter ,
                                              A278TicketUsuarioAsigno ,
                                              AV21OrderedBy ,
                                              A290EtapaDesarrolloId ,
                                              AV8EtapaDesarrolloId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV16UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV16UsuarioNombre), "%", "");
         lV17EstadoTicketTicketNombre = StringUtil.Concat( StringUtil.RTrim( AV17EstadoTicketTicketNombre), "%", "");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P00713 */
         pr_default.execute(1, new Object[] {A290EtapaDesarrolloId, AV8EtapaDesarrolloId, AV12TicketFecha_To, AV11TicketFecha_From, AV15TicketHora_To, AV14TicketHora_From, lV16UsuarioNombre, lV17EstadoTicketTicketNombre, AV20TicketFechaHora_To, AV19TicketFechaHora_From, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A278TicketUsuarioAsigno = P00713_A278TicketUsuarioAsigno[0];
            A285TicketHoraCaracter = P00713_A285TicketHoraCaracter[0];
            A54TicketLastId = P00713_A54TicketLastId[0];
            A187EstadoTicketTicketId = P00713_A187EstadoTicketTicketId[0];
            A88UsuarioDepartamento = P00713_A88UsuarioDepartamento[0];
            A91UsuarioGerencia = P00713_A91UsuarioGerencia[0];
            A94UsuarioRequerimiento = P00713_A94UsuarioRequerimiento[0];
            A15UsuarioId = P00713_A15UsuarioId[0];
            A14TicketId = P00713_A14TicketId[0];
            A289TicketFechaHora = P00713_A289TicketFechaHora[0];
            n289TicketFechaHora = P00713_n289TicketFechaHora[0];
            A188EstadoTicketTicketNombre = P00713_A188EstadoTicketTicketNombre[0];
            A93UsuarioNombre = P00713_A93UsuarioNombre[0];
            A48TicketHora = P00713_A48TicketHora[0];
            A46TicketFecha = P00713_A46TicketFecha[0];
            A53TicketLaptop = P00713_A53TicketLaptop[0];
            A42TicketDesktop = P00713_A42TicketDesktop[0];
            A55TicketMonitor = P00713_A55TicketMonitor[0];
            A50TicketImpresora = P00713_A50TicketImpresora[0];
            A45TicketEscaner = P00713_A45TicketEscaner[0];
            A59TicketRouter = P00713_A59TicketRouter[0];
            A60TicketSistemaOperativo = P00713_A60TicketSistemaOperativo[0];
            A56TicketOffice = P00713_A56TicketOffice[0];
            A39TicketAntivirus = P00713_A39TicketAntivirus[0];
            A40TicketAplicacion = P00713_A40TicketAplicacion[0];
            A44TicketDisenio = P00713_A44TicketDisenio[0];
            A51TicketIngenieria = P00713_A51TicketIngenieria[0];
            A43TicketDiscoDuroExterno = P00713_A43TicketDiscoDuroExterno[0];
            A58TicketPerifericos = P00713_A58TicketPerifericos[0];
            A87TicketUps = P00713_A87TicketUps[0];
            A41TicketApoyoUsuario = P00713_A41TicketApoyoUsuario[0];
            A52TicketInstalarDataShow = P00713_A52TicketInstalarDataShow[0];
            A57TicketOtros = P00713_A57TicketOtros[0];
            A188EstadoTicketTicketNombre = P00713_A188EstadoTicketTicketNombre[0];
            A88UsuarioDepartamento = P00713_A88UsuarioDepartamento[0];
            A91UsuarioGerencia = P00713_A91UsuarioGerencia[0];
            A94UsuarioRequerimiento = P00713_A94UsuarioRequerimiento[0];
            A93UsuarioNombre = P00713_A93UsuarioNombre[0];
            AV23CellRow = (int)(AV23CellRow+1);
            AV26ColumnIndex = 0;
            if ( AV35GridColumnVisible_TicketId )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Number = A14TicketId;
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV36GridColumnVisible_TicketFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A46TicketFecha ) ;
               AV22ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV37GridColumnVisible_TicketHora )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = context.localUtil.Format( A48TicketHora, "99:99");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV38GridColumnVisible_UsuarioId )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Number = A15UsuarioId;
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_UsuarioNombre )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A93UsuarioNombre);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV40GridColumnVisible_UsuarioRequerimiento )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A94UsuarioRequerimiento);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV41GridColumnVisible_UsuarioGerencia )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A91UsuarioGerencia);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV42GridColumnVisible_UsuarioDepartamento )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A88UsuarioDepartamento);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV43GridColumnVisible_EstadoTicketTicketId )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Number = A187EstadoTicketTicketId;
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV44GridColumnVisible_EstadoTicketTicketNombre )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A188EstadoTicketTicketNombre);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV45GridColumnVisible_TicketLastId )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Number = A54TicketLastId;
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV46GridColumnVisible_TicketHoraCaracter )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A285TicketHoraCaracter);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV47GridColumnVisible_TicketLaptop )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A53TicketLaptop ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV48GridColumnVisible_TicketDesktop )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A42TicketDesktop ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV49GridColumnVisible_TicketMonitor )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A55TicketMonitor ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV50GridColumnVisible_TicketImpresora )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A50TicketImpresora ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV51GridColumnVisible_TicketEscaner )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A45TicketEscaner ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV52GridColumnVisible_TicketRouter )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A59TicketRouter ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV53GridColumnVisible_TicketSistemaOperativo )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A60TicketSistemaOperativo ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV54GridColumnVisible_TicketOffice )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A56TicketOffice ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV55GridColumnVisible_TicketAntivirus )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A39TicketAntivirus ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV56GridColumnVisible_TicketAplicacion )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A40TicketAplicacion ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV57GridColumnVisible_TicketDisenio )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A44TicketDisenio ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV58GridColumnVisible_TicketIngenieria )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A51TicketIngenieria ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV59GridColumnVisible_TicketDiscoDuroExterno )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A43TicketDiscoDuroExterno ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV60GridColumnVisible_TicketPerifericos )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A58TicketPerifericos ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV61GridColumnVisible_TicketUps )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A87TicketUps ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV62GridColumnVisible_TicketApoyoUsuario )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A41TicketApoyoUsuario ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV63GridColumnVisible_TicketInstalarDataShow )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A52TicketInstalarDataShow ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV64GridColumnVisible_TicketOtros )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = (A57TicketOtros ? "Si" : "No");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV65GridColumnVisible_TicketUsuarioAsigno )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = StringUtil.RTrim( A278TicketUsuarioAsigno);
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            if ( AV66GridColumnVisible_TicketFechaHora )
            {
               AV22ExcelDocument.get_Cells(AV23CellRow, AV24FirstColumn+AV26ColumnIndex, 1, 1).Text = context.localUtil.Format( A289TicketFechaHora, "99/99/9999 99:99:99");
               AV26ColumnIndex = (short)(AV26ColumnIndex+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV22ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV22ExcelDocument.Close();
         if ( ! context.isAjaxRequest( ) )
         {
            AV29HttpResponse.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV29HttpResponse.AppendHeader("Content-Disposition", "attachment;filename=ExportEtapasDesarrolloTicketWC.xlsx");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV29HttpResponse.AppendHeader("X-Frame-Options", "sameOrigin");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV29HttpResponse.AppendHeader("X-Content-Type-Options", "nosniff");
         }
         AV29HttpResponse.AddFile(AV27Filename);
         new k2bremoveexceldocument(context).executeSubmit(  AV27Filename) ;
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV22ExcelDocument.ErrCode != 0 )
         {
            AV27Filename = "";
            AV28ErrorMessage = AV22ExcelDocument.ErrDescription;
            AV29HttpResponse.AddString(AV28ErrorMessage);
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S131 ();
         if (returnInSub) return;
         new k2bloadgridconfiguration(context ).execute(  "EtapasDesarrolloTicketWC",  "Grid", ref  AV31GridConfiguration) ;
         AV33GridColumns = AV31GridConfiguration.gxTpr_Gridcolumns;
         AV35GridColumnVisible_TicketId = true;
         AV36GridColumnVisible_TicketFecha = true;
         AV37GridColumnVisible_TicketHora = true;
         AV38GridColumnVisible_UsuarioId = true;
         AV39GridColumnVisible_UsuarioNombre = true;
         AV40GridColumnVisible_UsuarioRequerimiento = true;
         AV41GridColumnVisible_UsuarioGerencia = true;
         AV42GridColumnVisible_UsuarioDepartamento = true;
         AV43GridColumnVisible_EstadoTicketTicketId = true;
         AV44GridColumnVisible_EstadoTicketTicketNombre = true;
         AV45GridColumnVisible_TicketLastId = true;
         AV46GridColumnVisible_TicketHoraCaracter = true;
         AV47GridColumnVisible_TicketLaptop = true;
         AV48GridColumnVisible_TicketDesktop = true;
         AV49GridColumnVisible_TicketMonitor = true;
         AV50GridColumnVisible_TicketImpresora = true;
         AV51GridColumnVisible_TicketEscaner = true;
         AV52GridColumnVisible_TicketRouter = true;
         AV53GridColumnVisible_TicketSistemaOperativo = true;
         AV54GridColumnVisible_TicketOffice = true;
         AV55GridColumnVisible_TicketAntivirus = true;
         AV56GridColumnVisible_TicketAplicacion = true;
         AV57GridColumnVisible_TicketDisenio = true;
         AV58GridColumnVisible_TicketIngenieria = true;
         AV59GridColumnVisible_TicketDiscoDuroExterno = true;
         AV60GridColumnVisible_TicketPerifericos = true;
         AV61GridColumnVisible_TicketUps = true;
         AV62GridColumnVisible_TicketApoyoUsuario = true;
         AV63GridColumnVisible_TicketInstalarDataShow = true;
         AV64GridColumnVisible_TicketOtros = true;
         AV65GridColumnVisible_TicketUsuarioAsigno = true;
         AV66GridColumnVisible_TicketFechaHora = true;
         new k2bsavegridconfiguration(context ).execute(  "EtapasDesarrolloTicketWC",  "Grid",  AV31GridConfiguration,  false) ;
         AV33GridColumns = AV31GridConfiguration.gxTpr_Gridcolumns;
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV33GridColumns.Count )
         {
            AV34GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV33GridColumns.Item(AV73GXV1));
            if ( ! AV34GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  AV35GridColumnVisible_TicketId = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketFecha") == 0 )
               {
                  AV36GridColumnVisible_TicketFecha = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketHora") == 0 )
               {
                  AV37GridColumnVisible_TicketHora = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  AV38GridColumnVisible_UsuarioId = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  AV39GridColumnVisible_UsuarioNombre = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  AV40GridColumnVisible_UsuarioRequerimiento = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "UsuarioGerencia") == 0 )
               {
                  AV41GridColumnVisible_UsuarioGerencia = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "UsuarioDepartamento") == 0 )
               {
                  AV42GridColumnVisible_UsuarioDepartamento = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "EstadoTicketTicketId") == 0 )
               {
                  AV43GridColumnVisible_EstadoTicketTicketId = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "EstadoTicketTicketNombre") == 0 )
               {
                  AV44GridColumnVisible_EstadoTicketTicketNombre = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketLastId") == 0 )
               {
                  AV45GridColumnVisible_TicketLastId = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketHoraCaracter") == 0 )
               {
                  AV46GridColumnVisible_TicketHoraCaracter = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketLaptop") == 0 )
               {
                  AV47GridColumnVisible_TicketLaptop = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketDesktop") == 0 )
               {
                  AV48GridColumnVisible_TicketDesktop = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketMonitor") == 0 )
               {
                  AV49GridColumnVisible_TicketMonitor = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketImpresora") == 0 )
               {
                  AV50GridColumnVisible_TicketImpresora = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketEscaner") == 0 )
               {
                  AV51GridColumnVisible_TicketEscaner = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketRouter") == 0 )
               {
                  AV52GridColumnVisible_TicketRouter = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketSistemaOperativo") == 0 )
               {
                  AV53GridColumnVisible_TicketSistemaOperativo = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketOffice") == 0 )
               {
                  AV54GridColumnVisible_TicketOffice = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketAntivirus") == 0 )
               {
                  AV55GridColumnVisible_TicketAntivirus = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketAplicacion") == 0 )
               {
                  AV56GridColumnVisible_TicketAplicacion = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketDisenio") == 0 )
               {
                  AV57GridColumnVisible_TicketDisenio = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketIngenieria") == 0 )
               {
                  AV58GridColumnVisible_TicketIngenieria = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketDiscoDuroExterno") == 0 )
               {
                  AV59GridColumnVisible_TicketDiscoDuroExterno = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketPerifericos") == 0 )
               {
                  AV60GridColumnVisible_TicketPerifericos = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketUps") == 0 )
               {
                  AV61GridColumnVisible_TicketUps = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketApoyoUsuario") == 0 )
               {
                  AV62GridColumnVisible_TicketApoyoUsuario = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketInstalarDataShow") == 0 )
               {
                  AV63GridColumnVisible_TicketInstalarDataShow = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketOtros") == 0 )
               {
                  AV64GridColumnVisible_TicketOtros = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketUsuarioAsigno") == 0 )
               {
                  AV65GridColumnVisible_TicketUsuarioAsigno = false;
               }
               else if ( StringUtil.StrCmp(AV34GridColumn.gxTpr_Attributename, "TicketFechaHora") == 0 )
               {
                  AV66GridColumnVisible_TicketFechaHora = false;
               }
            }
            AV73GXV1 = (int)(AV73GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV33GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketId";
         AV34GridColumn.gxTpr_Columntitle = "RST No.";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketFecha";
         AV34GridColumn.gxTpr_Columntitle = "Fecha:";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketHora";
         AV34GridColumn.gxTpr_Columntitle = "Hora:";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "UsuarioId";
         AV34GridColumn.gxTpr_Columntitle = "Id Usuario";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV34GridColumn.gxTpr_Columntitle = "Usuario";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV34GridColumn.gxTpr_Columntitle = "Requerimiento";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "UsuarioGerencia";
         AV34GridColumn.gxTpr_Columntitle = "Gerencia";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "UsuarioDepartamento";
         AV34GridColumn.gxTpr_Columntitle = "Departamento";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "EstadoTicketTicketId";
         AV34GridColumn.gxTpr_Columntitle = "Estado Id";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "EstadoTicketTicketNombre";
         AV34GridColumn.gxTpr_Columntitle = "Estado Ticket";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketLastId";
         AV34GridColumn.gxTpr_Columntitle = "Last Id";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketHoraCaracter";
         AV34GridColumn.gxTpr_Columntitle = "Hora Caracter";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketLaptop";
         AV34GridColumn.gxTpr_Columntitle = "aptop";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketDesktop";
         AV34GridColumn.gxTpr_Columntitle = "Desktop";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketMonitor";
         AV34GridColumn.gxTpr_Columntitle = "Monitor";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketImpresora";
         AV34GridColumn.gxTpr_Columntitle = "Impresora";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketEscaner";
         AV34GridColumn.gxTpr_Columntitle = "Escaner";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketRouter";
         AV34GridColumn.gxTpr_Columntitle = "Internet/Router/Access Point";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketSistemaOperativo";
         AV34GridColumn.gxTpr_Columntitle = "Operativo";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketOffice";
         AV34GridColumn.gxTpr_Columntitle = "Office";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketAntivirus";
         AV34GridColumn.gxTpr_Columntitle = "Antivirus";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketAplicacion";
         AV34GridColumn.gxTpr_Columntitle = "Aplicación";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketDisenio";
         AV34GridColumn.gxTpr_Columntitle = "Diseño";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketIngenieria";
         AV34GridColumn.gxTpr_Columntitle = "Ingeniería";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketDiscoDuroExterno";
         AV34GridColumn.gxTpr_Columntitle = "Duro ";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketPerifericos";
         AV34GridColumn.gxTpr_Columntitle = "Periféricos";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketUps";
         AV34GridColumn.gxTpr_Columntitle = "UPS";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketApoyoUsuario";
         AV34GridColumn.gxTpr_Columntitle = "Usuario";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketInstalarDataShow";
         AV34GridColumn.gxTpr_Columntitle = "Data Show";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketOtros";
         AV34GridColumn.gxTpr_Columntitle = "Otros";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketUsuarioAsigno";
         AV34GridColumn.gxTpr_Columntitle = "Usuario Asigno";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV34GridColumn.gxTpr_Attributename = "TicketFechaHora";
         AV34GridColumn.gxTpr_Columntitle = "Ticket ";
         AV34GridColumn.gxTpr_Showattribute = true;
         AV33GridColumns.Add(AV34GridColumn, 0);
         AV31GridConfiguration.gxTpr_Gridcolumns = AV33GridColumns;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV27Filename = "";
         AV28ErrorMessage = "";
         AV70Pgmname = "";
         AV29HttpResponse = new GxHttpResponse( context);
         AV67Context = new SdtK2BContext(context);
         AV30File = new GxFile(context.GetPhysicalPath());
         AV22ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P00712_A290EtapaDesarrolloId = new short[1] ;
         P00712_A291EtapaDesarrolloNombre = new string[] {""} ;
         A291EtapaDesarrolloNombre = "";
         lV16UsuarioNombre = "";
         lV17EstadoTicketTicketNombre = "";
         lV9K2BToolsGenericSearchField = "";
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A93UsuarioNombre = "";
         A188EstadoTicketTicketNombre = "";
         A289TicketFechaHora = (DateTime)(DateTime.MinValue);
         A94UsuarioRequerimiento = "";
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A285TicketHoraCaracter = "";
         A278TicketUsuarioAsigno = "";
         P00713_A278TicketUsuarioAsigno = new string[] {""} ;
         P00713_A285TicketHoraCaracter = new string[] {""} ;
         P00713_A54TicketLastId = new long[1] ;
         P00713_A187EstadoTicketTicketId = new short[1] ;
         P00713_A88UsuarioDepartamento = new string[] {""} ;
         P00713_A91UsuarioGerencia = new string[] {""} ;
         P00713_A94UsuarioRequerimiento = new string[] {""} ;
         P00713_A15UsuarioId = new short[1] ;
         P00713_A14TicketId = new long[1] ;
         P00713_A289TicketFechaHora = new DateTime[] {DateTime.MinValue} ;
         P00713_n289TicketFechaHora = new bool[] {false} ;
         P00713_A188EstadoTicketTicketNombre = new string[] {""} ;
         P00713_A93UsuarioNombre = new string[] {""} ;
         P00713_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         P00713_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         P00713_A53TicketLaptop = new bool[] {false} ;
         P00713_A42TicketDesktop = new bool[] {false} ;
         P00713_A55TicketMonitor = new bool[] {false} ;
         P00713_A50TicketImpresora = new bool[] {false} ;
         P00713_A45TicketEscaner = new bool[] {false} ;
         P00713_A59TicketRouter = new bool[] {false} ;
         P00713_A60TicketSistemaOperativo = new bool[] {false} ;
         P00713_A56TicketOffice = new bool[] {false} ;
         P00713_A39TicketAntivirus = new bool[] {false} ;
         P00713_A40TicketAplicacion = new bool[] {false} ;
         P00713_A44TicketDisenio = new bool[] {false} ;
         P00713_A51TicketIngenieria = new bool[] {false} ;
         P00713_A43TicketDiscoDuroExterno = new bool[] {false} ;
         P00713_A58TicketPerifericos = new bool[] {false} ;
         P00713_A87TicketUps = new bool[] {false} ;
         P00713_A41TicketApoyoUsuario = new bool[] {false} ;
         P00713_A52TicketInstalarDataShow = new bool[] {false} ;
         P00713_A57TicketOtros = new bool[] {false} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV31GridConfiguration = new SdtK2BGridConfiguration(context);
         AV33GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV34GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportetapasdesarrolloticketwc__default(),
            new Object[][] {
                new Object[] {
               P00712_A290EtapaDesarrolloId, P00712_A291EtapaDesarrolloNombre
               }
               , new Object[] {
               P00713_A278TicketUsuarioAsigno, P00713_A285TicketHoraCaracter, P00713_A54TicketLastId, P00713_A187EstadoTicketTicketId, P00713_A88UsuarioDepartamento, P00713_A91UsuarioGerencia, P00713_A94UsuarioRequerimiento, P00713_A15UsuarioId, P00713_A14TicketId, P00713_A289TicketFechaHora,
               P00713_n289TicketFechaHora, P00713_A188EstadoTicketTicketNombre, P00713_A93UsuarioNombre, P00713_A48TicketHora, P00713_A46TicketFecha, P00713_A53TicketLaptop, P00713_A42TicketDesktop, P00713_A55TicketMonitor, P00713_A50TicketImpresora, P00713_A45TicketEscaner,
               P00713_A59TicketRouter, P00713_A60TicketSistemaOperativo, P00713_A56TicketOffice, P00713_A39TicketAntivirus, P00713_A40TicketAplicacion, P00713_A44TicketDisenio, P00713_A51TicketIngenieria, P00713_A43TicketDiscoDuroExterno, P00713_A58TicketPerifericos, P00713_A87TicketUps,
               P00713_A41TicketApoyoUsuario, P00713_A52TicketInstalarDataShow, P00713_A57TicketOtros
               }
            }
         );
         AV70Pgmname = "ExportEtapasDesarrolloTicketWC";
         /* GeneXus formulas. */
         AV70Pgmname = "ExportEtapasDesarrolloTicketWC";
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8EtapaDesarrolloId ;
      private short AV21OrderedBy ;
      private short GxWebError ;
      private short A290EtapaDesarrolloId ;
      private short AV26ColumnIndex ;
      private short A15UsuarioId ;
      private short A187EstadoTicketTicketId ;
      private int AV25Random ;
      private int AV23CellRow ;
      private int AV24FirstColumn ;
      private int AV73GXV1 ;
      private long A14TicketId ;
      private long A54TicketLastId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9K2BToolsGenericSearchField ;
      private string AV70Pgmname ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private string A285TicketHoraCaracter ;
      private DateTime AV14TicketHora_From ;
      private DateTime AV15TicketHora_To ;
      private DateTime AV19TicketFechaHora_From ;
      private DateTime AV20TicketFechaHora_To ;
      private DateTime A48TicketHora ;
      private DateTime A289TicketFechaHora ;
      private DateTime GXt_dtime1 ;
      private DateTime AV11TicketFecha_From ;
      private DateTime AV12TicketFecha_To ;
      private DateTime A46TicketFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV35GridColumnVisible_TicketId ;
      private bool AV36GridColumnVisible_TicketFecha ;
      private bool AV37GridColumnVisible_TicketHora ;
      private bool AV38GridColumnVisible_UsuarioId ;
      private bool AV39GridColumnVisible_UsuarioNombre ;
      private bool AV40GridColumnVisible_UsuarioRequerimiento ;
      private bool AV41GridColumnVisible_UsuarioGerencia ;
      private bool AV42GridColumnVisible_UsuarioDepartamento ;
      private bool AV43GridColumnVisible_EstadoTicketTicketId ;
      private bool AV44GridColumnVisible_EstadoTicketTicketNombre ;
      private bool AV45GridColumnVisible_TicketLastId ;
      private bool AV46GridColumnVisible_TicketHoraCaracter ;
      private bool AV47GridColumnVisible_TicketLaptop ;
      private bool AV48GridColumnVisible_TicketDesktop ;
      private bool AV49GridColumnVisible_TicketMonitor ;
      private bool AV50GridColumnVisible_TicketImpresora ;
      private bool AV51GridColumnVisible_TicketEscaner ;
      private bool AV52GridColumnVisible_TicketRouter ;
      private bool AV53GridColumnVisible_TicketSistemaOperativo ;
      private bool AV54GridColumnVisible_TicketOffice ;
      private bool AV55GridColumnVisible_TicketAntivirus ;
      private bool AV56GridColumnVisible_TicketAplicacion ;
      private bool AV57GridColumnVisible_TicketDisenio ;
      private bool AV58GridColumnVisible_TicketIngenieria ;
      private bool AV59GridColumnVisible_TicketDiscoDuroExterno ;
      private bool AV60GridColumnVisible_TicketPerifericos ;
      private bool AV61GridColumnVisible_TicketUps ;
      private bool AV62GridColumnVisible_TicketApoyoUsuario ;
      private bool AV63GridColumnVisible_TicketInstalarDataShow ;
      private bool AV64GridColumnVisible_TicketOtros ;
      private bool AV65GridColumnVisible_TicketUsuarioAsigno ;
      private bool AV66GridColumnVisible_TicketFechaHora ;
      private bool n289TicketFechaHora ;
      private bool A53TicketLaptop ;
      private bool A42TicketDesktop ;
      private bool A55TicketMonitor ;
      private bool A50TicketImpresora ;
      private bool A45TicketEscaner ;
      private bool A59TicketRouter ;
      private bool A60TicketSistemaOperativo ;
      private bool A56TicketOffice ;
      private bool A39TicketAntivirus ;
      private bool A40TicketAplicacion ;
      private bool A44TicketDisenio ;
      private bool A51TicketIngenieria ;
      private bool A43TicketDiscoDuroExterno ;
      private bool A58TicketPerifericos ;
      private bool A87TicketUps ;
      private bool A41TicketApoyoUsuario ;
      private bool A52TicketInstalarDataShow ;
      private bool A57TicketOtros ;
      private string AV16UsuarioNombre ;
      private string AV17EstadoTicketTicketNombre ;
      private string AV27Filename ;
      private string AV28ErrorMessage ;
      private string A291EtapaDesarrolloNombre ;
      private string lV16UsuarioNombre ;
      private string lV17EstadoTicketTicketNombre ;
      private string A93UsuarioNombre ;
      private string A188EstadoTicketTicketNombre ;
      private string A94UsuarioRequerimiento ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A278TicketUsuarioAsigno ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP10_OrderedBy ;
      private IDataStoreProvider pr_default ;
      private short[] P00712_A290EtapaDesarrolloId ;
      private string[] P00712_A291EtapaDesarrolloNombre ;
      private string[] P00713_A278TicketUsuarioAsigno ;
      private string[] P00713_A285TicketHoraCaracter ;
      private long[] P00713_A54TicketLastId ;
      private short[] P00713_A187EstadoTicketTicketId ;
      private string[] P00713_A88UsuarioDepartamento ;
      private string[] P00713_A91UsuarioGerencia ;
      private string[] P00713_A94UsuarioRequerimiento ;
      private short[] P00713_A15UsuarioId ;
      private long[] P00713_A14TicketId ;
      private DateTime[] P00713_A289TicketFechaHora ;
      private bool[] P00713_n289TicketFechaHora ;
      private string[] P00713_A188EstadoTicketTicketNombre ;
      private string[] P00713_A93UsuarioNombre ;
      private DateTime[] P00713_A48TicketHora ;
      private DateTime[] P00713_A46TicketFecha ;
      private bool[] P00713_A53TicketLaptop ;
      private bool[] P00713_A42TicketDesktop ;
      private bool[] P00713_A55TicketMonitor ;
      private bool[] P00713_A50TicketImpresora ;
      private bool[] P00713_A45TicketEscaner ;
      private bool[] P00713_A59TicketRouter ;
      private bool[] P00713_A60TicketSistemaOperativo ;
      private bool[] P00713_A56TicketOffice ;
      private bool[] P00713_A39TicketAntivirus ;
      private bool[] P00713_A40TicketAplicacion ;
      private bool[] P00713_A44TicketDisenio ;
      private bool[] P00713_A51TicketIngenieria ;
      private bool[] P00713_A43TicketDiscoDuroExterno ;
      private bool[] P00713_A58TicketPerifericos ;
      private bool[] P00713_A87TicketUps ;
      private bool[] P00713_A41TicketApoyoUsuario ;
      private bool[] P00713_A52TicketInstalarDataShow ;
      private bool[] P00713_A57TicketOtros ;
      private GxHttpResponse AV29HttpResponse ;
      private ExcelDocumentI AV22ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV33GridColumns ;
      private GxFile AV30File ;
      private SdtK2BGridConfiguration AV31GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV34GridColumn ;
      private SdtK2BContext AV67Context ;
   }

   public class exportetapasdesarrolloticketwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00713( IGxContext context ,
                                             DateTime AV12TicketFecha_To ,
                                             DateTime AV11TicketFecha_From ,
                                             DateTime AV15TicketHora_To ,
                                             DateTime AV14TicketHora_From ,
                                             string AV16UsuarioNombre ,
                                             string AV17EstadoTicketTicketNombre ,
                                             DateTime AV20TicketFechaHora_To ,
                                             DateTime AV19TicketFechaHora_From ,
                                             string AV9K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             string A93UsuarioNombre ,
                                             string A188EstadoTicketTicketNombre ,
                                             DateTime A289TicketFechaHora ,
                                             long A14TicketId ,
                                             short A15UsuarioId ,
                                             string A94UsuarioRequerimiento ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             short A187EstadoTicketTicketId ,
                                             long A54TicketLastId ,
                                             string A285TicketHoraCaracter ,
                                             string A278TicketUsuarioAsigno ,
                                             short AV21OrderedBy ,
                                             short A290EtapaDesarrolloId ,
                                             short AV8EtapaDesarrolloId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[21];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[TicketUsuarioAsigno], T1.[TicketHoraCaracter], T1.[TicketLastId], T1.[EstadoTicketTicketId] AS EstadoTicketTicketId, T3.[UsuarioDepartamento], T3.[UsuarioGerencia], T3.[UsuarioRequerimiento], T1.[UsuarioId], T1.[TicketId], T1.[TicketFechaHora], T2.[EstadoTicketNombre] AS EstadoTicketTicketNombre, T3.[UsuarioNombre], T1.[TicketHora], T1.[TicketFecha], T1.[TicketLaptop], T1.[TicketDesktop], T1.[TicketMonitor], T1.[TicketImpresora], T1.[TicketEscaner], T1.[TicketRouter], T1.[TicketSistemaOperativo], T1.[TicketOffice], T1.[TicketAntivirus], T1.[TicketAplicacion], T1.[TicketDisenio], T1.[TicketIngenieria], T1.[TicketDiscoDuroExterno], T1.[TicketPerifericos], T1.[TicketUps], T1.[TicketApoyoUsuario], T1.[TicketInstalarDataShow], T1.[TicketOtros] FROM (([Ticket] T1 INNER JOIN [EstadoTicket] T2 ON T2.[EstadoTicketId] = T1.[EstadoTicketTicketId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T1.[UsuarioId])";
         AddWhere(sWhereString, "(@EtapaDesarrolloId = @AV8EtapaDesarrolloId)");
         if ( ! (DateTime.MinValue==AV12TicketFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] <= @AV12TicketFecha_To)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV11TicketFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFecha] >= @AV11TicketFecha_From)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TicketHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] <= @AV15TicketHora_To)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TicketHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketHora] >= @AV14TicketHora_From)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16UsuarioNombre)) )
         {
            AddWhere(sWhereString, "(T3.[UsuarioNombre] like @lV16UsuarioNombre)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17EstadoTicketTicketNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoTicketNombre] like @lV17EstadoTicketTicketNombre)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV20TicketFechaHora_To) )
         {
            AddWhere(sWhereString, "(T1.[TicketFechaHora] <= @AV20TicketFechaHora_To)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV19TicketFechaHora_From) )
         {
            AddWhere(sWhereString, "(T1.[TicketFechaHora] >= @AV19TicketFechaHora_From)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[TicketId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(4), CAST(T1.[UsuarioId] AS decimal(4,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or T3.[UsuarioNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T3.[UsuarioRequerimiento] like '%' + @lV9K2BToolsGenericSearchField + '%' or T3.[UsuarioGerencia] like '%' + @lV9K2BToolsGenericSearchField + '%' or T3.[UsuarioDepartamento] like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(4), CAST(T1.[EstadoTicketTicketId] AS decimal(4,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or T2.[EstadoTicketNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST(T1.[TicketLastId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or T1.[TicketHoraCaracter] like '%' + @lV9K2BToolsGenericSearchField + '%' or T1.[TicketUsuarioAsigno] like '%' + @lV9K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[10] = 1;
            GXv_int2[11] = 1;
            GXv_int2[12] = 1;
            GXv_int2[13] = 1;
            GXv_int2[14] = 1;
            GXv_int2[15] = 1;
            GXv_int2[16] = 1;
            GXv_int2[17] = 1;
            GXv_int2[18] = 1;
            GXv_int2[19] = 1;
            GXv_int2[20] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV21OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[TicketId]";
         }
         else if ( AV21OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[TicketId] DESC";
         }
         else if ( AV21OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[TicketFecha]";
         }
         else if ( AV21OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T1.[TicketFecha] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00713(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (long)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00712;
          prmP00712 = new Object[] {
          new ParDef("@AV8EtapaDesarrolloId",GXType.Int16,4,0)
          };
          Object[] prmP00713;
          prmP00713 = new Object[] {
          new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0) ,
          new ParDef("@AV8EtapaDesarrolloId",GXType.Int16,4,0) ,
          new ParDef("@AV12TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV11TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV15TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV14TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV16UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV17EstadoTicketTicketNombre",GXType.NVarChar,30,0) ,
          new ParDef("@AV20TicketFechaHora_To",GXType.DateTime,10,8) ,
          new ParDef("@AV19TicketFechaHora_From",GXType.DateTime,10,8) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00712", "SELECT TOP 1 [EtapaDesarrolloId], [EtapaDesarrolloNombre] FROM [EtapasDesarrollo] WHERE [EtapaDesarrolloId] = @AV8EtapaDesarrolloId ORDER BY [EtapaDesarrolloId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00712,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00713", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00713,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 8);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(14);
                ((bool[]) buf[15])[0] = rslt.getBool(15);
                ((bool[]) buf[16])[0] = rslt.getBool(16);
                ((bool[]) buf[17])[0] = rslt.getBool(17);
                ((bool[]) buf[18])[0] = rslt.getBool(18);
                ((bool[]) buf[19])[0] = rslt.getBool(19);
                ((bool[]) buf[20])[0] = rslt.getBool(20);
                ((bool[]) buf[21])[0] = rslt.getBool(21);
                ((bool[]) buf[22])[0] = rslt.getBool(22);
                ((bool[]) buf[23])[0] = rslt.getBool(23);
                ((bool[]) buf[24])[0] = rslt.getBool(24);
                ((bool[]) buf[25])[0] = rslt.getBool(25);
                ((bool[]) buf[26])[0] = rslt.getBool(26);
                ((bool[]) buf[27])[0] = rslt.getBool(27);
                ((bool[]) buf[28])[0] = rslt.getBool(28);
                ((bool[]) buf[29])[0] = rslt.getBool(29);
                ((bool[]) buf[30])[0] = rslt.getBool(30);
                ((bool[]) buf[31])[0] = rslt.getBool(31);
                ((bool[]) buf[32])[0] = rslt.getBool(32);
                return;
       }
    }

 }

}
