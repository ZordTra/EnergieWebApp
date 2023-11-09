using EnergieWebApp.Models;

namespace EnergieWebApp.Modelview
{
    public class UserHomeViewModel
    {

        public User User { get; set; }
        public List<(String, double?)> Scores { get; set; }


    }
}
