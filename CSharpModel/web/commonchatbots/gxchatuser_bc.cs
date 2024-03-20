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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.commonchatbots {
   public class gxchatuser_bc : GXHttpHandler, IGxSilentTrn
   {
      public gxchatuser_bc( )
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

      public gxchatuser_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0K21( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0K21( ) ;
         standaloneModal( ) ;
         AddRow0K21( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z268GXChatUserId = (Guid)(A268GXChatUserId);
               Z269GXChatUserDevice = A269GXChatUserDevice;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0K0( )
      {
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0K21( ) ;
            }
            else
            {
               CheckExtendedTable0K21( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0K21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0K21( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z268GXChatUserId = (Guid)(A268GXChatUserId);
            Z269GXChatUserDevice = A269GXChatUserDevice;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A268GXChatUserId) )
         {
            A268GXChatUserId = (Guid)(Guid.NewGuid( ));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0K21( )
      {
         /* Using cursor BC000K4 */
         pr_default.execute(2, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound21 = 1;
            ZM0K21( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0K21( ) ;
      }

      protected void OnLoadActions0K21( )
      {
      }

      protected void CheckExtendedTable0K21( )
      {
         nIsDirty_21 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0K21( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0K21( )
      {
         /* Using cursor BC000K5 */
         pr_default.execute(3, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000K3 */
         pr_default.execute(1, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0K21( 3) ;
            RcdFound21 = 1;
            A268GXChatUserId = (Guid)((Guid)(BC000K3_A268GXChatUserId[0]));
            A269GXChatUserDevice = BC000K3_A269GXChatUserDevice[0];
            Z268GXChatUserId = (Guid)(A268GXChatUserId);
            Z269GXChatUserDevice = A269GXChatUserDevice;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0K21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0K21( ) ;
            }
            Gx_mode = sMode21;
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0K21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode21;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0K21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0K0( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0K21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000K2 */
            pr_default.execute(0, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"GXChatUser"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"GXChatUser"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K21( )
      {
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K21( 0) ;
            CheckOptimisticConcurrency0K21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000K6 */
                     pr_default.execute(4, new Object[] {A269GXChatUserDevice, A268GXChatUserId});
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("GXChatUser");
                     if ( (pr_default.getStatus(4) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0K21( ) ;
            }
            EndLevel0K21( ) ;
         }
         CloseExtendedTableCursors0K21( ) ;
      }

      protected void Update0K21( )
      {
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0K21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [GXChatUser] */
                     DeferredUpdate0K21( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0K21( ) ;
         }
         CloseExtendedTableCursors0K21( ) ;
      }

      protected void DeferredUpdate0K21( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K21( ) ;
            AfterConfirm0K21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000K7 */
                  pr_default.execute(5, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
                  pr_default.close(5);
                  dsDefault.SmartCacheProvider.SetUpdated("GXChatUser");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0K21( ) ;
         Gx_mode = sMode21;
      }

      protected void OnDeleteControls0K21( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000K8 */
            pr_default.execute(6, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
            if ( (pr_default.getStatus(6) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"GXChat Message"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(6);
         }
      }

      protected void EndLevel0K21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0K21( )
      {
         /* Using cursor BC000K9 */
         pr_default.execute(7, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound21 = 1;
            A268GXChatUserId = (Guid)((Guid)(BC000K9_A268GXChatUserId[0]));
            A269GXChatUserDevice = BC000K9_A269GXChatUserDevice[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0K21( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound21 = 0;
         ScanKeyLoad0K21( ) ;
      }

      protected void ScanKeyLoad0K21( )
      {
         sMode21 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound21 = 1;
            A268GXChatUserId = (Guid)((Guid)(BC000K9_A268GXChatUserId[0]));
            A269GXChatUserDevice = BC000K9_A269GXChatUserDevice[0];
         }
         Gx_mode = sMode21;
      }

      protected void ScanKeyEnd0K21( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0K21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0K21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0K21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0K21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K21( )
      {
      }

      protected void send_integrity_lvl_hashes0K21( )
      {
      }

      protected void AddRow0K21( )
      {
         VarsToRow21( bccommonchatbots_GXChatUser) ;
      }

      protected void ReadRow0K21( )
      {
         RowToVars21( bccommonchatbots_GXChatUser, 1) ;
      }

      protected void InitializeNonKey0K21( )
      {
      }

      protected void InitAll0K21( )
      {
         A268GXChatUserId = (Guid)(Guid.NewGuid( ));
         A269GXChatUserDevice = "";
         InitializeNonKey0K21( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow21( GeneXus.Programs.commonchatbots.SdtGXChatUser obj21 )
      {
         obj21.gxTpr_Mode = Gx_mode;
         obj21.gxTpr_Gxchatuserid = (Guid)(A268GXChatUserId);
         obj21.gxTpr_Gxchatuserdevice = A269GXChatUserDevice;
         obj21.gxTpr_Gxchatuserid_Z = (Guid)(Z268GXChatUserId);
         obj21.gxTpr_Gxchatuserdevice_Z = Z269GXChatUserDevice;
         obj21.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow21( GeneXus.Programs.commonchatbots.SdtGXChatUser obj21 )
      {
         obj21.gxTpr_Gxchatuserid = (Guid)(A268GXChatUserId);
         obj21.gxTpr_Gxchatuserdevice = A269GXChatUserDevice;
         return  ;
      }

      public void RowToVars21( GeneXus.Programs.commonchatbots.SdtGXChatUser obj21 ,
                               int forceLoad )
      {
         Gx_mode = obj21.gxTpr_Mode;
         A268GXChatUserId = (Guid)(obj21.gxTpr_Gxchatuserid);
         A269GXChatUserDevice = obj21.gxTpr_Gxchatuserdevice;
         Z268GXChatUserId = (Guid)(obj21.gxTpr_Gxchatuserid_Z);
         Z269GXChatUserDevice = obj21.gxTpr_Gxchatuserdevice_Z;
         Gx_mode = obj21.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A268GXChatUserId = (Guid)((Guid)getParm(obj,0));
         A269GXChatUserDevice = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0K21( ) ;
         ScanKeyStart0K21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z268GXChatUserId = (Guid)(A268GXChatUserId);
            Z269GXChatUserDevice = A269GXChatUserDevice;
         }
         ZM0K21( -3) ;
         OnLoadActions0K21( ) ;
         AddRow0K21( ) ;
         ScanKeyEnd0K21( ) ;
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars21( bccommonchatbots_GXChatUser, 0) ;
         ScanKeyStart0K21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z268GXChatUserId = (Guid)(A268GXChatUserId);
            Z269GXChatUserDevice = A269GXChatUserDevice;
         }
         ZM0K21( -3) ;
         OnLoadActions0K21( ) ;
         AddRow0K21( ) ;
         ScanKeyEnd0K21( ) ;
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0K21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0K21( ) ;
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( ( A268GXChatUserId != Z268GXChatUserId ) || ( StringUtil.StrCmp(A269GXChatUserDevice, Z269GXChatUserDevice) != 0 ) )
               {
                  A268GXChatUserId = (Guid)(Z268GXChatUserId);
                  A269GXChatUserDevice = Z269GXChatUserDevice;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0K21( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( ( A268GXChatUserId != Z268GXChatUserId ) || ( StringUtil.StrCmp(A269GXChatUserDevice, Z269GXChatUserDevice) != 0 ) )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0K21( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0K21( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars21( bccommonchatbots_GXChatUser, 1) ;
         SaveImpl( ) ;
         VarsToRow21( bccommonchatbots_GXChatUser) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars21( bccommonchatbots_GXChatUser, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K21( ) ;
         AfterTrn( ) ;
         VarsToRow21( bccommonchatbots_GXChatUser) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            GeneXus.Programs.commonchatbots.SdtGXChatUser auxBC = new GeneXus.Programs.commonchatbots.SdtGXChatUser(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A268GXChatUserId, A269GXChatUserDevice);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccommonchatbots_GXChatUser);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars21( bccommonchatbots_GXChatUser, 1) ;
         UpdateImpl( ) ;
         VarsToRow21( bccommonchatbots_GXChatUser) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars21( bccommonchatbots_GXChatUser, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K21( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow21( bccommonchatbots_GXChatUser) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars21( bccommonchatbots_GXChatUser, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0K21( ) ;
         if ( RcdFound21 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A268GXChatUserId != Z268GXChatUserId ) || ( StringUtil.StrCmp(A269GXChatUserDevice, Z269GXChatUserDevice) != 0 ) )
            {
               A268GXChatUserId = (Guid)(Z268GXChatUserId);
               A269GXChatUserDevice = Z269GXChatUserDevice;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( ( A268GXChatUserId != Z268GXChatUserId ) || ( StringUtil.StrCmp(A269GXChatUserDevice, Z269GXChatUserDevice) != 0 ) )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("commonchatbots.gxchatuser_bc",pr_default);
         VarsToRow21( bccommonchatbots_GXChatUser) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bccommonchatbots_GXChatUser.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccommonchatbots_GXChatUser.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccommonchatbots_GXChatUser )
         {
            bccommonchatbots_GXChatUser = (GeneXus.Programs.commonchatbots.SdtGXChatUser)(sdt);
            if ( StringUtil.StrCmp(bccommonchatbots_GXChatUser.gxTpr_Mode, "") == 0 )
            {
               bccommonchatbots_GXChatUser.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow21( bccommonchatbots_GXChatUser) ;
            }
            else
            {
               RowToVars21( bccommonchatbots_GXChatUser, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccommonchatbots_GXChatUser.gxTpr_Mode, "") == 0 )
            {
               bccommonchatbots_GXChatUser.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars21( bccommonchatbots_GXChatUser, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtGXChatUser GXChatUser_BC
      {
         get {
            return bccommonchatbots_GXChatUser ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "gxchatuser_Execute" ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z268GXChatUserId = (Guid)(Guid.Empty);
         A268GXChatUserId = (Guid)(Guid.Empty);
         Z269GXChatUserDevice = "";
         A269GXChatUserDevice = "";
         BC000K4_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         BC000K4_A269GXChatUserDevice = new string[] {""} ;
         BC000K5_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         BC000K5_A269GXChatUserDevice = new string[] {""} ;
         BC000K3_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         BC000K3_A269GXChatUserDevice = new string[] {""} ;
         sMode21 = "";
         BC000K2_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         BC000K2_A269GXChatUserDevice = new string[] {""} ;
         BC000K8_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         BC000K9_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         BC000K9_A269GXChatUserDevice = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatuser_bc__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatuser_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatuser_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatuser_bc__default(),
            new Object[][] {
                new Object[] {
               BC000K2_A268GXChatUserId, BC000K2_A269GXChatUserDevice
               }
               , new Object[] {
               BC000K3_A268GXChatUserId, BC000K3_A269GXChatUserDevice
               }
               , new Object[] {
               BC000K4_A268GXChatUserId, BC000K4_A269GXChatUserDevice
               }
               , new Object[] {
               BC000K5_A268GXChatUserId, BC000K5_A269GXChatUserDevice
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000K8_A267GXChatMessageId
               }
               , new Object[] {
               BC000K9_A268GXChatUserId, BC000K9_A269GXChatUserDevice
               }
            }
         );
         Z268GXChatUserId = (Guid)(Guid.NewGuid( ));
         A268GXChatUserId = (Guid)(Guid.NewGuid( ));
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound21 ;
      private short nIsDirty_21 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode21 ;
      private bool mustCommit ;
      private string Z269GXChatUserDevice ;
      private string A269GXChatUserDevice ;
      private Guid Z268GXChatUserId ;
      private Guid A268GXChatUserId ;
      private GeneXus.Programs.commonchatbots.SdtGXChatUser bccommonchatbots_GXChatUser ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000K4_A268GXChatUserId ;
      private string[] BC000K4_A269GXChatUserDevice ;
      private Guid[] BC000K5_A268GXChatUserId ;
      private string[] BC000K5_A269GXChatUserDevice ;
      private Guid[] BC000K3_A268GXChatUserId ;
      private string[] BC000K3_A269GXChatUserDevice ;
      private Guid[] BC000K2_A268GXChatUserId ;
      private string[] BC000K2_A269GXChatUserDevice ;
      private Guid[] BC000K8_A267GXChatMessageId ;
      private Guid[] BC000K9_A268GXChatUserId ;
      private string[] BC000K9_A269GXChatUserDevice ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class gxchatuser_bc__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class gxchatuser_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

public class gxchatuser_bc__gam : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       def= new CursorDef[] {
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
 }

 public override string getDataStoreName( )
 {
    return "GAM";
 }

}

public class gxchatuser_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
      ,new ForEachCursor(def[6])
      ,new ForEachCursor(def[7])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000K4;
       prmBC000K4 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       Object[] prmBC000K5;
       prmBC000K5 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       Object[] prmBC000K3;
       prmBC000K3 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       Object[] prmBC000K2;
       prmBC000K2 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       Object[] prmBC000K6;
       prmBC000K6 = new Object[] {
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0)
       };
       Object[] prmBC000K7;
       prmBC000K7 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       Object[] prmBC000K8;
       prmBC000K8 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       Object[] prmBC000K9;
       prmBC000K9 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000K2", "SELECT [GXChatUserId], [GXChatUserDevice] FROM [GXChatUser] WITH (UPDLOCK) WHERE [GXChatUserId] = @GXChatUserId AND [GXChatUserDevice] = @GXChatUserDevice ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K3", "SELECT [GXChatUserId], [GXChatUserDevice] FROM [GXChatUser] WHERE [GXChatUserId] = @GXChatUserId AND [GXChatUserDevice] = @GXChatUserDevice ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K4", "SELECT TM1.[GXChatUserId], TM1.[GXChatUserDevice] FROM [GXChatUser] TM1 WHERE TM1.[GXChatUserId] = @GXChatUserId and TM1.[GXChatUserDevice] = @GXChatUserDevice ORDER BY TM1.[GXChatUserId], TM1.[GXChatUserDevice]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K5", "SELECT [GXChatUserId], [GXChatUserDevice] FROM [GXChatUser] WHERE [GXChatUserId] = @GXChatUserId AND [GXChatUserDevice] = @GXChatUserDevice  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000K6", "INSERT INTO [GXChatUser]([GXChatUserDevice], [GXChatUserId]) VALUES(@GXChatUserDevice, @GXChatUserId)", GxErrorMask.GX_NOMASK,prmBC000K6)
          ,new CursorDef("BC000K7", "DELETE FROM [GXChatUser]  WHERE [GXChatUserId] = @GXChatUserId AND [GXChatUserDevice] = @GXChatUserDevice", GxErrorMask.GX_NOMASK,prmBC000K7)
          ,new CursorDef("BC000K8", "SELECT TOP 1 [GXChatMessageId] FROM [GXChatMessage] WHERE [GXChatUserId] = @GXChatUserId AND [GXChatUserDevice] = @GXChatUserDevice ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000K9", "SELECT TM1.[GXChatUserId], TM1.[GXChatUserDevice] FROM [GXChatUser] TM1 WHERE TM1.[GXChatUserId] = @GXChatUserId and TM1.[GXChatUserDevice] = @GXChatUserDevice ORDER BY TM1.[GXChatUserId], TM1.[GXChatUserDevice]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K9,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
    }
 }

}

}
