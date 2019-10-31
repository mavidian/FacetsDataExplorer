//XmlNodeData.cs
//
// Copyright © 2018-2019 Mavidian Technologies Limited Liability Company. All Rights Reserved.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FacetsDataExplorer
{
   /// <summary>
   /// Recursive class representing a node in XML, such as FacetsData.
   /// </summary>
   internal class XmlNodeData
   {
      //TODO: remove redundant elements in this class
      internal readonly int Level;
      internal readonly int SeqNo;
      internal readonly XElement Element;
      internal readonly string Name;
      internal readonly List<XAttribute> Attributes;
      /// <summary>
      /// Node name combined with the value of attribute named name (if present).
      /// </summary>
      internal string FullName
      {
         get
         {
            var nameAttrValue = Attributes.FirstOrDefault(a => a.Name == "name")?.Value;
            return nameAttrValue == null ? Name : Name + " - " + nameAttrValue;
         }
      }
      internal readonly string Value;
      internal readonly List<XmlNodeData> Children;
      private bool _hasChildren {  get { return Children.Any();  } }

      /// <summary>
      /// Extrernally accessible ctor accepts XML string data.
      /// </summary>
      /// <param name="data">XML string</param>
      /// <exception cref="System.Xml.XmlException">Throw if invalid xml data passed, e.g. "Root element is missing".</exception>
      internal XmlNodeData(string data) : this(XElement.Parse(data), 0, 0) { }

      /// <summary>
      /// Recursive ctor accepts element node and is intended for private/internal use.
      /// </summary>
      /// <param name="element"></param>
      /// <param name="level">0=root, ...</param>
      /// <param name="seqNo">0-based number in level</param>
      internal XmlNodeData(XElement element, int level, int seqNo)
      {
         Level = level;
         SeqNo = seqNo;
         Element = element;
         Name = element.Name.LocalName;
         Attributes = element.Attributes().ToList();
         Value = element.Value;
         Children = new List<XmlNodeData>();
         var childSeqNo = 0;
         foreach (var child in element.Elements())
         {
            Children.Add(new XmlNodeData(child, level + 1, childSeqNo++));
         }
      }

      /// <summary>
      /// "Pretty-print" friendly represenation of the node and its children.
      /// </summary>
      /// <returns></returns>
      internal new string ToString()
      {
         var indent = new string(' ', Level * 2);
         var retVal = new StringBuilder(indent + "<" + Name); //StartElement
         foreach (var attr in Attributes)
         {
            retVal.Append(" " + attr.Name.LocalName + "=\"" + attr.Value + "\"");
         }
         retVal.Append(">");
         if (_hasChildren)
         {
            retVal.Append("\r\n");
            foreach (var child in Children) retVal.Append(child.ToString());
            retVal.Append(indent);
         }
         else //leaf element
         {  //note that since value is only displayed for leaf elements, text contained in "mixed elements" gets ignored
            retVal.Append(Value);
         }
         retVal.Append("</" + Name + ">\r\n");  //EndElement
         return retVal.ToString();
      }
   }
}
