using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Geode;
public static class FeatureExtensions
{
    private static IEnumerable<string> MembersToExcludeBasedOnGeometryPropertiesCalled(Expression expressionBody)
    {
        var membersToExclude = new List<string>();
        if (expressionBody.NodeType == ExpressionType.New)
        {
            var argumentNames = (expressionBody as NewExpression)?.Arguments.Select(arg => (arg as MemberExpression)?.Member.Name);
            if(argumentNames != null)
            {
                membersToExclude.AddRange(argumentNames.Where(name => name != null)!);
            }
        }
        else if (expressionBody.NodeType == ExpressionType.MemberAccess)
        {
            var geometryMemberName = (expressionBody as MemberExpression)?.Member.Name;
            if (geometryMemberName != null)
            {
                membersToExclude.Add(geometryMemberName);
            }
        }
        else
        {
            throw new NotSupportedException($"Expression type {expressionBody.NodeType} is not supported.");
        }
        return membersToExclude;
    }
    public static IFeature<U>? ToFeature<T, U>(this T obj, Expression<Func<T, U>> geometryProperty) where U : IGeometry
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));
        if (geometryProperty == null) throw new ArgumentNullException(nameof(geometryProperty));
        
        var membersToExclude = MembersToExcludeBasedOnGeometryPropertiesCalled(geometryProperty.Body);

        var geometry = geometryProperty.Compile().Invoke(obj);

        var propertiesDictionary = new Dictionary<string, object?>();
        var type = obj.GetType();
        var properties = type.GetProperties().Where(prop => !membersToExclude.Contains(prop.Name)).ToArray();
        foreach (var property in properties)
        {
            var name = property.Name;
            object? value = property.GetValue(obj);
            propertiesDictionary[name] = value;
        }

        return new Feature<U>
        {
            Location = geometry,
            Properties = propertiesDictionary
        };
    }

    public static void MapToFeature<T>()
    {

    }
}
