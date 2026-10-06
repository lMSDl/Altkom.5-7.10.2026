using Models;

namespace ItemsManager
{
    internal class PersonManager : EntityManager<Person>
    {
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
