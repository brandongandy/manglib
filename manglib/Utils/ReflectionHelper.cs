using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mang.Utils
{
  public class ReflectionHelper
  {
    public static Dictionary<string, List<string>> GetNameDictionary()
    {
      var dict = new Dictionary<string, List<string>>();
      var nameList = Assembly.GetExecutingAssembly().GetTypes()
              .Where(t => t.Namespace == "Mang.Data.Names");

      foreach (var key in nameList)
      {
        var fieldList = key.GetFields();
        foreach (var f in fieldList)
        {
          var keyword = $"{key.Name}.{f.Name}";
          var l = Activator.CreateInstance(key);
          var f2 = (List<string>)f.GetValue(l);
          dict.Add(keyword, f2);
        }
      }

      return dict;
    }
  }
}
