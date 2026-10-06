using Models;

namespace ItemsManager
{
    internal class PersonManager : EntityManager
    {
        protected override Entity CreateEntity()
        {
            return new Person();
        }

        protected override void ExtraCreate(Entity entity)
        {
            Person person = (Person)entity;

            person.BirthDate = ReadDate("Birth date");
        }

        protected override void ExtraEdit(Entity current, Entity edited)
        {
            Person currentPerson = (Person)current;
            Person editedPerson = (Person)edited;

            editedPerson.BirthDate = ReadDate($"Birth date ({currentPerson.BirthDate})", currentPerson.BirthDate);
        }
    }
}
