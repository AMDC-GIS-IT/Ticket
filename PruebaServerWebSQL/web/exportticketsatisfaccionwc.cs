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
   public class exportticketsatisfaccionwc : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "TicketId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8TicketId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11SatisfaccionFecha_From = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_From"));
                  AV12SatisfaccionFecha_To = context.localUtil.ParseDateParm( GetPar( "SatisfaccionFecha_To"));
                  AV14UsuarioFecha_From = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_From"));
                  AV15UsuarioFecha_To = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha_To"));
                  AV16SatisfaccionResueltoNombre = GetPar( "SatisfaccionResueltoNombre");
                  AV17SatisfaccionTecnicoProblemaNombre = GetPar( "SatisfaccionTecnicoProblemaNombre");
                  AV18SatisfaccionTecnicoCompetenteNombre = GetPar( "SatisfaccionTecnicoCompetenteNombre");
                  AV19SatisfaccionTecnicoProfesionalismoNombre = GetPar( "SatisfaccionTecnicoProfesionalismoNombre");
                  AV20SatisfaccionTiempoNombre = GetPar( "SatisfaccionTiempoNombre");
                  AV21SatisfaccionAtencionNombre = GetPar( "SatisfaccionAtencionNombre");
                  AV9K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV22OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
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

      public exportticketsatisfaccionwc( )
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

      public exportticketsatisfaccionwc( IGxContext context )
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

      public void execute( long aP0_TicketId ,
                           DateTime aP1_SatisfaccionFecha_From ,
                           DateTime aP2_SatisfaccionFecha_To ,
                           DateTime aP3_UsuarioFecha_From ,
                           DateTime aP4_UsuarioFecha_To ,
                           string aP5_SatisfaccionResueltoNombre ,
                           string aP6_SatisfaccionTecnicoProblemaNombre ,
                           string aP7_SatisfaccionTecnicoCompetenteNombre ,
                           string aP8_SatisfaccionTecnicoProfesionalismoNombre ,
                           string aP9_SatisfaccionTiempoNombre ,
                           string aP10_SatisfaccionAtencionNombre ,
                           string aP11_K2BToolsGenericSearchField ,
                           ref short aP12_OrderedBy )
      {
         this.AV8TicketId = aP0_TicketId;
         this.AV11SatisfaccionFecha_From = aP1_SatisfaccionFecha_From;
         this.AV12SatisfaccionFecha_To = aP2_SatisfaccionFecha_To;
         this.AV14UsuarioFecha_From = aP3_UsuarioFecha_From;
         this.AV15UsuarioFecha_To = aP4_UsuarioFecha_To;
         this.AV16SatisfaccionResueltoNombre = aP5_SatisfaccionResueltoNombre;
         this.AV17SatisfaccionTecnicoProblemaNombre = aP6_SatisfaccionTecnicoProblemaNombre;
         this.AV18SatisfaccionTecnicoCompetenteNombre = aP7_SatisfaccionTecnicoCompetenteNombre;
         this.AV19SatisfaccionTecnicoProfesionalismoNombre = aP8_SatisfaccionTecnicoProfesionalismoNombre;
         this.AV20SatisfaccionTiempoNombre = aP9_SatisfaccionTiempoNombre;
         this.AV21SatisfaccionAtencionNombre = aP10_SatisfaccionAtencionNombre;
         this.AV9K2BToolsGenericSearchField = aP11_K2BToolsGenericSearchField;
         this.AV22OrderedBy = aP12_OrderedBy;
         initialize();
         executePrivate();
         aP12_OrderedBy=this.AV22OrderedBy;
      }

      public short executeUdp( long aP0_TicketId ,
                               DateTime aP1_SatisfaccionFecha_From ,
                               DateTime aP2_SatisfaccionFecha_To ,
                               DateTime aP3_UsuarioFecha_From ,
                               DateTime aP4_UsuarioFecha_To ,
                               string aP5_SatisfaccionResueltoNombre ,
                               string aP6_SatisfaccionTecnicoProblemaNombre ,
                               string aP7_SatisfaccionTecnicoCompetenteNombre ,
                               string aP8_SatisfaccionTecnicoProfesionalismoNombre ,
                               string aP9_SatisfaccionTiempoNombre ,
                               string aP10_SatisfaccionAtencionNombre ,
                               string aP11_K2BToolsGenericSearchField )
      {
         execute(aP0_TicketId, aP1_SatisfaccionFecha_From, aP2_SatisfaccionFecha_To, aP3_UsuarioFecha_From, aP4_UsuarioFecha_To, aP5_SatisfaccionResueltoNombre, aP6_SatisfaccionTecnicoProblemaNombre, aP7_SatisfaccionTecnicoCompetenteNombre, aP8_SatisfaccionTecnicoProfesionalismoNombre, aP9_SatisfaccionTiempoNombre, aP10_SatisfaccionAtencionNombre, aP11_K2BToolsGenericSearchField, ref aP12_OrderedBy);
         return AV22OrderedBy ;
      }

      public void executeSubmit( long aP0_TicketId ,
                                 DateTime aP1_SatisfaccionFecha_From ,
                                 DateTime aP2_SatisfaccionFecha_To ,
                                 DateTime aP3_UsuarioFecha_From ,
                                 DateTime aP4_UsuarioFecha_To ,
                                 string aP5_SatisfaccionResueltoNombre ,
                                 string aP6_SatisfaccionTecnicoProblemaNombre ,
                                 string aP7_SatisfaccionTecnicoCompetenteNombre ,
                                 string aP8_SatisfaccionTecnicoProfesionalismoNombre ,
                                 string aP9_SatisfaccionTiempoNombre ,
                                 string aP10_SatisfaccionAtencionNombre ,
                                 string aP11_K2BToolsGenericSearchField ,
                                 ref short aP12_OrderedBy )
      {
         exportticketsatisfaccionwc objexportticketsatisfaccionwc;
         objexportticketsatisfaccionwc = new exportticketsatisfaccionwc();
         objexportticketsatisfaccionwc.AV8TicketId = aP0_TicketId;
         objexportticketsatisfaccionwc.AV11SatisfaccionFecha_From = aP1_SatisfaccionFecha_From;
         objexportticketsatisfaccionwc.AV12SatisfaccionFecha_To = aP2_SatisfaccionFecha_To;
         objexportticketsatisfaccionwc.AV14UsuarioFecha_From = aP3_UsuarioFecha_From;
         objexportticketsatisfaccionwc.AV15UsuarioFecha_To = aP4_UsuarioFecha_To;
         objexportticketsatisfaccionwc.AV16SatisfaccionResueltoNombre = aP5_SatisfaccionResueltoNombre;
         objexportticketsatisfaccionwc.AV17SatisfaccionTecnicoProblemaNombre = aP6_SatisfaccionTecnicoProblemaNombre;
         objexportticketsatisfaccionwc.AV18SatisfaccionTecnicoCompetenteNombre = aP7_SatisfaccionTecnicoCompetenteNombre;
         objexportticketsatisfaccionwc.AV19SatisfaccionTecnicoProfesionalismoNombre = aP8_SatisfaccionTecnicoProfesionalismoNombre;
         objexportticketsatisfaccionwc.AV20SatisfaccionTiempoNombre = aP9_SatisfaccionTiempoNombre;
         objexportticketsatisfaccionwc.AV21SatisfaccionAtencionNombre = aP10_SatisfaccionAtencionNombre;
         objexportticketsatisfaccionwc.AV9K2BToolsGenericSearchField = aP11_K2BToolsGenericSearchField;
         objexportticketsatisfaccionwc.AV22OrderedBy = aP12_OrderedBy;
         objexportticketsatisfaccionwc.context.SetSubmitInitialConfig(context);
         objexportticketsatisfaccionwc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportticketsatisfaccionwc);
         aP12_OrderedBy=this.AV22OrderedBy;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportticketsatisfaccionwc)stateInfo).executePrivate();
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
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "Satisfaccion",  "Satisfaccion",  "List",  "",  "TicketSatisfaccionWC") )
         {
            AV28Filename = "";
            AV29ErrorMessage = "You are not authorized to do activity";
            AV29ErrorMessage += "EntityName:" + "Satisfaccion";
            AV29ErrorMessage += "TransactionName:" + "Satisfaccion";
            AV29ErrorMessage += "ActivityType:" + "";
            AV29ErrorMessage += "PgmName:" + AV49Pgmname;
            AV30HttpResponse.AddString(AV29ErrorMessage);
            context.nUserReturn = 1;
            this.cleanup();
            if (true) return;
         }
         new k2bgetcontext(context ).execute( out  AV46Context) ;
         AV26Random = (int)(NumberUtil.Random( )*10000);
         AV28Filename = GxDirectory.TemporaryFilesPath + AV31File.Separator + "ExportTicketSatisfaccionWC-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV26Random), 8, 0)) + ".xlsx";
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV23ExcelDocument.Open(AV28Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV23ExcelDocument.Clear();
         AV23ExcelDocument.AutoFit = 1;
         AV24CellRow = 1;
         AV25FirstColumn = 1;
         AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn, 1, 1).Size = 15;
         AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn, 1, 1).Bold = 1;
         AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn, 1, 1).Text = "Satisfacciones";
         AV24CellRow = (int)(AV24CellRow+4);
         /* Using cursor P003R2 */
         pr_default.execute(0, new Object[] {AV8TicketId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14TicketId = P003R2_A14TicketId[0];
            A46TicketFecha = P003R2_A46TicketFecha[0];
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Text = "Fecha:";
            GXt_dtime1 = DateTimeUtil.ResetTime( A46TicketFecha ) ;
            AV23ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+1, 1, 1).Date = GXt_dtime1;
            AV24CellRow = (int)(AV24CellRow+1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Text = "Búsqueda";
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+1, 1, 1).Text = AV9K2BToolsGenericSearchField;
            AV24CellRow = (int)(AV24CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV11SatisfaccionFecha_From) || ! (DateTime.MinValue==AV12SatisfaccionFecha_To) )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Text = "Fecha Encuesta:";
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV11SatisfaccionFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV12SatisfaccionFecha_To, 2, "/");
            AV24CellRow = (int)(AV24CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV14UsuarioFecha_From) || ! (DateTime.MinValue==AV15UsuarioFecha_To) )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Text = "Fecha";
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+1, 1, 1).Text = context.localUtil.DToC( AV14UsuarioFecha_From, 2, "/")+" - "+context.localUtil.DToC( AV15UsuarioFecha_To, 2, "/");
            AV24CellRow = (int)(AV24CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16SatisfaccionResueltoNombre)) )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Text = "Satisfaccion Resuelto Nombre";
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV16SatisfaccionResueltoNombre);
            AV24CellRow = (int)(AV24CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17SatisfaccionTecnicoProblemaNombre)) )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Text = "Satisfaccion Tecnico Problema Nombre";
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV17SatisfaccionTecnicoProblemaNombre);
            AV24CellRow = (int)(AV24CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SatisfaccionTecnicoCompetenteNombre)) )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Text = "Satisfaccion Tecnico Competente Nombre";
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV18SatisfaccionTecnicoCompetenteNombre);
            AV24CellRow = (int)(AV24CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Text = "Satisfaccion Tecnico Profesionalismo Nombre";
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV19SatisfaccionTecnicoProfesionalismoNombre);
            AV24CellRow = (int)(AV24CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SatisfaccionTiempoNombre)) )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Text = "Satisfaccion Tiempo Nombre";
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV20SatisfaccionTiempoNombre);
            AV24CellRow = (int)(AV24CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SatisfaccionAtencionNombre)) )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+0, 1, 1).Text = "Satisfaccion Atencion Nombre";
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+1, 1, 1).Text = StringUtil.RTrim( AV21SatisfaccionAtencionNombre);
            AV24CellRow = (int)(AV24CellRow+1);
         }
         AV24CellRow = (int)(AV24CellRow+3);
         AV27ColumnIndex = 0;
         if ( AV36GridColumnVisible_SatisfaccionId )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = "Id";
            AV27ColumnIndex = (short)(AV27ColumnIndex+1);
         }
         if ( AV37GridColumnVisible_SatisfaccionFecha )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = "Fecha Encuesta:";
            AV27ColumnIndex = (short)(AV27ColumnIndex+1);
         }
         if ( AV38GridColumnVisible_UsuarioFecha )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = "Fecha Inicio:";
            AV27ColumnIndex = (short)(AV27ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_SatisfaccionResueltoNombre )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = "Satisfaccion Resuelto Nombre";
            AV27ColumnIndex = (short)(AV27ColumnIndex+1);
         }
         if ( AV40GridColumnVisible_SatisfaccionTecnicoProblemaNombre )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = "Satisfaccion Tecnico Problema Nombre";
            AV27ColumnIndex = (short)(AV27ColumnIndex+1);
         }
         if ( AV41GridColumnVisible_SatisfaccionTecnicoCompetenteNombre )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = "Satisfaccion Tecnico Competente Nombre";
            AV27ColumnIndex = (short)(AV27ColumnIndex+1);
         }
         if ( AV42GridColumnVisible_SatisfaccionTecnicoProfesionalismoNombre )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = "Satisfaccion Tecnico Profesionalismo Nombre";
            AV27ColumnIndex = (short)(AV27ColumnIndex+1);
         }
         if ( AV43GridColumnVisible_SatisfaccionTiempoNombre )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = "Satisfaccion Tiempo Nombre";
            AV27ColumnIndex = (short)(AV27ColumnIndex+1);
         }
         if ( AV44GridColumnVisible_SatisfaccionAtencionNombre )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = "Satisfaccion Atencion Nombre";
            AV27ColumnIndex = (short)(AV27ColumnIndex+1);
         }
         if ( AV45GridColumnVisible_SatisfaccionSugerencia )
         {
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Bold = 1;
            AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = "Sugerencia:";
            AV27ColumnIndex = (short)(AV27ColumnIndex+1);
         }
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV12SatisfaccionFecha_To ,
                                              AV11SatisfaccionFecha_From ,
                                              AV15UsuarioFecha_To ,
                                              AV14UsuarioFecha_From ,
                                              AV16SatisfaccionResueltoNombre ,
                                              AV17SatisfaccionTecnicoProblemaNombre ,
                                              AV18SatisfaccionTecnicoCompetenteNombre ,
                                              AV19SatisfaccionTecnicoProfesionalismoNombre ,
                                              AV20SatisfaccionTiempoNombre ,
                                              AV21SatisfaccionAtencionNombre ,
                                              AV9K2BToolsGenericSearchField ,
                                              A32SatisfaccionFecha ,
                                              A90UsuarioFecha ,
                                              A33SatisfaccionResueltoNombre ,
                                              A36SatisfaccionTecnicoProblemaNombre ,
                                              A35SatisfaccionTecnicoCompetenteNombre ,
                                              A37SatisfaccionTecnicoProfesionalismoNombre ,
                                              A38SatisfaccionTiempoNombre ,
                                              A31SatisfaccionAtencionNombre ,
                                              A7SatisfaccionId ,
                                              A34SatisfaccionSugerencia ,
                                              AV22OrderedBy ,
                                              AV8TicketId ,
                                              A14TicketId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV16SatisfaccionResueltoNombre = StringUtil.Concat( StringUtil.RTrim( AV16SatisfaccionResueltoNombre), "%", "");
         lV17SatisfaccionTecnicoProblemaNombre = StringUtil.Concat( StringUtil.RTrim( AV17SatisfaccionTecnicoProblemaNombre), "%", "");
         lV18SatisfaccionTecnicoCompetenteNombre = StringUtil.Concat( StringUtil.RTrim( AV18SatisfaccionTecnicoCompetenteNombre), "%", "");
         lV19SatisfaccionTecnicoProfesionalismoNombre = StringUtil.Concat( StringUtil.RTrim( AV19SatisfaccionTecnicoProfesionalismoNombre), "%", "");
         lV20SatisfaccionTiempoNombre = StringUtil.Concat( StringUtil.RTrim( AV20SatisfaccionTiempoNombre), "%", "");
         lV21SatisfaccionAtencionNombre = StringUtil.Concat( StringUtil.RTrim( AV21SatisfaccionAtencionNombre), "%", "");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         lV9K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV9K2BToolsGenericSearchField), 200, "%");
         /* Using cursor P003R3 */
         pr_default.execute(1, new Object[] {AV8TicketId, AV12SatisfaccionFecha_To, AV11SatisfaccionFecha_From, AV15UsuarioFecha_To, AV14UsuarioFecha_From, lV16SatisfaccionResueltoNombre, lV17SatisfaccionTecnicoProblemaNombre, lV18SatisfaccionTecnicoCompetenteNombre, lV19SatisfaccionTecnicoProfesionalismoNombre, lV20SatisfaccionTiempoNombre, lV21SatisfaccionAtencionNombre, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField, lV9K2BToolsGenericSearchField});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A15UsuarioId = P003R3_A15UsuarioId[0];
            A8SatisfaccionResueltoId = P003R3_A8SatisfaccionResueltoId[0];
            A9SatisfaccionTecnicoProblemaId = P003R3_A9SatisfaccionTecnicoProblemaId[0];
            A10SatisfaccionTecnicoCompetenteId = P003R3_A10SatisfaccionTecnicoCompetenteId[0];
            A11SatisfaccionTecnicoProfesionalismoId = P003R3_A11SatisfaccionTecnicoProfesionalismoId[0];
            A12SatisfaccionTiempoId = P003R3_A12SatisfaccionTiempoId[0];
            A13SatisfaccionAtencionId = P003R3_A13SatisfaccionAtencionId[0];
            A34SatisfaccionSugerencia = P003R3_A34SatisfaccionSugerencia[0];
            A7SatisfaccionId = P003R3_A7SatisfaccionId[0];
            A31SatisfaccionAtencionNombre = P003R3_A31SatisfaccionAtencionNombre[0];
            A38SatisfaccionTiempoNombre = P003R3_A38SatisfaccionTiempoNombre[0];
            A37SatisfaccionTecnicoProfesionalismoNombre = P003R3_A37SatisfaccionTecnicoProfesionalismoNombre[0];
            A35SatisfaccionTecnicoCompetenteNombre = P003R3_A35SatisfaccionTecnicoCompetenteNombre[0];
            A36SatisfaccionTecnicoProblemaNombre = P003R3_A36SatisfaccionTecnicoProblemaNombre[0];
            A33SatisfaccionResueltoNombre = P003R3_A33SatisfaccionResueltoNombre[0];
            A90UsuarioFecha = P003R3_A90UsuarioFecha[0];
            A32SatisfaccionFecha = P003R3_A32SatisfaccionFecha[0];
            A14TicketId = P003R3_A14TicketId[0];
            A33SatisfaccionResueltoNombre = P003R3_A33SatisfaccionResueltoNombre[0];
            A36SatisfaccionTecnicoProblemaNombre = P003R3_A36SatisfaccionTecnicoProblemaNombre[0];
            A35SatisfaccionTecnicoCompetenteNombre = P003R3_A35SatisfaccionTecnicoCompetenteNombre[0];
            A37SatisfaccionTecnicoProfesionalismoNombre = P003R3_A37SatisfaccionTecnicoProfesionalismoNombre[0];
            A38SatisfaccionTiempoNombre = P003R3_A38SatisfaccionTiempoNombre[0];
            A31SatisfaccionAtencionNombre = P003R3_A31SatisfaccionAtencionNombre[0];
            A15UsuarioId = P003R3_A15UsuarioId[0];
            A90UsuarioFecha = P003R3_A90UsuarioFecha[0];
            AV24CellRow = (int)(AV24CellRow+1);
            AV27ColumnIndex = 0;
            if ( AV36GridColumnVisible_SatisfaccionId )
            {
               AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Number = A7SatisfaccionId;
               AV27ColumnIndex = (short)(AV27ColumnIndex+1);
            }
            if ( AV37GridColumnVisible_SatisfaccionFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A32SatisfaccionFecha ) ;
               AV23ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV27ColumnIndex = (short)(AV27ColumnIndex+1);
            }
            if ( AV38GridColumnVisible_UsuarioFecha )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A90UsuarioFecha ) ;
               AV23ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
               AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV27ColumnIndex = (short)(AV27ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_SatisfaccionResueltoNombre )
            {
               AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = StringUtil.RTrim( A33SatisfaccionResueltoNombre);
               AV27ColumnIndex = (short)(AV27ColumnIndex+1);
            }
            if ( AV40GridColumnVisible_SatisfaccionTecnicoProblemaNombre )
            {
               AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = StringUtil.RTrim( A36SatisfaccionTecnicoProblemaNombre);
               AV27ColumnIndex = (short)(AV27ColumnIndex+1);
            }
            if ( AV41GridColumnVisible_SatisfaccionTecnicoCompetenteNombre )
            {
               AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = StringUtil.RTrim( A35SatisfaccionTecnicoCompetenteNombre);
               AV27ColumnIndex = (short)(AV27ColumnIndex+1);
            }
            if ( AV42GridColumnVisible_SatisfaccionTecnicoProfesionalismoNombre )
            {
               AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = StringUtil.RTrim( A37SatisfaccionTecnicoProfesionalismoNombre);
               AV27ColumnIndex = (short)(AV27ColumnIndex+1);
            }
            if ( AV43GridColumnVisible_SatisfaccionTiempoNombre )
            {
               AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = StringUtil.RTrim( A38SatisfaccionTiempoNombre);
               AV27ColumnIndex = (short)(AV27ColumnIndex+1);
            }
            if ( AV44GridColumnVisible_SatisfaccionAtencionNombre )
            {
               AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = StringUtil.RTrim( A31SatisfaccionAtencionNombre);
               AV27ColumnIndex = (short)(AV27ColumnIndex+1);
            }
            if ( AV45GridColumnVisible_SatisfaccionSugerencia )
            {
               AV23ExcelDocument.get_Cells(AV24CellRow, AV25FirstColumn+AV27ColumnIndex, 1, 1).Text = StringUtil.RTrim( A34SatisfaccionSugerencia);
               AV27ColumnIndex = (short)(AV27ColumnIndex+1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV23ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV23ExcelDocument.Close();
         if ( ! context.isAjaxRequest( ) )
         {
            AV30HttpResponse.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV30HttpResponse.AppendHeader("Content-Disposition", "attachment;filename=ExportTicketSatisfaccionWC.xlsx");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV30HttpResponse.AppendHeader("X-Frame-Options", "sameOrigin");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV30HttpResponse.AppendHeader("X-Content-Type-Options", "nosniff");
         }
         AV30HttpResponse.AddFile(AV28Filename);
         new k2bremoveexceldocument(context).executeSubmit(  AV28Filename) ;
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
         if ( AV23ExcelDocument.ErrCode != 0 )
         {
            AV28Filename = "";
            AV29ErrorMessage = AV23ExcelDocument.ErrDescription;
            AV30HttpResponse.AddString(AV29ErrorMessage);
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
         new k2bloadgridconfiguration(context ).execute(  "TicketSatisfaccionWC",  "Grid", ref  AV32GridConfiguration) ;
         AV34GridColumns = AV32GridConfiguration.gxTpr_Gridcolumns;
         AV36GridColumnVisible_SatisfaccionId = true;
         AV37GridColumnVisible_SatisfaccionFecha = true;
         AV38GridColumnVisible_UsuarioFecha = true;
         AV39GridColumnVisible_SatisfaccionResueltoNombre = true;
         AV40GridColumnVisible_SatisfaccionTecnicoProblemaNombre = true;
         AV41GridColumnVisible_SatisfaccionTecnicoCompetenteNombre = true;
         AV42GridColumnVisible_SatisfaccionTecnicoProfesionalismoNombre = true;
         AV43GridColumnVisible_SatisfaccionTiempoNombre = true;
         AV44GridColumnVisible_SatisfaccionAtencionNombre = true;
         AV45GridColumnVisible_SatisfaccionSugerencia = true;
         new k2bsavegridconfiguration(context ).execute(  "TicketSatisfaccionWC",  "Grid",  AV32GridConfiguration,  false) ;
         AV34GridColumns = AV32GridConfiguration.gxTpr_Gridcolumns;
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV34GridColumns.Count )
         {
            AV35GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV34GridColumns.Item(AV52GXV1));
            if ( ! AV35GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV35GridColumn.gxTpr_Attributename, "SatisfaccionId") == 0 )
               {
                  AV36GridColumnVisible_SatisfaccionId = false;
               }
               else if ( StringUtil.StrCmp(AV35GridColumn.gxTpr_Attributename, "SatisfaccionFecha") == 0 )
               {
                  AV37GridColumnVisible_SatisfaccionFecha = false;
               }
               else if ( StringUtil.StrCmp(AV35GridColumn.gxTpr_Attributename, "UsuarioFecha") == 0 )
               {
                  AV38GridColumnVisible_UsuarioFecha = false;
               }
               else if ( StringUtil.StrCmp(AV35GridColumn.gxTpr_Attributename, "SatisfaccionResueltoNombre") == 0 )
               {
                  AV39GridColumnVisible_SatisfaccionResueltoNombre = false;
               }
               else if ( StringUtil.StrCmp(AV35GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoProblemaNombre") == 0 )
               {
                  AV40GridColumnVisible_SatisfaccionTecnicoProblemaNombre = false;
               }
               else if ( StringUtil.StrCmp(AV35GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoCompetenteNombre") == 0 )
               {
                  AV41GridColumnVisible_SatisfaccionTecnicoCompetenteNombre = false;
               }
               else if ( StringUtil.StrCmp(AV35GridColumn.gxTpr_Attributename, "SatisfaccionTecnicoProfesionalismoNombre") == 0 )
               {
                  AV42GridColumnVisible_SatisfaccionTecnicoProfesionalismoNombre = false;
               }
               else if ( StringUtil.StrCmp(AV35GridColumn.gxTpr_Attributename, "SatisfaccionTiempoNombre") == 0 )
               {
                  AV43GridColumnVisible_SatisfaccionTiempoNombre = false;
               }
               else if ( StringUtil.StrCmp(AV35GridColumn.gxTpr_Attributename, "SatisfaccionAtencionNombre") == 0 )
               {
                  AV44GridColumnVisible_SatisfaccionAtencionNombre = false;
               }
               else if ( StringUtil.StrCmp(AV35GridColumn.gxTpr_Attributename, "SatisfaccionSugerencia") == 0 )
               {
                  AV45GridColumnVisible_SatisfaccionSugerencia = false;
               }
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV34GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV35GridColumn.gxTpr_Attributename = "SatisfaccionId";
         AV35GridColumn.gxTpr_Columntitle = "Id";
         AV35GridColumn.gxTpr_Showattribute = true;
         AV34GridColumns.Add(AV35GridColumn, 0);
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV35GridColumn.gxTpr_Attributename = "SatisfaccionFecha";
         AV35GridColumn.gxTpr_Columntitle = "Fecha Encuesta:";
         AV35GridColumn.gxTpr_Showattribute = true;
         AV34GridColumns.Add(AV35GridColumn, 0);
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV35GridColumn.gxTpr_Attributename = "UsuarioFecha";
         AV35GridColumn.gxTpr_Columntitle = "Fecha Inicio:";
         AV35GridColumn.gxTpr_Showattribute = true;
         AV34GridColumns.Add(AV35GridColumn, 0);
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV35GridColumn.gxTpr_Attributename = "SatisfaccionResueltoNombre";
         AV35GridColumn.gxTpr_Columntitle = "Satisfaccion Resuelto Nombre";
         AV35GridColumn.gxTpr_Showattribute = true;
         AV34GridColumns.Add(AV35GridColumn, 0);
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV35GridColumn.gxTpr_Attributename = "SatisfaccionTecnicoProblemaNombre";
         AV35GridColumn.gxTpr_Columntitle = "Satisfaccion Tecnico Problema Nombre";
         AV35GridColumn.gxTpr_Showattribute = true;
         AV34GridColumns.Add(AV35GridColumn, 0);
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV35GridColumn.gxTpr_Attributename = "SatisfaccionTecnicoCompetenteNombre";
         AV35GridColumn.gxTpr_Columntitle = "Satisfaccion Tecnico Competente Nombre";
         AV35GridColumn.gxTpr_Showattribute = true;
         AV34GridColumns.Add(AV35GridColumn, 0);
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV35GridColumn.gxTpr_Attributename = "SatisfaccionTecnicoProfesionalismoNombre";
         AV35GridColumn.gxTpr_Columntitle = "Satisfaccion Tecnico Profesionalismo Nombre";
         AV35GridColumn.gxTpr_Showattribute = true;
         AV34GridColumns.Add(AV35GridColumn, 0);
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV35GridColumn.gxTpr_Attributename = "SatisfaccionTiempoNombre";
         AV35GridColumn.gxTpr_Columntitle = "Satisfaccion Tiempo Nombre";
         AV35GridColumn.gxTpr_Showattribute = true;
         AV34GridColumns.Add(AV35GridColumn, 0);
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV35GridColumn.gxTpr_Attributename = "SatisfaccionAtencionNombre";
         AV35GridColumn.gxTpr_Columntitle = "Satisfaccion Atencion Nombre";
         AV35GridColumn.gxTpr_Showattribute = true;
         AV34GridColumns.Add(AV35GridColumn, 0);
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV35GridColumn.gxTpr_Attributename = "SatisfaccionSugerencia";
         AV35GridColumn.gxTpr_Columntitle = "Sugerencia:";
         AV35GridColumn.gxTpr_Showattribute = true;
         AV34GridColumns.Add(AV35GridColumn, 0);
         AV32GridConfiguration.gxTpr_Gridcolumns = AV34GridColumns;
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
         AV28Filename = "";
         AV29ErrorMessage = "";
         AV49Pgmname = "";
         AV30HttpResponse = new GxHttpResponse( context);
         AV46Context = new SdtK2BContext(context);
         AV31File = new GxFile(context.GetPhysicalPath());
         AV23ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P003R2_A14TicketId = new long[1] ;
         P003R2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         A46TicketFecha = DateTime.MinValue;
         lV16SatisfaccionResueltoNombre = "";
         lV17SatisfaccionTecnicoProblemaNombre = "";
         lV18SatisfaccionTecnicoCompetenteNombre = "";
         lV19SatisfaccionTecnicoProfesionalismoNombre = "";
         lV20SatisfaccionTiempoNombre = "";
         lV21SatisfaccionAtencionNombre = "";
         lV9K2BToolsGenericSearchField = "";
         A32SatisfaccionFecha = DateTime.MinValue;
         A90UsuarioFecha = DateTime.MinValue;
         A33SatisfaccionResueltoNombre = "";
         A36SatisfaccionTecnicoProblemaNombre = "";
         A35SatisfaccionTecnicoCompetenteNombre = "";
         A37SatisfaccionTecnicoProfesionalismoNombre = "";
         A38SatisfaccionTiempoNombre = "";
         A31SatisfaccionAtencionNombre = "";
         A34SatisfaccionSugerencia = "";
         P003R3_A15UsuarioId = new short[1] ;
         P003R3_A8SatisfaccionResueltoId = new short[1] ;
         P003R3_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         P003R3_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         P003R3_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         P003R3_A12SatisfaccionTiempoId = new short[1] ;
         P003R3_A13SatisfaccionAtencionId = new short[1] ;
         P003R3_A34SatisfaccionSugerencia = new string[] {""} ;
         P003R3_A7SatisfaccionId = new long[1] ;
         P003R3_A31SatisfaccionAtencionNombre = new string[] {""} ;
         P003R3_A38SatisfaccionTiempoNombre = new string[] {""} ;
         P003R3_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         P003R3_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         P003R3_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         P003R3_A33SatisfaccionResueltoNombre = new string[] {""} ;
         P003R3_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         P003R3_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         P003R3_A14TicketId = new long[1] ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV32GridConfiguration = new SdtK2BGridConfiguration(context);
         AV34GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV35GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportticketsatisfaccionwc__default(),
            new Object[][] {
                new Object[] {
               P003R2_A14TicketId, P003R2_A46TicketFecha
               }
               , new Object[] {
               P003R3_A15UsuarioId, P003R3_A8SatisfaccionResueltoId, P003R3_A9SatisfaccionTecnicoProblemaId, P003R3_A10SatisfaccionTecnicoCompetenteId, P003R3_A11SatisfaccionTecnicoProfesionalismoId, P003R3_A12SatisfaccionTiempoId, P003R3_A13SatisfaccionAtencionId, P003R3_A34SatisfaccionSugerencia, P003R3_A7SatisfaccionId, P003R3_A31SatisfaccionAtencionNombre,
               P003R3_A38SatisfaccionTiempoNombre, P003R3_A37SatisfaccionTecnicoProfesionalismoNombre, P003R3_A35SatisfaccionTecnicoCompetenteNombre, P003R3_A36SatisfaccionTecnicoProblemaNombre, P003R3_A33SatisfaccionResueltoNombre, P003R3_A90UsuarioFecha, P003R3_A32SatisfaccionFecha, P003R3_A14TicketId
               }
            }
         );
         AV49Pgmname = "ExportTicketSatisfaccionWC";
         /* GeneXus formulas. */
         AV49Pgmname = "ExportTicketSatisfaccionWC";
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV22OrderedBy ;
      private short GxWebError ;
      private short AV27ColumnIndex ;
      private short A15UsuarioId ;
      private short A8SatisfaccionResueltoId ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short A10SatisfaccionTecnicoCompetenteId ;
      private short A11SatisfaccionTecnicoProfesionalismoId ;
      private short A12SatisfaccionTiempoId ;
      private short A13SatisfaccionAtencionId ;
      private int AV26Random ;
      private int AV24CellRow ;
      private int AV25FirstColumn ;
      private int AV52GXV1 ;
      private long AV8TicketId ;
      private long A14TicketId ;
      private long A7SatisfaccionId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV9K2BToolsGenericSearchField ;
      private string AV49Pgmname ;
      private string scmdbuf ;
      private string lV9K2BToolsGenericSearchField ;
      private DateTime GXt_dtime1 ;
      private DateTime AV11SatisfaccionFecha_From ;
      private DateTime AV12SatisfaccionFecha_To ;
      private DateTime AV14UsuarioFecha_From ;
      private DateTime AV15UsuarioFecha_To ;
      private DateTime A46TicketFecha ;
      private DateTime A32SatisfaccionFecha ;
      private DateTime A90UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV36GridColumnVisible_SatisfaccionId ;
      private bool AV37GridColumnVisible_SatisfaccionFecha ;
      private bool AV38GridColumnVisible_UsuarioFecha ;
      private bool AV39GridColumnVisible_SatisfaccionResueltoNombre ;
      private bool AV40GridColumnVisible_SatisfaccionTecnicoProblemaNombre ;
      private bool AV41GridColumnVisible_SatisfaccionTecnicoCompetenteNombre ;
      private bool AV42GridColumnVisible_SatisfaccionTecnicoProfesionalismoNombre ;
      private bool AV43GridColumnVisible_SatisfaccionTiempoNombre ;
      private bool AV44GridColumnVisible_SatisfaccionAtencionNombre ;
      private bool AV45GridColumnVisible_SatisfaccionSugerencia ;
      private string AV16SatisfaccionResueltoNombre ;
      private string AV17SatisfaccionTecnicoProblemaNombre ;
      private string AV18SatisfaccionTecnicoCompetenteNombre ;
      private string AV19SatisfaccionTecnicoProfesionalismoNombre ;
      private string AV20SatisfaccionTiempoNombre ;
      private string AV21SatisfaccionAtencionNombre ;
      private string AV28Filename ;
      private string AV29ErrorMessage ;
      private string lV16SatisfaccionResueltoNombre ;
      private string lV17SatisfaccionTecnicoProblemaNombre ;
      private string lV18SatisfaccionTecnicoCompetenteNombre ;
      private string lV19SatisfaccionTecnicoProfesionalismoNombre ;
      private string lV20SatisfaccionTiempoNombre ;
      private string lV21SatisfaccionAtencionNombre ;
      private string A33SatisfaccionResueltoNombre ;
      private string A36SatisfaccionTecnicoProblemaNombre ;
      private string A35SatisfaccionTecnicoCompetenteNombre ;
      private string A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string A38SatisfaccionTiempoNombre ;
      private string A31SatisfaccionAtencionNombre ;
      private string A34SatisfaccionSugerencia ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private short aP12_OrderedBy ;
      private IDataStoreProvider pr_default ;
      private long[] P003R2_A14TicketId ;
      private DateTime[] P003R2_A46TicketFecha ;
      private short[] P003R3_A15UsuarioId ;
      private short[] P003R3_A8SatisfaccionResueltoId ;
      private short[] P003R3_A9SatisfaccionTecnicoProblemaId ;
      private short[] P003R3_A10SatisfaccionTecnicoCompetenteId ;
      private short[] P003R3_A11SatisfaccionTecnicoProfesionalismoId ;
      private short[] P003R3_A12SatisfaccionTiempoId ;
      private short[] P003R3_A13SatisfaccionAtencionId ;
      private string[] P003R3_A34SatisfaccionSugerencia ;
      private long[] P003R3_A7SatisfaccionId ;
      private string[] P003R3_A31SatisfaccionAtencionNombre ;
      private string[] P003R3_A38SatisfaccionTiempoNombre ;
      private string[] P003R3_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string[] P003R3_A35SatisfaccionTecnicoCompetenteNombre ;
      private string[] P003R3_A36SatisfaccionTecnicoProblemaNombre ;
      private string[] P003R3_A33SatisfaccionResueltoNombre ;
      private DateTime[] P003R3_A90UsuarioFecha ;
      private DateTime[] P003R3_A32SatisfaccionFecha ;
      private long[] P003R3_A14TicketId ;
      private GxHttpResponse AV30HttpResponse ;
      private ExcelDocumentI AV23ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV34GridColumns ;
      private GxFile AV31File ;
      private SdtK2BGridConfiguration AV32GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV35GridColumn ;
      private SdtK2BContext AV46Context ;
   }

   public class exportticketsatisfaccionwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003R3( IGxContext context ,
                                             DateTime AV12SatisfaccionFecha_To ,
                                             DateTime AV11SatisfaccionFecha_From ,
                                             DateTime AV15UsuarioFecha_To ,
                                             DateTime AV14UsuarioFecha_From ,
                                             string AV16SatisfaccionResueltoNombre ,
                                             string AV17SatisfaccionTecnicoProblemaNombre ,
                                             string AV18SatisfaccionTecnicoCompetenteNombre ,
                                             string AV19SatisfaccionTecnicoProfesionalismoNombre ,
                                             string AV20SatisfaccionTiempoNombre ,
                                             string AV21SatisfaccionAtencionNombre ,
                                             string AV9K2BToolsGenericSearchField ,
                                             DateTime A32SatisfaccionFecha ,
                                             DateTime A90UsuarioFecha ,
                                             string A33SatisfaccionResueltoNombre ,
                                             string A36SatisfaccionTecnicoProblemaNombre ,
                                             string A35SatisfaccionTecnicoCompetenteNombre ,
                                             string A37SatisfaccionTecnicoProfesionalismoNombre ,
                                             string A38SatisfaccionTiempoNombre ,
                                             string A31SatisfaccionAtencionNombre ,
                                             long A7SatisfaccionId ,
                                             string A34SatisfaccionSugerencia ,
                                             short AV22OrderedBy ,
                                             long AV8TicketId ,
                                             long A14TicketId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[19];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T8.[UsuarioId], T1.[SatisfaccionResueltoId] AS SatisfaccionResueltoId, T1.[SatisfaccionTecnicoProblemaId] AS SatisfaccionTecnicoProblemaId, T1.[SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, T1.[SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, T1.[SatisfaccionTiempoId] AS SatisfaccionTiempoId, T1.[SatisfaccionAtencionId] AS SatisfaccionAtencionId, T1.[SatisfaccionSugerencia], T1.[SatisfaccionId], T7.[EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, T6.[EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, T5.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, T4.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, T3.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, T2.[EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, T9.[UsuarioFecha], T1.[SatisfaccionFecha], T1.[TicketId] FROM (((((((([Satisfaccion] T1 INNER JOIN [EstadoSatisfaccion] T2 ON T2.[EstadoSatisfaccionId] = T1.[SatisfaccionResueltoId]) INNER JOIN [EstadoSatisfaccion] T3 ON T3.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = T1.[SatisfaccionTecnicoProfesionalismoId]) INNER JOIN [EstadoSatisfaccion] T6 ON T6.[EstadoSatisfaccionId] = T1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T7 ON T7.[EstadoSatisfaccionId] = T1.[SatisfaccionAtencionId]) INNER JOIN [Ticket] T8 ON T8.[TicketId] = T1.[TicketId]) INNER JOIN [Usuario] T9 ON T9.[UsuarioId] = T8.[UsuarioId])";
         AddWhere(sWhereString, "(T1.[TicketId] = @AV8TicketId)");
         if ( ! (DateTime.MinValue==AV12SatisfaccionFecha_To) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] <= @AV12SatisfaccionFecha_To)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV11SatisfaccionFecha_From) )
         {
            AddWhere(sWhereString, "(T1.[SatisfaccionFecha] >= @AV11SatisfaccionFecha_From)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV15UsuarioFecha_To) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioFecha] <= @AV15UsuarioFecha_To)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV14UsuarioFecha_From) )
         {
            AddWhere(sWhereString, "(T9.[UsuarioFecha] >= @AV14UsuarioFecha_From)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16SatisfaccionResueltoNombre)) )
         {
            AddWhere(sWhereString, "(T2.[EstadoSatisfaccionNombre] like @lV16SatisfaccionResueltoNombre)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17SatisfaccionTecnicoProblemaNombre)) )
         {
            AddWhere(sWhereString, "(T3.[EstadoSatisfaccionNombre] like @lV17SatisfaccionTecnicoProblemaNombre)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SatisfaccionTecnicoCompetenteNombre)) )
         {
            AddWhere(sWhereString, "(T4.[EstadoSatisfaccionNombre] like @lV18SatisfaccionTecnicoCompetenteNombre)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SatisfaccionTecnicoProfesionalismoNombre)) )
         {
            AddWhere(sWhereString, "(T5.[EstadoSatisfaccionNombre] like @lV19SatisfaccionTecnicoProfesionalismoNombre)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SatisfaccionTiempoNombre)) )
         {
            AddWhere(sWhereString, "(T6.[EstadoSatisfaccionNombre] like @lV20SatisfaccionTiempoNombre)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SatisfaccionAtencionNombre)) )
         {
            AddWhere(sWhereString, "(T7.[EstadoSatisfaccionNombre] like @lV21SatisfaccionAtencionNombre)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "(CONVERT( char(10), CAST(T1.[SatisfaccionId] AS decimal(10,0))) like '%' + @lV9K2BToolsGenericSearchField + '%' or T2.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T3.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T4.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T5.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T6.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T7.[EstadoSatisfaccionNombre] like '%' + @lV9K2BToolsGenericSearchField + '%' or T1.[SatisfaccionSugerencia] like '%' + @lV9K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int2[11] = 1;
            GXv_int2[12] = 1;
            GXv_int2[13] = 1;
            GXv_int2[14] = 1;
            GXv_int2[15] = 1;
            GXv_int2[16] = 1;
            GXv_int2[17] = 1;
            GXv_int2[18] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV22OrderedBy == 0 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionId]";
         }
         else if ( AV22OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionId] DESC";
         }
         else if ( AV22OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionFecha]";
         }
         else if ( AV22OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T1.[SatisfaccionFecha] DESC";
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
                     return conditional_P003R3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (long)dynConstraints[22] , (long)dynConstraints[23] );
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
          Object[] prmP003R2;
          prmP003R2 = new Object[] {
          new ParDef("@AV8TicketId",GXType.Decimal,10,0)
          };
          Object[] prmP003R3;
          prmP003R3 = new Object[] {
          new ParDef("@AV8TicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV12SatisfaccionFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV11SatisfaccionFecha_From",GXType.Date,8,0) ,
          new ParDef("@AV15UsuarioFecha_To",GXType.Date,8,0) ,
          new ParDef("@AV14UsuarioFecha_From",GXType.Date,8,0) ,
          new ParDef("@lV16SatisfaccionResueltoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV17SatisfaccionTecnicoProblemaNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV18SatisfaccionTecnicoCompetenteNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV19SatisfaccionTecnicoProfesionalismoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV20SatisfaccionTiempoNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV21SatisfaccionAtencionNombre",GXType.NVarChar,30,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.Char,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0) ,
          new ParDef("@lV9K2BToolsGenericSearchField",GXType.NChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003R2", "SELECT TOP 1 [TicketId], [TicketFecha] FROM [Ticket] WHERE [TicketId] = @AV8TicketId ORDER BY [TicketId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003R2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003R3,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(16);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
                ((long[]) buf[17])[0] = rslt.getLong(18);
                return;
       }
    }

 }

}
