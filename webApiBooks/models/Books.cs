namespace webApiBooks.models {
    public class Books {
        //id, titulo, fecha de publicación, descricao, idAutor
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public int IdAuthor {  get; set; }

    }
}
