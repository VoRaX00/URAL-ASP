using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URAL.Application.FiltersParameters
{
    public record LogisticParameter
    {
        public string? Name { get; set; }
        public double? Length { get; set; }
        public double? Height { get; set; }
        public double? Volume { get; set; }
        public double? Width { get; set; }
    }
}
