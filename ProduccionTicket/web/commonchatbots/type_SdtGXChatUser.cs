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
   [XmlRoot(ElementName = "GXChatUser" )]
   [XmlType(TypeName =  "GXChatUser" , Namespace = "kb_ticket" )]
   [Serializable]
   public class SdtGXChatUser : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtGXChatUser( )
      {
      }

      public SdtGXChatUser( IGxContext context )
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

      public void Load( Guid AV268GXChatUserId ,
                        string AV269GXChatUserDevice )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV268GXChatUserId,(string)AV269GXChatUserDevice});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"GXChatUserId", typeof(Guid)}, new Object[]{"GXChatUserDevice", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CommonChatbots\\GXChatUser");
         metadata.Set("BT", "GXChatUser");
         metadata.Set("PK", "[ \"GXChatUserId\",\"GXChatUserDevice\" ]");
         metadata.Set("PKAssigned", "[ \"GXChatUserId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Gxchatuserid_Z");
         state.Add("gxTpr_Gxchatuserdevice_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.commonchatbots.SdtGXChatUser sdt;
         sdt = (GeneXus.Programs.commonchatbots.SdtGXChatUser)(source);
         gxTv_SdtGXChatUser_Gxchatuserid = sdt.gxTv_SdtGXChatUser_Gxchatuserid ;
         gxTv_SdtGXChatUser_Gxchatuserdevice = sdt.gxTv_SdtGXChatUser_Gxchatuserdevice ;
         gxTv_SdtGXChatUser_Mode = sdt.gxTv_SdtGXChatUser_Mode ;
         gxTv_SdtGXChatUser_Initialized = sdt.gxTv_SdtGXChatUser_Initialized ;
         gxTv_SdtGXChatUser_Gxchatuserid_Z = sdt.gxTv_SdtGXChatUser_Gxchatuserid_Z ;
         gxTv_SdtGXChatUser_Gxchatuserdevice_Z = sdt.gxTv_SdtGXChatUser_Gxchatuserdevice_Z ;
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
         AddObjectProperty("GXChatUserId", gxTv_SdtGXChatUser_Gxchatuserid, false, includeNonInitialized);
         AddObjectProperty("GXChatUserDevice", gxTv_SdtGXChatUser_Gxchatuserdevice, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtGXChatUser_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtGXChatUser_Initialized, false, includeNonInitialized);
            AddObjectProperty("GXChatUserId_Z", gxTv_SdtGXChatUser_Gxchatuserid_Z, false, includeNonInitialized);
            AddObjectProperty("GXChatUserDevice_Z", gxTv_SdtGXChatUser_Gxchatuserdevice_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.commonchatbots.SdtGXChatUser sdt )
      {
         if ( sdt.IsDirty("GXChatUserId") )
         {
            gxTv_SdtGXChatUser_N = 0;
            gxTv_SdtGXChatUser_Gxchatuserid = sdt.gxTv_SdtGXChatUser_Gxchatuserid ;
         }
         if ( sdt.IsDirty("GXChatUserDevice") )
         {
            gxTv_SdtGXChatUser_N = 0;
            gxTv_SdtGXChatUser_Gxchatuserdevice = sdt.gxTv_SdtGXChatUser_Gxchatuserdevice ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "GXChatUserId" )]
      [  XmlElement( ElementName = "GXChatUserId"   )]
      public Guid gxTpr_Gxchatuserid
      {
         get {
            return gxTv_SdtGXChatUser_Gxchatuserid ;
         }

         set {
            gxTv_SdtGXChatUser_N = 0;
            if ( gxTv_SdtGXChatUser_Gxchatuserid != value )
            {
               gxTv_SdtGXChatUser_Mode = "INS";
               this.gxTv_SdtGXChatUser_Gxchatuserid_Z_SetNull( );
               this.gxTv_SdtGXChatUser_Gxchatuserdevice_Z_SetNull( );
            }
            gxTv_SdtGXChatUser_Gxchatuserid = (Guid)(value);
            SetDirty("Gxchatuserid");
         }

      }

      [  SoapElement( ElementName = "GXChatUserDevice" )]
      [  XmlElement( ElementName = "GXChatUserDevice"   )]
      public string gxTpr_Gxchatuserdevice
      {
         get {
            return gxTv_SdtGXChatUser_Gxchatuserdevice ;
         }

         set {
            gxTv_SdtGXChatUser_N = 0;
            if ( StringUtil.StrCmp(gxTv_SdtGXChatUser_Gxchatuserdevice, value) != 0 )
            {
               gxTv_SdtGXChatUser_Mode = "INS";
               this.gxTv_SdtGXChatUser_Gxchatuserid_Z_SetNull( );
               this.gxTv_SdtGXChatUser_Gxchatuserdevice_Z_SetNull( );
            }
            gxTv_SdtGXChatUser_Gxchatuserdevice = value;
            SetDirty("Gxchatuserdevice");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtGXChatUser_Mode ;
         }

         set {
            gxTv_SdtGXChatUser_N = 0;
            gxTv_SdtGXChatUser_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtGXChatUser_Mode_SetNull( )
      {
         gxTv_SdtGXChatUser_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtGXChatUser_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtGXChatUser_Initialized ;
         }

         set {
            gxTv_SdtGXChatUser_N = 0;
            gxTv_SdtGXChatUser_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtGXChatUser_Initialized_SetNull( )
      {
         gxTv_SdtGXChatUser_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtGXChatUser_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatUserId_Z" )]
      [  XmlElement( ElementName = "GXChatUserId_Z"   )]
      public Guid gxTpr_Gxchatuserid_Z
      {
         get {
            return gxTv_SdtGXChatUser_Gxchatuserid_Z ;
         }

         set {
            gxTv_SdtGXChatUser_N = 0;
            gxTv_SdtGXChatUser_Gxchatuserid_Z = (Guid)(value);
            SetDirty("Gxchatuserid_Z");
         }

      }

      public void gxTv_SdtGXChatUser_Gxchatuserid_Z_SetNull( )
      {
         gxTv_SdtGXChatUser_Gxchatuserid_Z = (Guid)(Guid.Empty);
         SetDirty("Gxchatuserid_Z");
         return  ;
      }

      public bool gxTv_SdtGXChatUser_Gxchatuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GXChatUserDevice_Z" )]
      [  XmlElement( ElementName = "GXChatUserDevice_Z"   )]
      public string gxTpr_Gxchatuserdevice_Z
      {
         get {
            return gxTv_SdtGXChatUser_Gxchatuserdevice_Z ;
         }

         set {
            gxTv_SdtGXChatUser_N = 0;
            gxTv_SdtGXChatUser_Gxchatuserdevice_Z = value;
            SetDirty("Gxchatuserdevice_Z");
         }

      }

      public void gxTv_SdtGXChatUser_Gxchatuserdevice_Z_SetNull( )
      {
         gxTv_SdtGXChatUser_Gxchatuserdevice_Z = "";
         SetDirty("Gxchatuserdevice_Z");
         return  ;
      }

      public bool gxTv_SdtGXChatUser_Gxchatuserdevice_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtGXChatUser_Gxchatuserid = (Guid)(Guid.Empty);
         gxTv_SdtGXChatUser_N = 1;
         gxTv_SdtGXChatUser_Gxchatuserdevice = "";
         gxTv_SdtGXChatUser_Mode = "";
         gxTv_SdtGXChatUser_Gxchatuserid_Z = (Guid)(Guid.Empty);
         gxTv_SdtGXChatUser_Gxchatuserdevice_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "commonchatbots.gxchatuser", "GeneXus.Programs.commonchatbots.gxchatuser_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtGXChatUser_N ;
      }

      private short gxTv_SdtGXChatUser_N ;
      private short gxTv_SdtGXChatUser_Initialized ;
      private string gxTv_SdtGXChatUser_Mode ;
      private string gxTv_SdtGXChatUser_Gxchatuserdevice ;
      private string gxTv_SdtGXChatUser_Gxchatuserdevice_Z ;
      private Guid gxTv_SdtGXChatUser_Gxchatuserid ;
      private Guid gxTv_SdtGXChatUser_Gxchatuserid_Z ;
   }

   [DataContract(Name = @"CommonChatbots\GXChatUser", Namespace = "kb_ticket")]
   public class SdtGXChatUser_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.commonchatbots.SdtGXChatUser>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtGXChatUser_RESTInterface( ) : base()
      {
      }

      public SdtGXChatUser_RESTInterface( GeneXus.Programs.commonchatbots.SdtGXChatUser psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "GXChatUserId" , Order = 0 )]
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

      [DataMember( Name = "GXChatUserDevice" , Order = 1 )]
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

      public GeneXus.Programs.commonchatbots.SdtGXChatUser sdt
      {
         get {
            return (GeneXus.Programs.commonchatbots.SdtGXChatUser)Sdt ;
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
            sdt = new GeneXus.Programs.commonchatbots.SdtGXChatUser() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
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

   [DataContract(Name = @"CommonChatbots\GXChatUser", Namespace = "kb_ticket")]
   public class SdtGXChatUser_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.commonchatbots.SdtGXChatUser>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtGXChatUser_RESTLInterface( ) : base()
      {
      }

      public SdtGXChatUser_RESTLInterface( GeneXus.Programs.commonchatbots.SdtGXChatUser psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "uri", Order = 0 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.commonchatbots.SdtGXChatUser sdt
      {
         get {
            return (GeneXus.Programs.commonchatbots.SdtGXChatUser)Sdt ;
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
            sdt = new GeneXus.Programs.commonchatbots.SdtGXChatUser() ;
         }
      }

   }

}
