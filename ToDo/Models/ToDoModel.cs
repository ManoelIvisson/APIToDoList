namespace ToDo.Models {
    public class TodoModel {
        public int Id { get; set; }
        public int Titulo { get; set; }
        public bool Pronta { get; set; }
        public DateTime DataDeCriacao { get; set; }
    }
}