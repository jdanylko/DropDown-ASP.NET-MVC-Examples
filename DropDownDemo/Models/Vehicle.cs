namespace DropDownDemo.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            Rating = 0;
        }
        public int Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Rating { get; set; }
    }
}