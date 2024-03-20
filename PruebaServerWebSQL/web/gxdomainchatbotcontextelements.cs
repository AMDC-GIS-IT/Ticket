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
   public class gxdomainchatbotcontextelements
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainchatbotcontextelements ()
      {
         domain["GXSerializedContext"] = "GXSerialized Context";
         domain["context"] = "context";
         domain["GXAction"] = "GXAction";
         domain["GXClean"] = "GXClean";
         domain["GXComponentWeb"] = "GXComponent Web";
         domain["GXComponentSD"] = "GXComponent SD";
         domain["GXCallPanelSD"] = "GXCall Panel SD";
         domain["GXImage"] = "GXImage";
         domain["GXResponseImage"] = "GXResponse Image";
         domain["NoAction"] = "GXNo Action";
         domain["True"] = "GXTrue";
         domain["{}"] = "GXEmpty Context";
         domain["ChatbotMessage"] = "GXChatbot Message";
         domain["GXSessionId"] = "GXSession Id";
         domain["GXOutput"] = "GXOutput";
         domain["GXOutputCollection"] = "GXOutput Collection";
         domain["Context"] = "ContextUp";
         domain["GXSetImageResponse"] = "GXSet Image Response";
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
            domainMap["GXSerializedContext"] = "GXSerializedContext";
            domainMap["GXContext"] = "context";
            domainMap["GXAction"] = "GXAction";
            domainMap["GXClean"] = "GXClean";
            domainMap["GXComponentWeb"] = "GXComponentWeb";
            domainMap["GXComponentSD"] = "GXComponentSD";
            domainMap["GXCallPanelSD"] = "GXCallPanelSD";
            domainMap["GXImage"] = "GXImage";
            domainMap["GXResponseImage"] = "GXResponseImage";
            domainMap["GXNoAction"] = "NoAction";
            domainMap["GXTrue"] = "True";
            domainMap["GXEmptyContext"] = "{}";
            domainMap["GXChatbotMessage"] = "ChatbotMessage";
            domainMap["GXSessionId"] = "GXSessionId";
            domainMap["GXOutput"] = "GXOutput";
            domainMap["GXOutputCollection"] = "GXOutputCollection";
            domainMap["Context"] = "Context";
            domainMap["GXSetImageResponse"] = "GXSetImageResponse";
         }
         return (string)domainMap[key] ;
      }

   }

}
