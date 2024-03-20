using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.commonchatbots {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "GXChatMessage" )]
   [XmlType(TypeName =  "GXChatMessage" , Namespace = "kb_ticket" )]
   [Serializable]
   public class SdtGXChatMessage : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtGXChatMessage( )
      {
      }

      public SdtGXChatMessage( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( Guid AV267GXChatMessageId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV267GXChatMessageId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"GXChatMessageId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CommonChatbots\\GXChatMessage");
         metadata.Set("BT", "GXChatMessage");
         metadata.Set("PK", "[ \"GXChatMessageId\" ]");
         metadata.Set("PKAssigned", "[ \"GXChatMessageId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"GXChatUserId\",\"GXChatUserDevice\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Gxchatmessageimage_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Gxchatmessageid_Z");
         state.Add("gxTpr_Gxchatuserid_Z");
         state.Add("gxTpr_Gxchatmessagetype_Z");
         state.Add("gxTpr_Gxchatmessagedate_Z_Nullable");
         state.Add("gxTpr_Gxchatuserdevice_Z");
         state.Add("gxTpr_Gxchatmessagerepeat_Z");
         state.Add("gxTpr_Gxchatmessageinstance_Z");
         state.Add("gxTpr_Gxchatmessageimage_gxi_Z");
         state.Add("gxTpr_Gxchatmessageimage_N");
         state.Add("gxTpr_Gxchatmessageimage_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.commonchatbots.SdtGXChatMessage sdt;
         sdt = (GeneXus.Programs.commonchatbots.SdtGXChatMessage)(source);
         gxTv_SdtGXChatMessage_Gxchatmessageid = sdt.gxTv_SdtGXChatMessage_Gxchatmessageid ;
         gxTv_SdtGXChatMessage_Gxchatuserid = sdt.gxTv_SdtGXChatMessage_Gxchatuserid ;
         gxTv_SdtGXChatMessage_Gxchatmessagemessage = sdt.gxTv_SdtGXChatMessage_Gxchatmessagemessage ;
         gxTv_SdtGXChatMessage_Gxchatmessagetype = sdt.gxTv_SdtGXChatMessage_Gxchatmessagetype ;
         gxTv_SdtGXChatMessage_Gxchatmessageimage = sdt.gxTv_SdtGXChatMessage_Gxchatmessageimage ;
         gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi = sdt.gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi ;
         gxTv_SdtGXChatMessage_Gxchatmessagedate = sdt.gxTv_SdtGXChatMessage_Gxchatmessagedate ;
         gxTv_SdtGXChatMessage_Gxchatmessagemeta = sdt.gxTv_SdtGXChatMessage_Gxchatmessagemeta ;
         gxTv_SdtGXChatMessage_Gxchatuserdevice = sdt.gxTv_SdtGXChatMessage_Gxchatuserdevice ;
         gxTv_SdtGXChatMessage_Gxchatmessagerepeat = sdt.gxTv_SdtGXChatMessage_Gxchatmessagerepeat ;
         gxTv_SdtGXChatMessage_Gxchatmessageinstance = sdt.gxTv_SdtGXChatMessage_Gxchatmessageinstance ;
         gxTv_SdtGXChatMessage_Mode = sdt.gxTv_SdtGXChatMessage_Mode ;
         gxTv_SdtGXChatMessage_Initialized = sdt.gxTv_SdtGXChatMessage_Initialized ;
         gxTv_SdtGXChatMessage_Gxchatmessageid_Z = sdt.gxTv_SdtGXChatMessage_Gxchatmessageid_Z ;
         gxTv_SdtGXChatMessage_Gxchatuserid_Z = sdt.gxTv_SdtGXChatMessage_Gxchatuserid_Z ;
         gxTv_SdtGXChatMessage_Gxchatmessagetype_Z = sdt.gxTv_SdtGXChatMessage_Gxchatmessagetype_Z ;
         gxTv_SdtGXChatMessage_Gxchatmessagedate_Z = sdt.gxTv_SdtGXChatMessage_Gxchatmessagedate_Z ;
         gxTv_SdtGXChatMessage_Gxchatuserdevice_Z = sdt.gxTv_SdtGXChatMessage_Gxchatuserdevice_Z ;
         gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z = sdt.gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z ;
         gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z = sdt.gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z ;
         gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z = sdt.gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z ;
         gxTv_SdtGXChatMessage_Gxchatmessageimage_N = sdt.gxTv_SdtGXChatMessage_Gxchatmessageimage_N ;
         gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N = sdt.gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("GXChatMessageId", gxTv_SdtGXChatMessage_Gxchatmessageid, false, includeNonInitialized);
         AddObjectProperty("GXChatUserId", gxTv_SdtGXChatMessage_Gxchatuserid, false, includeNonInitialized);
         AddObjectProperty("GXChatMessageMessage", gxTv_SdtGXChatMessage_Gxchatmessagemessage, false, includeNonInitialized);
         AddObjectProperty("GXChatMessageType", gxTv_SdtGXChatMessage_Gxchatmessagetype, false, includeNonInitialized);
         AddObjectProperty("GXChatMessageImage", gxTv_SdtGXChatMessage_Gxchatmessageimage, false, includeNonInitialized);
         AddObjectProperty("GXChatMessageImage_N", gxTv_SdtGXChatMessage_Gxchatmessageimage_N, false, includeNonInitialized);
         datetimemil_STZ = gxTv_SdtGXChatMessage_Gxchatmessagedate;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ".";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("GXChatMessageDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("GXChatMessageMeta", gxTv_SdtGXChatMessage_Gxchatmessagemeta, false, includeNonInitialized);
         AddObjectProperty("GXChatUserDevice", gxTv_SdtGXChatMessage_Gxchatuserdevice, false, includeNonInitialized);
         AddObjectProperty("GXChatMessageRepeat", gxTv_SdtGXChatMessage_Gxchatmessagerepeat, false, includeNonInitialized);
         AddObjectProperty("GXChatMessageInstance", gxTv_SdtGXChatMessage_Gxchatmessageinstance, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("GXChatMessageImage_GXI", gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtGXChatMessage_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtGXChatMessage_Initialized, false, includeNonInitialized);
            AddObjectProperty("GXChatMessageId_Z", gxTv_SdtGXChatMessage_Gxchatmessageid_Z, false, includeNonInitialized);
            AddObjectProperty("GXChatUserId_Z", gxTv_SdtGXChatMessage_Gxchatuserid_Z, false, includeNonInitialized);
            AddObjectProperty("GXChatMessageType_Z", gxTv_SdtGXChatMessage_Gxchatmessagetype_Z, false, includeNonInitialized);
            datetimemil_STZ = gxTv_SdtGXChatMessage_Gxchatmessagedate_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ".";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.MilliSecond( datetimemil_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "000", 1, 3-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("GXChatMessageDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("GXChatUserDevice_Z", gxTv_SdtGXChatMessage_Gxchatuserdevice_Z, false, includeNonInitialized);
            AddObjectProperty("GXChatMessageRepeat_Z", gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z, false, includeNonInitialized);
            AddObjectProperty("GXChatMessageInstance_Z", gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z, false, includeNonInitialized);
            AddObjectProperty("GXChatMessageImage_GXI_Z", gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("GXChatMessageImage_N", gxTv_SdtGXChatMessage_Gxchatmessageimage_N, false, includeNonInitialized);
            AddObjectProperty("GXChatMessageImage_GXI_N", gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.commonchatbots.SdtGXChatMessage sdt )
      {
         if ( sdt.IsDirty("GXChatMessageId") )
         {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageid = sdt.gxTv_SdtGXChatMessage_Gxchatmessageid ;
         }
         if ( sdt.IsDirty("GXChatUserId") )
         {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatuserid = sdt.gxTv_SdtGXChatMessage_Gxchatuserid ;
         }
         if ( sdt.IsDirty("GXChatMessageMessage") )
         {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagemessage = sdt.gxTv_SdtGXChatMessage_Gxchatmessagemessage ;
         }
         if ( sdt.IsDirty("GXChatMessageType") )
         {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagetype = sdt.gxTv_SdtGXChatMessage_Gxchatmessagetype ;
         }
         if ( sdt.IsDirty("GXChatMessageImage") )
         {
            gxTv_SdtGXChatMessage_Gxchatmessageimage_N = (short)(sdt.gxTv_SdtGXChatMessage_Gxchatmessageimage_N);
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageimage = sdt.gxTv_SdtGXChatMessage_Gxchatmessageimage ;
         }
         if ( sdt.IsDirty("GXChatMessageImage") )
         {
            gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N = (short)(sdt.gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N);
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi = sdt.gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi ;
         }
         if ( sdt.IsDirty("GXChatMessageDate") )
         {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagedate = sdt.gxTv_SdtGXChatMessage_Gxchatmessagedate ;
         }
         if ( sdt.IsDirty("GXChatMessageMeta") )
         {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagemeta = sdt.gxTv_SdtGXChatMessage_Gxchatmessagemeta ;
         }
         if ( sdt.IsDirty("GXChatUserDevice") )
         {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatuserdevice = sdt.gxTv_SdtGXChatMessage_Gxchatuserdevice ;
         }
         if ( sdt.IsDirty("GXChatMessageRepeat") )
         {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagerepeat = sdt.gxTv_SdtGXChatMessage_Gxchatmessagerepeat ;
         }
         if ( sdt.IsDirty("GXChatMessageInstance") )
         {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageinstance = sdt.gxTv_SdtGXChatMessage_Gxchatmessageinstance ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "GXChatMessageId" )]
      [  XmlElement( ElementName = "GXChatMessageId"   )]
      public Guid gxTpr_Gxchatmessageid
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessageid ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            if ( gxTv_SdtGXChatMessage_Gxchatmessageid != value )
            {
               gxTv_SdtGXChatMessage_Mode = "INS";
               this.gxTv_SdtGXChatMessage_Gxchatmessageid_Z_SetNull( );
               this.gxTv_SdtGXChatMessage_Gxchatuserid_Z_SetNull( );
               this.gxTv_SdtGXChatMessage_Gxchatmessagetype_Z_SetNull( );
               this.gxTv_SdtGXChatMessage_Gxchatmessagedate_Z_SetNull( );
               this.gxTv_SdtGXChatMessage_Gxchatuserdevice_Z_SetNull( );
               this.gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z_SetNull( );
               this.gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z_SetNull( );
               this.gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z_SetNull( );
            }
            gxTv_SdtGXChatMessage_Gxchatmessageid = (Guid)(value);
            SetDirty("Gxchatmessageid");
         }

      }

      [  SoapElement( ElementName = "GXChatUserId" )]
      [  XmlElement( ElementName = "GXChatUserId"   )]
      public Guid gxTpr_Gxchatuserid
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatuserid ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatuserid = (Guid)(value);
            SetDirty("Gxchatuserid");
         }

      }

      [  SoapElement( ElementName = "GXChatMessageMessage" )]
      [  XmlElement( ElementName = "GXChatMessageMessage"   )]
      public string gxTpr_Gxchatmessagemessage
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessagemessage ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagemessage = value;
            SetDirty("Gxchatmessagemessage");
         }

      }

      [  SoapElement( ElementName = "GXChatMessageType" )]
      [  XmlElement( ElementName = "GXChatMessageType"   )]
      public string gxTpr_Gxchatmessagetype
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessagetype ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagetype = value;
            SetDirty("Gxchatmessagetype");
         }

      }

      [  SoapElement( ElementName = "GXChatMessageImage" )]
      [  XmlElement( ElementName = "GXChatMessageImage"   )]
      [GxUpload()]
      public string gxTpr_Gxchatmessageimage
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessageimage ;
         }

         set {
            gxTv_SdtGXChatMessage_Gxchatmessageimage_N = 0;
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageimage = value;
            SetDirty("Gxchatmessageimage");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatmessageimage_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessageimage_N = 1;
         gxTv_SdtGXChatMessage_Gxchatmessageimage = "";
         SetDirty("Gxchatmessageimage");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatmessageimage_IsNull( )
      {
         return (gxTv_SdtGXChatMessage_Gxchatmessageimage_N==1) ;
      }

      [  SoapElement( ElementName = "GXChatMessageImage_GXI" )]
      [  XmlElement( ElementName = "GXChatMessageImage_GXI"   )]
      public string gxTpr_Gxchatmessageimage_gxi
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi ;
         }

         set {
            gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N = 0;
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi = value;
            SetDirty("Gxchatmessageimage_gxi");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N = 1;
         gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi = "";
         SetDirty("Gxchatmessageimage_gxi");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_IsNull( )
      {
         return (gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "GXChatMessageDate" )]
      [  XmlElement( ElementName = "GXChatMessageDate"  , IsNullable=true )]
      public string gxTpr_Gxchatmessagedate_Nullable
      {
         get {
            if ( gxTv_SdtGXChatMessage_Gxchatmessagedate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtGXChatMessage_Gxchatmessagedate, null, true).value ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtGXChatMessage_Gxchatmessagedate = DateTime.MinValue;
            else
               gxTv_SdtGXChatMessage_Gxchatmessagedate = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Gxchatmessagedate
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessagedate ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagedate = value;
            SetDirty("Gxchatmessagedate");
         }

      }

      [  SoapElement( ElementName = "GXChatMessageMeta" )]
      [  XmlElement( ElementName = "GXChatMessageMeta"   )]
      public string gxTpr_Gxchatmessagemeta
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessagemeta ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagemeta = value;
            SetDirty("Gxchatmessagemeta");
         }

      }

      [  SoapElement( ElementName = "GXChatUserDevice" )]
      [  XmlElement( ElementName = "GXChatUserDevice"   )]
      public string gxTpr_Gxchatuserdevice
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatuserdevice ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatuserdevice = value;
            SetDirty("Gxchatuserdevice");
         }

      }

      [  SoapElement( ElementName = "GXChatMessageRepeat" )]
      [  XmlElement( ElementName = "GXChatMessageRepeat"   )]
      public string gxTpr_Gxchatmessagerepeat
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessagerepeat ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagerepeat = value;
            SetDirty("Gxchatmessagerepeat");
         }

      }

      [  SoapElement( ElementName = "GXChatMessageInstance" )]
      [  XmlElement( ElementName = "GXChatMessageInstance"   )]
      public string gxTpr_Gxchatmessageinstance
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessageinstance ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageinstance = value;
            SetDirty("Gxchatmessageinstance");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtGXChatMessage_Mode ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtGXChatMessage_Mode_SetNull( )
      {
         gxTv_SdtGXChatMessage_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtGXChatMessage_Initialized ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtGXChatMessage_Initialized_SetNull( )
      {
         gxTv_SdtGXChatMessage_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatMessageId_Z" )]
      [  XmlElement( ElementName = "GXChatMessageId_Z"   )]
      public Guid gxTpr_Gxchatmessageid_Z
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessageid_Z ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageid_Z = (Guid)(value);
            SetDirty("Gxchatmessageid_Z");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatmessageid_Z_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessageid_Z = (Guid)(Guid.Empty);
         SetDirty("Gxchatmessageid_Z");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatmessageid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatUserId_Z" )]
      [  XmlElement( ElementName = "GXChatUserId_Z"   )]
      public Guid gxTpr_Gxchatuserid_Z
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatuserid_Z ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatuserid_Z = (Guid)(value);
            SetDirty("Gxchatuserid_Z");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatuserid_Z_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatuserid_Z = (Guid)(Guid.Empty);
         SetDirty("Gxchatuserid_Z");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatMessageType_Z" )]
      [  XmlElement( ElementName = "GXChatMessageType_Z"   )]
      public string gxTpr_Gxchatmessagetype_Z
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessagetype_Z ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagetype_Z = value;
            SetDirty("Gxchatmessagetype_Z");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatmessagetype_Z_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessagetype_Z = "";
         SetDirty("Gxchatmessagetype_Z");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatmessagetype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatMessageDate_Z" )]
      [  XmlElement( ElementName = "GXChatMessageDate_Z"  , IsNullable=true )]
      public string gxTpr_Gxchatmessagedate_Z_Nullable
      {
         get {
            if ( gxTv_SdtGXChatMessage_Gxchatmessagedate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtGXChatMessage_Gxchatmessagedate_Z, null, true).value ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtGXChatMessage_Gxchatmessagedate_Z = DateTime.MinValue;
            else
               gxTv_SdtGXChatMessage_Gxchatmessagedate_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Gxchatmessagedate_Z
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessagedate_Z ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagedate_Z = value;
            SetDirty("Gxchatmessagedate_Z");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatmessagedate_Z_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessagedate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Gxchatmessagedate_Z");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatmessagedate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatUserDevice_Z" )]
      [  XmlElement( ElementName = "GXChatUserDevice_Z"   )]
      public string gxTpr_Gxchatuserdevice_Z
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatuserdevice_Z ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatuserdevice_Z = value;
            SetDirty("Gxchatuserdevice_Z");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatuserdevice_Z_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatuserdevice_Z = "";
         SetDirty("Gxchatuserdevice_Z");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatuserdevice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatMessageRepeat_Z" )]
      [  XmlElement( ElementName = "GXChatMessageRepeat_Z"   )]
      public string gxTpr_Gxchatmessagerepeat_Z
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z = value;
            SetDirty("Gxchatmessagerepeat_Z");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z = "";
         SetDirty("Gxchatmessagerepeat_Z");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatMessageInstance_Z" )]
      [  XmlElement( ElementName = "GXChatMessageInstance_Z"   )]
      public string gxTpr_Gxchatmessageinstance_Z
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z = value;
            SetDirty("Gxchatmessageinstance_Z");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z = "";
         SetDirty("Gxchatmessageinstance_Z");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatMessageImage_GXI_Z" )]
      [  XmlElement( ElementName = "GXChatMessageImage_GXI_Z"   )]
      public string gxTpr_Gxchatmessageimage_gxi_Z
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z = value;
            SetDirty("Gxchatmessageimage_gxi_Z");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z = "";
         SetDirty("Gxchatmessageimage_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatMessageImage_N" )]
      [  XmlElement( ElementName = "GXChatMessageImage_N"   )]
      public short gxTpr_Gxchatmessageimage_N
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessageimage_N ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageimage_N = value;
            SetDirty("Gxchatmessageimage_N");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatmessageimage_N_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessageimage_N = 0;
         SetDirty("Gxchatmessageimage_N");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatmessageimage_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatMessageImage_GXI_N" )]
      [  XmlElement( ElementName = "GXChatMessageImage_GXI_N"   )]
      public short gxTpr_Gxchatmessageimage_gxi_N
      {
         get {
            return gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N ;
         }

         set {
            gxTv_SdtGXChatMessage_N = 0;
            gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N = value;
            SetDirty("Gxchatmessageimage_gxi_N");
         }

      }

      public void gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N_SetNull( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N = 0;
         SetDirty("Gxchatmessageimage_gxi_N");
         return  ;
      }

      public bool gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtGXChatMessage_Gxchatmessageid = (Guid)(Guid.Empty);
         gxTv_SdtGXChatMessage_N = 1;
         gxTv_SdtGXChatMessage_Gxchatuserid = (Guid)(Guid.Empty);
         gxTv_SdtGXChatMessage_Gxchatmessagemessage = "";
         gxTv_SdtGXChatMessage_Gxchatmessagetype = "";
         gxTv_SdtGXChatMessage_Gxchatmessageimage = "";
         gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi = "";
         gxTv_SdtGXChatMessage_Gxchatmessagedate = (DateTime)(DateTime.MinValue);
         gxTv_SdtGXChatMessage_Gxchatmessagemeta = "";
         gxTv_SdtGXChatMessage_Gxchatuserdevice = "";
         gxTv_SdtGXChatMessage_Gxchatmessagerepeat = "";
         gxTv_SdtGXChatMessage_Gxchatmessageinstance = "";
         gxTv_SdtGXChatMessage_Mode = "";
         gxTv_SdtGXChatMessage_Gxchatmessageid_Z = (Guid)(Guid.Empty);
         gxTv_SdtGXChatMessage_Gxchatuserid_Z = (Guid)(Guid.Empty);
         gxTv_SdtGXChatMessage_Gxchatmessagetype_Z = "";
         gxTv_SdtGXChatMessage_Gxchatmessagedate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtGXChatMessage_Gxchatuserdevice_Z = "";
         gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z = "";
         gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z = "";
         gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z = "";
         datetimemil_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "commonchatbots.gxchatmessage", "GeneXus.Programs.commonchatbots.gxchatmessage_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtGXChatMessage_N ;
      }

      private short gxTv_SdtGXChatMessage_N ;
      private short gxTv_SdtGXChatMessage_Initialized ;
      private short gxTv_SdtGXChatMessage_Gxchatmessageimage_N ;
      private short gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_N ;
      private string gxTv_SdtGXChatMessage_Gxchatmessagetype ;
      private string gxTv_SdtGXChatMessage_Mode ;
      private string gxTv_SdtGXChatMessage_Gxchatmessagetype_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtGXChatMessage_Gxchatmessagedate ;
      private DateTime gxTv_SdtGXChatMessage_Gxchatmessagedate_Z ;
      private DateTime datetimemil_STZ ;
      private string gxTv_SdtGXChatMessage_Gxchatmessagemessage ;
      private string gxTv_SdtGXChatMessage_Gxchatmessagemeta ;
      private string gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi ;
      private string gxTv_SdtGXChatMessage_Gxchatuserdevice ;
      private string gxTv_SdtGXChatMessage_Gxchatmessagerepeat ;
      private string gxTv_SdtGXChatMessage_Gxchatmessageinstance ;
      private string gxTv_SdtGXChatMessage_Gxchatuserdevice_Z ;
      private string gxTv_SdtGXChatMessage_Gxchatmessagerepeat_Z ;
      private string gxTv_SdtGXChatMessage_Gxchatmessageinstance_Z ;
      private string gxTv_SdtGXChatMessage_Gxchatmessageimage_gxi_Z ;
      private string gxTv_SdtGXChatMessage_Gxchatmessageimage ;
      private Guid gxTv_SdtGXChatMessage_Gxchatmessageid ;
      private Guid gxTv_SdtGXChatMessage_Gxchatuserid ;
      private Guid gxTv_SdtGXChatMessage_Gxchatmessageid_Z ;
      private Guid gxTv_SdtGXChatMessage_Gxchatuserid_Z ;
   }

   [DataContract(Name = @"CommonChatbots\GXChatMessage", Namespace = "kb_ticket")]
   public class SdtGXChatMessage_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.commonchatbots.SdtGXChatMessage>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtGXChatMessage_RESTInterface( ) : base()
      {
      }

      public SdtGXChatMessage_RESTInterface( GeneXus.Programs.commonchatbots.SdtGXChatMessage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "GXChatMessageId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Gxchatmessageid
      {
         get {
            return sdt.gxTpr_Gxchatmessageid ;
         }

         set {
            sdt.gxTpr_Gxchatmessageid = (Guid)(value);
         }

      }

      [DataMember( Name = "GXChatUserId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Gxchatuserid
      {
         get {
            return sdt.gxTpr_Gxchatuserid ;
         }

         set {
            sdt.gxTpr_Gxchatuserid = (Guid)(value);
         }

      }

      [DataMember( Name = "GXChatMessageMessage" , Order = 2 )]
      public string gxTpr_Gxchatmessagemessage
      {
         get {
            return sdt.gxTpr_Gxchatmessagemessage ;
         }

         set {
            sdt.gxTpr_Gxchatmessagemessage = value;
         }

      }

      [DataMember( Name = "GXChatMessageType" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Gxchatmessagetype
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxchatmessagetype) ;
         }

         set {
            sdt.gxTpr_Gxchatmessagetype = value;
         }

      }

      [DataMember( Name = "GXChatMessageImage" , Order = 4 )]
      [GxUpload()]
      public string gxTpr_Gxchatmessageimage
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Gxchatmessageimage)) ? PathUtil.RelativeURL( sdt.gxTpr_Gxchatmessageimage) : StringUtil.RTrim( sdt.gxTpr_Gxchatmessageimage_gxi)) ;
         }

         set {
            sdt.gxTpr_Gxchatmessageimage = value;
         }

      }

      [DataMember( Name = "GXChatMessageDate" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Gxchatmessagedate
      {
         get {
            return DateTimeUtil.TToC3( sdt.gxTpr_Gxchatmessagedate) ;
         }

         set {
            sdt.gxTpr_Gxchatmessagedate = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "GXChatMessageMeta" , Order = 6 )]
      public string gxTpr_Gxchatmessagemeta
      {
         get {
            return sdt.gxTpr_Gxchatmessagemeta ;
         }

         set {
            sdt.gxTpr_Gxchatmessagemeta = value;
         }

      }

      [DataMember( Name = "GXChatUserDevice" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Gxchatuserdevice
      {
         get {
            return sdt.gxTpr_Gxchatuserdevice ;
         }

         set {
            sdt.gxTpr_Gxchatuserdevice = value;
         }

      }

      [DataMember( Name = "GXChatMessageRepeat" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Gxchatmessagerepeat
      {
         get {
            return sdt.gxTpr_Gxchatmessagerepeat ;
         }

         set {
            sdt.gxTpr_Gxchatmessagerepeat = value;
         }

      }

      [DataMember( Name = "GXChatMessageInstance" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Gxchatmessageinstance
      {
         get {
            return sdt.gxTpr_Gxchatmessageinstance ;
         }

         set {
            sdt.gxTpr_Gxchatmessageinstance = value;
         }

      }

      public GeneXus.Programs.commonchatbots.SdtGXChatMessage sdt
      {
         get {
            return (GeneXus.Programs.commonchatbots.SdtGXChatMessage)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.commonchatbots.SdtGXChatMessage() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 10 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"CommonChatbots\GXChatMessage", Namespace = "kb_ticket")]
   public class SdtGXChatMessage_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.commonchatbots.SdtGXChatMessage>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtGXChatMessage_RESTLInterface( ) : base()
      {
      }

      public SdtGXChatMessage_RESTLInterface( GeneXus.Programs.commonchatbots.SdtGXChatMessage psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "GXChatMessageType" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Gxchatmessagetype
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxchatmessagetype) ;
         }

         set {
            sdt.gxTpr_Gxchatmessagetype = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.commonchatbots.SdtGXChatMessage sdt
      {
         get {
            return (GeneXus.Programs.commonchatbots.SdtGXChatMessage)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.commonchatbots.SdtGXChatMessage() ;
         }
      }

   }

}
