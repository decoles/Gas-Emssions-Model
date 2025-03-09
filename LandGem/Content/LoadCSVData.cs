using System.Globalization;
using System.IO;

namespace LandGEM.Content
{
    public static class LandfillGasData
    {
        public static Dictionary<string, (double? Concentration, double MolecularWeight)> GasData { get; private set; } = new();

        public static Dictionary<string, double> parameter1 { get; private set; } = new();
        public static Dictionary<string, double> parameter2 { get; private set; } = new();
        public static Dictionary<string, double> parameter3 { get; private set; } = new();
        public static Dictionary<string, double> parameter4 { get; private set; } = new();

        public static void LoadData()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Content", "pollutants.csv");
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException($"CSV file not found: {filePath}");

                foreach (var line in File.ReadLines(filePath))
                {
                    var parts = line.Split(',');

                    if (parts.Length < 3) continue;

                    string name = parts[0].Trim();
                    double? concentration = string.IsNullOrWhiteSpace(parts[1]) ? null : double.Parse(parts[1], CultureInfo.InvariantCulture);
                    double molecularWeight = double.Parse(parts[2], CultureInfo.InvariantCulture);

                    GasData[name] = (concentration, molecularWeight);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }

            parameter1 = new Dictionary<string, double>
            {
                { "CAA Conventional - 0.05", 0.05 },
                { "CAA Arid Area - 0.02",  0.02 },
                { "Inventory Conventional 0.04",  0.04},
                { "Inventory Arid Area - 0.02",  0.02},
                { "Inventory Wet - 0.7", 0.7},
                { "User-Specified", 0 }
            };

            parameter2 = new Dictionary<string, double>
            {
                { "CAA Conventional - 170", 170 },
                { "CAA Arid Area - 170",  170 },
                { "Inventory Conventional 100",  100},
                { "Inventory Arid Area - 100",  100},
                { "Inventory Wet - 96", 96},
                { "User-Specified", 0 }
            };

            parameter3 = new Dictionary<string, double>
            {
                { "CAA - 4000", 4000 },
                { "Inventory No or Unkown Co-disposal - 600",  600 },
                { "Inventory Co-disposal",  2400},
                { "User-Specified", 0 }
            };

            parameter4 = new Dictionary<string, double>
            {
                { "CAA - 50% by volume", .50 },
                { "User-Specified", 0 }
            };
        }

        public static (double? Concentration, double MolecularWeight)? GetGasInfo(string name)
        {
            return GasData.TryGetValue(name, out var data) ? data : null;
        }
    }
}
