/*
				   File: type_SdtDashboardViewerItemClickData
			Description: DashboardViewerItemClickData
				 Author: Nemo 🐠 for C# version 17.0.9.159740
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="DashboardViewerItemClickData")]
	[XmlType(TypeName="DashboardViewerItemClickData" , Namespace="kb_ticket" )]
	[Serializable]
	public class SdtDashboardViewerItemClickData : GxUserType
	{
		public SdtDashboardViewerItemClickData( )
		{
			/* Constructor for serialization */
			gxTv_SdtDashboardViewerItemClickData_Object = "";

			gxTv_SdtDashboardViewerItemClickData_Element = "";

			gxTv_SdtDashboardViewerItemClickData_Value = "";

		}

		public SdtDashboardViewerItemClickData(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("Object", gxTpr_Object, false);


			AddObjectProperty("Element", gxTpr_Element, false);


			AddObjectProperty("Value", gxTpr_Value, false);

			if (gxTv_SdtDashboardViewerItemClickData_Context != null)
			{
				AddObjectProperty("Context", gxTv_SdtDashboardViewerItemClickData_Context, false);
			}
			if (gxTv_SdtDashboardViewerItemClickData_Allfilters != null)
			{
				AddObjectProperty("AllFilters", gxTv_SdtDashboardViewerItemClickData_Allfilters, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Object")]
		[XmlElement(ElementName="Object")]
		public string gxTpr_Object
		{
			get {
				return gxTv_SdtDashboardViewerItemClickData_Object; 
			}
			set {
				gxTv_SdtDashboardViewerItemClickData_Object = value;
				SetDirty("Object");
			}
		}




		[SoapElement(ElementName="Element")]
		[XmlElement(ElementName="Element")]
		public string gxTpr_Element
		{
			get {
				return gxTv_SdtDashboardViewerItemClickData_Element; 
			}
			set {
				gxTv_SdtDashboardViewerItemClickData_Element = value;
				SetDirty("Element");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtDashboardViewerItemClickData_Value; 
			}
			set {
				gxTv_SdtDashboardViewerItemClickData_Value = value;
				SetDirty("Value");
			}
		}




		[SoapElement(ElementName="Context" )]
		[XmlArray(ElementName="Context"  )]
		[XmlArrayItemAttribute(ElementName="Element" , IsNullable=false )]
		public GXBaseCollection<SdtDashboardViewerItemClickData_Element> gxTpr_Context
		{
			get {
				if ( gxTv_SdtDashboardViewerItemClickData_Context == null )
				{
					gxTv_SdtDashboardViewerItemClickData_Context = new GXBaseCollection<SdtDashboardViewerItemClickData_Element>( context, "DashboardViewerItemClickData.Element", "");
				}
				return gxTv_SdtDashboardViewerItemClickData_Context;
			}
			set {
				gxTv_SdtDashboardViewerItemClickData_Context_N = false;
				gxTv_SdtDashboardViewerItemClickData_Context = value;
				SetDirty("Context");
			}
		}

		public void gxTv_SdtDashboardViewerItemClickData_Context_SetNull()
		{
			gxTv_SdtDashboardViewerItemClickData_Context_N = true;
			gxTv_SdtDashboardViewerItemClickData_Context = null;
		}

		public bool gxTv_SdtDashboardViewerItemClickData_Context_IsNull()
		{
			return gxTv_SdtDashboardViewerItemClickData_Context == null;
		}
		public bool ShouldSerializegxTpr_Context_GxSimpleCollection_Json()
		{
			return gxTv_SdtDashboardViewerItemClickData_Context != null && gxTv_SdtDashboardViewerItemClickData_Context.Count > 0;

		}



		[SoapElement(ElementName="AllFilters" )]
		[XmlArray(ElementName="AllFilters"  )]
		[XmlArrayItemAttribute(ElementName="Filter" , IsNullable=false )]
		public GXBaseCollection<SdtDashboardViewerItemClickData_Filter> gxTpr_Allfilters
		{
			get {
				if ( gxTv_SdtDashboardViewerItemClickData_Allfilters == null )
				{
					gxTv_SdtDashboardViewerItemClickData_Allfilters = new GXBaseCollection<SdtDashboardViewerItemClickData_Filter>( context, "DashboardViewerItemClickData.Filter", "");
				}
				return gxTv_SdtDashboardViewerItemClickData_Allfilters;
			}
			set {
				gxTv_SdtDashboardViewerItemClickData_Allfilters_N = false;
				gxTv_SdtDashboardViewerItemClickData_Allfilters = value;
				SetDirty("Allfilters");
			}
		}

		public void gxTv_SdtDashboardViewerItemClickData_Allfilters_SetNull()
		{
			gxTv_SdtDashboardViewerItemClickData_Allfilters_N = true;
			gxTv_SdtDashboardViewerItemClickData_Allfilters = null;
		}

		public bool gxTv_SdtDashboardViewerItemClickData_Allfilters_IsNull()
		{
			return gxTv_SdtDashboardViewerItemClickData_Allfilters == null;
		}
		public bool ShouldSerializegxTpr_Allfilters_GxSimpleCollection_Json()
		{
			return gxTv_SdtDashboardViewerItemClickData_Allfilters != null && gxTv_SdtDashboardViewerItemClickData_Allfilters.Count > 0;

		}


		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDashboardViewerItemClickData_Object = "";
			gxTv_SdtDashboardViewerItemClickData_Element = "";
			gxTv_SdtDashboardViewerItemClickData_Value = "";

			gxTv_SdtDashboardViewerItemClickData_Context_N = true;


			gxTv_SdtDashboardViewerItemClickData_Allfilters_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtDashboardViewerItemClickData_Object;
		 

		protected string gxTv_SdtDashboardViewerItemClickData_Element;
		 

		protected string gxTv_SdtDashboardViewerItemClickData_Value;
		 
		protected bool gxTv_SdtDashboardViewerItemClickData_Context_N;
		protected GXBaseCollection<SdtDashboardViewerItemClickData_Element> gxTv_SdtDashboardViewerItemClickData_Context = null; 

		protected bool gxTv_SdtDashboardViewerItemClickData_Allfilters_N;
		protected GXBaseCollection<SdtDashboardViewerItemClickData_Filter> gxTv_SdtDashboardViewerItemClickData_Allfilters = null; 



		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"DashboardViewerItemClickData", Namespace="kb_ticket")]
	public class SdtDashboardViewerItemClickData_RESTInterface : GxGenericCollectionItem<SdtDashboardViewerItemClickData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDashboardViewerItemClickData_RESTInterface( ) : base()
		{	
		}

		public SdtDashboardViewerItemClickData_RESTInterface( SdtDashboardViewerItemClickData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Object", Order=0)]
		public  string gxTpr_Object
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Object);

			}
			set { 
				 sdt.gxTpr_Object = value;
			}
		}

		[DataMember(Name="Element", Order=1)]
		public  string gxTpr_Element
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Element);

			}
			set { 
				 sdt.gxTpr_Element = value;
			}
		}

		[DataMember(Name="Value", Order=2)]
		public  string gxTpr_Value
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value);

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}

		[DataMember(Name="Context", Order=3, EmitDefaultValue=false)]
		public GxGenericCollection<SdtDashboardViewerItemClickData_Element_RESTInterface> gxTpr_Context
		{
			get {
				if (sdt.ShouldSerializegxTpr_Context_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtDashboardViewerItemClickData_Element_RESTInterface>(sdt.gxTpr_Context);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Context);
			}
		}

		[DataMember(Name="AllFilters", Order=4, EmitDefaultValue=false)]
		public GxGenericCollection<SdtDashboardViewerItemClickData_Filter_RESTInterface> gxTpr_Allfilters
		{
			get {
				if (sdt.ShouldSerializegxTpr_Allfilters_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtDashboardViewerItemClickData_Filter_RESTInterface>(sdt.gxTpr_Allfilters);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Allfilters);
			}
		}


		#endregion

		public SdtDashboardViewerItemClickData sdt
		{
			get { 
				return (SdtDashboardViewerItemClickData)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtDashboardViewerItemClickData() ;
			}
		}
	}
	#endregion
}