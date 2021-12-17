using System;
using System.Threading;
using CPUTemperature;
using RAMinfo;
using CPUInfo;

namespace project
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      Console.WriteLine("Loading...");

      while (true)
      {
        Console.Clear();
        Check();
        Thread.Sleep(1000);
      }
    }
    private static void Check()
    {
      Console.Clear();
      ram ram = new ram();
      ram.getAvailableRAM();
      foreach (var temperature in Temperature.Instances)
      {
        Console.WriteLine(temperature);
      }
      TestPerfCounter cpu = new TestPerfCounter();
      cpu.Tets();
    }
  }
}
