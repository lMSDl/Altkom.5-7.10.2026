using Models;

namespace ItemsManager
{
    internal class PersonManager : EntityManager<Person>
    {
        public PersonManager(string filePath) : base(filePath)
        {
        }

        protected override void ExtraCreate(Person entity)
        {
            entity.BirthDate = ReadDate("Birth date");
        }

        protected override void ExtraEdit(Person current, Person edited)
        {
            edited.BirthDate = ReadDate($"Birth date ({current.BirthDate})", current.BirthDate);
        }
    }
}
