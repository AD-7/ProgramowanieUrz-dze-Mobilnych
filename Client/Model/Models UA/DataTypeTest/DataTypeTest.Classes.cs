/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using ;

namespace DataTypeTest
{
    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the Menu_Menu Method.
        /// </summary>
        public const uint Menu_Menu = 43;

        /// <summary>
        /// The identifier for the NameNotSet53_Dish Method.
        /// </summary>
        public const uint NameNotSet53_Dish = 48;
    }
    #endregion

    #region Object Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <summary>
        /// The identifier for the Menu_Dishes Object.
        /// </summary>
        public const uint Menu_Dishes = 42;

        /// <summary>
        /// The identifier for the Client Object.
        /// </summary>
        public const uint Client = 49;

        /// <summary>
        /// The identifier for the Address Object.
        /// </summary>
        public const uint Address = 54;

        /// <summary>
        /// The identifier for the Advertisement Object.
        /// </summary>
        public const uint Advertisement = 55;

        /// <summary>
        /// The identifier for the Order Object.
        /// </summary>
        public const uint Order = 59;

        /// <summary>
        /// The identifier for the Order_Dishes Object.
        /// </summary>
        public const uint Order_Dishes = 62;

        /// <summary>
        /// The identifier for the Product Object.
        /// </summary>
        public const uint Product = 66;
    }
    #endregion

    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the Menu ObjectType.
        /// </summary>
        public const uint Menu = 37;

        /// <summary>
        /// The identifier for the NameNotSet53 ObjectType.
        /// </summary>
        public const uint NameNotSet53 = 36;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the Menu_Id Variable.
        /// </summary>
        public const uint Menu_Id = 38;

        /// <summary>
        /// The identifier for the Menu_NameNotSet52 Variable.
        /// </summary>
        public const uint Menu_NameNotSet52 = 39;

        /// <summary>
        /// The identifier for the NameNotSet53_Name Variable.
        /// </summary>
        public const uint NameNotSet53_Name = 45;

        /// <summary>
        /// The identifier for the NameNotSet53_Description Variable.
        /// </summary>
        public const uint NameNotSet53_Description = 46;

        /// <summary>
        /// The identifier for the NameNotSet53_Price Variable.
        /// </summary>
        public const uint NameNotSet53_Price = 47;

        /// <summary>
        /// The identifier for the NameNotSet53_DishId Variable.
        /// </summary>
        public const uint NameNotSet53_DishId = 69;

        /// <summary>
        /// The identifier for the Client_ClientId Variable.
        /// </summary>
        public const uint Client_ClientId = 70;

        /// <summary>
        /// The identifier for the Client_ClientName Variable.
        /// </summary>
        public const uint Client_ClientName = 71;

        /// <summary>
        /// The identifier for the Client_PhoneNumber Variable.
        /// </summary>
        public const uint Client_PhoneNumber = 52;

        /// <summary>
        /// The identifier for the Client_NameNotSet23 Variable.
        /// </summary>
        public const uint Client_NameNotSet23 = 72;

        /// <summary>
        /// The identifier for the Advertisement_Text Variable.
        /// </summary>
        public const uint Advertisement_Text = 56;

        /// <summary>
        /// The identifier for the Advertisement_HourFrom Variable.
        /// </summary>
        public const uint Advertisement_HourFrom = 57;

        /// <summary>
        /// The identifier for the Advertisement_HourTo Variable.
        /// </summary>
        public const uint Advertisement_HourTo = 58;

        /// <summary>
        /// The identifier for the Order_OrderDate Variable.
        /// </summary>
        public const uint Order_OrderDate = 61;

        /// <summary>
        /// The identifier for the Order_TotalPrice Variable.
        /// </summary>
        public const uint Order_TotalPrice = 63;

        /// <summary>
        /// The identifier for the Order_CompleteOrderDate Variable.
        /// </summary>
        public const uint Order_CompleteOrderDate = 64;

        /// <summary>
        /// The identifier for the Order_cLIENT Variable.
        /// </summary>
        public const uint Order_cLIENT = 65;

        /// <summary>
        /// The identifier for the Order_OrderId Variable.
        /// </summary>
        public const uint Order_OrderId = 73;

        /// <summary>
        /// The identifier for the Product_ProductId Variable.
        /// </summary>
        public const uint Product_ProductId = 74;

        /// <summary>
        /// The identifier for the Product_ProductName Variable.
        /// </summary>
        public const uint Product_ProductName = 75;
    }
    #endregion

    #region Method Node Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <summary>
        /// The identifier for the Menu_Menu Method.
        /// </summary>
        public static readonly ExpandedNodeId Menu_Menu = new ExpandedNodeId(DataTypeTest.Methods.Menu_Menu, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the NameNotSet53_Dish Method.
        /// </summary>
        public static readonly ExpandedNodeId NameNotSet53_Dish = new ExpandedNodeId(DataTypeTest.Methods.NameNotSet53_Dish, DataTypeTest.Namespaces.cas);
    }
    #endregion

    #region Object Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <summary>
        /// The identifier for the Menu_Dishes Object.
        /// </summary>
        public static readonly ExpandedNodeId Menu_Dishes = new ExpandedNodeId(DataTypeTest.Objects.Menu_Dishes, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Client Object.
        /// </summary>
        public static readonly ExpandedNodeId Client = new ExpandedNodeId(DataTypeTest.Objects.Client, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Address Object.
        /// </summary>
        public static readonly ExpandedNodeId Address = new ExpandedNodeId(DataTypeTest.Objects.Address, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Advertisement Object.
        /// </summary>
        public static readonly ExpandedNodeId Advertisement = new ExpandedNodeId(DataTypeTest.Objects.Advertisement, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Order Object.
        /// </summary>
        public static readonly ExpandedNodeId Order = new ExpandedNodeId(DataTypeTest.Objects.Order, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Order_Dishes Object.
        /// </summary>
        public static readonly ExpandedNodeId Order_Dishes = new ExpandedNodeId(DataTypeTest.Objects.Order_Dishes, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Product Object.
        /// </summary>
        public static readonly ExpandedNodeId Product = new ExpandedNodeId(DataTypeTest.Objects.Product, DataTypeTest.Namespaces.cas);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the Menu ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId Menu = new ExpandedNodeId(DataTypeTest.ObjectTypes.Menu, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the NameNotSet53 ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId NameNotSet53 = new ExpandedNodeId(DataTypeTest.ObjectTypes.NameNotSet53, DataTypeTest.Namespaces.cas);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the Menu_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId Menu_Id = new ExpandedNodeId(DataTypeTest.Variables.Menu_Id, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Menu_NameNotSet52 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Menu_NameNotSet52 = new ExpandedNodeId(DataTypeTest.Variables.Menu_NameNotSet52, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the NameNotSet53_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId NameNotSet53_Name = new ExpandedNodeId(DataTypeTest.Variables.NameNotSet53_Name, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the NameNotSet53_Description Variable.
        /// </summary>
        public static readonly ExpandedNodeId NameNotSet53_Description = new ExpandedNodeId(DataTypeTest.Variables.NameNotSet53_Description, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the NameNotSet53_Price Variable.
        /// </summary>
        public static readonly ExpandedNodeId NameNotSet53_Price = new ExpandedNodeId(DataTypeTest.Variables.NameNotSet53_Price, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the NameNotSet53_DishId Variable.
        /// </summary>
        public static readonly ExpandedNodeId NameNotSet53_DishId = new ExpandedNodeId(DataTypeTest.Variables.NameNotSet53_DishId, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Client_ClientId Variable.
        /// </summary>
        public static readonly ExpandedNodeId Client_ClientId = new ExpandedNodeId(DataTypeTest.Variables.Client_ClientId, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Client_ClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId Client_ClientName = new ExpandedNodeId(DataTypeTest.Variables.Client_ClientName, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Client_PhoneNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId Client_PhoneNumber = new ExpandedNodeId(DataTypeTest.Variables.Client_PhoneNumber, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Client_NameNotSet23 Variable.
        /// </summary>
        public static readonly ExpandedNodeId Client_NameNotSet23 = new ExpandedNodeId(DataTypeTest.Variables.Client_NameNotSet23, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Advertisement_Text Variable.
        /// </summary>
        public static readonly ExpandedNodeId Advertisement_Text = new ExpandedNodeId(DataTypeTest.Variables.Advertisement_Text, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Advertisement_HourFrom Variable.
        /// </summary>
        public static readonly ExpandedNodeId Advertisement_HourFrom = new ExpandedNodeId(DataTypeTest.Variables.Advertisement_HourFrom, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Advertisement_HourTo Variable.
        /// </summary>
        public static readonly ExpandedNodeId Advertisement_HourTo = new ExpandedNodeId(DataTypeTest.Variables.Advertisement_HourTo, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Order_OrderDate Variable.
        /// </summary>
        public static readonly ExpandedNodeId Order_OrderDate = new ExpandedNodeId(DataTypeTest.Variables.Order_OrderDate, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Order_TotalPrice Variable.
        /// </summary>
        public static readonly ExpandedNodeId Order_TotalPrice = new ExpandedNodeId(DataTypeTest.Variables.Order_TotalPrice, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Order_CompleteOrderDate Variable.
        /// </summary>
        public static readonly ExpandedNodeId Order_CompleteOrderDate = new ExpandedNodeId(DataTypeTest.Variables.Order_CompleteOrderDate, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Order_cLIENT Variable.
        /// </summary>
        public static readonly ExpandedNodeId Order_cLIENT = new ExpandedNodeId(DataTypeTest.Variables.Order_cLIENT, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Order_OrderId Variable.
        /// </summary>
        public static readonly ExpandedNodeId Order_OrderId = new ExpandedNodeId(DataTypeTest.Variables.Order_OrderId, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Product_ProductId Variable.
        /// </summary>
        public static readonly ExpandedNodeId Product_ProductId = new ExpandedNodeId(DataTypeTest.Variables.Product_ProductId, DataTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the Product_ProductName Variable.
        /// </summary>
        public static readonly ExpandedNodeId Product_ProductName = new ExpandedNodeId(DataTypeTest.Variables.Product_ProductName, DataTypeTest.Namespaces.cas);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the Address component.
        /// </summary>
        public const string Address = "Address";

        /// <summary>
        /// The BrowseName for the Advertisement component.
        /// </summary>
        public const string Advertisement = "Advertisement";

        /// <summary>
        /// The BrowseName for the cLIENT component.
        /// </summary>
        public const string cLIENT = "Client";

        /// <summary>
        /// The BrowseName for the Client component.
        /// </summary>
        public const string Client = "Client";

        /// <summary>
        /// The BrowseName for the ClientId component.
        /// </summary>
        public const string ClientId = "Id";

        /// <summary>
        /// The BrowseName for the ClientName component.
        /// </summary>
        public const string ClientName = "Name";

        /// <summary>
        /// The BrowseName for the CompleteOrderDate component.
        /// </summary>
        public const string CompleteOrderDate = "CompleteOrderDate";

        /// <summary>
        /// The BrowseName for the Description component.
        /// </summary>
        public const string Description = "Description";

        /// <summary>
        /// The BrowseName for the Dish component.
        /// </summary>
        public const string Dish = "Dish";

        /// <summary>
        /// The BrowseName for the Dishes component.
        /// </summary>
        public const string Dishes = "Dishes";

        /// <summary>
        /// The BrowseName for the DishId component.
        /// </summary>
        public const string DishId = "Id";

        /// <summary>
        /// The BrowseName for the HourFrom component.
        /// </summary>
        public const string HourFrom = "HourFrom";

        /// <summary>
        /// The BrowseName for the HourTo component.
        /// </summary>
        public const string HourTo = "HourTo";

        /// <summary>
        /// The BrowseName for the Id component.
        /// </summary>
        public const string Id = "Id";

        /// <summary>
        /// The BrowseName for the Menu component.
        /// </summary>
        public const string Menu = "Menu";

        /// <summary>
        /// The BrowseName for the Name component.
        /// </summary>
        public const string Name = "Name";

        /// <summary>
        /// The BrowseName for the NameNotSet23 component.
        /// </summary>
        public const string NameNotSet23 = "Address";

        /// <summary>
        /// The BrowseName for the NameNotSet52 component.
        /// </summary>
        public const string NameNotSet52 = "Name";

        /// <summary>
        /// The BrowseName for the NameNotSet53 component.
        /// </summary>
        public const string NameNotSet53 = "Dish";

        /// <summary>
        /// The BrowseName for the Order component.
        /// </summary>
        public const string Order = "Order";

        /// <summary>
        /// The BrowseName for the OrderDate component.
        /// </summary>
        public const string OrderDate = "OrderDate";

        /// <summary>
        /// The BrowseName for the OrderId component.
        /// </summary>
        public const string OrderId = "Id";

        /// <summary>
        /// The BrowseName for the PhoneNumber component.
        /// </summary>
        public const string PhoneNumber = "PhoneNumber";

        /// <summary>
        /// The BrowseName for the Price component.
        /// </summary>
        public const string Price = "Price";

        /// <summary>
        /// The BrowseName for the Product component.
        /// </summary>
        public const string Product = "Product";

        /// <summary>
        /// The BrowseName for the ProductId component.
        /// </summary>
        public const string ProductId = "Id";

        /// <summary>
        /// The BrowseName for the ProductName component.
        /// </summary>
        public const string ProductName = "Name";

        /// <summary>
        /// The BrowseName for the Text component.
        /// </summary>
        public const string Text = "Text";

        /// <summary>
        /// The BrowseName for the TotalPrice component.
        /// </summary>
        public const string TotalPrice = "TotalPrice";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the cas namespace (.NET code namespace is 'DataTypeTest').
        /// </summary>
        public const string cas = "http://cas.eu/UA/CommServer/UnitTests/DataTypeTest";

        /// <summary>
        /// The URI for the ua namespace (.NET code namespace is '').
        /// </summary>
        public const string ua = "http://opcfoundation.org/UA/";
    }
    #endregion

    #region MenuState Class
    #if (!OPCUA_EXCLUDE_MenuState)
    /// <summary>
    /// Stores an instance of the Menu ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MenuState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public MenuState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DataTypeTest.ObjectTypes.Menu, DataTypeTest.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAADIAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvVW5pdFRlc3RzL0RhdGFUeXBlVGVzdP//" +
           "//8EYIAAAQAAAAEADAAAAE1lbnVJbnN0YW5jZQEBJQABASUA/////wQAAAAVYIkKAgAAAAEAAgAAAElk" +
           "AQEmAAAvAD8mAAAAABv/////AQH/////AAAAABVgyQoCAAAADAAAAE5hbWVOb3RTZXQ1MgEABAAAAE5h" +
           "bWUBAScAAC8APycAAAAADP////8BAf////8AAAAABGCACgEAAAABAAYAAABEaXNoZXMBASoAAC8AOioA" +
           "AAD/////AAAAAARhggoEAAAAAQAEAAAATWVudQEBKwAALwEBKwArAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Id Variable.
        /// </summary>
        public BaseDataVariableState Id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <summary>
        /// A description for the Name Variable.
        /// </summary>
        public BaseDataVariableState<string> NameNotSet52
        {
            get
            {
                return m_nameNotSet52;
            }

            set
            {
                if (!Object.ReferenceEquals(m_nameNotSet52, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_nameNotSet52 = value;
            }
        }

        /// <summary>
        /// A description for the Dishes Object.
        /// </summary>
        public BaseObjectState Dishes
        {
            get
            {
                return m_dishes;
            }

            set
            {
                if (!Object.ReferenceEquals(m_dishes, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_dishes = value;
            }
        }

        /// <summary>
        /// A description for the Menu Method.
        /// </summary>
        public MethodState Menu
        {
            get
            {
                return m_menuMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_menuMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_menuMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_nameNotSet52 != null)
            {
                children.Add(m_nameNotSet52);
            }

            if (m_dishes != null)
            {
                children.Add(m_dishes);
            }

            if (m_menuMethod != null)
            {
                children.Add(m_menuMethod);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DataTypeTest.BrowseNames.Id:
                {
                    if (createOrReplace)
                    {
                        if (Id == null)
                        {
                            if (replacement == null)
                            {
                                Id = new BaseDataVariableState(this);
                            }
                            else
                            {
                                Id = (BaseDataVariableState)replacement;
                            }
                        }
                    }

                    instance = Id;
                    break;
                }

                case DataTypeTest.BrowseNames.NameNotSet52:
                {
                    if (createOrReplace)
                    {
                        if (NameNotSet52 == null)
                        {
                            if (replacement == null)
                            {
                                NameNotSet52 = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                NameNotSet52 = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = NameNotSet52;
                    break;
                }

                case DataTypeTest.BrowseNames.Dishes:
                {
                    if (createOrReplace)
                    {
                        if (Dishes == null)
                        {
                            if (replacement == null)
                            {
                                Dishes = new BaseObjectState(this);
                            }
                            else
                            {
                                Dishes = (BaseObjectState)replacement;
                            }
                        }
                    }

                    instance = Dishes;
                    break;
                }

                case DataTypeTest.BrowseNames.Menu:
                {
                    if (createOrReplace)
                    {
                        if (Menu == null)
                        {
                            if (replacement == null)
                            {
                                Menu = new MethodState(this);
                            }
                            else
                            {
                                Menu = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Menu;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState m_id;
        private BaseDataVariableState<string> m_nameNotSet52;
        private BaseObjectState m_dishes;
        private MethodState m_menuMethod;
        #endregion
    }
    #endif
    #endregion

    #region NameNotSet53State Class
    #if (!OPCUA_EXCLUDE_NameNotSet53State)
    /// <summary>
    /// Stores an instance of the NameNotSet53 ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class NameNotSet53State : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public NameNotSet53State(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DataTypeTest.ObjectTypes.NameNotSet53, DataTypeTest.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAADIAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvVW5pdFRlc3RzL0RhdGFUeXBlVGVzdP//" +
           "//8EYIAAAQAAAAEAFAAAAE5hbWVOb3RTZXQ1M0luc3RhbmNlAQEkAAEBJAD/////BQAAABVgiQoCAAAA" +
           "AQAEAAAATmFtZQEBLQAALgBELQAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEACwAAAERlc2NyaXB0" +
           "aW9uAQEuAAAuAEQuAAAAAAz/////AQH/////AAAAABVgiQoCAAAAAQAFAAAAUHJpY2UBAS8AAC4ARC8A" +
           "AAAAG/////8BAf////8AAAAABGGCCgQAAAABAAQAAABEaXNoAQEwAAAvAQEwADAAAAABAf////8AAAAA" +
           "FWDJCgIAAAAGAAAARGlzaElkAQACAAAASWQBAUUAAC4AREUAAAAAG/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Name Property.
        /// </summary>
        public PropertyState<string> Name
        {
            get
            {
                return m_name;
            }

            set
            {
                if (!Object.ReferenceEquals(m_name, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_name = value;
            }
        }

        /// <summary>
        /// A description for the Description Property.
        /// </summary>
        public PropertyState<string> Description
        {
            get
            {
                return m_description;
            }

            set
            {
                if (!Object.ReferenceEquals(m_description, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_description = value;
            }
        }

        /// <summary>
        /// A description for the Price Property.
        /// </summary>
        public PropertyState Price
        {
            get
            {
                return m_price;
            }

            set
            {
                if (!Object.ReferenceEquals(m_price, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_price = value;
            }
        }

        /// <summary>
        /// A description for the Dish Method.
        /// </summary>
        public MethodState Dish
        {
            get
            {
                return m_dishMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_dishMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_dishMethod = value;
            }
        }

        /// <summary>
        /// A description for the Id Property.
        /// </summary>
        public PropertyState DishId
        {
            get
            {
                return m_dishId;
            }

            set
            {
                if (!Object.ReferenceEquals(m_dishId, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_dishId = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_name != null)
            {
                children.Add(m_name);
            }

            if (m_description != null)
            {
                children.Add(m_description);
            }

            if (m_price != null)
            {
                children.Add(m_price);
            }

            if (m_dishMethod != null)
            {
                children.Add(m_dishMethod);
            }

            if (m_dishId != null)
            {
                children.Add(m_dishId);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DataTypeTest.BrowseNames.Name:
                {
                    if (createOrReplace)
                    {
                        if (Name == null)
                        {
                            if (replacement == null)
                            {
                                Name = new PropertyState<string>(this);
                            }
                            else
                            {
                                Name = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Name;
                    break;
                }

                case DataTypeTest.BrowseNames.Description:
                {
                    if (createOrReplace)
                    {
                        if (Description == null)
                        {
                            if (replacement == null)
                            {
                                Description = new PropertyState<string>(this);
                            }
                            else
                            {
                                Description = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Description;
                    break;
                }

                case DataTypeTest.BrowseNames.Price:
                {
                    if (createOrReplace)
                    {
                        if (Price == null)
                        {
                            if (replacement == null)
                            {
                                Price = new PropertyState(this);
                            }
                            else
                            {
                                Price = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = Price;
                    break;
                }

                case DataTypeTest.BrowseNames.Dish:
                {
                    if (createOrReplace)
                    {
                        if (Dish == null)
                        {
                            if (replacement == null)
                            {
                                Dish = new MethodState(this);
                            }
                            else
                            {
                                Dish = (MethodState)replacement;
                            }
                        }
                    }

                    instance = Dish;
                    break;
                }

                case DataTypeTest.BrowseNames.DishId:
                {
                    if (createOrReplace)
                    {
                        if (DishId == null)
                        {
                            if (replacement == null)
                            {
                                DishId = new PropertyState(this);
                            }
                            else
                            {
                                DishId = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = DishId;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_name;
        private PropertyState<string> m_description;
        private PropertyState m_price;
        private MethodState m_dishMethod;
        private PropertyState m_dishId;
        #endregion
    }
    #endif
    #endregion
}