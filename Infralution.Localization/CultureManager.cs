#region File Header
//
//      FILE:   CultureManager.cs.
//
//    AUTHOR:   Grant Frisken
//
// COPYRIGHT:   Copyright 2008 
//              Infralution
//
#endregion
using System;
using System.ComponentModel;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Drawing;
using System.Resources;
namespace Infralution.Localization
{
    /// <summary>
    /// Defines a component for managing the User Interface culture for
    /// a form (or control) and allows the <see cref="UICulture"/> of an individual form 
    /// or entire application be changed dynamically.
    /// </summary>
    /// <remarks>
    /// This handles forms and components developed in C# and VB.NET but may or may not 
    /// work for components/forms developed in other languages depending on how the language 
    /// handles resource naming and serialization.
    /// </remarks>
    [ToolboxItem(true)]
    public class CultureManager : Component
    {

        #region Static/Constant Member Variables

        private const AnchorStyles anchorLeftRight = AnchorStyles.Left | AnchorStyles.Right;
        private const AnchorStyles anchorTopBottom = AnchorStyles.Top | AnchorStyles.Bottom;
        private const AnchorStyles anchorAll = anchorLeftRight | anchorTopBottom;

        /// <summary>
        /// The application UI culture
        /// </summary>
        private static CultureInfo _applicationUICulture;

        /// <summary>
        /// Should the <see cref="Thread.CurrentCulture"/> be changed when the
        /// <see cref="UICulture"/> changes.
        /// </summary>
        private static bool _synchronizeThreadCulture = true;

        #endregion

        #region Member Variables

        /// <summary>
        /// The control (or more usually form) being managed
        /// </summary>
        private Control _managedControl;

        /// <summary>
        /// The current UI culture for the managed control
        /// </summary>
        private CultureInfo _uiCulture;

        /// <summary>
        /// If true form size is preserved when changing culture
        /// </summary>
        private bool _preserveFormSize = true;

        /// <summary>
        /// If true form location is preserved when changing culture
        /// </summary>
        private bool _preserveFormLocation = true;

        /// <summary>
        /// Properties to be excluded when applying culture resources
        /// </summary>
        private List<string> _excludeProperties = new List<string>();

        /// <summary>
        /// Should the Form <see cref="UICulture"/> be changed when the 
        /// <see cref="ApplicationUICulture"/> changes.
        /// </summary>
        private bool _synchronizeUICulture = true;

        /// <summary>
        /// The current auto scale factor
        /// </summary>
        private SizeF _autoScaleFactor = new SizeF(1, 1);

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Represents the method that will handle the <see cref="UICultureChanged"/> event   
        /// </summary>
        public delegate void CultureChangedHandler(CultureInfo newCulture);

        /// <summary>
        /// Raised when the <see cref="ApplicationUICulture"/> is changed  
        /// </summary>
        public static event CultureChangedHandler ApplicationUICultureChanged;

        /// <summary>
        /// Set/Get the UICulture for whole application. 
        /// </summary>
        /// <remarks>
        /// Setting this property changes the <see cref="Thread.CurrentUICulture"/> 
        /// and sets the <see cref="UICulture"/> for all <see cref="CultureManager">CultureManagers</see> 
        /// to the given culture.  
        /// </remarks>
        public static CultureInfo ApplicationUICulture
        {
            get
            {
                if (_applicationUICulture == null)
                {
                    _applicationUICulture = Thread.CurrentThread.CurrentUICulture;
                }
                return _applicationUICulture;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();

                if (!value.Equals(_applicationUICulture))
                {
                    _applicationUICulture = value;
                    SetThreadUICulture(SynchronizeThreadCulture);
                    if (ApplicationUICultureChanged != null)
                    {
                        ApplicationUICultureChanged(value);
                    }
                }
            }
        }


        /// <summary>
        /// If set to true then the <see cref="Thread.CurrentCulture"/> property is changed
        /// to match the current <see cref="UICulture"/>
        /// </summary>
        public static bool SynchronizeThreadCulture
        {
            get { return _synchronizeThreadCulture; }
            set
            {
                _synchronizeThreadCulture = value;
                if (value)
                {
                    SetThreadUICulture(true);
                }
            }
        }

