using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomainhorazone
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainhorazone ()
      {
         domain["Africa/Cairo"] = "Africa/Cairo";
         domain["Africa/Johannesburg"] = "Africa/Johannesburg";
         domain["Africa/Lagos"] = "Africa/Lagos";
         domain["America/Anchorage"] = "America/Anchorage";
         domain["America/Argentina/Buenos_Aires"] = "America/Argentina/Buenos_Aires";
         domain["America/Asuncion"] = "America/Asuncion";
         domain["America/Bogota"] = "America/Bogota";
         domain["America/Caracas"] = "America/Caracas";
         domain["America/Chicago"] = "America/Chicago";
         domain["America/Denver"] = "America/Denver";
         domain["America/Godthab"] = "America/Godthab";
         domain["America/Guatemala"] = "America/Guatemala";
         domain["America/Halifax"] = "America/Halifax";
         domain["America/Los_Angeles"] = "America/Los_Angeles";
         domain["America/Mexico_City"] = "America/Mexico_City";
         domain["America/Montevideo"] = "America/Montevideo";
         domain["America/New_York"] = "America/New_York";
         domain["America/Noronha"] = "America/Noronha";
         domain["America/Phoenix"] = "America/Phoenix";
         domain["America/Santiago"] = "America/Santiago";
         domain["America/Santo_Domingo"] = "America/Santo_Domingo";
         domain["America/Sao_Paulo"] = "America/Sao_Paulo";
         domain["America/St_Johns"] = "America/St_Johns";
         domain["Asia/Baghdad"] = "Asia/Baghdad";
         domain["Asia/Beirut"] = "Asia/Beirut";
         domain["Asia/Damascus"] = "Asia/Damascus";
         domain["Asia/Dhaka"] = "Asia/Dhaka";
         domain["Asia/Dubai"] = "Asia/Dubai";
         domain["Asia/Jerusalem"] = "Asia/Jerusalem";
         domain["Asia/Kabul"] = "Asia/Kabul";
         domain["Asia/Karachi"] = "Asia/Karachi";
         domain["Asia/Katmandu"] = "Asia/Katmandu";
         domain["Asia/Kolkata"] = "Asia/Kolkata";
         domain["Asia/Rangoon"] = "Asia/Rangoon";
         domain["Asia/Shanghai"] = "Asia/Shanghai";
         domain["Asia/Tehran"] = "Asia/Tehran";
         domain["Asia/Tokyo"] = "Asia/Tokyo";
         domain["Asia/Yerevan"] = "Asia/Yerevan";
         domain["Atlantic/Azores"] = "Atlantic/Azores";
         domain["Atlantic/Cape_Verde"] = "Atlantic/Cape_Verde";
         domain["Australia/Adelaide"] = "Australia/Adelaide";
         domain["Australia/Brisbane"] = "Australia/Brisbane";
         domain["Australia/Darwin"] = "Australia/Darwin";
         domain["Australia/Sydney"] = "Australia/Sydney";
         domain["Etc/GMT_12"] = "Etc/GMT_12";
         domain["Etc/GMT_2"] = "Etc/GMT_2";
         domain["Etc/UTC"] = "Etc/UTC";
         domain["Europe/Berlin"] = "Europe/Berlin";
         domain["Europe/Helsinki"] = "Europe/Helsinki";
         domain["Europe/Istanbul"] = "Europe/Istanbul";
         domain["Europe/London"] = "Europe/London";
         domain["Pacific/Auckland"] = "Pacific/Auckland";
         domain["Pacific/Honolulu"] = "Pacific/Honolulu";
         domain["Pacific/Noumea"] = "Pacific/Noumea";
         domain["Pacific/Tongatapu"] = "Pacific/Tongatapu";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Cairo"] = "Africa/Cairo";
            domainMap["Johannesburg"] = "Africa/Johannesburg";
            domainMap["Lagos"] = "Africa/Lagos";
            domainMap["Anchorage"] = "America/Anchorage";
            domainMap["Buenos_Aires"] = "America/Argentina/Buenos_Aires";
            domainMap["Asuncion"] = "America/Asuncion";
            domainMap["Bogota"] = "America/Bogota";
            domainMap["Caracas"] = "America/Caracas";
            domainMap["Chicago"] = "America/Chicago";
            domainMap["Denver"] = "America/Denver";
            domainMap["Godthab"] = "America/Godthab";
            domainMap["Guatemala"] = "America/Guatemala";
            domainMap["Halifax"] = "America/Halifax";
            domainMap["Los_Angeles"] = "America/Los_Angeles";
            domainMap["Mexico_City"] = "America/Mexico_City";
            domainMap["Montevideo"] = "America/Montevideo";
            domainMap["New_York"] = "America/New_York";
            domainMap["Noronha"] = "America/Noronha";
            domainMap["Phoenix"] = "America/Phoenix";
            domainMap["Santiago"] = "America/Santiago";
            domainMap["Santo_Domingo"] = "America/Santo_Domingo";
            domainMap["Sao_Paulo"] = "America/Sao_Paulo";
            domainMap["St_Johns"] = "America/St_Johns";
            domainMap["Baghdad"] = "Asia/Baghdad";
            domainMap["Beirut"] = "Asia/Beirut";
            domainMap["Damascus"] = "Asia/Damascus";
            domainMap["Dhaka"] = "Asia/Dhaka";
            domainMap["Dubai"] = "Asia/Dubai";
            domainMap["Jerusalem"] = "Asia/Jerusalem";
            domainMap["Kabul"] = "Asia/Kabul";
            domainMap["Karachi"] = "Asia/Karachi";
            domainMap["Katmandu"] = "Asia/Katmandu";
            domainMap["Kolkata"] = "Asia/Kolkata";
            domainMap["Rangoon"] = "Asia/Rangoon";
            domainMap["Shanghai"] = "Asia/Shanghai";
            domainMap["Tehran"] = "Asia/Tehran";
            domainMap["Tokyo"] = "Asia/Tokyo";
            domainMap["Yerevan"] = "Asia/Yerevan";
            domainMap["Azores"] = "Atlantic/Azores";
            domainMap["Cape_Verde"] = "Atlantic/Cape_Verde";
            domainMap["Adelaide"] = "Australia/Adelaide";
            domainMap["Brisbane"] = "Australia/Brisbane";
            domainMap["Darwin"] = "Australia/Darwin";
            domainMap["Sydney"] = "Australia/Sydney";
            domainMap["GMT_12"] = "Etc/GMT_12";
            domainMap["GMT_2"] = "Etc/GMT_2";
            domainMap["UTC"] = "Etc/UTC";
            domainMap["Berlin"] = "Europe/Berlin";
            domainMap["Helsinki"] = "Europe/Helsinki";
            domainMap["Istanbul"] = "Europe/Istanbul";
            domainMap["London"] = "Europe/London";
            domainMap["Auckland"] = "Pacific/Auckland";
            domainMap["Honolulu"] = "Pacific/Honolulu";
            domainMap["Noumea"] = "Pacific/Noumea";
            domainMap["Tongatapu"] = "Pacific/Tongatapu";
         }
         return (string)domainMap[key] ;
      }

   }

}
