using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerApiVersioning.Models
{
    public class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters.Count > 0)
            {
                var versionParameter = operation.Parameters.Single(p => p.Name == "version");
                operation.Parameters.Remove(versionParameter);
            }

        }
    }

    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var pahts = swaggerDoc.Paths;
            swaggerDoc.Paths = new OpenApiPaths();
            foreach (var paht in pahts)
            {
                var key = paht.Key.Replace("v{version}",swaggerDoc.Info.Version);
                var value = paht.Value;
                swaggerDoc.Paths.Add(key,value);
            }
        }
    }

}
