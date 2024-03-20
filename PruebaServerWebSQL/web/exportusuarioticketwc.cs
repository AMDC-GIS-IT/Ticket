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
   public class exportusuarioticketwc : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "UsuarioId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8UsuarioId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11TicketFecha_From = context.localUtil.ParseDateParm( GetPar( "TicketFecha_From"));
                  AV12TicketFecha_To = context.localUtil.ParseDateParm( GetPar( "TicketFecha_To"));
                  AV14TicketHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_From")));
                  AV15TicketHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TicketHora_To")));
                  AV9K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV16OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
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

      public exportusuarioticketwc( )
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

      public exportusuarioticketwc( IGxContext context )
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

      public void execute( short aP0_UsuarioId ,
                           DateTime aP1_TicketFecha_From ,
                           DateTime aP2_TicketFecha_To ,
                           DateTime aP3_TicketHora_From ,
                           DateTime aP4_TicketHora_To ,
                           string aP5_K2BToolsGenericSearchField ,
                           ref short aP6_OrderedBy )
      {
         this.AV8UsuarioId = aP0_UsuarioId;
         this.AV11TicketFecha_From = aP1_TicketFecha_From;
         this.AV12TicketFecha_To = aP2_TicketFecha_To;
         this.AV14TicketHora_From = aP3_TicketHora_From;
         this.AV15TicketHora_To = aP4_TicketHora_To;
         this.AV9K2BToolsGenericSearchField = aP5_K2BToolsGenericSearchField;
         this.AV16OrderedBy = aP6_OrderedBy;
         initialize();
         executePrivate();
         aP6_OrderedBy=this.AV16OrderedBy;
      }

      public short executeUdp( short aP0_UsuarioId ,
                               DateTime aP1_TicketFecha_From ,
                               DateTime aP2_TicketFecha_To ,
                               DateTime aP3_TicketHora_From ,
                               DateTime aP4_TicketHora_To ,
                               string aP5_K2BToolsGenericSearchField )
      {
         execute(aP0_UsuarioId, aP1_TicketFecha_From, aP2_TicketFecha_To, aP3_TicketHora_From, aP4_TicketHora_To, aP5_K2BToolsGenericSearchField, ref aP6_OrderedBy);
         return AV16OrderedBy ;
      }

      public void executeSubmit( short aP0_UsuarioId ,
                                 DateTime aP1_TicketFecha_From ,
                                 DateTime aP2_TicketFecha_To ,
                                 DateTime aP3_TicketHora_From ,
                                 DateTime aP4_TicketHora_To ,
                                 string aP5_K2BToolsGenericSearchField ,
                                 ref short aP6_OrderedBy )
      {
         exportusuarioticketwc objexportusuarioticketwc;
         objexportusuarioticketwc = new exportusuarioticketwc();
         objexportusuarioticketwc.AV8UsuarioId = aP0_UsuarioId;
         objexportusuarioticketwc.AV11TicketFecha_From = aP1_TicketFecha_From;
         objexportusuarioticketwc.AV12TicketFecha_To = aP2_TicketFecha_To;
         objexportusuarioticketwc.AV14TicketHora_From = aP3_TicketHora_From;
         objexportusuarioticketwc.AV15TicketHora_To = aP4_TicketHora_To;
         objexportusuarioticketwc.AV9K2BToolsGenericSearchField = aP5_K2BToolsGenericSearchField;
         objexportusuarioticketwc.AV16OrderedBy = aP6_OrderedBy;
         objexportusuarioticketwc.context.SetSubmitInitialConfig(context);
         objexportusuarioticketwc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportusuarioticketwc);
         aP6_OrderedBy=this.AV16OrderedBy;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportusuarioticketwc)stateInfo).executePrivate();
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
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Ticket",  "Ticket",  "List",  "",  "UsuarioTicketWC") )
         {
            AV22Filename = "";
            AV23ErrorMessage = "You are not authorized to do activity";
            AV23ErrorMessage += "EntityName:" + "Ticket";
            AV23ErrorMessage += "TransactionName:" + "Ticket";
            AV23ErrorMessage += "ActivityType:" + "";
            AV23ErrorMessage += "PgmName:" + AV56Pgmname;
            AV24HttpResponse.AddString(AV23ErrorMessage);
            context.nUserReturn = 1;
            this.cleanup();
            if (true) return;
         }
         new k2bgetcontext(context ).execute( out  AV53Context) ;
         AV20Random = (int)(NumberUtil.Random( )*10000);
         AV22Filename = GxDirectory.TemporaryFilesPath + AV25File.Separator + "ExportUsuarioTicketWC-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV20Random), 8, 0)) + ".xlsx";
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV17ExcelDocument.Open(AV22Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV17ExcelDocument.Clear();
         AV17ExcelDocument.AutoFit = 1;
         AV18CellRow = 1;
         AV19FirstColumn = 1;
         AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn, 1, 1).Size = 15;
         AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn, 1, 1).Bold = 1;
         AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn, 1, 1).Text = "Ticketes";
         AV18CellRow = (int)(AV18CellRow+4);
         /* Using cursor P003J2 */
         pr_default.execute(0, new Object[] {AV8UsuarioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15UsuarioId = P003J2_A15UsuarioId[0];
            A93UsuarioNombre = P003J2_A93UsuarioNombre[0];
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+0, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+0, 1, 1).Text = "Usuario:";
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+1, 1, 1).Text = StringUtil.RTrim( A93UsuarioNombre);
            AV18CellRow = (int)(AV18CellRow+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+0, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+1, 1, 1).Text = AV9K2BToolsGenericSearchField;
            AV18CellRow = (int)(AV18CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV11TicketFecha_From) || ! (DateTime.MinValue==AV12TicketFecha_To) )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+0, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+0, 1, 1).Text = "Fecha:";
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV11TicketFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV12TicketFecha_To, 2, "/");
            AV18CellRow = (int)(AV18CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV14TicketHora_From) || ! (DateTime.MinValue==AV15TicketHora_To) )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+0, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+0, 1, 1).Text = "Hora:";
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+1, 1, 1).Text = context.localUtil.TToC( AV14TicketHora_From, 0, 5, 0, 3, "/", ":", " ")+" - "+context.localUtil.TToC( AV15TicketHora_To, 0, 5, 0, 3, "/", ":", " ");
            AV18CellRow = (int)(AV18CellRow+1);
         }
         AV18CellRow = (int)(AV18CellRow+3);
         AV21ColumnIndex = 0;
         if ( AV30GridColumnVisible_TicketId )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "RST No.";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV31GridColumnVisible_TicketFecha )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Fecha:";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_TicketHora )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Hora:";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV34GridColumnVisible_TicketLastId )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Last Id";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV35GridColumnVisible_TicketLaptop )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "aptop";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV36GridColumnVisible_TicketDesktop )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Desktop";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV37GridColumnVisible_TicketMonitor )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Monitor";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV38GridColumnVisible_TicketImpresora )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Impresora";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_TicketEscaner )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Escaner";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV40GridColumnVisible_TicketRouter )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Router";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV41GridColumnVisible_TicketSistemaOperativo )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Operativo";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV42GridColumnVisible_TicketOffice )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Office";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV43GridColumnVisible_TicketAntivirus )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Antivirus";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV44GridColumnVisible_TicketAplicacion )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Aplicación";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV45GridColumnVisible_TicketDisenio )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Diseño";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV46GridColumnVisible_TicketIngenieria )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Ingeniería";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV47GridColumnVisible_TicketDiscoDuroExterno )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Duro ";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV48GridColumnVisible_TicketPerifericos )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Periféricos";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV49GridColumnVisible_TicketUps )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "UPS";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV50GridColumnVisible_TicketApoyoUsuario )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Usuario";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV51GridColumnVisible_TicketInstalarDataShow )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Data Show";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         if ( AV52GridColumnVisible_TicketOtros )
         {
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Bold = 1;
            AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = "Otros";
            AV21ColumnIndex = (short)(AV21ColumnIndex+1);
         }
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV12TicketFecha_To ,
                                              AV11TicketFecha_From ,
                                              AV15TicketHora_To ,
                                              AV14TicketHora_From ,
                                              AV9K2BToolsGenericSearchField ,
                                              A46TicketFecha ,
                                              A48TicketHora ,
                                              A14TicketId ,
                                              A54TicketLastId ,
                                              AV16OrderedBy ,
                                              AV8UsuarioId ,
                                              A15UsuarioId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P003J3 */
         pr_default.execute(1, new Object[] {AV8UsuarioId, AV12TicketFecha_To, AV11TicketFecha_From, AV15TicketHora_To, AV14TicketHora_From, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A54TicketLastId = P003J3_A54TicketLastId[0];
            A14TicketId = P003J3_A14TicketId[0];
            A48TicketHora = P003J3_A48TicketHora[0];
            A46TicketFecha = P003J3_A46TicketFecha[0];
            A15UsuarioId = P003J3_A15UsuarioId[0];
            A53TicketLaptop = P003J3_A53TicketLaptop[0];
            A42TicketDesktop = P003J3_A42TicketDesktop[0];
            A55TicketMonitor = P003J3_A55TicketMonitor[0];
            A50TicketImpresora = P003J3_A50TicketImpresora[0];
            A45TicketEscaner = P003J3_A45TicketEscaner[0];
            A59TicketRouter = P003J3_A59TicketRouter[0];
            A60TicketSistemaOperativo = P003J3_A60TicketSistemaOperativo[0];
            A56TicketOffice = P003J3_A56TicketOffice[0];
            A39TicketAntivirus = P003J3_A39TicketAntivirus[0];
            A40TicketAplicacion = P003J3_A40TicketAplicacion[0];
            A44TicketDisenio = P003J3_A44TicketDisenio[0];
            A51TicketIngenieria = P003J3_A51TicketIngenieria[0];
            A43TicketDiscoDuroExterno = P003J3_A43TicketDiscoDuroExterno[0];
            A58TicketPerifericos = P003J3_A58TicketPerifericos[0];
            A87TicketUps = P003J3_A87TicketUps[0];
            A41TicketApoyoUsuario = P003J3_A41TicketApoyoUsuario[0];
            A52TicketInstalarDataShow = P003J3_A52TicketInstalarDataShow[0];
            A57TicketOtros = P003J3_A57TicketOtros[0];
            AV18CellRow = (int)(AV18CellRow+1);
            AV21ColumnIndex = 0;
            if ( AV30GridColumnVisible_TicketId )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Number = A14TicketId;
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV31GridColumnVisible_TicketFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A46TicketFecha ) ;
               AV17ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV32GridColumnVisible_TicketHora )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = context.localUtil.Format( A48TicketHora, "99:99");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV34GridColumnVisible_TicketLastId )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Number = A54TicketLastId;
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV35GridColumnVisible_TicketLaptop )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A53TicketLaptop ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV36GridColumnVisible_TicketDesktop )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A42TicketDesktop ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV37GridColumnVisible_TicketMonitor )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A55TicketMonitor ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV38GridColumnVisible_TicketImpresora )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A50TicketImpresora ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_TicketEscaner )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A45TicketEscaner ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV40GridColumnVisible_TicketRouter )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A59TicketRouter ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV41GridColumnVisible_TicketSistemaOperativo )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A60TicketSistemaOperativo ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV42GridColumnVisible_TicketOffice )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A56TicketOffice ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV43GridColumnVisible_TicketAntivirus )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A39TicketAntivirus ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV44GridColumnVisible_TicketAplicacion )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A40TicketAplicacion ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV45GridColumnVisible_TicketDisenio )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A44TicketDisenio ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV46GridColumnVisible_TicketIngenieria )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A51TicketIngenieria ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV47GridColumnVisible_TicketDiscoDuroExterno )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A43TicketDiscoDuroExterno ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV48GridColumnVisible_TicketPerifericos )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A58TicketPerifericos ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV49GridColumnVisible_TicketUps )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A87TicketUps ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV50GridColumnVisible_TicketApoyoUsuario )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A41TicketApoyoUsuario ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV51GridColumnVisible_TicketInstalarDataShow )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A52TicketInstalarDataShow ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            if ( AV52GridColumnVisible_TicketOtros )
            {
               AV17ExcelDocument.get_Cells(AV18CellRow, AV19FirstColumn+AV21ColumnIndex, 1, 1).Text = (A57TicketOtros ? "Si" : "No");
               AV21ColumnIndex = (short)(AV21ColumnIndex+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV17ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV17ExcelDocument.Close();
         if ( ! context.isAjaxRequest( ) )
         {
            AV24HttpResponse.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV24HttpResponse.AppendHeader("Content-Disposition", "attachment;filename=ExportUsuarioTicketWC.xlsx");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV24HttpResponse.AppendHeader("X-Frame-Options", "sameOrigin");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV24HttpResponse.AppendHeader("X-Content-Type-Options", "nosniff");
         }
         AV24HttpResponse.AddFile(AV22Filename);
         new k2bremoveexceldocument(context).executeSubmit(  AV22Filename) ;
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
         if ( AV17ExcelDocument.ErrCode != 0 )
         {
            AV22Filename = "";
            AV23ErrorMessage = AV17ExcelDocument.ErrDescription;
            AV24HttpResponse.AddString(AV23ErrorMessage);
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
         new k2bloadgridconfiguration(context ).execute(  "UsuarioTicketWC",  "Grid", ref  AV26GridConfiguration) ;
         AV28GridColumns = AV26GridConfiguration.gxTpr_Gridcolumns;
         AV30GridColumnVisible_TicketId = true;
         AV31GridColumnVisible_TicketFecha = true;
         AV32GridColumnVisible_TicketHora = true;
         AV34GridColumnVisible_TicketLastId = true;
         AV35GridColumnVisible_TicketLaptop = true;
         AV36GridColumnVisible_TicketDesktop = true;
         AV37GridColumnVisible_TicketMonitor = true;
         AV38GridColumnVisible_TicketImpresora = true;
         AV39GridColumnVisible_TicketEscaner = true;
         AV40GridColumnVisible_TicketRouter = true;
         AV41GridColumnVisible_TicketSistemaOperativo = true;
         AV42GridColumnVisible_TicketOffice = true;
         AV43GridColumnVisible_TicketAntivirus = true;
         AV44GridColumnVisible_TicketAplicacion = true;
         AV45GridColumnVisible_TicketDisenio = true;
         AV46GridColumnVisible_TicketIngenieria = true;
         AV47GridColumnVisible_TicketDiscoDuroExterno = true;
         AV48GridColumnVisible_TicketPerifericos = true;
         AV49GridColumnVisible_TicketUps = true;
         AV50GridColumnVisible_TicketApoyoUsuario = true;
         AV51GridColumnVisible_TicketInstalarDataShow = true;
         AV52GridColumnVisible_TicketOtros = true;
         new k2bsavegridconfiguration(context ).execute(  "UsuarioTicketWC",  "Grid",  AV26GridConfiguration,  false) ;
         AV28GridColumns = AV26GridConfiguration.gxTpr_Gridcolumns;
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV28GridColumns.Count )
         {
            AV29GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV28GridColumns.Item(AV59GXV1));
            if ( ! AV29GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketId") == 0 )
               {
                  AV30GridColumnVisible_TicketId = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketFecha") == 0 )
               {
                  AV31GridColumnVisible_TicketFecha = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketHora") == 0 )
               {
                  AV32GridColumnVisible_TicketHora = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketLastId") == 0 )
               {
                  AV34GridColumnVisible_TicketLastId = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketLaptop") == 0 )
               {
                  AV35GridColumnVisible_TicketLaptop = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketDesktop") == 0 )
               {
                  AV36GridColumnVisible_TicketDesktop = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketMonitor") == 0 )
               {
                  AV37GridColumnVisible_TicketMonitor = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketImpresora") == 0 )
               {
                  AV38GridColumnVisible_TicketImpresora = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketEscaner") == 0 )
               {
                  AV39GridColumnVisible_TicketEscaner = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketRouter") == 0 )
               {
                  AV40GridColumnVisible_TicketRouter = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketSistemaOperativo") == 0 )
               {
                  AV41GridColumnVisible_TicketSistemaOperativo = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketOffice") == 0 )
               {
                  AV42GridColumnVisible_TicketOffice = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketAntivirus") == 0 )
               {
                  AV43GridColumnVisible_TicketAntivirus = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketAplicacion") == 0 )
               {
                  AV44GridColumnVisible_TicketAplicacion = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketDisenio") == 0 )
               {
                  AV45GridColumnVisible_TicketDisenio = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketIngenieria") == 0 )
               {
                  AV46GridColumnVisible_TicketIngenieria = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketDiscoDuroExterno") == 0 )
               {
                  AV47GridColumnVisible_TicketDiscoDuroExterno = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketPerifericos") == 0 )
               {
                  AV48GridColumnVisible_TicketPerifericos = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketUps") == 0 )
               {
                  AV49GridColumnVisible_TicketUps = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketApoyoUsuario") == 0 )
               {
                  AV50GridColumnVisible_TicketApoyoUsuario = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketInstalarDataShow") == 0 )
               {
                  AV51GridColumnVisible_TicketInstalarDataShow = false;
               }
               else if ( StringUtil.StrCmp(AV29GridColumn.gxTpr_Attributename, "TicketOtros") == 0 )
               {
                  AV52GridColumnVisible_TicketOtros = false;
               }
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV28GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketId";
         AV29GridColumn.gxTpr_Columntitle = "RST No.";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketFecha";
         AV29GridColumn.gxTpr_Columntitle = "Fecha:";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketHora";
         AV29GridColumn.gxTpr_Columntitle = "Hora:";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketLastId";
         AV29GridColumn.gxTpr_Columntitle = "Last Id";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketLaptop";
         AV29GridColumn.gxTpr_Columntitle = "aptop";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketDesktop";
         AV29GridColumn.gxTpr_Columntitle = "Desktop";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketMonitor";
         AV29GridColumn.gxTpr_Columntitle = "Monitor";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketImpresora";
         AV29GridColumn.gxTpr_Columntitle = "Impresora";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketEscaner";
         AV29GridColumn.gxTpr_Columntitle = "Escaner";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketRouter";
         AV29GridColumn.gxTpr_Columntitle = "Router";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketSistemaOperativo";
         AV29GridColumn.gxTpr_Columntitle = "Operativo";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketOffice";
         AV29GridColumn.gxTpr_Columntitle = "Office";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketAntivirus";
         AV29GridColumn.gxTpr_Columntitle = "Antivirus";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketAplicacion";
         AV29GridColumn.gxTpr_Columntitle = "Aplicación";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketDisenio";
         AV29GridColumn.gxTpr_Columntitle = "Diseño";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketIngenieria";
         AV29GridColumn.gxTpr_Columntitle = "Ingeniería";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketDiscoDuroExterno";
         AV29GridColumn.gxTpr_Columntitle = "Duro ";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketPerifericos";
         AV29GridColumn.gxTpr_Columntitle = "Periféricos";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketUps";
         AV29GridColumn.gxTpr_Columntitle = "UPS";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketApoyoUsuario";
         AV29GridColumn.gxTpr_Columntitle = "Usuario";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketInstalarDataShow";
         AV29GridColumn.gxTpr_Columntitle = "Data Show";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV29GridColumn.gxTpr_Attributename = "TicketOtros";
         AV29GridColumn.gxTpr_Columntitle = "Otros";
         AV29GridColumn.gxTpr_Showattribute = true;
         AV28GridColumns.Add(AV29GridColumn, 0);
         AV26GridConfiguration.gxTpr_Gridcolumns = AV28GridColumns;
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
         AV22Filename = "";
         AV23ErrorMessage = "";
         AV56Pgmname = "";
         AV24HttpResponse = new GxHttpResponse( context);
         AV53Context = new SdtK2BContext(context);
         AV25File = new GxFile(context.GetPhysicalPath());
         AV17ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P003J2_A15UsuarioId = new short[1] ;
         P003J2_A93UsuarioNombre = new string[] {""} ;
         A93UsuarioNombre = "";
         lV9K2BToolsGenericSearchField = "";
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         P003J3_A54TicketLastId = new long[1] ;
         P003J3_A14TicketId = new long[1] ;
         P003J3_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         P003J3_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         P003J3_A15UsuarioId = new short[1] ;
         P003J3_A53TicketLaptop = new bool[] {false} ;
         P003J3_A42TicketDesktop = new bool[] {false} ;
         P003J3_A55TicketMonitor = new bool[] {false} ;
         P003J3_A50TicketImpresora = new bool[] {false} ;
         P003J3_A45TicketEscaner = new bool[] {false} ;
         P003J3_A59TicketRouter = new bool[] {false} ;
         P003J3_A60TicketSistemaOperativo = new bool[] {false} ;
         P003J3_A56TicketOffice = new bool[] {false} ;
         P003J3_A39TicketAntivirus = new bool[] {false} ;
         P003J3_A40TicketAplicacion = new bool[] {false} ;
         P003J3_A44TicketDisenio = new bool[] {false} ;
         P003J3_A51TicketIngenieria = new bool[] {false} ;
         P003J3_A43TicketDiscoDuroExterno = new bool[] {false} ;
         P003J3_A58TicketPerifericos = new bool[] {false} ;
         P003J3_A87TicketUps = new bool[] {false} ;
         P003J3_A41TicketApoyoUsuario = new bool[] {false} ;
         P003J3_A52TicketInstalarDataShow = new bool[] {false} ;
         P003J3_A57TicketOtros = new bool[] {false} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV26GridConfiguration = new SdtK2BGridConfiguration(context);
         AV28GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV29GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportusuarioticketwc__default(),
            new Object[][] {
                new Object[] {
               P003J2_A15UsuarioId, P003J2_A93UsuarioNombre
               }
               , new Object[] {
               P003J3_A54TicketLastId, P003J3_A14TicketId, P003J3_A48TicketHora, P003J3_A46TicketFecha, P003J3_A15UsuarioId, P003J3_A53TicketLaptop, P003J3_A42TicketDesktop, P003J3_A55TicketMonitor, P003J3_A50TicketImpresora, P003J3_A45TicketEscaner,
               P003J3_A59TicketRouter, P003J3_A60TicketSistemaOperativo, P003J3_A56TicketOffice, P003J3_A39TicketAntivirus, P003J3_A40TicketAplicacion, P003J3_A44TicketDisenio, P003J3_A51TicketIngenieria, P003J3_A43TicketDiscoDuroExterno, P003J3_A58TicketPerifericos, P003J3_A87TicketUps,
               P003J3_A41TicketApoyoUsuario, P003J3_A52TicketInstalarDataShow, P003J3_A57TicketOtros
               }
            }
         );
         AV56Pgmname = "ExportUsuarioTicketWC";
         /* GeneXus formulas. */
         AV56Pgmname = "ExportUsuarioTicketWC";
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8UsuarioId ;
      private short AV16OrderedBy ;
      private short GxWebError ;
      private short A15UsuarioId ;
      private short AV21ColumnIndex ;
      private int AV20Random ;
      private int AV18CellRow ;
      private int AV19FirstColumn ;
      private int AV59GXV1 ;
      private long A14TicketId ;
      private long A54TicketLastId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9K2BToolsGenericSearchField ;
      private string AV56Pgmname ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime AV14TicketHora_From ;
      private DateTime AV15TicketHora_To ;
      private DateTime A48TicketHora ;
      private DateTime GXt_dtime1 ;
      private DateTime AV11TicketFecha_From ;
      private DateTime AV12TicketFecha_To ;
      private DateTime A46TicketFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV30GridColumnVisible_TicketId ;
      private bool AV31GridColumnVisible_TicketFecha ;
      private bool AV32GridColumnVisible_TicketHora ;
      private bool AV34GridColumnVisible_TicketLastId ;
      private bool AV35GridColumnVisible_TicketLaptop ;
      private bool AV36GridColumnVisible_TicketDesktop ;
      private bool AV37GridColumnVisible_TicketMonitor ;
      private bool AV38GridColumnVisible_TicketImpresora ;
      private bool AV39GridColumnVisible_TicketEscaner ;
      private bool AV40GridColumnVisible_TicketRouter ;
      private bool AV41GridColumnVisible_TicketSistemaOperativo ;
      private bool AV42GridColumnVisible_TicketOffice ;
      private bool AV43GridColumnVisible_TicketAntivirus ;
      private bool AV44GridColumnVisible_TicketAplicacion ;
      private bool AV45GridColumnVisible_TicketDisenio ;
      private bool AV46GridColumnVisible_TicketIngenieria ;
      private bool AV47GridColumnVisible_TicketDiscoDuroExterno ;
      private bool AV48GridColumnVisible_TicketPerifericos ;
      private bool AV49GridColumnVisible_TicketUps ;
      private bool AV50GridColumnVisible_TicketApoyoUsuario ;
      private bool AV51GridColumnVisible_TicketInstalarDataShow ;
      private bool AV52GridColumnVisible_TicketOtros ;
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
      private string AV22Filename ;
      private string AV23ErrorMessage ;
      private string A93UsuarioNombre ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP6_OrderedBy ;
      private IDataStoreProvider pr_default ;
      private short[] P003J2_A15UsuarioId ;
      private string[] P003J2_A93UsuarioNombre ;
      private long[] P003J3_A54TicketLastId ;
      private long[] P003J3_A14TicketId ;
      private DateTime[] P003J3_A48TicketHora ;
      private DateTime[] P003J3_A46TicketFecha ;
      private short[] P003J3_A15UsuarioId ;
      private bool[] P003J3_A53TicketLaptop ;
      private bool[] P003J3_A42TicketDesktop ;
      private bool[] P003J3_A55TicketMonitor ;
      private bool[] P003J3_A50TicketImpresora ;
      private bool[] P003J3_A45TicketEscaner ;
      private bool[] P003J3_A59TicketRouter ;
      private bool[] P003J3_A60TicketSistemaOperativo ;
      private bool[] P003J3_A56TicketOffice ;
      private bool[] P003J3_A39TicketAntivirus ;
      private bool[] P003J3_A40TicketAplicacion ;
      private bool[] P003J3_A44TicketDisenio ;
      private bool[] P003J3_A51TicketIngenieria ;
      private bool[] P003J3_A43TicketDiscoDuroExterno ;
      private bool[] P003J3_A58TicketPerifericos ;
      private bool[] P003J3_A87TicketUps ;
      private bool[] P003J3_A41TicketApoyoUsuario ;
      private bool[] P003J3_A52TicketInstalarDataShow ;
      private bool[] P003J3_A57TicketOtros ;
      private GxHttpResponse AV24HttpResponse ;
      private ExcelDocumentI AV17ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV28GridColumns ;
      private GxFile AV25File ;
      private SdtK2BGridConfiguration AV26GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV29GridColumn ;
      private SdtK2BContext AV53Context ;
   }

   public class exportusuarioticketwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003J3( IGxContext context ,
                                             DateTime AV12TicketFecha_To ,
                                             DateTime AV11TicketFecha_From ,
                                             DateTime AV15TicketHora_To ,
                                             DateTime AV14TicketHora_From ,
                                             string AV9K2BToolsGenericSearchField ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             long A14TicketId ,
                                             long A54TicketLastId ,
                                             short AV16OrderedBy ,
                                             short AV8UsuarioId ,
                                             short A15UsuarioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [TicketLastId], [TicketId], [TicketHora], [TicketFecha], [UsuarioId], [TicketLaptop], [TicketDesktop], [TicketMonitor], [TicketImpresora], [TicketEscaner], [TicketRouter], [TicketSistemaOperativo], [TicketOffice], [TicketAntivirus], [TicketAplicacion], [TicketDisenio], [TicketIngenieria], [TicketDiscoDuroExterno], [TicketPerifericos], [TicketUps], [TicketApoyoUsuario], [TicketInstalarDataShow], [TicketOtros] FROM [Ticket]";
         AddWhere(sWhereString, "([UsuarioId] = @AV8UsuarioId)");
         if ( ! (DateTime.MinValue==AV12TicketFecha_To) )
         {
            AddWhere(sWhereString, "([TicketFecha] <= @AV12TicketFecha_To)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV11TicketFecha_From) )
         {
            AddWhere(sWhereString, "([TicketFecha] >= @AV11TicketFecha_From)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV15TicketHora_To) )
         {
            AddWhere(sWhereString, "([TicketHora] <= @AV15TicketHora_To)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV14TicketHora_From) )
         {
            AddWhere(sWhereString, "([TicketHora] >= @AV14TicketHora_From)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST([TicketId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(10), CAST([TicketLastId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [TicketId]";
         }
         else if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [TicketId] DESC";
         }
         else if ( AV16OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [TicketFecha]";
         }
         else if ( AV16OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [TicketFecha] DESC";
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
                     return conditional_P003J3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (long)dynConstraints[7] , (long)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
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
          Object[] prmP003J2;
          prmP003J2 = new Object[] {
          new ParDef("@AV8UsuarioId",GXType.Int16,4,0)
          };
          Object[] prmP003J3;
          prmP003J3 = new Object[] {
          new ParDef("@AV8UsuarioId",GXType.Int16,4,0) ,
          new ParDef("@AV12TicketFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV11TicketFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV15TicketHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV14TicketHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003J2", "SELECT TOP 1 [UsuarioId], [UsuarioNombre] FROM [Usuario] WHERE [UsuarioId] = @AV8UsuarioId ORDER BY [UsuarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003J2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003J3,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((bool[]) buf[6])[0] = rslt.getBool(7);
                ((bool[]) buf[7])[0] = rslt.getBool(8);
                ((bool[]) buf[8])[0] = rslt.getBool(9);
                ((bool[]) buf[9])[0] = rslt.getBool(10);
                ((bool[]) buf[10])[0] = rslt.getBool(11);
                ((bool[]) buf[11])[0] = rslt.getBool(12);
                ((bool[]) buf[12])[0] = rslt.getBool(13);
                ((bool[]) buf[13])[0] = rslt.getBool(14);
                ((bool[]) buf[14])[0] = rslt.getBool(15);
                ((bool[]) buf[15])[0] = rslt.getBool(16);
                ((bool[]) buf[16])[0] = rslt.getBool(17);
                ((bool[]) buf[17])[0] = rslt.getBool(18);
                ((bool[]) buf[18])[0] = rslt.getBool(19);
                ((bool[]) buf[19])[0] = rslt.getBool(20);
                ((bool[]) buf[20])[0] = rslt.getBool(21);
                ((bool[]) buf[21])[0] = rslt.getBool(22);
                ((bool[]) buf[22])[0] = rslt.getBool(23);
                return;
       }
    }

 }

}
