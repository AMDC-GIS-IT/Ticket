/*
				   File: type_SdtDashboardViewerFiltersChangedData_ChangedFilter
			Description: ChangedFilters
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
	[XmlRoot(ElementName="DashboardViewerFiltersChangedData.ChangedFilter")]
	[XmlType(TypeName="DashboardViewerFiltersChangedData.ChangedFilter" , Namespace="kb_ticket" )]
	[Serializable]
	public class SdtDashboardViewerFiltersChangedData_ChangedFilter : GxUserType
	{
		public SdtDashboardViewerFiltersChangedData_ChangedFilter( )
		{
			/* Constructor for serialization */
			gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Name = "";

		}

		public SdtDashboardViewerFiltersChangedData_ChangedFilter(IGxContext context)
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
			AddObjectProperty("Enabled", gxTpr_Enabled, false);


			AddObjectProperty("Name", gxTpr_Name, false);

			if (gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values != null)
			{
				AddObjectProperty("Values", gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Enabled")]
		[XmlElement(ElementName="Enabled")]
		public bool gxTpr_Enabled
		{
			get {
				return gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Enabled; 
			}
			set {
				gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Enabled = value;
				SetDirty("Enabled");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Name; 
			}
			set {
				gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Values" )]
		[XmlArray(ElementName="Values"  )]
		[XmlArrayItemAttribute(ElementName="Value" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Values_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values == null )
				{
					gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values;
			}
			set {
				gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values_N = false;
				gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Values
		{
			get {
				if ( gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values == null )
				{
					gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values = new GxSimpleCollection<string>();
				}
				gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values_N = false;
				return gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values ;
			}
			set {
				gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values_N = false;
				gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values = value;
				SetDirty("Values");
			}
		}

		public void gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values_SetNull()
		{
			gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values_N = true;
			gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values = null;
		}

		public bool gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values_IsNull()
		{
			return gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values == null;
		}
		public bool ShouldSerializegxTpr_Values_GxSimpleCollection_Json()
		{
			return gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values != null && gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Name = "";

			gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Enabled;
		 

		protected string gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Name;
		 
		protected bool gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values_N;
		protected GxSimpleCollection<string> gxTv_SdtDashboardViewerFiltersChangedData_ChangedFilter_Values = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"DashboardViewerFiltersChangedData.ChangedFilter", Namespace="kb_ticket")]
	public class SdtDashboardViewerFiltersChangedData_ChangedFilter_RESTInterface : GxGenericCollectionItem<SdtDashboardViewerFiltersChangedData_ChangedFilter>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDashboardViewerFiltersChangedData_ChangedFilter_RESTInterface( ) : base()
		{	
		}

		public SdtDashboardViewerFiltersChangedData_ChangedFilter_RESTInterface( SdtDashboardViewerFiltersChangedData_ChangedFilter psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Enabled", Order=0)]
		public bool gxTpr_Enabled
		{
			get { 
				return sdt.gxTpr_Enabled;

			}
			set { 
				sdt.gxTpr_Enabled = value;
			}
		}

		[DataMember(Name="Name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Values", Order=2, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Values
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Values_GxSimpleCollection_Json())
					return sdt.gxTpr_Values;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Values = value ;
			}
		}


		#endregion

		public SdtDashboardViewerFiltersChangedData_ChangedFilter sdt
		{
			get { 
				return (SdtDashboardViewerFiltersChangedData_ChangedFilter)Sdt;
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
				sdt = new SdtDashboardViewerFiltersChangedData_ChangedFilter() ;
			}
		}
	}
	#endregion
}