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
   public class exportestadoticketusuariowc : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "EstadoTicketId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8EstadoTicketId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10UsuarioNombre = GetPar( "UsuarioNombre");
                  AV12UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
                  AV13UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
                  AV15UsuarioHora_From = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "UsuarioHora_From")));
                  AV16UsuarioHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "UsuarioHora_To")));
                  AV9K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV17OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
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

      public exportestadoticketusuariowc( )
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

      public exportestadoticketusuariowc( IGxContext context )
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

      public void execute( short aP0_EstadoTicketId ,
                           string aP1_UsuarioNombre ,
                           DateTime aP2_UsuarioFecha_From ,
                           DateTime aP3_UsuarioFecha_To ,
                           DateTime aP4_UsuarioHora_From ,
                           DateTime aP5_UsuarioHora_To ,
                           string aP6_K2BToolsGenericSearchField ,
                           ref short aP7_OrderedBy )
      {
         this.AV8EstadoTicketId = aP0_EstadoTicketId;
         this.AV10UsuarioNombre = aP1_UsuarioNombre;
         this.AV12UsuarioFecha_From = aP2_UsuarioFecha_From;
         this.AV13UsuarioFecha_To = aP3_UsuarioFecha_To;
         this.AV15UsuarioHora_From = aP4_UsuarioHora_From;
         this.AV16UsuarioHora_To = aP5_UsuarioHora_To;
         this.AV9K2BToolsGenericSearchField = aP6_K2BToolsGenericSearchField;
         this.AV17OrderedBy = aP7_OrderedBy;
         initialize();
         executePrivate();
         aP7_OrderedBy=this.AV17OrderedBy;
      }

      public short executeUdp( short aP0_EstadoTicketId ,
                               string aP1_UsuarioNombre ,
                               DateTime aP2_UsuarioFecha_From ,
                               DateTime aP3_UsuarioFecha_To ,
                               DateTime aP4_UsuarioHora_From ,
                               DateTime aP5_UsuarioHora_To ,
                               string aP6_K2BToolsGenericSearchField )
      {
         execute(aP0_EstadoTicketId, aP1_UsuarioNombre, aP2_UsuarioFecha_From, aP3_UsuarioFecha_To, aP4_UsuarioHora_From, aP5_UsuarioHora_To, aP6_K2BToolsGenericSearchField, ref aP7_OrderedBy);
         return AV17OrderedBy ;
      }

      public void executeSubmit( short aP0_EstadoTicketId ,
                                 string aP1_UsuarioNombre ,
                                 DateTime aP2_UsuarioFecha_From ,
                                 DateTime aP3_UsuarioFecha_To ,
                                 DateTime aP4_UsuarioHora_From ,
                                 DateTime aP5_UsuarioHora_To ,
                                 string aP6_K2BToolsGenericSearchField ,
                                 ref short aP7_OrderedBy )
      {
         exportestadoticketusuariowc objexportestadoticketusuariowc;
         objexportestadoticketusuariowc = new exportestadoticketusuariowc();
         objexportestadoticketusuariowc.AV8EstadoTicketId = aP0_EstadoTicketId;
         objexportestadoticketusuariowc.AV10UsuarioNombre = aP1_UsuarioNombre;
         objexportestadoticketusuariowc.AV12UsuarioFecha_From = aP2_UsuarioFecha_From;
         objexportestadoticketusuariowc.AV13UsuarioFecha_To = aP3_UsuarioFecha_To;
         objexportestadoticketusuariowc.AV15UsuarioHora_From = aP4_UsuarioHora_From;
         objexportestadoticketusuariowc.AV16UsuarioHora_To = aP5_UsuarioHora_To;
         objexportestadoticketusuariowc.AV9K2BToolsGenericSearchField = aP6_K2BToolsGenericSearchField;
         objexportestadoticketusuariowc.AV17OrderedBy = aP7_OrderedBy;
         objexportestadoticketusuariowc.context.SetSubmitInitialConfig(context);
         objexportestadoticketusuariowc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportestadoticketusuariowc);
         aP7_OrderedBy=this.AV17OrderedBy;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportestadoticketusuariowc)stateInfo).executePrivate();
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
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Usuario",  "Usuario",  "List",  "",  "EstadoTicketUsuarioWC") )
         {
            AV23Filename = "";
            AV24ErrorMessage = "You are not authorized to do activity";
            AV24ErrorMessage += "EntityName:" + "Usuario";
            AV24ErrorMessage += "TransactionName:" + "Usuario";
            AV24ErrorMessage += "ActivityType:" + "";
            AV24ErrorMessage += "PgmName:" + AV43Pgmname;
            AV25HttpResponse.AddString(AV24ErrorMessage);
            context.nUserReturn = 1;
            this.cleanup();
            if (true) return;
         }
         new k2bgetcontext(context ).execute( out  AV40Context) ;
         AV21Random = (int)(NumberUtil.Random( )*10000);
         AV23Filename = GxDirectory.TemporaryFilesPath + AV26File.Separator + "ExportEstadoTicketUsuarioWC-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV21Random), 8, 0)) + ".xlsx";
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV18ExcelDocument.Open(AV23Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV18ExcelDocument.Clear();
         AV18ExcelDocument.AutoFit = 1;
         AV19CellRow = 1;
         AV20FirstColumn = 1;
         AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn, 1, 1).Size = 15;
         AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn, 1, 1).Bold = 1;
         AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn, 1, 1).Text = "Usuarios";
         AV19CellRow = (int)(AV19CellRow+4);
         /* Using cursor P003D2 */
         pr_default.execute(0, new Object[] {AV8EstadoTicketId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5EstadoTicketId = P003D2_A5EstadoTicketId[0];
            A24EstadoTicketNombre = P003D2_A24EstadoTicketNombre[0];
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Text = "Estado Ticket:";
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+1, 1, 1).Text = StringUtil.RTrim( A24EstadoTicketNombre);
            AV19CellRow = (int)(AV19CellRow+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+1, 1, 1).Text = AV9K2BToolsGenericSearchField;
            AV19CellRow = (int)(AV19CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10UsuarioNombre)) )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Text = "Usuario:";
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV10UsuarioNombre);
            AV19CellRow = (int)(AV19CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV12UsuarioFecha_From) || ! (DateTime.MinValue==AV13UsuarioFecha_To) )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Text = "Fecha Inicio:";
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV12UsuarioFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV13UsuarioFecha_To, 2, "/");
            AV19CellRow = (int)(AV19CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV15UsuarioHora_From) || ! (DateTime.MinValue==AV16UsuarioHora_To) )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+0, 1, 1).Text = "Hora Inicio:";
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+1, 1, 1).Text = context.localUtil.TToC( AV15UsuarioHora_From, 0, 5, 0, 3, "/", ":", " ")+" - "+context.localUtil.TToC( AV16UsuarioHora_To, 0, 5, 0, 3, "/", ":", " ");
            AV19CellRow = (int)(AV19CellRow+1);
         }
         AV19CellRow = (int)(AV19CellRow+3);
         AV22ColumnIndex = 0;
         if ( AV31GridColumnVisible_UsuarioId )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Id Usuario:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV32GridColumnVisible_UsuarioNombre )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Usuario:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV33GridColumnVisible_UsuarioFecha )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Fecha Inicio:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV34GridColumnVisible_UsuarioHora )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Hora Inicio:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV35GridColumnVisible_UsuarioGerencia )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Gerencia:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV36GridColumnVisible_UsuarioDepartamento )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Departamento:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV37GridColumnVisible_UsuarioRequerimiento )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Descripción del Requerimiento:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV38GridColumnVisible_UsuarioEmail )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Email:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_UsuarioTelefono )
         {
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Bold = 1;
            AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = "Teléfono:";
            AV22ColumnIndex = (short)(AV22ColumnIndex+1);
         }
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV10UsuarioNombre ,
                                              AV13UsuarioFecha_To ,
                                              AV12UsuarioFecha_From ,
                                              AV16UsuarioHora_To ,
                                              AV15UsuarioHora_From ,
                                              AV9K2BToolsGenericSearchField ,
                                              A93UsuarioNombre ,
                                              A90UsuarioFecha ,
                                              A92UsuarioHora ,
                                              A15UsuarioId ,
                                              A91UsuarioGerencia ,
                                              A88UsuarioDepartamento ,
                                              A94UsuarioRequerimiento ,
                                              A89UsuarioEmail ,
                                              A95UsuarioTelefono ,
                                              AV17OrderedBy ,
                                              A5EstadoTicketId ,
                                              AV8EstadoTicketId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT
                                              }
         });
         lV10UsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV10UsuarioNombre), "%", "");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P003D3 */
         pr_default.execute(1, new Object[] {A5EstadoTicketId, AV8EstadoTicketId, lV10UsuarioNombre, AV13UsuarioFecha_To, AV12UsuarioFecha_From, AV16UsuarioHora_To, AV15UsuarioHora_From, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A95UsuarioTelefono = P003D3_A95UsuarioTelefono[0];
            A89UsuarioEmail = P003D3_A89UsuarioEmail[0];
            A94UsuarioRequerimiento = P003D3_A94UsuarioRequerimiento[0];
            A88UsuarioDepartamento = P003D3_A88UsuarioDepartamento[0];
            A91UsuarioGerencia = P003D3_A91UsuarioGerencia[0];
            A15UsuarioId = P003D3_A15UsuarioId[0];
            A92UsuarioHora = P003D3_A92UsuarioHora[0];
            A90UsuarioFecha = P003D3_A90UsuarioFecha[0];
            A93UsuarioNombre = P003D3_A93UsuarioNombre[0];
            AV19CellRow = (int)(AV19CellRow+1);
            AV22ColumnIndex = 0;
            if ( AV31GridColumnVisible_UsuarioId )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Number = A15UsuarioId;
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV32GridColumnVisible_UsuarioNombre )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = StringUtil.RTrim( A93UsuarioNombre);
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV33GridColumnVisible_UsuarioFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A90UsuarioFecha ) ;
               AV18ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV34GridColumnVisible_UsuarioHora )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = context.localUtil.Format( A92UsuarioHora, "99:99");
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV35GridColumnVisible_UsuarioGerencia )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = StringUtil.RTrim( A91UsuarioGerencia);
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV36GridColumnVisible_UsuarioDepartamento )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = StringUtil.RTrim( A88UsuarioDepartamento);
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV37GridColumnVisible_UsuarioRequerimiento )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = StringUtil.RTrim( A94UsuarioRequerimiento);
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV38GridColumnVisible_UsuarioEmail )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Text = StringUtil.RTrim( A89UsuarioEmail);
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_UsuarioTelefono )
            {
               AV18ExcelDocument.get_Cells(AV19CellRow, AV20FirstColumn+AV22ColumnIndex, 1, 1).Number = A95UsuarioTelefono;
               AV22ColumnIndex = (short)(AV22ColumnIndex+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV18ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV18ExcelDocument.Close();
         if ( ! context.isAjaxRequest( ) )
         {
            AV25HttpResponse.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV25HttpResponse.AppendHeader("Content-Disposition", "attachment;filename=ExportEstadoTicketUsuarioWC.xlsx");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV25HttpResponse.AppendHeader("X-Frame-Options", "sameOrigin");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV25HttpResponse.AppendHeader("X-Content-Type-Options", "nosniff");
         }
         AV25HttpResponse.AddFile(AV23Filename);
         new k2bremoveexceldocument(context).executeSubmit(  AV23Filename) ;
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
         if ( AV18ExcelDocument.ErrCode != 0 )
         {
            AV23Filename = "";
            AV24ErrorMessage = AV18ExcelDocument.ErrDescription;
            AV25HttpResponse.AddString(AV24ErrorMessage);
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
         new k2bloadgridconfiguration(context ).execute(  "EstadoTicketUsuarioWC",  "Grid", ref  AV27GridConfiguration) ;
         AV29GridColumns = AV27GridConfiguration.gxTpr_Gridcolumns;
         AV31GridColumnVisible_UsuarioId = true;
         AV32GridColumnVisible_UsuarioNombre = true;
         AV33GridColumnVisible_UsuarioFecha = true;
         AV34GridColumnVisible_UsuarioHora = true;
         AV35GridColumnVisible_UsuarioGerencia = true;
         AV36GridColumnVisible_UsuarioDepartamento = true;
         AV37GridColumnVisible_UsuarioRequerimiento = true;
         AV38GridColumnVisible_UsuarioEmail = true;
         AV39GridColumnVisible_UsuarioTelefono = true;
         new k2bsavegridconfiguration(context ).execute(  "EstadoTicketUsuarioWC",  "Grid",  AV27GridConfiguration,  false) ;
         AV29GridColumns = AV27GridConfiguration.gxTpr_Gridcolumns;
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV29GridColumns.Count )
         {
            AV30GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV29GridColumns.Item(AV46GXV1));
            if ( ! AV30GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  AV31GridColumnVisible_UsuarioId = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioNombre") == 0 )
               {
                  AV32GridColumnVisible_UsuarioNombre = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
               {
                  AV33GridColumnVisible_UsuarioFecha = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioHora") == 0 )
               {
                  AV34GridColumnVisible_UsuarioHora = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioGerencia") == 0 )
               {
                  AV35GridColumnVisible_UsuarioGerencia = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioDepartamento") == 0 )
               {
                  AV36GridColumnVisible_UsuarioDepartamento = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioRequerimiento") == 0 )
               {
                  AV37GridColumnVisible_UsuarioRequerimiento = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioEmail") == 0 )
               {
                  AV38GridColumnVisible_UsuarioEmail = false;
               }
               else if ( StringUtil.StrCmp(AV30GridColumn.gxTpr_Attributename, "UsuarioTelefono") == 0 )
               {
                  AV39GridColumnVisible_UsuarioTelefono = false;
               }
            }
            AV46GXV1 = (int)(AV46GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV29GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioId";
         AV30GridColumn.gxTpr_Columntitle = "Id Usuario:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioNombre";
         AV30GridColumn.gxTpr_Columntitle = "Usuario:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioFecha";
         AV30GridColumn.gxTpr_Columntitle = "Fecha Inicio:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioHora";
         AV30GridColumn.gxTpr_Columntitle = "Hora Inicio:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioGerencia";
         AV30GridColumn.gxTpr_Columntitle = "Gerencia:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioDepartamento";
         AV30GridColumn.gxTpr_Columntitle = "Departamento:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioRequerimiento";
         AV30GridColumn.gxTpr_Columntitle = "Descripción del Requerimiento:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioEmail";
         AV30GridColumn.gxTpr_Columntitle = "Email:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV30GridColumn.gxTpr_Attributename = "UsuarioTelefono";
         AV30GridColumn.gxTpr_Columntitle = "Teléfono:";
         AV30GridColumn.gxTpr_Showattribute = true;
         AV29GridColumns.Add(AV30GridColumn, 0);
         AV27GridConfiguration.gxTpr_Gridcolumns = AV29GridColumns;
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
         AV23Filename = "";
         AV24ErrorMessage = "";
         AV43Pgmname = "";
         AV25HttpResponse = new GxHttpResponse( context);
         AV40Context = new SdtK2BContext(context);
         AV26File = new GxFile(context.GetPhysicalPath());
         AV18ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P003D2_A5EstadoTicketId = new short[1] ;
         P003D2_A24EstadoTicketNombre = new string[] {""} ;
         A24EstadoTicketNombre = "";
         lV10UsuarioNombre = "";
         lV9K2BToolsGenericSearchField = "";
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A94UsuarioRequerimiento = "";
         A89UsuarioEmail = "";
         P003D3_A95UsuarioTelefono = new int[1] ;
         P003D3_A89UsuarioEmail = new string[] {""} ;
         P003D3_A94UsuarioRequerimiento = new string[] {""} ;
         P003D3_A88UsuarioDepartamento = new string[] {""} ;
         P003D3_A91UsuarioGerencia = new string[] {""} ;
         P003D3_A15UsuarioId = new short[1] ;
         P003D3_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         P003D3_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         P003D3_A93UsuarioNombre = new string[] {""} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV27GridConfiguration = new SdtK2BGridConfiguration(context);
         AV29GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV30GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportestadoticketusuariowc__default(),
            new Object[][] {
                new Object[] {
               P003D2_A5EstadoTicketId, P003D2_A24EstadoTicketNombre
               }
               , new Object[] {
               P003D3_A95UsuarioTelefono, P003D3_A89UsuarioEmail, P003D3_A94UsuarioRequerimiento, P003D3_A88UsuarioDepartamento, P003D3_A91UsuarioGerencia, P003D3_A15UsuarioId, P003D3_A92UsuarioHora, P003D3_A90UsuarioFecha, P003D3_A93UsuarioNombre
               }
            }
         );
         AV43Pgmname = "ExportEstadoTicketUsuarioWC";
         /* GeneXus formulas. */
         AV43Pgmname = "ExportEstadoTicketUsuarioWC";
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8EstadoTicketId ;
      private short AV17OrderedBy ;
      private short GxWebError ;
      private short A5EstadoTicketId ;
      private short AV22ColumnIndex ;
      private short A15UsuarioId ;
      private int AV21Random ;
      private int AV19CellRow ;
      private int AV20FirstColumn ;
      private int A95UsuarioTelefono ;
      private int AV46GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9K2BToolsGenericSearchField ;
      private string AV43Pgmname ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime AV15UsuarioHora_From ;
      private DateTime AV16UsuarioHora_To ;
      private DateTime A92UsuarioHora ;
      private DateTime GXt_dtime1 ;
      private DateTime AV12UsuarioFecha_From ;
      private DateTime AV13UsuarioFecha_To ;
      private DateTime A90UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV31GridColumnVisible_UsuarioId ;
      private bool AV32GridColumnVisible_UsuarioNombre ;
      private bool AV33GridColumnVisible_UsuarioFecha ;
      private bool AV34GridColumnVisible_UsuarioHora ;
      private bool AV35GridColumnVisible_UsuarioGerencia ;
      private bool AV36GridColumnVisible_UsuarioDepartamento ;
      private bool AV37GridColumnVisible_UsuarioRequerimiento ;
      private bool AV38GridColumnVisible_UsuarioEmail ;
      private bool AV39GridColumnVisible_UsuarioTelefono ;
      private string AV10UsuarioNombre ;
      private string AV23Filename ;
      private string AV24ErrorMessage ;
      private string A24EstadoTicketNombre ;
      private string lV10UsuarioNombre ;
      private string A93UsuarioNombre ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A94UsuarioRequerimiento ;
      private string A89UsuarioEmail ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP7_OrderedBy ;
      private IDataStoreProvider pr_default ;
      private short[] P003D2_A5EstadoTicketId ;
      private string[] P003D2_A24EstadoTicketNombre ;
      private int[] P003D3_A95UsuarioTelefono ;
      private string[] P003D3_A89UsuarioEmail ;
      private string[] P003D3_A94UsuarioRequerimiento ;
      private string[] P003D3_A88UsuarioDepartamento ;
      private string[] P003D3_A91UsuarioGerencia ;
      private short[] P003D3_A15UsuarioId ;
      private DateTime[] P003D3_A92UsuarioHora ;
      private DateTime[] P003D3_A90UsuarioFecha ;
      private string[] P003D3_A93UsuarioNombre ;
      private GxHttpResponse AV25HttpResponse ;
      private ExcelDocumentI AV18ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV29GridColumns ;
      private GxFile AV26File ;
      private SdtK2BGridConfiguration AV27GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV30GridColumn ;
      private SdtK2BContext AV40Context ;
   }

   public class exportestadoticketusuariowc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003D3( IGxContext context ,
                                             string AV10UsuarioNombre ,
                                             DateTime AV13UsuarioFecha_To ,
                                             DateTime AV12UsuarioFecha_From ,
                                             DateTime AV16UsuarioHora_To ,
                                             DateTime AV15UsuarioHora_From ,
                                             string AV9K2BToolsGenericSearchField ,
                                             string A93UsuarioNombre ,
                                             DateTime A90UsuarioFecha ,
                                             DateTime A92UsuarioHora ,
                                             short A15UsuarioId ,
                                             string A91UsuarioGerencia ,
                                             string A88UsuarioDepartamento ,
                                             string A94UsuarioRequerimiento ,
                                             string A89UsuarioEmail ,
                                             int A95UsuarioTelefono ,
                                             short AV17OrderedBy ,
                                             short A5EstadoTicketId ,
                                             short AV8EstadoTicketId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [UsuarioTelefono], [UsuarioEmail], [UsuarioRequerimiento], [UsuarioDepartamento], [UsuarioGerencia], [UsuarioId], [UsuarioHora], [UsuarioFecha], [UsuarioNombre] FROM [Usuario]";
         AddWhere(sWhereString, "(@EstadoTicketId = @AV8EstadoTicketId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10UsuarioNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like @lV10UsuarioNombre)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV13UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] <= @AV13UsuarioFecha_To)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV12UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] >= @AV12UsuarioFecha_From)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV16UsuarioHora_To) )
         {
            AddWhere(sWhereString, "([UsuarioHora] <= @AV16UsuarioHora_To)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV15UsuarioHora_From) )
         {
            AddWhere(sWhereString, "([UsuarioHora] >= @AV15UsuarioHora_From)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(4), CAST([UsuarioId] AS decimal(4,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or [UsuarioNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or [UsuarioGerencia] like '%' + @lV9K2BToolsGenericSearchField + '%' or [UsuarioDepartamento] like '%' + @lV9K2BToolsGenericSearchField + '%' or [UsuarioRequerimiento] like '%' + @lV9K2BToolsGenericSearchField + '%' or [UsuarioEmail] like '%' + @lV9K2BToolsGenericSearchField + '%' or CONVERT( char(9), CAST([UsuarioTelefono] AS decimal(9,0))) like '%' + @lV9K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
            GXv_int2[10] = 1;
            GXv_int2[11] = 1;
            GXv_int2[12] = 1;
            GXv_int2[13] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV17OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY [UsuarioId]";
         }
         else if ( AV17OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY [UsuarioId] DESC";
         }
         else if ( AV17OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY [UsuarioNombre]";
         }
         else if ( AV17OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY [UsuarioNombre] DESC";
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
                     return conditional_P003D3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (short)dynConstraints[15] , (short)dynConstraints[16] , (short)dynConstraints[17] );
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
          Object[] prmP003D2;
          prmP003D2 = new Object[] {
          new ParDef("@AV8EstadoTicketId",GXType.Int16,4,0)
          };
          Object[] prmP003D3;
          prmP003D3 = new Object[] {
          new ParDef("@EstadoTicketId",GXType.Int16,4,0) ,
          new ParDef("@AV8EstadoTicketId",GXType.Int16,4,0) ,
          new ParDef("@lV10UsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@AV13UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV12UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV16UsuarioHora_To",GXType.DateTime,0,5) ,
          new ParDef("@AV15UsuarioHora_From",GXType.DateTime,0,5) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003D2", "SELECT TOP 1 [EstadoTicketId], [EstadoTicketNombre] FROM [EstadoTicket] WHERE [EstadoTicketId] = @AV8EstadoTicketId ORDER BY [EstadoTicketId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003D2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003D3,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

}
