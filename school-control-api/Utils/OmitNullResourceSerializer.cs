using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData;
using Microsoft.OData.Edm;

namespace school_control_net.Utils
{
      public class OmitNullResourceSerializer : ODataResourceSerializer
      {
            public OmitNullResourceSerializer(IODataSerializerProvider serializerProvider) : base(serializerProvider)
            {
            }

            public override ODataProperty CreateStructuralProperty(IEdmStructuralProperty structuralProperty, ResourceContext resourceContext)
            {
                object propertyValue = resourceContext.GetPropertyValue(structuralProperty.Name);
                if (propertyValue == null)
                {
                    return null;
                }

                return base.CreateStructuralProperty(structuralProperty, resourceContext);
            }
      }
}