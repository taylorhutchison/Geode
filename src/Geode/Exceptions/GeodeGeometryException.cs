using System;

namespace Geode;

public class GeodeGeometryException : Exception
{
    public GeodeGeometryException () : base() { }
    public GeodeGeometryException (string message) : base(message)
    {

    }
    public GeodeGeometryException (string message, Exception ex) : base(message, ex)
    {

    }

}
