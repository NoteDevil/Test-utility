using System;
using System.Diagnostics;

namespace RAMinfo
{
  class ram
  {
    private PerformanceCounter
        ramCounter =
            new PerformanceCounter("Memory", "% Committed Bytes In Use");

    public void getAvailableRAM()
    {
      Console
          .WriteLine("RAM: " +
          Math.Round(this.ramCounter.NextValue()) +
          " %");
    }
  }
}