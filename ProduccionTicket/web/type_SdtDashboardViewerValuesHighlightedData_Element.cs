/*
				   File: type_SdtDashboardViewerValuesHighlightedData_Element
			Description: Elements
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
	[XmlRoot(ElementName="DashboardViewerValuesHighlightedData.Element")]
	[XmlType(TypeName="DashboardViewerValuesHighlightedData.Element" , Namespace="kb_ticket" )]
	[Serializable]
	public class SdtDashboardViewerValuesHighlightedData_Element : GxUserType
	{
		public SdtDashboardViewerValuesHighlightedData_Element( )
		{
			/* Constructor for serialization */
			gxTv_SdtDashboardViewerValuesHighlightedData_Element_Name = "";

			gxTv_SdtDashboardViewerValuesHighlightedData_Element_Value = "";

		}

		public SdtDashboardViewerValuesHighlightedData_Element(IGxContext context)
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


			AddObjectProperty("Value", gxTpr_Value, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtDashboardViewerValuesHighlightedData_Element_Name; 
			}
			set {
				gxTv_SdtDashboardViewerValuesHighlightedData_Element_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Value")]
		[XmlElement(ElementName="Value")]
		public string gxTpr_Value
		{
			get {
				return gxTv_SdtDashboardViewerValuesHighlightedData_Element_Value; 
			}
			set {
				gxTv_SdtDashboardViewerValuesHighlightedData_Element_Value = value;
				SetDirty("Value");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtDashboardViewerValuesHighlightedData_Element_Name = "";
			gxTv_SdtDashboardViewerValuesHighlightedData_Element_Value = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtDashboardViewerValuesHighlightedData_Element_Name;
		 

		protected string gxTv_SdtDashboardViewerValuesHighlightedData_Element_Value;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"DashboardViewerValuesHighlightedData.Element", Namespace="kb_ticket")]
	public class SdtDashboardViewerValuesHighlightedData_Element_RESTInterface : GxGenericCollectionItem<SdtDashboardViewerValuesHighlightedData_Element>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtDashboardViewerValuesHighlightedData_Element_RESTInterface( ) : base()
		{	
		}

		public SdtDashboardViewerValuesHighlightedData_Element_RESTInterface( SdtDashboardViewerValuesHighlightedData_Element psdt ) : base(psdt)
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

		[DataMember(Name="Value", Order=1)]
		public  string gxTpr_Value
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value);

			}
			set { 
				 sdt.gxTpr_Value = value;
			}
		}


		#endregion

		public SdtDashboardViewerValuesHighlightedData_Element sdt
		{
			get { 
				return (SdtDashboardViewerValuesHighlightedData_Element)Sdt;
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
				sdt = new SdtDashboardViewerValuesHighlightedData_Element() ;
			}
		}
	}
	#endregion
}