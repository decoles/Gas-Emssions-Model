using LandGEM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandGEM.Models
{
    public class DataInsertionModel : ObservableObject
    {
        private int _landfillOpenYear;
        private int _landfillClosureYear;
        private bool _calculateClosureYear;
        private string _wasteDesignCapacity = "";

        // Model Parameters
        private string _methaneGenerationRate = "";
        private string _potentialMethaneGenerationCapacity = "";
        private string _nmocConcentration = "";
        private string _methaneContent = "";

        // Pollutants
        private string _pollutant1 = "";
        private string _pollutant2 = "";
        private string _pollutant3 = "";
        private string _pollutant4 = "";

        public int LandfillOpenYear
        {
            get => _landfillOpenYear;
            set => SetProperty(ref _landfillOpenYear, value);
        }

        public int LandfillClosureYear
        {
            get => _landfillClosureYear;
            set => SetProperty(ref _landfillClosureYear, value);
        }

        public bool CalculateClosureYear
        {
            get => _calculateClosureYear;
            set => SetProperty(ref _calculateClosureYear, value);
        }

        public string WasteDesignCapacity
        {
            get => _wasteDesignCapacity;
            set => SetProperty(ref _wasteDesignCapacity, value);
        }

        public string MethaneGenerationRate
        {
            get => _methaneGenerationRate;
            set => SetProperty(ref _methaneGenerationRate, value);
        }

        public string PotentialMethaneGenerationCapacity
        {
            get => _potentialMethaneGenerationCapacity;
            set => SetProperty(ref _potentialMethaneGenerationCapacity, value);
        }

        public string NMOCConcentration
        {
            get => _nmocConcentration;
            set => SetProperty(ref _nmocConcentration, value);
        }

        public string MethaneContent
        {
            get => _methaneContent;
            set => SetProperty(ref _methaneContent, value);
        }

        public string Pollutant1
        {
            get => _pollutant1;
            set => SetProperty(ref _pollutant1, value);
        }

        public string Pollutant2
        {
            get => _pollutant2;
            set => SetProperty(ref _pollutant2, value);
        }

        public string Pollutant3
        {
            get => _pollutant3;
            set => SetProperty(ref _pollutant3, value);
        }

        public string Pollutant4
        {
            get => _pollutant4;
            set => SetProperty(ref _pollutant4, value);
        }
    }
}
