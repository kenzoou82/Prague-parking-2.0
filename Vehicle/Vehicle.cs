namespace Prague_parking_klasser
{
    public abstract class Vehicle
    {
        public string RegNumber { get; set; }
        public DateTime EntryTime { get; set; }
        public string VehicleType => this.GetType().Name;

        public abstract int VehicleSize { get; }
        public Vehicle(string regNumber)
        {
            RegNumber = regNumber.ToUpper().Replace(" ", "");
            if (RegNumber.Length < 1 || RegNumber.Length > 10)
            {
                throw new ArgumentException("Registreringsnummret måste vara 1-10 tecken.");
            }
            EntryTime = DateTime.Now;
        }   
    }

}
