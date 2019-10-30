using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Company.Csv2Json
{
  class Program
  {
    static void Main(string[] args)
    {
      var lines = File.ReadAllLines(args[0]).ToList();
      var companyItems = lines.Skip(1).Select(ToJson).ToArray();
      File.WriteAllText(args[1], JsonConvert.SerializeObject(companyItems));
      Console.WriteLine("Press any key...");
      Console.ReadKey();
    }

    private static CompanyItem ToJson(string line)
    {
      Console.WriteLine(line);
      var items = line.Split(';');
      var ci = new CompanyItem()
      {
        Id = Guid.NewGuid(),
        Name = items[0].Substring(1, items[0].Length - 2).Replace("\"\"", "\"").Trim(),
        Abbr = items[1],
        EquipemntGroups = BuildGroups(IsTrueValue(items[2]), IsTrueValue(items[3]), IsTrueValue(items[4]), IsTrueValue(items[5]), IsTrueValue(items[6]), IsTrueValue(items[7])),
        ContractualWorks = new string[0]
      };
      return ci;
    }

    static string[] BuildGroups(bool casingColumnElements, bool handlingEquipment, bool pumps, bool cleaningSystem, bool blowoutPreventerSystem, bool bhaElements)
    {
      var group = new List<string>();

      if (casingColumnElements)
        group.Add("Обсадные трубы");

      if (pumps)
        group.Add("Насосный блок");

      if (handlingEquipment)
        group.Add("Вышечно-лебедочный блок");

      if (cleaningSystem)
        group.Add("Блок очистки/осушки бурового раствора");

      if (blowoutPreventerSystem)
        group.Add("Блок ПВО");

      if (bhaElements)
        group.Add("Долота");

      return group.ToArray();
    }

    private static bool IsTrueValue(string item) => item.ToUpper().Equals("ДА");


    class CompanyItem
    {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public string Abbr { get; set; }
      public string[] EquipemntGroups { get; set; }
      public string[] ContractualWorks { get; set; }
    }

  }
}
