namespace ToDo.Models {
    public class TodoModel {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Pronta { get; set; }
        public DateTime DataDeCriacao { get; set; }
    }
}