/*
				   File: type_SdtQueryViewerElements_Element_AxisOrder
			Description: AxisOrder
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
	[XmlRoot(ElementName="QueryViewerElements.Element.AxisOrder")]
	[XmlType(TypeName="QueryViewerElements.Element.AxisOrder" , Namespace="kb_ticket" )]
	[Serializable]
	public class SdtQueryViewerElements_Element_AxisOrder : GxUserType
	{
		public SdtQueryViewerElements_Element_AxisOrder( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerElements_Element_AxisOrder_Type = "";

		}

		public SdtQueryViewerElements_Element_AxisOrder(IGxContext context)
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
			AddObjectProperty("Type", gxTpr_Type, false);

			if (gxTv_SdtQueryViewerElements_Element_AxisOrder_Values != null)
			{
				AddObjectProperty("Values", gxTv_SdtQueryViewerElements_Element_AxisOrder_Values, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtQueryViewerElements_Element_AxisOrder_Type; 
			}
			set {
				gxTv_SdtQueryViewerElements_Element_AxisOrder_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Values" )]
		[XmlArray(ElementName="Values"  )]
		[XmlArrayItemAttribute(ElementName="Value" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Values_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_AxisOrder_Values == null )
				{
					gxTv_SdtQueryViewerElements_Element_AxisOrder_Values = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtQueryViewerElements_Element_AxisOrder_Values;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_AxisOrder_Values_N = false;
				gxTv_SdtQueryViewerElements_Element_AxisOrder_Values = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Values
		{
			get {
				if ( gxTv_SdtQueryViewerElements_Element_AxisOrder_Values == null )
				{
					gxTv_SdtQueryViewerElements_Element_AxisOrder_Values = new GxSimpleCollection<string>();
				}
				gxTv_SdtQueryViewerElements_Element_AxisOrder_Values_N = false;
				return gxTv_SdtQueryViewerElements_Element_AxisOrder_Values ;
			}
			set {
				gxTv_SdtQueryViewerElements_Element_AxisOrder_Values_N = false;
				gxTv_SdtQueryViewerElements_Element_AxisOrder_Values = value;
				SetDirty("Values");
			}
		}

		public void gxTv_SdtQueryViewerElements_Element_AxisOrder_Values_SetNull()
		{
			gxTv_SdtQueryViewerElements_Element_AxisOrder_Values_N = true;
			gxTv_SdtQueryViewerElements_Element_AxisOrder_Values = null;
		}

		public bool gxTv_SdtQueryViewerElements_Element_AxisOrder_Values_IsNull()
		{
			return gxTv_SdtQueryViewerElements_Element_AxisOrder_Values == null;
		}
		public bool ShouldSerializegxTpr_Values_GxSimpleCollection_Json()
		{
			return gxTv_SdtQueryViewerElements_Element_AxisOrder_Values != null && gxTv_SdtQueryViewerElements_Element_AxisOrder_Values.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerElements_Element_AxisOrder_Type = "";

			gxTv_SdtQueryViewerElements_Element_AxisOrder_Values_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerElements_Element_AxisOrder_Type;
		 
		protected bool gxTv_SdtQueryViewerElements_Element_AxisOrder_Values_N;
		protected GxSimpleCollection<string> gxTv_SdtQueryViewerElements_Element_AxisOrder_Values = null;  


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"QueryViewerElements.Element.AxisOrder", Namespace="kb_ticket")]
	public class SdtQueryViewerElements_Element_AxisOrder_RESTInterface : GxGenericCollectionItem<SdtQueryViewerElements_Element_AxisOrder>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerElements_Element_AxisOrder_RESTInterface( ) : base()
		{	
		}

		public SdtQueryViewerElements_Element_AxisOrder_RESTInterface( SdtQueryViewerElements_Element_AxisOrder psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Type", Order=0)]
		public  string gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
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

		public SdtQueryViewerElements_Element_AxisOrder sdt
		{
			get { 
				return (SdtQueryViewerElements_Element_AxisOrder)Sdt;
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
				sdt = new SdtQueryViewerElements_Element_AxisOrder() ;
			}
		}
	}
	#endregion
}