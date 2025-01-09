using webApiBooks.models;

namespace webApiBooks.dto {
    public class AuthorsDto {
        //Id, nombre, apellido, fecha de registro, fecha de nacimiento
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime Birthdate { get; set; }
        public IQueryable<Books> LibrosDelAutor {  get; set; }
    }
}
