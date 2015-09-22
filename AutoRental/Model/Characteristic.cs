using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Model
{
    class Characteristic
    {
        enum TransmissionType { Automatic, Manual, Robot };
        enum EngineType { Benzine, Diesel, Gas, Electro };

        public int CatalogID { get; set; }

        public int EngineCapacity { get; set; } //Объем двигателя

        public int Mileage { get; set; } //Пробег

        public int FuelConsumption { get; set; }  //Расход топлива

        public String Transmission { get; set; }

        public String Engine { get; set; }

        public int CatalogTrailerID { get; set; }

        public bool RemovableBoard { get; set; }   //Съемные борта

        public int LoadCapacity { get; set; }    //Грузоподъемность

        public int Weight { get; set; }

        public int BoardHeight { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
        
        public int NumberOfAxis { get; set; }

    }
}
