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
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "Item" )]
   [XmlType(TypeName =  "Item" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtPanelTecnico_Level_Detail_Grid1Sdt_Item : GxUserType
   {
      public SdtPanelTecnico_Level_Detail_Grid1Sdt_Item( )
      {
         /* Constructor for serialization */
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuarionombre = "";
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha = DateTime.MinValue;
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariohora = (DateTime)(DateTime.MinValue);
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariodepartamento = "";
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Tickettecnicoresponsablenombre = "";
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadoticketticketnombre = "";
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve = DateTime.MinValue;
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablehoraresuelve = (DateTime)(DateTime.MinValue);
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadotickettecniconombre = "";
      }

      public SdtPanelTecnico_Level_Detail_Grid1Sdt_Item( IGxContext context )
      {
         this.context = context;
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
         AddObjectProperty("TicketId", gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketid, false, false);
         AddObjectProperty("TicketResponsableId", gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsableid, false, false);
         AddObjectProperty("UsuarioId", gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuarioid, false, false);
         AddObjectProperty("UsuarioNombre", gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuarionombre, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuarioFecha", sDateCnv, false, false);
         datetime_STZ = gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariohora;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("UsuarioHora", sDateCnv, false, false);
         AddObjectProperty("UsuarioDepartamento", gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariodepartamento, false, false);
         AddObjectProperty("TicketTecnicoResponsableNombre", gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Tickettecnicoresponsablenombre, false, false);
         AddObjectProperty("EstadoTicketTicketNombre", gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadoticketticketnombre, false, false);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TicketResponsableFechaResuelve", sDateCnv, false, false);
         datetime_STZ = gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablehoraresuelve;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TicketResponsableHoraResuelve", sDateCnv, false, false);
         AddObjectProperty("EstadoTicketTecnicoNombre", gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadotickettecniconombre, false, false);
         AddObjectProperty("TicketTecnicoResponsableId", gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Tickettecnicoresponsableid, false, false);
         AddObjectProperty("EstadoTicketTecnicoId", gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadotickettecnicoid, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "TicketId" )]
      [  XmlElement( ElementName = "TicketId"   )]
      public long gxTpr_Ticketid
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketid ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketid = value;
            SetDirty("Ticketid");
         }

      }

      [  SoapElement( ElementName = "TicketResponsableId" )]
      [  XmlElement( ElementName = "TicketResponsableId"   )]
      public long gxTpr_Ticketresponsableid
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsableid ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsableid = value;
            SetDirty("Ticketresponsableid");
         }

      }

      [  SoapElement( ElementName = "UsuarioId" )]
      [  XmlElement( ElementName = "UsuarioId"   )]
      public short gxTpr_Usuarioid
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuarioid ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuarioid = value;
            SetDirty("Usuarioid");
         }

      }

      [  SoapElement( ElementName = "UsuarioNombre" )]
      [  XmlElement( ElementName = "UsuarioNombre"   )]
      public string gxTpr_Usuarionombre
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuarionombre ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuarionombre = value;
            SetDirty("Usuarionombre");
         }

      }

      [  SoapElement( ElementName = "UsuarioFecha" )]
      [  XmlElement( ElementName = "UsuarioFecha"  , IsNullable=true )]
      public string gxTpr_Usuariofecha_Nullable
      {
         get {
            if ( gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha).value ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha = DateTime.MinValue;
            else
               gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariofecha
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha = value;
            SetDirty("Usuariofecha");
         }

      }

      [  SoapElement( ElementName = "UsuarioHora" )]
      [  XmlElement( ElementName = "UsuarioHora"  , IsNullable=true )]
      public string gxTpr_Usuariohora_Nullable
      {
         get {
            if ( gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariohora == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariohora).value ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariohora = DateTime.MinValue;
            else
               gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariohora = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariohora
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariohora ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariohora = value;
            SetDirty("Usuariohora");
         }

      }

      [  SoapElement( ElementName = "UsuarioDepartamento" )]
      [  XmlElement( ElementName = "UsuarioDepartamento"   )]
      public string gxTpr_Usuariodepartamento
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariodepartamento ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariodepartamento = value;
            SetDirty("Usuariodepartamento");
         }

      }

      [  SoapElement( ElementName = "TicketTecnicoResponsableNombre" )]
      [  XmlElement( ElementName = "TicketTecnicoResponsableNombre"   )]
      public string gxTpr_Tickettecnicoresponsablenombre
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Tickettecnicoresponsablenombre ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Tickettecnicoresponsablenombre = value;
            SetDirty("Tickettecnicoresponsablenombre");
         }

      }

      [  SoapElement( ElementName = "EstadoTicketTicketNombre" )]
      [  XmlElement( ElementName = "EstadoTicketTicketNombre"   )]
      public string gxTpr_Estadoticketticketnombre
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadoticketticketnombre ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadoticketticketnombre = value;
            SetDirty("Estadoticketticketnombre");
         }

      }

      [  SoapElement( ElementName = "TicketResponsableFechaResuelve" )]
      [  XmlElement( ElementName = "TicketResponsableFechaResuelve"  , IsNullable=true )]
      public string gxTpr_Ticketresponsablefecharesuelve_Nullable
      {
         get {
            if ( gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve).value ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve = DateTime.MinValue;
            else
               gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Ticketresponsablefecharesuelve
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve = value;
            SetDirty("Ticketresponsablefecharesuelve");
         }

      }

      [  SoapElement( ElementName = "TicketResponsableHoraResuelve" )]
      [  XmlElement( ElementName = "TicketResponsableHoraResuelve"  , IsNullable=true )]
      public string gxTpr_Ticketresponsablehoraresuelve_Nullable
      {
         get {
            if ( gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablehoraresuelve == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablehoraresuelve).value ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablehoraresuelve = DateTime.MinValue;
            else
               gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablehoraresuelve = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Ticketresponsablehoraresuelve
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablehoraresuelve ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablehoraresuelve = value;
            SetDirty("Ticketresponsablehoraresuelve");
         }

      }

      [  SoapElement( ElementName = "EstadoTicketTecnicoNombre" )]
      [  XmlElement( ElementName = "EstadoTicketTecnicoNombre"   )]
      public string gxTpr_Estadotickettecniconombre
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadotickettecniconombre ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadotickettecniconombre = value;
            SetDirty("Estadotickettecniconombre");
         }

      }

      [  SoapElement( ElementName = "TicketTecnicoResponsableId" )]
      [  XmlElement( ElementName = "TicketTecnicoResponsableId"   )]
      public short gxTpr_Tickettecnicoresponsableid
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Tickettecnicoresponsableid ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Tickettecnicoresponsableid = value;
            SetDirty("Tickettecnicoresponsableid");
         }

      }

      [  SoapElement( ElementName = "EstadoTicketTecnicoId" )]
      [  XmlElement( ElementName = "EstadoTicketTecnicoId"   )]
      public short gxTpr_Estadotickettecnicoid
      {
         get {
            return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadotickettecnicoid ;
         }

         set {
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 0;
            gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadotickettecnicoid = value;
            SetDirty("Estadotickettecnicoid");
         }

      }

      public void initialize( )
      {
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuarionombre = "";
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha = DateTime.MinValue;
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariohora = (DateTime)(DateTime.MinValue);
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariodepartamento = "";
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Tickettecnicoresponsablenombre = "";
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadoticketticketnombre = "";
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve = DateTime.MinValue;
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablehoraresuelve = (DateTime)(DateTime.MinValue);
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadotickettecniconombre = "";
         gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N = 1;
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N ;
      }

      protected short gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_N ;
      protected short gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuarioid ;
      protected short gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Tickettecnicoresponsableid ;
      protected short gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadotickettecnicoid ;
      protected long gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketid ;
      protected long gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsableid ;
      protected string sDateCnv ;
      protected string sNumToPad ;
      protected DateTime gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariohora ;
      protected DateTime gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablehoraresuelve ;
      protected DateTime datetime_STZ ;
      protected DateTime gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariofecha ;
      protected DateTime gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Ticketresponsablefecharesuelve ;
      protected string gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuarionombre ;
      protected string gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Usuariodepartamento ;
      protected string gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Tickettecnicoresponsablenombre ;
      protected string gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadoticketticketnombre ;
      protected string gxTv_SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_Estadotickettecniconombre ;
   }

   [DataContract(Name = @"PanelTecnico_Level_Detail_Grid1Sdt.Item", Namespace = "http://tempuri.org/")]
   public class SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_RESTInterface : GxGenericCollectionItem<SdtPanelTecnico_Level_Detail_Grid1Sdt_Item>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_RESTInterface( ) : base()
      {
      }

      public SdtPanelTecnico_Level_Detail_Grid1Sdt_Item_RESTInterface( SdtPanelTecnico_Level_Detail_Grid1Sdt_Item psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TicketId" , Order = 0 )]
      public string gxTpr_Ticketid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ticketid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Ticketid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "TicketResponsableId" , Order = 1 )]
      public string gxTpr_Ticketresponsableid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Ticketresponsableid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Ticketresponsableid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "UsuarioId" , Order = 2 )]
      public Nullable<short> gxTpr_Usuarioid
      {
         get {
            return sdt.gxTpr_Usuarioid ;
         }

         set {
            sdt.gxTpr_Usuarioid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuarioNombre" , Order = 3 )]
      public string gxTpr_Usuarionombre
      {
         get {
            return sdt.gxTpr_Usuarionombre ;
         }

         set {
            sdt.gxTpr_Usuarionombre = value;
         }

      }

      [DataMember( Name = "UsuarioFecha" , Order = 4 )]
      public string gxTpr_Usuariofecha
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usuariofecha) ;
         }

         set {
            sdt.gxTpr_Usuariofecha = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "UsuarioHora" , Order = 5 )]
      public string gxTpr_Usuariohora
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Usuariohora) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Usuariohora = GXt_dtime1;
         }

      }

      [DataMember( Name = "UsuarioDepartamento" , Order = 6 )]
      public string gxTpr_Usuariodepartamento
      {
         get {
            return sdt.gxTpr_Usuariodepartamento ;
         }

         set {
            sdt.gxTpr_Usuariodepartamento = value;
         }

      }

      [DataMember( Name = "TicketTecnicoResponsableNombre" , Order = 7 )]
      public string gxTpr_Tickettecnicoresponsablenombre
      {
         get {
            return sdt.gxTpr_Tickettecnicoresponsablenombre ;
         }

         set {
            sdt.gxTpr_Tickettecnicoresponsablenombre = value;
         }

      }

      [DataMember( Name = "EstadoTicketTicketNombre" , Order = 8 )]
      public string gxTpr_Estadoticketticketnombre
      {
         get {
            return sdt.gxTpr_Estadoticketticketnombre ;
         }

         set {
            sdt.gxTpr_Estadoticketticketnombre = value;
         }

      }

      [DataMember( Name = "TicketResponsableFechaResuelve" , Order = 9 )]
      public string gxTpr_Ticketresponsablefecharesuelve
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Ticketresponsablefecharesuelve) ;
         }

         set {
            sdt.gxTpr_Ticketresponsablefecharesuelve = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TicketResponsableHoraResuelve" , Order = 10 )]
      public string gxTpr_Ticketresponsablehoraresuelve
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Ticketresponsablehoraresuelve) ;
         }

         set {
            GXt_dtime1 = DateTimeUtil.ResetDate(DateTimeUtil.CToT2( value));
            sdt.gxTpr_Ticketresponsablehoraresuelve = GXt_dtime1;
         }

      }

      [DataMember( Name = "EstadoTicketTecnicoNombre" , Order = 11 )]
      public string gxTpr_Estadotickettecniconombre
      {
         get {
            return sdt.gxTpr_Estadotickettecniconombre ;
         }

         set {
            sdt.gxTpr_Estadotickettecniconombre = value;
         }

      }

      [DataMember( Name = "TicketTecnicoResponsableId" , Order = 12 )]
      public Nullable<short> gxTpr_Tickettecnicoresponsableid
      {
         get {
            return sdt.gxTpr_Tickettecnicoresponsableid ;
         }

         set {
            sdt.gxTpr_Tickettecnicoresponsableid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EstadoTicketTecnicoId" , Order = 13 )]
      public Nullable<short> gxTpr_Estadotickettecnicoid
      {
         get {
            return sdt.gxTpr_Estadotickettecnicoid ;
         }

         set {
            sdt.gxTpr_Estadotickettecnicoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtPanelTecnico_Level_Detail_Grid1Sdt_Item sdt
      {
         get {
            return (SdtPanelTecnico_Level_Detail_Grid1Sdt_Item)Sdt ;
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
            sdt = new SdtPanelTecnico_Level_Detail_Grid1Sdt_Item() ;
         }
      }

      protected DateTime GXt_dtime1 ;
   }

}
