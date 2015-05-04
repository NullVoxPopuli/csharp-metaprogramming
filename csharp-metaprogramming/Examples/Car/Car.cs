using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_metaprogramming.Examples.Car
{
  class Car : DynamicObject
  {

    public static List<string> availableFeatures = new List<string>() {
      "Wheels", "Windows", "AirConditioning", 
      "GullWingDoors", "MoonRoof", "Turbo", "TouchScreen"
    };

    public List<String> features = new List<string>();

    Dictionary<string, object> _dictionary = new Dictionary<string,object>();

    // Sets the property name to an entry in _dictionary
    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
      _dictionary[binder.Name] = value;
      return true;
    }

    // Retrieves a property value from the _dictionary
    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
      return _dictionary.TryGetValue(binder.Name, out result);
    }

    // basically "method_missing" from ruby.
    // allows you to intercept method calls, and redirect / add functionality.
    //
    // This could also be used to delegate method calls to another object.
    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
      string methodName = binder.Name;

      // check if the methodName matches the pattern that we are wanting
      // to have dynamic (i.e.: lazy-programmer) functionality for
      System.Text.RegularExpressions.Match featureMatch =
        System.Text.RegularExpressions.Regex.Match(methodName, @"Has(.+)");

      if (featureMatch.Success)
      {
        result = this.features.Contains(featureMatch.Groups[1].Value);
        // TryInvokeMember must return true, otherwise it throws a 
        // "No such member" error
        return true;
      }

      // none of the matches were successful, continue with the 
      // default functionality
      return base.TryInvokeMember(binder, args, out result);
    }
  }
}
