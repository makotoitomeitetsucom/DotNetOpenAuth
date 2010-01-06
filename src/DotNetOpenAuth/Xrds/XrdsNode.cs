//-----------------------------------------------------------------------
// <copyright file="XrdsNode.cs" company="Andrew Arnott, Scott Hanselman">
//     Copyright (c) Andrew Arnott, Scott Hanselman. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOpenAuth.Xrds {
	using System;
	using System.Diagnostics.Contracts;
	using System.Xml;
	using System.Xml.XPath;
	using DotNetOpenAuth.Messaging;

	/// <summary>
	/// A node in an XRDS document.
	/// </summary>
	internal class XrdsNode {
		/// <summary>
		/// The XRD namespace xri://$xrd*($v*2.0)
		/// </summary>
		internal const string XrdNamespace = "xri://$xrd*($v*2.0)";

		/// <summary>
		/// The XRDS namespace xri://$xrds
		/// </summary>
		internal const string XrdsNamespace = "xri://$xrds";

		/// <summary>
		/// Initializes a new instance of the <see cref="XrdsNode"/> class.
		/// </summary>
		/// <param name="node">The node represented by this instance.</param>
		/// <param name="parentNode">The parent node.</param>
		protected XrdsNode(XPathNavigator node, XrdsNode parentNode) {
			Contract.Requires<ArgumentNullException>(node != null);
			Contract.Requires<ArgumentNullException>(parentNode != null);

			this.Node = node;
			this.ParentNode = parentNode;
			this.XmlNamespaceResolver = this.ParentNode.XmlNamespaceResolver;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="XrdsNode"/> class.
		/// </summary>
		/// <param name="document">The document's root node, which this instance represents.</param>
		protected XrdsNode(XPathNavigator document) {
			Contract.Requires<ArgumentNullException>(document != null);
			Contract.Requires<ArgumentException>(document.NameTable != null);

			this.Node = document;
			this.XmlNamespaceResolver = new XmlNamespaceManager(document.NameTable);
		}

		/// <summary>
		/// Gets the node.
		/// </summary>
		internal XPathNavigator Node { get; private set; }

		/// <summary>
		/// Gets the parent node, or null if this is the root node.
		/// </summary>
		protected internal XrdsNode ParentNode { get; private set; }

		/// <summary>
		/// Gets the XML namespace resolver to use in XPath expressions.
		/// </summary>
		protected internal XmlNamespaceManager XmlNamespaceResolver { get; private set; }
	}
}
