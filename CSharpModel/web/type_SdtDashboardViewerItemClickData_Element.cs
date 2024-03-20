/*
				   File: type_SdtDashboardViewerItemClickData_Element
			Description: Context
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
	[XmlRoot(ElementName="DashboardViewerItemClickData.Element")]
	[XmlType(TypeName="DashboardViewerItemClickData.Element" , Namespace="kb_ticket" )]
	[Serializable]
	public class SdtDashboardViewerItemClickData_Element : GxUserType
	{
		public SdtDashboardViewerItemClickData_Element( )
		{
			/* Constructor for serialization */
			gxTv_SdtDashboardViewerItemClickData_Element_Name = "";

		}

		public SdtDashboardViewerItemClickData_Element(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);

			if (gxTv_SdtDashboardViewerItemClickData_Element_Values != null)
			{
				AddObjectProperty("Values", gxTv_SdtDashboardViewerItemClickData_Element_Values, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtDashboardViewerItemClickData_Element_Name; 
			}
			set {
				gxTv_SdtDashboardViewerItemClickData_Element_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Values" )]
		[XmlArray(ElementName="Values"  )]
		[XmlArrayItemAttribute(ElementName="Value" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Values_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtDashboardViewerItemClickData_Element_Values == null )
				{
					gxTv_SdtDashboardViewerItemClickData_Element_Values = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtDashboardViewerItemClickData_Element_Values;
			}
			set {
				gxTv_SdtDashboardViewerItemClickData_Element_Values_N = false;
				gxTv_SdtDashboardViewerItemClickData_Element_Values = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Values
		{
			get {
				if ( gxTv_SdtDashboardViewerItemClickData_Element_Values == null )
				{
					gxTv_SdtDashboardViewerItemClickData_Element_Values = new GxSimpleCollection<string>();
				}
				gxTv_SdtDashboardViewerItemClickData_Element_Values_N = false;
				return gxTv_SdtDashboardViewerItemClickData_Element_Values ;
			}
			set {
				gxTv_SdtDashboardViewerItemClickData_Element_Values_N = false;
				gxTv_SdtDashboardViewerItemClickData_Element_Values = value;
				SetDirty("Values");
			}
		}

		public void gxTv_SdtDashboardViewerItemClickData_Element_Values_SetNull()
		{
			gxTv_SdtDashboardViewerItemClickData_Element_Values_N = true;
			gxTv_SdtDashboardViewerItemClickData_Element_Values = null;
		}

		public bool gxTv_SdtDashboardViewerItemClickData_Element_Values_IsNull()
		{
			return gxTv_SdtDashboardViewerItemClickData_Element_Values == null;
		}
		public bool ShouldSerializegxTpr_Values_GxSimpleCollection_Json()
		{
			return gxTv_SdtDashboardViewerItemClickData_Element_Values != null && gxTv_SdtDashboardViewerItemClickData_Element_Values.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDashboardViewerItemClickData_Element_Name = "";

			gxTv_SdtDashboardViewerItemClickData_Element_Values_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtDashboardViewerItemClickData_Element_Name;
		 
		protected bool gxTv_SdtDashboardViewerItemClickData_Element_Values_N;
		protected GxSimpleCollection<string> gxTv_SdtDashboardViewerItemClickData_Element_Values = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"DashboardViewerItemClickData.Element", Namespace="kb_ticket")]
	public class SdtDashboardViewerItemClickData_Element_RESTInterface : GxGenericCollectionItem<SdtDashboardViewerItemClickData_Element>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDashboardViewerItemClickData_Element_RESTInterface( ) : base()
		{	
		}

		public SdtDashboardViewerItemClickData_Element_RESTInterface( SdtDashboardViewerItemClickData_Element psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Values", Order=1, EmitDefaultValue=false)]
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

		public SdtDashboardViewerItemClickData_Element sdt
		{
			get { 
				return (SdtDashboardViewerItemClickData_Element)Sdt;
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
				sdt = new SdtDashboardViewerItemClickData_Element() ;
			}
		}
	}
	#endregion
}