namespace policecaseapi.Models{
    public class Sak 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PoliceDistrict { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; }
        public string Report { get; set; }
        public string Victims { get; set; }
        public string Suspects { get; set; }
        public string Offenders { get; set; }
        public int IsSolved { get; set; }
    }
}