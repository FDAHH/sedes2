using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using sedes.Models.Frontend;

namespace sedes2.Models
{
    static public class EdmModelHelper
    {

        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
            builder.EntitySet<ZBuilding>("Building");
            builder.EntitySet<ZRoom>("Room");
            builder.EntitySet<ZSeat>("Seat");

            return builder.GetEdmModel();
        }

    }
}
