using Models;

namespace ItemsManager
{
    internal class ShoppingItemManager : EntityManager<ShoppingItem>
    {
        protected override void ExtraCreate(ShoppingItem entity)
        {
            entity.Quantity = ReadInt("Quantity");
        }

        protected override void ExtraEdit(ShoppingItem current, ShoppingItem edited)
        {
            edited.Quantity = ReadInt($"Quantity ({current.Quantity})", current.Quantity);
        }
    }
}
