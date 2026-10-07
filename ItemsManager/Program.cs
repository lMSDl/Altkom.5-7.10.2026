using ItemsManager;
using Models;

string filePath = @"C:\Users\Student\Desktop\Data\data";

EntityManager<Product> manager = new ProductManager(filePath);

//DelegateManager<Pet> manager = new DelegateManager<Models.Pet>(current => current.Age = EntityManager<Pet>.ReadInt("Age"),
//                                                               (current, edited) => edited.Age = EntityManager<Pet>.ReadInt($"Age ({current.Age})", current.Age));

manager.Run();