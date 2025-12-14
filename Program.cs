using System;
using System.Windows.Forms;

namespace ImeConverter2025
{
    internal static class Program
    {
        [STAThread] // still fine to include
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new TemperatureConverter());
        }
    }
}
