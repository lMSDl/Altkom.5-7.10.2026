using ItemsManager;
using Models;

//EntityManager<ShoppingItem> manager = new ShoppingItemManager();

DelegateManager<Pet> manager = new DelegateManager<Models.Pet>(current => current.Age = EntityManager<Pet>.ReadInt("Age"),
                                                               (current, edited) => edited.Age = EntityManager<Pet>.ReadInt($"Age ({current.Age})", current.Age));

manager.Run();