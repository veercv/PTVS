// Visual Studio Shared Project
// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the License); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY
// IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Microsoft.VisualStudioTools.Project {
    /// <summary>
    /// Enables a managed object to expose properties and attributes for COM objects.
    /// </summary>
    [ComVisible(true)]
    public class LocalizableProperties : ICustomTypeDescriptor {
        #region ICustomTypeDescriptor
        public virtual AttributeCollection GetAttributes() {
            AttributeCollection col = TypeDescriptor.GetAttributes(this, true);
            return col;
        }

        public virtual EventDescriptor GetDefaultEvent() {
            EventDescriptor ed = TypeDescriptor.GetDefaultEvent(this, true);
            return ed;
        }

        public virtual PropertyDescriptor GetDefaultProperty() {
            PropertyDescriptor pd = TypeDescriptor.GetDefaultProperty(this, true);
            return pd;
        }

        public virtual object GetEditor(Type editorBaseType) {
            object o = TypeDescriptor.GetEditor(this, editorBaseType, true);
            return o;
        }

        public virtual EventDescriptorCollection GetEvents() {
            EventDescriptorCollection edc = TypeDescriptor.GetEvents(this, true);
            return edc;
        }

        public virtual EventDescriptorCollection GetEvents(System.Attribute[] attributes) {
            EventDescriptorCollection edc = TypeDescriptor.GetEvents(this, attributes, true);
            return edc;
        }

        public virtual object GetPropertyOwner(PropertyDescriptor pd) {
            return this;
        }

        public virtual PropertyDescriptorCollection GetProperties() {
            PropertyDescriptorCollection pcol = GetProperties(null);
            return pcol;
        }

        public virtual PropertyDescriptorCollection GetProperties(System.Attribute[] attributes) {
            ArrayList newList = new ArrayList();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this, attributes, true);

            for (int i = 0; i < props.Count; i++)
                newList.Add(CreateDesignPropertyDescriptor(props[i]));

            return new PropertyDescriptorCollection((PropertyDescriptor[])newList.ToArray(typeof(PropertyDescriptor)));
            ;
        }

        public virtual DesignPropertyDescriptor CreateDesignPropertyDescriptor(PropertyDescriptor propertyDescriptor) {
            return new DesignPropertyDescriptor(propertyDescriptor);
        }

        public virtual string GetComponentName() {
            string name = TypeDescriptor.GetComponentName(this, true);
            return name;
        }

        public virtual TypeConverter GetConverter() {
            TypeConverter tc = TypeDescriptor.GetConverter(this, true);
            return tc;
        }

        public virtual string GetClassName() {
            return this.GetType().FullName;
        }

        #endregion ICustomTypeDescriptor
    }
}
