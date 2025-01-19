using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geode.Serializers;
public class GeoJsonSerializer
{
    public string Serialize<T>(T obj)
    {
        return string.Empty;
    }

    public T? Deserialize<T>(string json)
    {
        return default(T);
    }
}
