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
   public class gxchatmessage_bc : GXHttpHandler, IGxSilentTrn
   {
      public gxchatmessage_bc( )
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

      public gxchatmessage_bc( IGxContext context )
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
         ReadRow0J20( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0J20( ) ;
         standaloneModal( ) ;
         AddRow0J20( ) ;
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
               Z267GXChatMessageId = (Guid)(A267GXChatMessageId);
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J20( ) ;
            }
            else
            {
               CheckExtendedTable0J20( ) ;
               if ( AnyError == 0 )
               {
                  ZM0J20( 6) ;
               }
               CloseExtendedTableCursors0J20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0J20( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z271GXChatMessageType = A271GXChatMessageType;
            Z270GXChatMessageDate = A270GXChatMessageDate;
            Z275GXChatMessageRepeat = A275GXChatMessageRepeat;
            Z273GXChatMessageInstance = A273GXChatMessageInstance;
            Z268GXChatUserId = (Guid)(A268GXChatUserId);
            Z269GXChatUserDevice = A269GXChatUserDevice;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -5 )
         {
            Z267GXChatMessageId = (Guid)(A267GXChatMessageId);
            Z272GXChatMessageMessage = A272GXChatMessageMessage;
            Z271GXChatMessageType = A271GXChatMessageType;
            Z274GXChatMessageImage = A274GXChatMessageImage;
            Z40000GXChatMessageImage_GXI = A40000GXChatMessageImage_GXI;
            Z270GXChatMessageDate = A270GXChatMessageDate;
            Z276GXChatMessageMeta = A276GXChatMessageMeta;
            Z275GXChatMessageRepeat = A275GXChatMessageRepeat;
            Z273GXChatMessageInstance = A273GXChatMessageInstance;
            Z268GXChatUserId = (Guid)(A268GXChatUserId);
            Z269GXChatUserDevice = A269GXChatUserDevice;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A267GXChatMessageId) )
         {
            A267GXChatMessageId = (Guid)(Guid.NewGuid( ));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0J20( )
      {
         /* Using cursor BC000J5 */
         pr_default.execute(3, new Object[] {A267GXChatMessageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
            A272GXChatMessageMessage = BC000J5_A272GXChatMessageMessage[0];
            A271GXChatMessageType = BC000J5_A271GXChatMessageType[0];
            A40000GXChatMessageImage_GXI = BC000J5_A40000GXChatMessageImage_GXI[0];
            n40000GXChatMessageImage_GXI = BC000J5_n40000GXChatMessageImage_GXI[0];
            A270GXChatMessageDate = BC000J5_A270GXChatMessageDate[0];
            A276GXChatMessageMeta = BC000J5_A276GXChatMessageMeta[0];
            A275GXChatMessageRepeat = BC000J5_A275GXChatMessageRepeat[0];
            A273GXChatMessageInstance = BC000J5_A273GXChatMessageInstance[0];
            A268GXChatUserId = (Guid)((Guid)(BC000J5_A268GXChatUserId[0]));
            A269GXChatUserDevice = BC000J5_A269GXChatUserDevice[0];
            A274GXChatMessageImage = BC000J5_A274GXChatMessageImage[0];
            n274GXChatMessageImage = BC000J5_n274GXChatMessageImage[0];
            ZM0J20( -5) ;
         }
         pr_default.close(3);
         OnLoadActions0J20( ) ;
      }

      protected void OnLoadActions0J20( )
      {
      }

      protected void CheckExtendedTable0J20( )
      {
         nIsDirty_20 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000J4 */
         pr_default.execute(2, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'GX Chat User'.", "ForeignKeyNotFound", 1, "GXCHATUSERDEVICE");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A270GXChatMessageDate) || ( A270GXChatMessageDate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo GXChat Message Date fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0J20( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0J20( )
      {
         /* Using cursor BC000J6 */
         pr_default.execute(4, new Object[] {A267GXChatMessageId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000J3 */
         pr_default.execute(1, new Object[] {A267GXChatMessageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J20( 5) ;
            RcdFound20 = 1;
            A267GXChatMessageId = (Guid)((Guid)(BC000J3_A267GXChatMessageId[0]));
            A272GXChatMessageMessage = BC000J3_A272GXChatMessageMessage[0];
            A271GXChatMessageType = BC000J3_A271GXChatMessageType[0];
            A40000GXChatMessageImage_GXI = BC000J3_A40000GXChatMessageImage_GXI[0];
            n40000GXChatMessageImage_GXI = BC000J3_n40000GXChatMessageImage_GXI[0];
            A270GXChatMessageDate = BC000J3_A270GXChatMessageDate[0];
            A276GXChatMessageMeta = BC000J3_A276GXChatMessageMeta[0];
            A275GXChatMessageRepeat = BC000J3_A275GXChatMessageRepeat[0];
            A273GXChatMessageInstance = BC000J3_A273GXChatMessageInstance[0];
            A268GXChatUserId = (Guid)((Guid)(BC000J3_A268GXChatUserId[0]));
            A269GXChatUserDevice = BC000J3_A269GXChatUserDevice[0];
            A274GXChatMessageImage = BC000J3_A274GXChatMessageImage[0];
            n274GXChatMessageImage = BC000J3_n274GXChatMessageImage[0];
            Z267GXChatMessageId = (Guid)(A267GXChatMessageId);
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0J20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0J20( ) ;
            }
            Gx_mode = sMode20;
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0J20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode20;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J20( ) ;
         if ( RcdFound20 == 0 )
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
         CONFIRM_0J0( ) ;
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

      protected void CheckOptimisticConcurrency0J20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000J2 */
            pr_default.execute(0, new Object[] {A267GXChatMessageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"GXChatMessage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z271GXChatMessageType, BC000J2_A271GXChatMessageType[0]) != 0 ) || ( Z270GXChatMessageDate != BC000J2_A270GXChatMessageDate[0] ) || ( StringUtil.StrCmp(Z275GXChatMessageRepeat, BC000J2_A275GXChatMessageRepeat[0]) != 0 ) || ( StringUtil.StrCmp(Z273GXChatMessageInstance, BC000J2_A273GXChatMessageInstance[0]) != 0 ) || ( Z268GXChatUserId != BC000J2_A268GXChatUserId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z269GXChatUserDevice, BC000J2_A269GXChatUserDevice[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"GXChatMessage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J20( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J20( 0) ;
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J7 */
                     pr_default.execute(5, new Object[] {A272GXChatMessageMessage, A271GXChatMessageType, n274GXChatMessageImage, A274GXChatMessageImage, n40000GXChatMessageImage_GXI, A40000GXChatMessageImage_GXI, A270GXChatMessageDate, A276GXChatMessageMeta, A275GXChatMessageRepeat, A273GXChatMessageInstance, A268GXChatUserId, A269GXChatUserDevice, A267GXChatMessageId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("GXChatMessage");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load0J20( ) ;
            }
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void Update0J20( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J8 */
                     pr_default.execute(6, new Object[] {A272GXChatMessageMessage, A271GXChatMessageType, A270GXChatMessageDate, A276GXChatMessageMeta, A275GXChatMessageRepeat, A273GXChatMessageInstance, A268GXChatUserId, A269GXChatUserDevice, A267GXChatMessageId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("GXChatMessage");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"GXChatMessage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J20( ) ;
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
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void DeferredUpdate0J20( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000J9 */
            pr_default.execute(7, new Object[] {n274GXChatMessageImage, A274GXChatMessageImage, n40000GXChatMessageImage_GXI, A40000GXChatMessageImage_GXI, A267GXChatMessageId});
            pr_default.close(7);
            dsDefault.SmartCacheProvider.SetUpdated("GXChatMessage");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J20( ) ;
            AfterConfirm0J20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000J10 */
                  pr_default.execute(8, new Object[] {A267GXChatMessageId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("GXChatMessage");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0J20( ) ;
         Gx_mode = sMode20;
      }

      protected void OnDeleteControls0J20( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0J20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J20( ) ;
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

      public void ScanKeyStart0J20( )
      {
         /* Using cursor BC000J11 */
         pr_default.execute(9, new Object[] {A267GXChatMessageId});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound20 = 1;
            A267GXChatMessageId = (Guid)((Guid)(BC000J11_A267GXChatMessageId[0]));
            A272GXChatMessageMessage = BC000J11_A272GXChatMessageMessage[0];
            A271GXChatMessageType = BC000J11_A271GXChatMessageType[0];
            A40000GXChatMessageImage_GXI = BC000J11_A40000GXChatMessageImage_GXI[0];
            n40000GXChatMessageImage_GXI = BC000J11_n40000GXChatMessageImage_GXI[0];
            A270GXChatMessageDate = BC000J11_A270GXChatMessageDate[0];
            A276GXChatMessageMeta = BC000J11_A276GXChatMessageMeta[0];
            A275GXChatMessageRepeat = BC000J11_A275GXChatMessageRepeat[0];
            A273GXChatMessageInstance = BC000J11_A273GXChatMessageInstance[0];
            A268GXChatUserId = (Guid)((Guid)(BC000J11_A268GXChatUserId[0]));
            A269GXChatUserDevice = BC000J11_A269GXChatUserDevice[0];
            A274GXChatMessageImage = BC000J11_A274GXChatMessageImage[0];
            n274GXChatMessageImage = BC000J11_n274GXChatMessageImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0J20( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound20 = 0;
         ScanKeyLoad0J20( ) ;
      }

      protected void ScanKeyLoad0J20( )
      {
         sMode20 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound20 = 1;
            A267GXChatMessageId = (Guid)((Guid)(BC000J11_A267GXChatMessageId[0]));
            A272GXChatMessageMessage = BC000J11_A272GXChatMessageMessage[0];
            A271GXChatMessageType = BC000J11_A271GXChatMessageType[0];
            A40000GXChatMessageImage_GXI = BC000J11_A40000GXChatMessageImage_GXI[0];
            n40000GXChatMessageImage_GXI = BC000J11_n40000GXChatMessageImage_GXI[0];
            A270GXChatMessageDate = BC000J11_A270GXChatMessageDate[0];
            A276GXChatMessageMeta = BC000J11_A276GXChatMessageMeta[0];
            A275GXChatMessageRepeat = BC000J11_A275GXChatMessageRepeat[0];
            A273GXChatMessageInstance = BC000J11_A273GXChatMessageInstance[0];
            A268GXChatUserId = (Guid)((Guid)(BC000J11_A268GXChatUserId[0]));
            A269GXChatUserDevice = BC000J11_A269GXChatUserDevice[0];
            A274GXChatMessageImage = BC000J11_A274GXChatMessageImage[0];
            n274GXChatMessageImage = BC000J11_n274GXChatMessageImage[0];
         }
         Gx_mode = sMode20;
      }

      protected void ScanKeyEnd0J20( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0J20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J20( )
      {
      }

      protected void send_integrity_lvl_hashes0J20( )
      {
      }

      protected void AddRow0J20( )
      {
         VarsToRow20( bccommonchatbots_GXChatMessage) ;
      }

      protected void ReadRow0J20( )
      {
         RowToVars20( bccommonchatbots_GXChatMessage, 1) ;
      }

      protected void InitializeNonKey0J20( )
      {
         A268GXChatUserId = (Guid)(Guid.Empty);
         A272GXChatMessageMessage = "";
         A271GXChatMessageType = "";
         A274GXChatMessageImage = "";
         n274GXChatMessageImage = false;
         A40000GXChatMessageImage_GXI = "";
         n40000GXChatMessageImage_GXI = false;
         A270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         A276GXChatMessageMeta = "";
         A269GXChatUserDevice = "";
         A275GXChatMessageRepeat = "";
         A273GXChatMessageInstance = "";
         Z271GXChatMessageType = "";
         Z270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         Z275GXChatMessageRepeat = "";
         Z273GXChatMessageInstance = "";
         Z268GXChatUserId = (Guid)(Guid.Empty);
         Z269GXChatUserDevice = "";
      }

      protected void InitAll0J20( )
      {
         A267GXChatMessageId = (Guid)(Guid.NewGuid( ));
         InitializeNonKey0J20( ) ;
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

      public void VarsToRow20( GeneXus.Programs.commonchatbots.SdtGXChatMessage obj20 )
      {
         obj20.gxTpr_Mode = Gx_mode;
         obj20.gxTpr_Gxchatuserid = (Guid)(A268GXChatUserId);
         obj20.gxTpr_Gxchatmessagemessage = A272GXChatMessageMessage;
         obj20.gxTpr_Gxchatmessagetype = A271GXChatMessageType;
         obj20.gxTpr_Gxchatmessageimage = A274GXChatMessageImage;
         obj20.gxTpr_Gxchatmessageimage_gxi = A40000GXChatMessageImage_GXI;
         obj20.gxTpr_Gxchatmessagedate = A270GXChatMessageDate;
         obj20.gxTpr_Gxchatmessagemeta = A276GXChatMessageMeta;
         obj20.gxTpr_Gxchatuserdevice = A269GXChatUserDevice;
         obj20.gxTpr_Gxchatmessagerepeat = A275GXChatMessageRepeat;
         obj20.gxTpr_Gxchatmessageinstance = A273GXChatMessageInstance;
         obj20.gxTpr_Gxchatmessageid = (Guid)(A267GXChatMessageId);
         obj20.gxTpr_Gxchatmessageid_Z = (Guid)(Z267GXChatMessageId);
         obj20.gxTpr_Gxchatuserid_Z = (Guid)(Z268GXChatUserId);
         obj20.gxTpr_Gxchatmessagetype_Z = Z271GXChatMessageType;
         obj20.gxTpr_Gxchatmessagedate_Z = Z270GXChatMessageDate;
         obj20.gxTpr_Gxchatuserdevice_Z = Z269GXChatUserDevice;
         obj20.gxTpr_Gxchatmessagerepeat_Z = Z275GXChatMessageRepeat;
         obj20.gxTpr_Gxchatmessageinstance_Z = Z273GXChatMessageInstance;
         obj20.gxTpr_Gxchatmessageimage_gxi_Z = Z40000GXChatMessageImage_GXI;
         obj20.gxTpr_Gxchatmessageimage_N = (short)(Convert.ToInt16(n274GXChatMessageImage));
         obj20.gxTpr_Gxchatmessageimage_gxi_N = (short)(Convert.ToInt16(n40000GXChatMessageImage_GXI));
         obj20.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow20( GeneXus.Programs.commonchatbots.SdtGXChatMessage obj20 )
      {
         obj20.gxTpr_Gxchatmessageid = (Guid)(A267GXChatMessageId);
         return  ;
      }

      public void RowToVars20( GeneXus.Programs.commonchatbots.SdtGXChatMessage obj20 ,
                               int forceLoad )
      {
         Gx_mode = obj20.gxTpr_Mode;
         A268GXChatUserId = (Guid)(obj20.gxTpr_Gxchatuserid);
         A272GXChatMessageMessage = obj20.gxTpr_Gxchatmessagemessage;
         A271GXChatMessageType = obj20.gxTpr_Gxchatmessagetype;
         A274GXChatMessageImage = obj20.gxTpr_Gxchatmessageimage;
         n274GXChatMessageImage = false;
         A40000GXChatMessageImage_GXI = obj20.gxTpr_Gxchatmessageimage_gxi;
         n40000GXChatMessageImage_GXI = false;
         A270GXChatMessageDate = obj20.gxTpr_Gxchatmessagedate;
         A276GXChatMessageMeta = obj20.gxTpr_Gxchatmessagemeta;
         A269GXChatUserDevice = obj20.gxTpr_Gxchatuserdevice;
         A275GXChatMessageRepeat = obj20.gxTpr_Gxchatmessagerepeat;
         A273GXChatMessageInstance = obj20.gxTpr_Gxchatmessageinstance;
         A267GXChatMessageId = (Guid)(obj20.gxTpr_Gxchatmessageid);
         Z267GXChatMessageId = (Guid)(obj20.gxTpr_Gxchatmessageid_Z);
         Z268GXChatUserId = (Guid)(obj20.gxTpr_Gxchatuserid_Z);
         Z271GXChatMessageType = obj20.gxTpr_Gxchatmessagetype_Z;
         Z270GXChatMessageDate = obj20.gxTpr_Gxchatmessagedate_Z;
         Z269GXChatUserDevice = obj20.gxTpr_Gxchatuserdevice_Z;
         Z275GXChatMessageRepeat = obj20.gxTpr_Gxchatmessagerepeat_Z;
         Z273GXChatMessageInstance = obj20.gxTpr_Gxchatmessageinstance_Z;
         Z40000GXChatMessageImage_GXI = obj20.gxTpr_Gxchatmessageimage_gxi_Z;
         n274GXChatMessageImage = (bool)(Convert.ToBoolean(obj20.gxTpr_Gxchatmessageimage_N));
         n40000GXChatMessageImage_GXI = (bool)(Convert.ToBoolean(obj20.gxTpr_Gxchatmessageimage_gxi_N));
         Gx_mode = obj20.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A267GXChatMessageId = (Guid)((Guid)getParm(obj,0));
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0J20( ) ;
         ScanKeyStart0J20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z267GXChatMessageId = (Guid)(A267GXChatMessageId);
         }
         ZM0J20( -5) ;
         OnLoadActions0J20( ) ;
         AddRow0J20( ) ;
         ScanKeyEnd0J20( ) ;
         if ( RcdFound20 == 0 )
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
         RowToVars20( bccommonchatbots_GXChatMessage, 0) ;
         ScanKeyStart0J20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z267GXChatMessageId = (Guid)(A267GXChatMessageId);
         }
         ZM0J20( -5) ;
         OnLoadActions0J20( ) ;
         AddRow0J20( ) ;
         ScanKeyEnd0J20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0J20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0J20( ) ;
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A267GXChatMessageId != Z267GXChatMessageId )
               {
                  A267GXChatMessageId = (Guid)(Z267GXChatMessageId);
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
                  Update0J20( ) ;
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
                  if ( A267GXChatMessageId != Z267GXChatMessageId )
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
                        Insert0J20( ) ;
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
                        Insert0J20( ) ;
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
         RowToVars20( bccommonchatbots_GXChatMessage, 1) ;
         SaveImpl( ) ;
         VarsToRow20( bccommonchatbots_GXChatMessage) ;
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
         RowToVars20( bccommonchatbots_GXChatMessage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J20( ) ;
         AfterTrn( ) ;
         VarsToRow20( bccommonchatbots_GXChatMessage) ;
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
            GeneXus.Programs.commonchatbots.SdtGXChatMessage auxBC = new GeneXus.Programs.commonchatbots.SdtGXChatMessage(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A267GXChatMessageId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccommonchatbots_GXChatMessage);
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
         RowToVars20( bccommonchatbots_GXChatMessage, 1) ;
         UpdateImpl( ) ;
         VarsToRow20( bccommonchatbots_GXChatMessage) ;
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
         RowToVars20( bccommonchatbots_GXChatMessage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J20( ) ;
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
         VarsToRow20( bccommonchatbots_GXChatMessage) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars20( bccommonchatbots_GXChatMessage, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0J20( ) ;
         if ( RcdFound20 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A267GXChatMessageId != Z267GXChatMessageId )
            {
               A267GXChatMessageId = (Guid)(Z267GXChatMessageId);
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
            if ( A267GXChatMessageId != Z267GXChatMessageId )
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
         context.RollbackDataStores("commonchatbots.gxchatmessage_bc",pr_default);
         VarsToRow20( bccommonchatbots_GXChatMessage) ;
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
         Gx_mode = bccommonchatbots_GXChatMessage.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccommonchatbots_GXChatMessage.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccommonchatbots_GXChatMessage )
         {
            bccommonchatbots_GXChatMessage = (GeneXus.Programs.commonchatbots.SdtGXChatMessage)(sdt);
            if ( StringUtil.StrCmp(bccommonchatbots_GXChatMessage.gxTpr_Mode, "") == 0 )
            {
               bccommonchatbots_GXChatMessage.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow20( bccommonchatbots_GXChatMessage) ;
            }
            else
            {
               RowToVars20( bccommonchatbots_GXChatMessage, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccommonchatbots_GXChatMessage.gxTpr_Mode, "") == 0 )
            {
               bccommonchatbots_GXChatMessage.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars20( bccommonchatbots_GXChatMessage, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtGXChatMessage GXChatMessage_BC
      {
         get {
            return bccommonchatbots_GXChatMessage ;
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
            return "gxchatmessage_Execute" ;
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
         Z267GXChatMessageId = (Guid)(Guid.Empty);
         A267GXChatMessageId = (Guid)(Guid.Empty);
         Z271GXChatMessageType = "";
         A271GXChatMessageType = "";
         Z270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         A270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         Z275GXChatMessageRepeat = "";
         A275GXChatMessageRepeat = "";
         Z273GXChatMessageInstance = "";
         A273GXChatMessageInstance = "";
         Z268GXChatUserId = (Guid)(Guid.Empty);
         A268GXChatUserId = (Guid)(Guid.Empty);
         Z269GXChatUserDevice = "";
         A269GXChatUserDevice = "";
         Z272GXChatMessageMessage = "";
         A272GXChatMessageMessage = "";
         Z274GXChatMessageImage = "";
         A274GXChatMessageImage = "";
         Z40000GXChatMessageImage_GXI = "";
         A40000GXChatMessageImage_GXI = "";
         Z276GXChatMessageMeta = "";
         A276GXChatMessageMeta = "";
         BC000J5_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         BC000J5_A272GXChatMessageMessage = new string[] {""} ;
         BC000J5_A271GXChatMessageType = new string[] {""} ;
         BC000J5_A40000GXChatMessageImage_GXI = new string[] {""} ;
         BC000J5_n40000GXChatMessageImage_GXI = new bool[] {false} ;
         BC000J5_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000J5_A276GXChatMessageMeta = new string[] {""} ;
         BC000J5_A275GXChatMessageRepeat = new string[] {""} ;
         BC000J5_A273GXChatMessageInstance = new string[] {""} ;
         BC000J5_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         BC000J5_A269GXChatUserDevice = new string[] {""} ;
         BC000J5_A274GXChatMessageImage = new string[] {""} ;
         BC000J5_n274GXChatMessageImage = new bool[] {false} ;
         BC000J4_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         BC000J6_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         BC000J3_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         BC000J3_A272GXChatMessageMessage = new string[] {""} ;
         BC000J3_A271GXChatMessageType = new string[] {""} ;
         BC000J3_A40000GXChatMessageImage_GXI = new string[] {""} ;
         BC000J3_n40000GXChatMessageImage_GXI = new bool[] {false} ;
         BC000J3_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000J3_A276GXChatMessageMeta = new string[] {""} ;
         BC000J3_A275GXChatMessageRepeat = new string[] {""} ;
         BC000J3_A273GXChatMessageInstance = new string[] {""} ;
         BC000J3_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         BC000J3_A269GXChatUserDevice = new string[] {""} ;
         BC000J3_A274GXChatMessageImage = new string[] {""} ;
         BC000J3_n274GXChatMessageImage = new bool[] {false} ;
         sMode20 = "";
         BC000J2_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         BC000J2_A272GXChatMessageMessage = new string[] {""} ;
         BC000J2_A271GXChatMessageType = new string[] {""} ;
         BC000J2_A40000GXChatMessageImage_GXI = new string[] {""} ;
         BC000J2_n40000GXChatMessageImage_GXI = new bool[] {false} ;
         BC000J2_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000J2_A276GXChatMessageMeta = new string[] {""} ;
         BC000J2_A275GXChatMessageRepeat = new string[] {""} ;
         BC000J2_A273GXChatMessageInstance = new string[] {""} ;
         BC000J2_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         BC000J2_A269GXChatUserDevice = new string[] {""} ;
         BC000J2_A274GXChatMessageImage = new string[] {""} ;
         BC000J2_n274GXChatMessageImage = new bool[] {false} ;
         BC000J11_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         BC000J11_A272GXChatMessageMessage = new string[] {""} ;
         BC000J11_A271GXChatMessageType = new string[] {""} ;
         BC000J11_A40000GXChatMessageImage_GXI = new string[] {""} ;
         BC000J11_n40000GXChatMessageImage_GXI = new bool[] {false} ;
         BC000J11_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000J11_A276GXChatMessageMeta = new string[] {""} ;
         BC000J11_A275GXChatMessageRepeat = new string[] {""} ;
         BC000J11_A273GXChatMessageInstance = new string[] {""} ;
         BC000J11_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         BC000J11_A269GXChatUserDevice = new string[] {""} ;
         BC000J11_A274GXChatMessageImage = new string[] {""} ;
         BC000J11_n274GXChatMessageImage = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatmessage_bc__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatmessage_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatmessage_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatmessage_bc__default(),
            new Object[][] {
                new Object[] {
               BC000J2_A267GXChatMessageId, BC000J2_A272GXChatMessageMessage, BC000J2_A271GXChatMessageType, BC000J2_A40000GXChatMessageImage_GXI, BC000J2_n40000GXChatMessageImage_GXI, BC000J2_A270GXChatMessageDate, BC000J2_A276GXChatMessageMeta, BC000J2_A275GXChatMessageRepeat, BC000J2_A273GXChatMessageInstance, BC000J2_A268GXChatUserId,
               BC000J2_A269GXChatUserDevice, BC000J2_A274GXChatMessageImage, BC000J2_n274GXChatMessageImage
               }
               , new Object[] {
               BC000J3_A267GXChatMessageId, BC000J3_A272GXChatMessageMessage, BC000J3_A271GXChatMessageType, BC000J3_A40000GXChatMessageImage_GXI, BC000J3_n40000GXChatMessageImage_GXI, BC000J3_A270GXChatMessageDate, BC000J3_A276GXChatMessageMeta, BC000J3_A275GXChatMessageRepeat, BC000J3_A273GXChatMessageInstance, BC000J3_A268GXChatUserId,
               BC000J3_A269GXChatUserDevice, BC000J3_A274GXChatMessageImage, BC000J3_n274GXChatMessageImage
               }
               , new Object[] {
               BC000J4_A268GXChatUserId
               }
               , new Object[] {
               BC000J5_A267GXChatMessageId, BC000J5_A272GXChatMessageMessage, BC000J5_A271GXChatMessageType, BC000J5_A40000GXChatMessageImage_GXI, BC000J5_n40000GXChatMessageImage_GXI, BC000J5_A270GXChatMessageDate, BC000J5_A276GXChatMessageMeta, BC000J5_A275GXChatMessageRepeat, BC000J5_A273GXChatMessageInstance, BC000J5_A268GXChatUserId,
               BC000J5_A269GXChatUserDevice, BC000J5_A274GXChatMessageImage, BC000J5_n274GXChatMessageImage
               }
               , new Object[] {
               BC000J6_A267GXChatMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000J11_A267GXChatMessageId, BC000J11_A272GXChatMessageMessage, BC000J11_A271GXChatMessageType, BC000J11_A40000GXChatMessageImage_GXI, BC000J11_n40000GXChatMessageImage_GXI, BC000J11_A270GXChatMessageDate, BC000J11_A276GXChatMessageMeta, BC000J11_A275GXChatMessageRepeat, BC000J11_A273GXChatMessageInstance, BC000J11_A268GXChatUserId,
               BC000J11_A269GXChatUserDevice, BC000J11_A274GXChatMessageImage, BC000J11_n274GXChatMessageImage
               }
            }
         );
         Z267GXChatMessageId = (Guid)(Guid.NewGuid( ));
         A267GXChatMessageId = (Guid)(Guid.NewGuid( ));
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
      private short RcdFound20 ;
      private short nIsDirty_20 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z271GXChatMessageType ;
      private string A271GXChatMessageType ;
      private string sMode20 ;
      private DateTime Z270GXChatMessageDate ;
      private DateTime A270GXChatMessageDate ;
      private bool n40000GXChatMessageImage_GXI ;
      private bool n274GXChatMessageImage ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z272GXChatMessageMessage ;
      private string A272GXChatMessageMessage ;
      private string Z276GXChatMessageMeta ;
      private string A276GXChatMessageMeta ;
      private string Z275GXChatMessageRepeat ;
      private string A275GXChatMessageRepeat ;
      private string Z273GXChatMessageInstance ;
      private string A273GXChatMessageInstance ;
      private string Z269GXChatUserDevice ;
      private string A269GXChatUserDevice ;
      private string Z40000GXChatMessageImage_GXI ;
      private string A40000GXChatMessageImage_GXI ;
      private string Z274GXChatMessageImage ;
      private string A274GXChatMessageImage ;
      private Guid Z267GXChatMessageId ;
      private Guid A267GXChatMessageId ;
      private Guid Z268GXChatUserId ;
      private Guid A268GXChatUserId ;
      private GeneXus.Programs.commonchatbots.SdtGXChatMessage bccommonchatbots_GXChatMessage ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000J5_A267GXChatMessageId ;
      private string[] BC000J5_A272GXChatMessageMessage ;
      private string[] BC000J5_A271GXChatMessageType ;
      private string[] BC000J5_A40000GXChatMessageImage_GXI ;
      private bool[] BC000J5_n40000GXChatMessageImage_GXI ;
      private DateTime[] BC000J5_A270GXChatMessageDate ;
      private string[] BC000J5_A276GXChatMessageMeta ;
      private string[] BC000J5_A275GXChatMessageRepeat ;
      private string[] BC000J5_A273GXChatMessageInstance ;
      private Guid[] BC000J5_A268GXChatUserId ;
      private string[] BC000J5_A269GXChatUserDevice ;
      private string[] BC000J5_A274GXChatMessageImage ;
      private bool[] BC000J5_n274GXChatMessageImage ;
      private Guid[] BC000J4_A268GXChatUserId ;
      private Guid[] BC000J6_A267GXChatMessageId ;
      private Guid[] BC000J3_A267GXChatMessageId ;
      private string[] BC000J3_A272GXChatMessageMessage ;
      private string[] BC000J3_A271GXChatMessageType ;
      private string[] BC000J3_A40000GXChatMessageImage_GXI ;
      private bool[] BC000J3_n40000GXChatMessageImage_GXI ;
      private DateTime[] BC000J3_A270GXChatMessageDate ;
      private string[] BC000J3_A276GXChatMessageMeta ;
      private string[] BC000J3_A275GXChatMessageRepeat ;
      private string[] BC000J3_A273GXChatMessageInstance ;
      private Guid[] BC000J3_A268GXChatUserId ;
      private string[] BC000J3_A269GXChatUserDevice ;
      private string[] BC000J3_A274GXChatMessageImage ;
      private bool[] BC000J3_n274GXChatMessageImage ;
      private Guid[] BC000J2_A267GXChatMessageId ;
      private string[] BC000J2_A272GXChatMessageMessage ;
      private string[] BC000J2_A271GXChatMessageType ;
      private string[] BC000J2_A40000GXChatMessageImage_GXI ;
      private bool[] BC000J2_n40000GXChatMessageImage_GXI ;
      private DateTime[] BC000J2_A270GXChatMessageDate ;
      private string[] BC000J2_A276GXChatMessageMeta ;
      private string[] BC000J2_A275GXChatMessageRepeat ;
      private string[] BC000J2_A273GXChatMessageInstance ;
      private Guid[] BC000J2_A268GXChatUserId ;
      private string[] BC000J2_A269GXChatUserDevice ;
      private string[] BC000J2_A274GXChatMessageImage ;
      private bool[] BC000J2_n274GXChatMessageImage ;
      private Guid[] BC000J11_A267GXChatMessageId ;
      private string[] BC000J11_A272GXChatMessageMessage ;
      private string[] BC000J11_A271GXChatMessageType ;
      private string[] BC000J11_A40000GXChatMessageImage_GXI ;
      private bool[] BC000J11_n40000GXChatMessageImage_GXI ;
      private DateTime[] BC000J11_A270GXChatMessageDate ;
      private string[] BC000J11_A276GXChatMessageMeta ;
      private string[] BC000J11_A275GXChatMessageRepeat ;
      private string[] BC000J11_A273GXChatMessageInstance ;
      private Guid[] BC000J11_A268GXChatUserId ;
      private string[] BC000J11_A269GXChatUserDevice ;
      private string[] BC000J11_A274GXChatMessageImage ;
      private bool[] BC000J11_n274GXChatMessageImage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class gxchatmessage_bc__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class gxchatmessage_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class gxchatmessage_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class gxchatmessage_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000J5;
       prmBC000J5 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmBC000J4;
       prmBC000J4 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       Object[] prmBC000J6;
       prmBC000J6 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmBC000J3;
       prmBC000J3 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmBC000J2;
       prmBC000J2 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmBC000J7;
       prmBC000J7 = new Object[] {
       new ParDef("@GXChatMessageMessage",GXType.NVarChar,2097152,0) ,
       new ParDef("@GXChatMessageType",GXType.NChar,2,0) ,
       new ParDef("@GXChatMessageImage",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
       new ParDef("@GXChatMessageImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=2, Tbl="GXChatMessage", Fld="GXChatMessageImage"} ,
       new ParDef("@GXChatMessageDate",GXType.DateTime2,8,12) ,
       new ParDef("@GXChatMessageMeta",GXType.NVarChar,2097152,0) ,
       new ParDef("@GXChatMessageRepeat",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatMessageInstance",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmBC000J8;
       prmBC000J8 = new Object[] {
       new ParDef("@GXChatMessageMessage",GXType.NVarChar,2097152,0) ,
       new ParDef("@GXChatMessageType",GXType.NChar,2,0) ,
       new ParDef("@GXChatMessageDate",GXType.DateTime2,8,12) ,
       new ParDef("@GXChatMessageMeta",GXType.NVarChar,2097152,0) ,
       new ParDef("@GXChatMessageRepeat",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatMessageInstance",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmBC000J9;
       prmBC000J9 = new Object[] {
       new ParDef("@GXChatMessageImage",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
       new ParDef("@GXChatMessageImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="GXChatMessage", Fld="GXChatMessageImage"} ,
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmBC000J10;
       prmBC000J10 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmBC000J11;
       prmBC000J11 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000J2", "SELECT [GXChatMessageId], [GXChatMessageMessage], [GXChatMessageType], [GXChatMessageImage_GXI], [GXChatMessageDate], [GXChatMessageMeta], [GXChatMessageRepeat], [GXChatMessageInstance], [GXChatUserId], [GXChatUserDevice], [GXChatMessageImage] FROM [GXChatMessage] WITH (UPDLOCK) WHERE [GXChatMessageId] = @GXChatMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J3", "SELECT [GXChatMessageId], [GXChatMessageMessage], [GXChatMessageType], [GXChatMessageImage_GXI], [GXChatMessageDate], [GXChatMessageMeta], [GXChatMessageRepeat], [GXChatMessageInstance], [GXChatUserId], [GXChatUserDevice], [GXChatMessageImage] FROM [GXChatMessage] WHERE [GXChatMessageId] = @GXChatMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J4", "SELECT [GXChatUserId] FROM [GXChatUser] WHERE [GXChatUserId] = @GXChatUserId AND [GXChatUserDevice] = @GXChatUserDevice ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J5", "SELECT TM1.[GXChatMessageId], TM1.[GXChatMessageMessage], TM1.[GXChatMessageType], TM1.[GXChatMessageImage_GXI], TM1.[GXChatMessageDate], TM1.[GXChatMessageMeta], TM1.[GXChatMessageRepeat], TM1.[GXChatMessageInstance], TM1.[GXChatUserId], TM1.[GXChatUserDevice], TM1.[GXChatMessageImage] FROM [GXChatMessage] TM1 WHERE TM1.[GXChatMessageId] = @GXChatMessageId ORDER BY TM1.[GXChatMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J6", "SELECT [GXChatMessageId] FROM [GXChatMessage] WHERE [GXChatMessageId] = @GXChatMessageId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000J7", "INSERT INTO [GXChatMessage]([GXChatMessageMessage], [GXChatMessageType], [GXChatMessageImage], [GXChatMessageImage_GXI], [GXChatMessageDate], [GXChatMessageMeta], [GXChatMessageRepeat], [GXChatMessageInstance], [GXChatUserId], [GXChatUserDevice], [GXChatMessageId]) VALUES(@GXChatMessageMessage, @GXChatMessageType, @GXChatMessageImage, @GXChatMessageImage_GXI, @GXChatMessageDate, @GXChatMessageMeta, @GXChatMessageRepeat, @GXChatMessageInstance, @GXChatUserId, @GXChatUserDevice, @GXChatMessageId)", GxErrorMask.GX_NOMASK,prmBC000J7)
          ,new CursorDef("BC000J8", "UPDATE [GXChatMessage] SET [GXChatMessageMessage]=@GXChatMessageMessage, [GXChatMessageType]=@GXChatMessageType, [GXChatMessageDate]=@GXChatMessageDate, [GXChatMessageMeta]=@GXChatMessageMeta, [GXChatMessageRepeat]=@GXChatMessageRepeat, [GXChatMessageInstance]=@GXChatMessageInstance, [GXChatUserId]=@GXChatUserId, [GXChatUserDevice]=@GXChatUserDevice  WHERE [GXChatMessageId] = @GXChatMessageId", GxErrorMask.GX_NOMASK,prmBC000J8)
          ,new CursorDef("BC000J9", "UPDATE [GXChatMessage] SET [GXChatMessageImage]=@GXChatMessageImage, [GXChatMessageImage_GXI]=@GXChatMessageImage_GXI  WHERE [GXChatMessageId] = @GXChatMessageId", GxErrorMask.GX_NOMASK,prmBC000J9)
          ,new CursorDef("BC000J10", "DELETE FROM [GXChatMessage]  WHERE [GXChatMessageId] = @GXChatMessageId", GxErrorMask.GX_NOMASK,prmBC000J10)
          ,new CursorDef("BC000J11", "SELECT TM1.[GXChatMessageId], TM1.[GXChatMessageMessage], TM1.[GXChatMessageType], TM1.[GXChatMessageImage_GXI], TM1.[GXChatMessageDate], TM1.[GXChatMessageMeta], TM1.[GXChatMessageRepeat], TM1.[GXChatMessageInstance], TM1.[GXChatUserId], TM1.[GXChatUserDevice], TM1.[GXChatMessageImage] FROM [GXChatMessage] TM1 WHERE TM1.[GXChatMessageId] = @GXChatMessageId ORDER BY TM1.[GXChatMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 2);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[9])[0] = rslt.getGuid(9);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 2);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[9])[0] = rslt.getGuid(9);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 2);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[9])[0] = rslt.getGuid(9);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 2);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[9])[0] = rslt.getGuid(9);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             return;
    }
 }

}

}
