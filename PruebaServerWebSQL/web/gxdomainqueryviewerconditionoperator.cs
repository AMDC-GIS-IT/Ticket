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
   public class gxdomainqueryviewerconditionoperator
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainqueryviewerconditionoperator ()
      {
         domain["EQ"] = "Equal";
         domain["LT"] = "Less Than";
         domain["GT"] = "Greater Than";
         domain["LE"] = "Less Or Equal";
         domain["GE"] = "Greater Or Equal";
         domain["NE"] = "Not Equal";
         domain["IN"] = "Interval";
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
            domainMap["Equal"] = "EQ";
            domainMap["LessThan"] = "LT";
            domainMap["GreaterThan"] = "GT";
            domainMap["LessOrEqual"] = "LE";
            domainMap["GreaterOrEqual"] = "GE";
            domainMap["NotEqual"] = "NE";
            domainMap["Interval"] = "IN";
         }
         return (string)domainMap[key] ;
      }

   }

}
