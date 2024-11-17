using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Contact
    {
   
        public int Id { get; set; }   

        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage =  "Email is required." )] [EmailAddress(ErrorMessage ="Invalid email address.")]
        public string Email { get; set; }

    }

    public static class Sequence
    {
        private static int _counter = 0;
       
       
        public static int NextId()
        {
            _counter++;
            return _counter;
        }


       

    }
}
