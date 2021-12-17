using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace CPUTemperature
{
  public struct Temperature
  {
    public readonly bool Active;
    public readonly uint[] ActiveTripPoint;
    public readonly uint ActiveTripPointCount;
    public readonly uint CriticalTripPointRaw;
    public readonly uint CurrentTemperatureRaw;
    public readonly string InstanceName;

    public Temperature(bool active, uint[] activeTripPoint, uint activeTripPointCount, uint criticalTripPointRaw, uint currentTemperatureRaw, string instanceName) : this()
    {
      Active = active;
      ActiveTripPoint = activeTripPoint;
      ActiveTripPointCount = activeTripPointCount;
      CriticalTripPointRaw = criticalTripPointRaw;
      CurrentTemperatureRaw = currentTemperatureRaw;
      InstanceName = instanceName;
    }

    public double CriticalTripPoint
    {
      get { return CriticalTripPointRaw * 0.1 - 273.15; }
    }

    public double CurrentTemperature
    {
      get { return CurrentTemperatureRaw * 0.1 - 273.15; }
    }

    public static IEnumerable<Temperature> Instances
    {
      get
      {
        var searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
        return from ManagementObject obj in searcher.Get()
               select new Temperature((bool)obj["Active"], (uint[])obj["ActiveTripPoint"], (uint)obj["ActiveTripPointCount"],
               (uint)obj["CriticalTripPoint"], (uint)obj["CurrentTemperature"], (string)obj["InstanceName"]);
      }
    }

    public override string ToString()
    {
      return string.Format("CPU Temperature: {0} °С / {1} °С", Math.Round(CurrentTemperature), Math.Round(CriticalTripPoint));
    }
  }
}