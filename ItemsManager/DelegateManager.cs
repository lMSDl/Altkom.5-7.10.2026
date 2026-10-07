using Models;

namespace ItemsManager
{
    internal class DelegateManager<T> : EntityManager<T> where T : Entity
    {
        private readonly Action<T> _extraCreate;
        private readonly Action<T, T> _extraEdit;

        public DelegateManager(Action<T> extraCreate, Action<T, T> extraEdit, string filePath) : base(filePath)
        {
            _extraCreate = extraCreate;
            _extraEdit = extraEdit;
        }

        protected override void ExtraCreate(T entity)
        {
            _extraCreate(entity);
        }

        protected override void ExtraEdit(T current, T edited)
        {
            _extraEdit(current, edited);
        }
    }
}
