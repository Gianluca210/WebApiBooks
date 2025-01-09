using Microsoft.OpenApi.MicrosoftExtensions;

namespace webApiBooks.models {
    public class Authors {
        //Id, nombre, apellido, fecha de registro, fecha de nacimiento
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
