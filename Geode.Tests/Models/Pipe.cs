using System;
using System.Collections.Generic;
using System.Text;

namespace Geode.Tests.Models
{
    public class Pipe
    {
        public int Id { get; set; }
        public IEnumerable<double[]> Location { get; set; }
    }
}
