namespace TCCESTOQUE.Interfaces.Service
{
    public interface IServiceBase<T> where T : class
    {
        public T GetDetalheModel(int? id);
        public T GetEdicao(int? id);
        public object GetCriacao();
        public T GetExclusao(int? id);
        public object GetEmail(string email);
        public object GetSenha(string senha);

        public bool PostCriacao(T model);
        public bool PutEdicao(int id, T model);
        public object PostExclusao(int id);
    }
}