        /// <summary>
        /// Set the <see cref="Thread.CurrentUICulture"/>, and optionally <see cref="Thread.CurrentCulture"/>, of the current thread 
        /// to match the <see cref="ApplicationUICulture"/>. 
        /// </summary>
        /// <param name="synchronizeThreadCulture">If true the <see cref="Thread.CurrentCulture"/> property is set to a compatible culture</param>
        public static void SetThreadUICulture(bool synchronizeThreadCulture)
        {
            Thread.CurrentThread.CurrentUICulture = ApplicationUICulture;
            if (synchronizeThreadCulture)
            {
                if (ApplicationUICulture.IsNeutralCulture)
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ApplicationUICulture.Name);
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = ApplicationUICulture;
                }
            }
        }


        #endregion

        #region Public Instance Methods

        /// <summary>
        /// Raised when the <see cref="UICulture"/> is changed for this component.  This enables forms
        /// to update their layout following a change to the <see cref="UICulture"/>.
        /// </summary>
        public event CultureChangedHandler UICultureChanged;

        /// <summary>
        /// Represents the method that will handle the <see cref="ExcludeResource"/> event   
        /// </summary>
        public delegate bool ExcludedResourceHandler(string componentName, string propertyName);

        /// <summary>
        /// Raised for each resource to check if it should be excluded from updating
        /// </summary>
        public event ExcludedResourceHandler ExcludeResource;

        /// <summary>
        /// Create a new instance of the component
        /// </summary>
        public CultureManager()
        {
            ApplicationUICultureChanged += new CultureChangedHandler(OnApplicationUICultureChanged);
        }

        /// <summary>
        /// Create a new instance of the component
        /// </summary>
        public CultureManager(IContainer container)
            : this()
        {
            container.Add(this);
        }

        /// <summary>
        /// The control or form to manage the UICulture for
        /// </summary>
        [Description("The control or form to manage the UICulture for")]
        public Control ManagedControl
        {
            get
            {
                if (_managedControl == null)
                {
                    if (Site != null)
                    {
                        IDesignerHost host = Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
                        if (host != null && host.Container != null && host.Container.Components.Count > 0)
                        {
                            _managedControl = host.Container.Components[0] as Control;
                        }
                    }
                }
                return _managedControl;
            }
            set
            {
                _managedControl = value;
            }
        }

        /// <summary>
        /// Should the form size be preserved when the culture is changed
        /// </summary>
        [DefaultValue(true)]
        [Description("Should the form size be preserved when the culture is changed")]
        public bool PreserveFormSize
        {
            get { return _preserveFormSize; }
            set { _preserveFormSize = value; }
        }

        /// <summary>
        /// Should the form location be preserved when the culture is changed
        /// </summary>
        [DefaultValue(true)]
        [Description("Should the form location be preserved when the culture is changed")]
        public bool PreserveFormLocation
        {
            get { return _preserveFormLocation; }
            set { _preserveFormLocation = value; }
        }

        /// <summary>
        /// List of properties to exclude when applying culture specific resources
        /// </summary>
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))] 
        [Description("List of properties to exclude when applying culture specific resources")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<string> ExcludeProperties
        {
            get { return _excludeProperties; }
            set 
            {
                if (value == null) throw new ArgumentNullException();
                _excludeProperties = value; 
            }
        }

        /// <summary>
        /// Called by framework to determine whether the ExcludeProperties should be serialised
        /// </summary>
        /// <returns>True if the style should be serialized</returns>
        private bool ShouldSerializeExcludeProperties()
        {
            return (_excludeProperties.Count > 0); ;
        }

        /// <summary>
        /// Called by framework to reset the ExcludeProperties
        /// </summary>
        private void ResetExcludeProperties()
        {
            _excludeProperties.Clear();
        }
        /// <summary>
        /// The current user interface culture for the <see cref="ManagedControl"/>. 
        /// </summary>
        /// <remarks>
        /// This can be set independently of the <see cref="ApplicationUICulture"/>, allowing
        /// you to have an application simultaneously displaying forms with different cultures.   
        /// Set the <see cref="ApplicationUICulture"/> to change the <see cref="UICulture"/> of
        /// all forms in the application which have associated CultureManagers.
        /// </remarks>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CultureInfo UICulture
        {
            get 
            {
                if (_uiCulture == null)
                {
                    _uiCulture = ApplicationUICulture;
                }
                return _uiCulture; 
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                ChangeUICulture(value);
            }
        }

        /// <summary>
        /// Should the <see cref="UICulture"/> of this form be changed
        /// when the <see cref="ApplicationUICulture"/> is changed
        /// </summary>
        [DefaultValue(true)]
        [Description("Should the UICulture of this form be changed when the ApplicationUICulture")]
        public bool SynchronizeUICulture
        {
            get { return _synchronizeUICulture; }
            set { _synchronizeUICulture = value; }
        }

        #endregion

        #region Local Methods

        /// <summary>
        /// Dispose of the component
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // detach from the global event handler
                //
                ApplicationUICultureChanged -= new CultureChangedHandler(OnApplicationUICultureChanged);
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Handle a change to <see cref="ApplicationUICulture"/>
        /// </summary>
        /// <param name="newCulture"></param>
        protected virtual void OnApplicationUICultureChanged(CultureInfo newCulture)
        {
            if (SynchronizeUICulture)
            {
                ChangeUICulture(newCulture);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCulture"></param>
        protected virtual void OnUICultureChanged(CultureInfo newCulture)
        {
            if (UICultureChanged != null)
            {
                UICultureChanged(newCulture);
            }
        }

        /// <summary>
        /// Set the UI Culture for the managed form/control
        /// </summary>
        /// <param name="culture">The culture to change to</param>
        protected virtual void ChangeUICulture(CultureInfo culture)
        {
            if (!culture.Equals(_uiCulture))
            {
                _uiCulture = culture;
                if (_managedControl != null)
                {
                    _managedControl.SuspendLayout();
                    foreach (Control childControl in _managedControl.Controls)
                    {
                        childControl.SuspendLayout();
                    }
                    try
                    {
                        ApplyResources(_managedControl.GetType(), _managedControl, culture);
                        OnUICultureChanged(culture);
                    }
                    finally
                    {
                        foreach (Control childControl in _managedControl.Controls)
                        {
                            childControl.ResumeLayout();
                        }
                        _managedControl.ResumeLayout();
                    }
                }
            }
        }

        /// <summary>
        /// Load the localized resource for the given culture into a sorted list (indexed by resource name)
        /// </summary>
        /// <param name="rm">The resource manager to load resources from</param>
        /// <param name="culture">The culture to load resources for</param>
        /// <param name="resources">The list to load the resources into</param>
        /// <remarks>
        /// Recursively loads the resources by loading the resources for the parent culture first.
        /// </remarks>
        private void LoadResources(ComponentResourceManager rm, CultureInfo culture, SortedList<string, object> resources)
        {
            if (!culture.Equals(CultureInfo.InvariantCulture))
            {
                LoadResources(rm, culture.Parent, resources);
            }
            ResourceSet resourceSet = rm.GetResourceSet(culture, true, true);
            if (resourceSet != null)
            {
                foreach (DictionaryEntry entry in resourceSet)
                {
                    resources[(string)entry.Key] = entry.Value;
                }
            }
        }

        /// <summary>
        /// Return the current auto scaling factor
        /// </summary>
        protected SizeF AutoScaleFactor
        {
            get 
            {
                  return _autoScaleFactor; 
            }
        }

        /// <summary>
        /// Set the AutoScaleDimensions for the given control
        /// </summary>
        /// <param name="control">The control that the property is set for</param>
        /// <param name="size">The design time dimensions for the control</param>
        protected void SetAutoScaleDimensions(ContainerControl control, SizeF size)
        {
            SizeF cSize = control.CurrentAutoScaleDimensions;
            _autoScaleFactor = new SizeF(cSize.Width / size.Width, cSize.Height / size.Height);
        }

        /// <summary>
        /// Scale a size by the current auto scaling factor
        /// </summary>
        /// <param name="size">The size to scale</param>
        /// <returns>The scaled size</returns>
        protected Size AutoScaleSize(Size size)
        {
            size.Width = (int)(size.Width * AutoScaleFactor.Width);
            size.Height = (int)(size.Height * AutoScaleFactor.Height);
            return size;
        }

        /// <summary>
        /// Scale a point by the current auto scaling factor
        /// </summary>
        /// <param name="point">The point to scale</param>
        /// <returns>The scaled size</returns>
        protected Point AutoScalePoint(Point point)
        {
            point.X = (int)(point.X * AutoScaleFactor.Width);
            point.Y = (int)(point.Y * AutoScaleFactor.Height);
            return point;
        }

        /// <summary>
        /// Scale a padding by the current auto scaling factor
        /// </summary>
        /// <param name="padding">The padding to scale</param>
        /// <returns>The scaled padding</returns>
        protected virtual Padding AutoScalePadding(Padding padding)
        {
            SizeF factor = AutoScaleFactor;
            padding.Top = (int)(padding.Top * factor.Height);
            padding.Bottom = (int)(padding.Bottom * factor.Height);
            padding.Left = (int)(padding.Left * factor.Width);
            padding.Right = (int)(padding.Right * factor.Width);
            return padding;
        }

        /// <summary>
        /// Set the size of a control handling docked/anchored controls appropriately
        /// </summary>
        /// <param name="control">The control to set the size of</param>
        /// <param name="size">The new size of the control</param>
        protected virtual void SetControlSize(Control control, Size size)
        {
            // if the control is a form and we are preserving form size then exit
            //
            if (control is Form && PreserveFormSize) return;

            // if dock fill or anchor all is set then don't change the size
            //
            if (control.Dock == DockStyle.Fill || control.Anchor == anchorAll) return;

            size = AutoScaleSize(size);

            // if docked top/bottom or anchored left/right don't change the width
            //
            if (control.Dock == DockStyle.Top || control.Dock == DockStyle.Bottom ||
               (control.Anchor & anchorLeftRight) == anchorLeftRight)
            {
                size.Width = control.Width;
            }

            // if docked left/right or anchored top/bottom don't change the height
            //
            if (control.Dock == DockStyle.Left || control.Dock == DockStyle.Right ||
               (control.Anchor & anchorTopBottom) == anchorTopBottom)
            {
                size.Height = control.Height;
            }
            control.Size = size;
        }

        /// <summary>
        /// Set the location of a control handling docked/anchored controls appropriately
        /// </summary>
        /// <param name="control">The control to set the location of</param>
        /// <param name="location">The new location of the control</param>
        protected virtual void SetControlLocation(Control control, Point location)
        {
            // if the control is a form and we are preserving form location then exit
            //
            if (control is Form && PreserveFormLocation) return;

            // if dock is set then don't change the location
            //
            if (control.Dock != DockStyle.None) return;

            location = AutoScalePoint(location);

            // if anchored to the right (but not left) then don't change x coord
            //
            if ((control.Anchor & anchorLeftRight) == AnchorStyles.Right)
            {
                location.X = control.Left;
            }

            // if anchored to the bottom (but not top) then don't change y coord
            //
            if ((control.Anchor & anchorTopBottom) == AnchorStyles.Bottom)
            {
                location.Y = control.Top;
            }
            control.Location = location;
        }

 
        /// <summary>
        /// Apply a resource for an extender provider to the given control
        /// </summary>
        /// <param name="extenderProviders">Extender providers for the parent control indexed by type</param>
        /// <param name="control">The control that the extended resource is associated with</param>
        /// <param name="propertyName">The extender provider property name</param>
        /// <param name="value">The value to apply</param>
        /// <remarks>
        /// This can be overridden to add support for other ExtenderProviders.  The default implementation
        /// handles <see cref="ToolTip">ToolTips</see>, <see cref="HelpProvider">HelpProviders</see>,
        /// and <see cref="ErrorProvider">ErrorProviders</see>
        /// </remarks>
        protected virtual void ApplyExtenderResource(Dictionary<Type, IExtenderProvider> extenderProviders, 
                                                     Control control, string propertyName, object value)
        {
            IExtenderProvider extender = null;

            if (propertyName == "ToolTip")
            {
                if (extenderProviders.TryGetValue(typeof(ToolTip), out extender))
                {
                    (extender as ToolTip).SetToolTip(control, value as string);
                }
            }
            else if (propertyName == "HelpKeyword")
            {
                if (extenderProviders.TryGetValue(typeof(HelpProvider), out extender))
                {
                    (extender as HelpProvider).SetHelpKeyword(control, value as string);
                }
            }
            else if (propertyName == "HelpString")
            {
                if (extenderProviders.TryGetValue(typeof(HelpProvider), out extender))
                {
                    (extender as HelpProvider).SetHelpString(control, value as string);
                }
            }
            else if (propertyName == "ShowHelp")
            {
                if (extenderProviders.TryGetValue(typeof(HelpProvider), out extender))
                {
                    (extender as HelpProvider).SetShowHelp(control, (bool)value);
                }
            }
            else if (propertyName == "Error")
            {
                if (extenderProviders.TryGetValue(typeof(ErrorProvider), out extender))
                {
                    (extender as ErrorProvider).SetError(control, value as string);
                }
            }
            else if (propertyName == "IconAlignment")
            {
                if (extenderProviders.TryGetValue(typeof(ErrorProvider), out extender))
                {
                    (extender as ErrorProvider).SetIconAlignment(control, (ErrorIconAlignment)value);
                }
            }
            else if (propertyName == "IconPadding")
            {
                if (extenderProviders.TryGetValue(typeof(ErrorProvider), out extender))
                {
                    (extender as ErrorProvider).SetIconPadding(control, (int)value);
                }
            }
        }

        /// <summary>
        /// Check whether a given component/property should be excluded
        /// </summary>
        /// <param name="componentName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected virtual bool IsExcluded(string componentName, string propertyName)
        {
            string resourceName = componentName + "." + propertyName;
            foreach (string value in _excludeProperties)
            {
                if (value.Contains("."))
                {
                    if (resourceName.Contains(value)) return true;
                }
                else
                {
                    // backward compatibility with previous versions that could only exclude
                    // based on the property name
                    //
                    if (value == propertyName) return true;
                }
            }
            if (ExcludeResource != null)
            {
                return ExcludeResource(componentName, propertyName);
            }
            return false;
        }

        /// <summary>
        /// Return true if the given assembly was compiled using VB.NET
        /// </summary>
        /// <param name="assembly">The assembly to check</param>
        /// <returns>True if the assembly was compiled using VB</returns>
        protected static bool IsVBAssembly(Assembly assembly)
        {
            AssemblyName[] referencedAssemblies = assembly.GetReferencedAssemblies();
            foreach (AssemblyName refAssembly in referencedAssemblies)
            {
                if (refAssembly.Name == "Microsoft.VisualBasic")
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Recursively apply localized resources to a component and its constituent components
        /// </summary>
        /// <param name="componentType">The type we are applying resources for</param>
        /// <param name="instance">The component instance to apply resources to</param>
        /// <param name="culture">The culture resources to apply</param>
        protected virtual void ApplyResources(Type componentType, IComponent instance, CultureInfo culture)
        {
            // check whether there are localizable resources for the type - if not we are done
            //
            System.IO.Stream resourceStream = componentType.Assembly.GetManifestResourceStream(componentType.FullName + ".resources");
            if (resourceStream == null) return;

            // recursively apply the resources localized in the base type
            //
            Type parentType = componentType.BaseType;
            if (parentType != null)
            {
                ApplyResources(parentType, instance, culture);
            }

            // load the resources for this IComponent type into a sorted list
            //
            ComponentResourceManager resourceManager = new ComponentResourceManager(componentType);
            SortedList<string, object> resources = new SortedList<string, object>();
            LoadResources(resourceManager, culture, resources);

            // build a lookup table of components indexed by resource name
            //
            Dictionary<string, IComponent> components = new Dictionary<string, IComponent>();

            // build a lookup table of extender providers indexed by type
            //
            Dictionary<Type, IExtenderProvider> extenderProviders = new Dictionary<Type, IExtenderProvider>();

            bool isVB = IsVBAssembly(componentType.Assembly);

            components["$this"] = instance;
            FieldInfo[] fields = componentType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                string fieldName = field.Name;
                
                // in VB the field names are prepended with an "underscore" so we need to 
                // remove this
                //
                if (isVB)
                {
                    fieldName = fieldName.Substring(1, fieldName.Length - 1);
                }

                // check whether this field is a localized component of the parent
                //
                string resourceName = ">>" + fieldName + ".Name";
                if (resources.ContainsKey(resourceName))
                {
                    IComponent childComponent = field.GetValue(instance) as IComponent;
                    if (childComponent != null)
                    {
                        components[fieldName] = childComponent;

                        // apply resources localized in the child component type
                        //
                        ApplyResources(childComponent.GetType(), childComponent, culture);

                        // if this component is an extender provider then keep track of it
                        //
                        if (childComponent is IExtenderProvider)
                        {
                            extenderProviders[childComponent.GetType()] = childComponent as IExtenderProvider;
                        }
                    }
                }
            }

            // now process the resources 
            //
            foreach (KeyValuePair<string, object> pair in resources)
            {
                string resourceName = pair.Key;
                object resourceValue = pair.Value;
                string[] resourceNameParts = resourceName.Split('.');
                string componentName = resourceNameParts[0];
                string propertyName = resourceNameParts[1];

                if (componentName.StartsWith(">>")) continue;
                if (IsExcluded(componentName, propertyName)) continue;

                IComponent component = null;
                if (!components.TryGetValue(componentName, out component)) continue;

                // some special case handling for control sizes/locations
                //
                Control control = component as Control;
                if (control != null)
                {
                    switch (propertyName)
                    {
                        case "AutoScaleDimensions":
                            SetAutoScaleDimensions(control as ContainerControl, (SizeF)resourceValue);
                            continue;
                        case "Size":
                            SetControlSize(control, (Size)resourceValue);
                            continue;
                        case "Location":
                            SetControlLocation(control, (Point)resourceValue);
                            continue;
                        case "Padding":
                        case "Margin":
                            resourceValue = AutoScalePadding((Padding)resourceValue);
                            break;
                        case "ClientSize":
                            if (control is Form && PreserveFormSize) continue;
                            resourceValue = AutoScaleSize((Size)resourceValue);
                            break;
                    }
                }

                // use the property descriptor to set the resource value
                //
                PropertyDescriptor pd = TypeDescriptor.GetProperties(component).Find(propertyName, false);
                if (((pd != null) && !pd.IsReadOnly) && ((resourceValue == null) || pd.PropertyType.IsInstanceOfType(resourceValue)))
                {
                    try
                    {
                        pd.SetValue(component, resourceValue);
                    }
                    catch (Exception e)
                    {
                        string error = e.GetType().Name + " - " + e.Message;
                        Debug.WriteLine(String.Format("CultureManager Error ({0}) setting property ({1}) for component ({2})", error, propertyName, componentName));
                    }
                }
                else 
                {
                    // there was no property corresponding to the given resource name.  If this is a control
                    // the property may be an extender property so try applying it as an extender resource
                    //
                    if (control != null)
                    {
                        ApplyExtenderResource(extenderProviders, control, propertyName, resourceValue);
                    }
                }

            }

        }

        #endregion
    }
}
