using System;
using System.Collections.Generic;
using System.Reflection;

public static class Utils {
    public static class ReflectionHelper
{
    


    

    public static List<string> GetFieldNames(object obj){
        List<string> strings = new();
        Type type = obj.GetType();
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach(FieldInfo field in fields){
            strings.Add(field.Name);
        }
        return strings;
    }
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

        return "9999";
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