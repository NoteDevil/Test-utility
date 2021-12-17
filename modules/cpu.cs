using System;
using System.Threading;
using System.Diagnostics;

namespace CPUInfo
{
  public class TestPerfCounter
  {
    static PerformanceCounter myCounter;

    public void Tets()
    {
      if (!PerformanceCounterCategory.Exists("Processor"))
      {
        Console.WriteLine("Object Processor does not exist!");
        return;
      }

      if (!PerformanceCounterCategory.CounterExists(@"% Processor Time", "Processor"))
      {
        Console.WriteLine(@"Counter % Processor Time does not exist!");
        return;
      }

      myCounter = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");
      Console.Write("CPU: %");
      for (int i = 1; i < 5; i++)
      {
        myCounter.NextValue();
        Thread.Sleep(100);
      }
      Console.Write("\rCPU: {0} %", Math.Round(myCounter.NextValue()).ToString());
    }
  }
}