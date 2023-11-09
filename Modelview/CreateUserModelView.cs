using EnergieWebApp.Models;

namespace EnergieWebApp.Modelview
{
    public class CreateUserModelView
    {

        public int HouseholdId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
}
