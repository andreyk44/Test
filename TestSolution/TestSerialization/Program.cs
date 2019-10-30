using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestSerialization
{
  class Program
  {
    static void Main(string[] args)
    {
      var c1 = new Container()
      {
        List1 = new List<Base>()
        {
          new DerivedA(){PropA = "PropA"},
          new DerivedB(){PropB = "PropB"},
        }
      };
      var s1 = JsonConvert.SerializeObject(c1);
      Console.WriteLine(s1);

      var c2 = JsonConvert.DeserializeObject(s1);

      var s2 = JsonConvert.SerializeObject(c2);
      Console.WriteLine(s2);


      Console.ReadKey();
    }
  }

  class Container
  {
    public List<Base> List1 { get; set; }
  }


  class Base
  {
    public string PropBase { get; set; }
  }

  class DerivedA : Base
  {
    public DerivedA()
    {
      PropBase = "A";
    }
    public string PropA { get; set; }
  }

  class DerivedB : Base
  {
    public DerivedB()
    {
      PropBase = "B";
    }
    public string PropB { get; set; }
  }

}
