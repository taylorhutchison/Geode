using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geode.Tests.Structures;
public class StructuresTestData {
    public static IEnumerable<object[]> QuadTreeTestData()
    {
        yield return new object[] { 4, new Point(3.1, 3.1), new Point(3, 3) };
        yield return new object[] { 4, new Point(1.00001, 2.00001), new Point(1, 2) };
        yield return new object[] { 4, new Point(10, 10), new Point(4, 4) };
        yield return new object[] { 4, new Point(-10, 10), new Point(0, 4) };
        yield return new object[] { 4, new Point(-10, -10), new Point(0, 0) };
        yield return new object[] { 4, new Point(10, -10), new Point(4, 0) };
    }

}
