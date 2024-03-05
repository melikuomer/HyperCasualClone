using System;
using System.Reflection;

public static class Utils {
    public static class ReflectionHelper
{
    
    public static string GetNonZeroMemberName(object obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        Type type = obj.GetType();

        if (!type.IsValueType)
        {
            throw new ArgumentException("This method only works with structs.");
        }

        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        //List<string> nonZeroNames = new List<string>();

        foreach (FieldInfo field in fields)
        {
            object value = field.GetValue(obj);

            if (IsNonZero(value))
            {
                return field.Name;
            }
        }

        return " ";
    }

    private static bool IsNonZero(object value)
    {
        if (value == null)
        {
            return false;
        }
        return (float)value != 0f;
        
    }


    public static float GetValueWithName(object obj , string name){
        Type type = obj.GetType();

        FieldInfo field = type.GetField(name);
        return (float)field.GetValue(obj);
    }
}


}