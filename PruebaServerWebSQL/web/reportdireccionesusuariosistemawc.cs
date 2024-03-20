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
using GeneXus.Printer;
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
   public class reportdireccionesusuariosistemawc : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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
            gxfirstwebparm = GetFirstPar( "DireccionId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV9DireccionId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV16UsuarioSistemaIdentidad = GetPar( "UsuarioSistemaIdentidad");
                  AV17DepartamentoNombre = GetPar( "DepartamentoNombre");
                  AV10K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
                  AV11OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
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

      public reportdireccionesusuariosistemawc( )
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

      public reportdireccionesusuariosistemawc( IGxContext context )
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

      public void execute( short aP0_DireccionId ,
                           string aP1_UsuarioSistemaIdentidad ,
                           string aP2_DepartamentoNombre ,
                           string aP3_K2BToolsGenericSearchField ,
                           short aP4_OrderedBy )
      {
         this.AV9DireccionId = aP0_DireccionId;
         this.AV16UsuarioSistemaIdentidad = aP1_UsuarioSistemaIdentidad;
         this.AV17DepartamentoNombre = aP2_DepartamentoNombre;
         this.AV10K2BToolsGenericSearchField = aP3_K2BToolsGenericSearchField;
         this.AV11OrderedBy = aP4_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_DireccionId ,
                                 string aP1_UsuarioSistemaIdentidad ,
                                 string aP2_DepartamentoNombre ,
                                 string aP3_K2BToolsGenericSearchField ,
                                 short aP4_OrderedBy )
      {
         reportdireccionesusuariosistemawc objreportdireccionesusuariosistemawc;
         objreportdireccionesusuariosistemawc = new reportdireccionesusuariosistemawc();
         objreportdireccionesusuariosistemawc.AV9DireccionId = aP0_DireccionId;
         objreportdireccionesusuariosistemawc.AV16UsuarioSistemaIdentidad = aP1_UsuarioSistemaIdentidad;
         objreportdireccionesusuariosistemawc.AV17DepartamentoNombre = aP2_DepartamentoNombre;
         objreportdireccionesusuariosistemawc.AV10K2BToolsGenericSearchField = aP3_K2BToolsGenericSearchField;
         objreportdireccionesusuariosistemawc.AV11OrderedBy = aP4_OrderedBy;
         objreportdireccionesusuariosistemawc.context.SetSubmitInitialConfig(context);
         objreportdireccionesusuariosistemawc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportdireccionesusuariosistemawc);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportdireccionesusuariosistemawc)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 9, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            new k2bgetcontext(context ).execute( out  AV8Context) ;
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "UsuarioSistema",  "UsuarioSistema",  "List",  "",  AV29Pgmname) )
            {
               H630( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usted no está autorizado a ver el reporte", 71, Gx_line+0, 755, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H630( false, 40) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario sistemas", 238, Gx_line+0, 589, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) )
               {
                  H630( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Búsqueda", 10, Gx_line+7, 69, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10K2BToolsGenericSearchField, "")), 230, Gx_line+7, 1689, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16UsuarioSistemaIdentidad)) )
               {
                  H630( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Sistema Identidad", 10, Gx_line+7, 135, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16UsuarioSistemaIdentidad, "")), 143, Gx_line+7, 363, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17DepartamentoNombre)) )
               {
                  H630( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Departamento Nombre", 10, Gx_line+7, 150, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DepartamentoNombre, "")), 158, Gx_line+7, 2018, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               H630( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Sistema Id", 18, Gx_line+7, 748, Gx_line+22, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV16UsuarioSistemaIdentidad ,
                                                    A101UsuarioSistemaIdentidad ,
                                                    AV11OrderedBy ,
                                                    AV10K2BToolsGenericSearchField ,
                                                    A99UsuarioSistemaId ,
                                                    A100UsuarioSistemaNombre ,
                                                    A263UsuarioSistemaGerencia ,
                                                    A257UsuarioSistemaDepartamento ,
                                                    A261DepartamentoNombre ,
                                                    AV17DepartamentoNombre ,
                                                    AV9DireccionId ,
                                                    A258DireccionId } ,
                                                    new int[]{
                                                    TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                    }
               });
               lV16UsuarioSistemaIdentidad = StringUtil.Concat( StringUtil.RTrim( AV16UsuarioSistemaIdentidad), "%", "");
               /* Using cursor P00632 */
               pr_default.execute(0, new Object[] {AV9DireccionId, lV16UsuarioSistemaIdentidad});
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A259CentrodecostoId = P00632_A259CentrodecostoId[0];
                  A260DepartamentoId = P00632_A260DepartamentoId[0];
                  A258DireccionId = P00632_A258DireccionId[0];
                  A257UsuarioSistemaDepartamento = P00632_A257UsuarioSistemaDepartamento[0];
                  n257UsuarioSistemaDepartamento = P00632_n257UsuarioSistemaDepartamento[0];
                  A263UsuarioSistemaGerencia = P00632_A263UsuarioSistemaGerencia[0];
                  n263UsuarioSistemaGerencia = P00632_n263UsuarioSistemaGerencia[0];
                  A100UsuarioSistemaNombre = P00632_A100UsuarioSistemaNombre[0];
                  A99UsuarioSistemaId = P00632_A99UsuarioSistemaId[0];
                  A101UsuarioSistemaIdentidad = P00632_A101UsuarioSistemaIdentidad[0];
                  /* Using cursor P00633 */
                  pr_datastore2.execute(0, new Object[] {A259CentrodecostoId, A260DepartamentoId});
                  A261DepartamentoNombre = P00633_A261DepartamentoNombre[0];
                  pr_datastore2.close(0);
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17DepartamentoNombre)) || ( StringUtil.Like( A261DepartamentoNombre , StringUtil.PadR( AV17DepartamentoNombre , 300 , "%"),  ' ' ) ) )
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10K2BToolsGenericSearchField)) || ( StringUtil.Like( A99UsuarioSistemaId , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A101UsuarioSistemaIdentidad , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A100UsuarioSistemaNombre , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 202 , "%"),  ' ' ) || StringUtil.Like( A263UsuarioSistemaGerencia , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A257UsuarioSistemaDepartamento , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) || StringUtil.Like( A261DepartamentoNombre , StringUtil.PadR( "%" + AV10K2BToolsGenericSearchField + "%" , 300 , "%"),  ' ' ) ) )
                     {
                        AV23LineCount_30 = (short)(LVCharUtil.LinesWrap( A99UsuarioSistemaId, 104));
                        AV24Multiline_UsuarioSistemaId = LVCharUtil.GetLineWrap( A99UsuarioSistemaId, 1, 104);
                        H630( false, 23) ;
                        getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Multiline_UsuarioSistemaId, "")), 18, Gx_line+7, 748, Gx_line+23, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+23);
                        AV22K2BT_CMR = 2;
                        while ( AV22K2BT_CMR <= AV23LineCount_30 )
                        {
                           if ( AV22K2BT_CMR <= AV23LineCount_30 )
                           {
                              AV24Multiline_UsuarioSistemaId = LVCharUtil.GetLineWrap( A99UsuarioSistemaId, AV22K2BT_CMR, 104);
                           }
                           else
                           {
                              AV24Multiline_UsuarioSistemaId = "";
                           }
                           H630( false, 16) ;
                           getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Multiline_UsuarioSistemaId, "")), 18, Gx_line+0, 748, Gx_line+16, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+16);
                           AV22K2BT_CMR = (short)(AV22K2BT_CMR+1);
                        }
                        H630( false, 14) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+14);
                     }
                  }
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               pr_datastore2.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H630( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H630( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxDrawLine(50, Gx_line+0, 775, Gx_line+0, 1, 211, 211, 211, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 383, Gx_line+33, 398, Gx_line+47, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("{{Pages}}", 417, Gx_line+33, 432, Gx_line+47, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Page", 353, Gx_line+33, 383, Gx_line+47, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("of", 400, Gx_line+33, 415, Gx_line+47, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+50);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "b7ea4f08-f7a5-4fad-b32e-2c1b1255fdbb", "", context.GetTheme( )), 0, Gx_line+0, 75, Gx_line+67) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 608, Gx_line+0, 653, Gx_line+15, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Date", 575, Gx_line+0, 608, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Page", 720, Gx_line+0, 750, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("of", 767, Gx_line+0, 782, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("{{Pages}}", 783, Gx_line+0, 798, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 750, Gx_line+0, 765, Gx_line+14, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+71);
               if ( GxHdr3 )
               {
                  getPrinter().GxDrawLine(10, Gx_line+0, 817, Gx_line+0, 1, 211, 211, 211, 0) ;
                  getPrinter().GxDrawLine(10, Gx_line+29, 817, Gx_line+29, 1, 211, 211, 211, 0) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Sistema Id", 18, Gx_line+7, 748, Gx_line+22, 0, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
         add_metrics2( ) ;
         add_metrics3( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Courier New", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Courier New", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
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
         AV8Context = new SdtK2BContext(context);
         AV29Pgmname = "";
         scmdbuf = "";
         lV16UsuarioSistemaIdentidad = "";
         A101UsuarioSistemaIdentidad = "";
         A99UsuarioSistemaId = "";
         A100UsuarioSistemaNombre = "";
         A263UsuarioSistemaGerencia = "";
         A257UsuarioSistemaDepartamento = "";
         A261DepartamentoNombre = "";
         P00632_A259CentrodecostoId = new string[] {""} ;
         P00632_A260DepartamentoId = new short[1] ;
         P00632_A258DireccionId = new short[1] ;
         P00632_A257UsuarioSistemaDepartamento = new string[] {""} ;
         P00632_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         P00632_A263UsuarioSistemaGerencia = new string[] {""} ;
         P00632_n263UsuarioSistemaGerencia = new bool[] {false} ;
         P00632_A100UsuarioSistemaNombre = new string[] {""} ;
         P00632_A99UsuarioSistemaId = new string[] {""} ;
         P00632_A101UsuarioSistemaIdentidad = new string[] {""} ;
         A259CentrodecostoId = "";
         P00633_A261DepartamentoNombre = new string[] {""} ;
         AV24Multiline_UsuarioSistemaId = "";
         Gx_date = DateTime.MinValue;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.reportdireccionesusuariosistemawc__datastore2(),
            new Object[][] {
                new Object[] {
               P00633_A261DepartamentoNombre
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportdireccionesusuariosistemawc__default(),
            new Object[][] {
                new Object[] {
               P00632_A259CentrodecostoId, P00632_A260DepartamentoId, P00632_A258DireccionId, P00632_A257UsuarioSistemaDepartamento, P00632_n257UsuarioSistemaDepartamento, P00632_A263UsuarioSistemaGerencia, P00632_n263UsuarioSistemaGerencia, P00632_A100UsuarioSistemaNombre, P00632_A99UsuarioSistemaId, P00632_A101UsuarioSistemaIdentidad
               }
            }
         );
         AV29Pgmname = "ReportDireccionesUsuarioSistemaWC";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV29Pgmname = "ReportDireccionesUsuarioSistemaWC";
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV9DireccionId ;
      private short AV11OrderedBy ;
      private short GxWebError ;
      private short A258DireccionId ;
      private short A260DepartamentoId ;
      private short AV23LineCount_30 ;
      private short AV22K2BT_CMR ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV10K2BToolsGenericSearchField ;
      private string AV29Pgmname ;
      private string scmdbuf ;
      private string AV24Multiline_UsuarioSistemaId ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr3 ;
      private bool n257UsuarioSistemaDepartamento ;
      private bool n263UsuarioSistemaGerencia ;
      private string AV16UsuarioSistemaIdentidad ;
      private string AV17DepartamentoNombre ;
      private string lV16UsuarioSistemaIdentidad ;
      private string A101UsuarioSistemaIdentidad ;
      private string A99UsuarioSistemaId ;
      private string A100UsuarioSistemaNombre ;
      private string A263UsuarioSistemaGerencia ;
      private string A257UsuarioSistemaDepartamento ;
      private string A261DepartamentoNombre ;
      private string A259CentrodecostoId ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00632_A259CentrodecostoId ;
      private short[] P00632_A260DepartamentoId ;
      private short[] P00632_A258DireccionId ;
      private string[] P00632_A257UsuarioSistemaDepartamento ;
      private bool[] P00632_n257UsuarioSistemaDepartamento ;
      private string[] P00632_A263UsuarioSistemaGerencia ;
      private bool[] P00632_n263UsuarioSistemaGerencia ;
      private string[] P00632_A100UsuarioSistemaNombre ;
      private string[] P00632_A99UsuarioSistemaId ;
      private string[] P00632_A101UsuarioSistemaIdentidad ;
      private IDataStoreProvider pr_datastore2 ;
      private string[] P00633_A261DepartamentoNombre ;
      private SdtK2BContext AV8Context ;
   }

   public class reportdireccionesusuariosistemawc__datastore2 : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00633;
          prmP00633 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00633", "SELECT [DepartamentoNombre] FROM dbo.[Depto] WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00633,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class reportdireccionesusuariosistemawc__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00632( IGxContext context ,
                                           string AV16UsuarioSistemaIdentidad ,
                                           string A101UsuarioSistemaIdentidad ,
                                           short AV11OrderedBy ,
                                           string AV10K2BToolsGenericSearchField ,
                                           string A99UsuarioSistemaId ,
                                           string A100UsuarioSistemaNombre ,
                                           string A263UsuarioSistemaGerencia ,
                                           string A257UsuarioSistemaDepartamento ,
                                           string A261DepartamentoNombre ,
                                           string AV17DepartamentoNombre ,
                                           short AV9DireccionId ,
                                           short A258DireccionId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int1 = new short[2];
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT [CentrodecostoId], [DepartamentoId], [DireccionId], [UsuarioSistemaDepartamento], [UsuarioSistemaGerencia], [UsuarioSistemaNombre], [UsuarioSistemaId], [UsuarioSistemaIdentidad] FROM [UsuarioSistema]";
       AddWhere(sWhereString, "([DireccionId] = @AV9DireccionId)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16UsuarioSistemaIdentidad)) )
       {
          AddWhere(sWhereString, "([UsuarioSistemaIdentidad] like @lV16UsuarioSistemaIdentidad)");
       }
       else
       {
          GXv_int1[1] = 1;
       }
       scmdbuf += sWhereString;
       if ( AV11OrderedBy == 0 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId]";
       }
       else if ( AV11OrderedBy == 1 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaId] DESC";
       }
       else if ( AV11OrderedBy == 2 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad]";
       }
       else if ( AV11OrderedBy == 3 )
       {
          scmdbuf += " ORDER BY [UsuarioSistemaIdentidad] DESC";
       }
       GXv_Object2[0] = scmdbuf;
       GXv_Object2[1] = GXv_int1;
       return GXv_Object2 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_P00632(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

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
        Object[] prmP00632;
        prmP00632 = new Object[] {
        new ParDef("@AV9DireccionId",GXType.Int16,4,0) ,
        new ParDef("@lV16UsuarioSistemaIdentidad",GXType.NVarChar,30,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00632", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00632,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              return;
     }
  }

}

}
