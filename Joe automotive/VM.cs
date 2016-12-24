using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Joe_automotive
{
    class VM: INotifyPropertyChanged
    {
        public const decimal Oil = 26m;
        public const decimal Lube = 18m;
        public const decimal Radiate = 30m;
        public const decimal Transmit = 80m;
        public const decimal Inspect = 15m;
        public const decimal MufflerReplace = 100m;
        public const decimal TireRotate = 20m;
        public const decimal Taxc = 0.06m;
        public const decimal labor = 20m;
        public bool OilChange
        {
            get { return _oilChange; }
            set { _oilChange = value; OnPropertyChanged(); }
        }
        private bool _oilChange;
        public bool LubeChange
        {
            get { return _lubeChange; }
            set { _lubeChange = value; OnPropertyChanged(); }
        }
        private bool _lubeChange;
        public bool Radiator
        {
            get { return _radiator; }
            set { _radiator = value; OnPropertyChanged(); }
        }
        private bool _radiator;
        public bool Transmission
        {
            get { return _transmission; }
            set { _transmission = value; OnPropertyChanged(); }
        }
        private bool _transmission;
        public bool Inspection
        {
            get { return _inspection; }
            set { _inspection = value; OnPropertyChanged(); }
        }
        private bool _inspection;
        public bool Muffler
        {
            get { return _muffler; }
            set { _muffler = value; OnPropertyChanged(); }
        }
        private bool _muffler;
        public bool Tire
        {
            get { return _tire; }
            set { _tire = value; OnPropertyChanged(); }
        }
        private bool _tire;
        public decimal PartPrice
        {
            get { return _partPrice; }
            set { _partPrice = value; OnPropertyChanged(); }
        }
        private decimal _partPrice;
        public decimal Hours
        {
            get { return _hours; }
            set { _hours = value; OnPropertyChanged(); }
        }
        private decimal _hours;
        public decimal Tax
        {
            get { return _tax; }
            set { _tax = value; OnPropertyChanged(); }
        }
        private decimal _tax;
        public decimal Cost
        {
            get { return _cost; }
            set { _cost = value; OnPropertyChanged(); }
        }
        private decimal _cost;
        public void docalc()
        {
            Cost = Calculation() + Calculation2();
        }
        public decimal Calculation()
        {
            decimal calculate = 0m;
            if (Tire) { calculate += TireRotate ; }
            if(Muffler) { calculate += MufflerReplace; }
            if(OilChange) { calculate += Oil;  }
            if(LubeChange) { calculate += Lube; }
            if(Inspection) { calculate += Inspect; }
            if(Radiator) { calculate += Radiate; }
            if(Transmission) { calculate += Transmit; }
            return calculate;
        }
        public decimal Calculation2()
        {
            Tax = PartPrice * Taxc;
            decimal Hour = Hours * labor; 
            decimal calculate2 = 0m;
            calculate2 = PartPrice + Tax + Hour;
            return calculate2;
        }
        public void clear()
        {
            Tire = false;
            Muffler = false;
            OilChange = false;
            LubeChange = false;
            Inspection = false;
            Radiator = false;
            Transmission = false;
            PartPrice = 0;
            Hours = 0;
            Tax = 0;
            Cost = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
