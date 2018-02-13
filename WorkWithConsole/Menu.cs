using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace WorkWithConsole
{
    class Menu
    {
        private Logic.System system;
        public Menu()
        {
            system = new Logic.System();
        }
        public void Start()
        {
            bool NotEnded = true;
            while (NotEnded)
            {
                Console.WriteLine("Пожалуйста сделайте выбор:\n1 - Действия с животными\n2 - Действия с хозяевами\n3 - Действия со временем\n4 - Выход");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        WorkWithAnimals();
                        break;
                    case 2:
                        WorkWithOwners();
                        break;
                    case 3:
                        WorkWithTime();
                        break;
                    case 4:
                        NotEnded = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели неправильное число. Пожалуйста,попробуйте снова.");
                        break;
                }
                
            }
        }
        public void WorkWithAnimals()
        {
            bool NotEnded = true;
            while (NotEnded)
            {
                ShowAnimals(system.GetAnimalsList());
                Console.WriteLine("Пожалуйста,выберите действие:\n1 - Добавить животное" +
                    "\n2 - Удалить животное\n3 - Получить информацию о животном\n4 - Назад");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddAnimal();
                        break;
                    case 2:
                        RemoveAnimal();
                        break;
                    case 3:
                        InfoAboutAnimal();
                        break;
                    case 4:
                        NotEnded = false;
                        break;
                        
                }
            }
            void AddAnimal()
            {
                Console.WriteLine("Пожалуйста, выберите зверя:\n1 - Собака\n2 - Канарейка\n3 - Ящерица");
                int animal_choice = int.Parse(Console.ReadLine());
                switch (animal_choice)
                {
                    case 1:
                        system.AddAnimal(new Dog());
                        break;
                    case 2:
                        system.AddAnimal(new Canary());
                        break;
                    case 3:
                        system.AddAnimal(new Lizard());
                        break;
                    default:
                        break;
                }
            }
            void RemoveAnimal()
            {
                Console.WriteLine("Пожалуйста, выберите номер животного, которое хотите удалить");
                int index = int.Parse(Console.ReadLine());
                system.RemoveAnimal(system.GetAnimal(index));
            }
            void InfoAboutAnimal()
            {
                Console.WriteLine("Пожалуйста,выберите номер животного, информацию о котором вы хотите получить");
                int index = int.Parse(Console.ReadLine());
                Animal animal = system.GetAnimal(index);
                if (animal.IsDead)
                {
                    Console.WriteLine("Животное мертво");
                }
                else
                {
                    Console.WriteLine("Умеет ходить: {0}", animal.CanWalk() ? "да" : "нет");
                    Console.WriteLine("Умеет летать: {0}", animal.CanFly() ? "да" : "нет");
                    Console.WriteLine("Может петь: {0}", animal.CanSing() ? "да" : "нет");
                    Console.WriteLine("Может бегать: {0}", animal.CanRun() ? "да" : "нет");
                    Console.WriteLine("Животное счастливо: {0}", animal.IsHappy() ? "да" : "нет");
                    Console.WriteLine("Животное голодно: {0}", animal.IsHungry ? "да" : "нет");
                }
            }
        }
        public void WorkWithOwners()
        {
            bool NotEnded = true;
            while (NotEnded)
            {
                int count = 0;
                Console.WriteLine("Список владельцев:");
                foreach (Owner owner in system.GetOwnersList())
                {
                    Console.WriteLine(count +") "+ owner.ToString());
                    count++;
                }
                Console.WriteLine("Пожалуйста,выберите действие:\n1 - Добавить владельца" +
                    "\n2 - Удалить владельца\n3 - Перейти к действиям отдельного владельца\n4 - Назад");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddOwner();
                        break;
                    case 2:
                        RemoveOwner();
                        break;
                    case 3:
                        Console.WriteLine("Пожалуйста, выберите владельца");
                        int index = int.Parse(Console.ReadLine());
                        WorkWithOwner(system.GetOwner(index));
                        break;
                    case 4:
                        NotEnded = false;
                        break;

                }
            }
            void AddOwner()
            {
                Console.WriteLine("Пожалуйста, выберите владельца:\n1 - Человек\n2 - Зоомагазин");
                int animal_choice = int.Parse(Console.ReadLine());
                switch (animal_choice)
                {
                    case 1:
                        Console.WriteLine("Пожалуйста, введите имя человека");
                        string name = Console.ReadLine();
                        Console.WriteLine("Пожалуйста, введите фамилию человека");
                        string surname = Console.ReadLine();
                        system.AddOwner(new Human(name,surname));
                        break;
                    case 2:
                        Console.WriteLine("Пожалуйста, введите зоо-магазина");
                        string title = Console.ReadLine();
                        system.AddOwner(new ZooShop(title));
                        break;             
                    default:
                        break;
                }
            }
            void RemoveOwner()
            {
                Console.WriteLine("Пожалуйста, выберите номер владельца, которого хотите удалить");
                int index = int.Parse(Console.ReadLine());
                system.RemoveOwner(system.GetOwner(index));
            }
            void WorkWithOwner(Owner owner)
            {
                bool not_ended = true;
                while (not_ended)
                {
                    ShowAnimals(owner.GetAnimals());
                    Console.WriteLine("Пожалуйста, выберите действие:\n1 - Покормить животное\n2 - Поубирать за животным\n3 - Начать ухаживать за новым животным\n4 - Отпустить животное на волю\n5 - Назад");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Выберите номер животного");                 
                            owner.FeedAnimal(owner.GetAnimal(int.Parse(Console.ReadLine())));
                            break;
                        case 2:
                            Console.WriteLine("Выберите номер животного");
                            owner.CleanAnimal(owner.GetAnimal(int.Parse(Console.ReadLine())));
                            break;
                        case 3:
                            ShowAnimals(system.GetAnimalsList());
                            Console.WriteLine("Выберите нового животного");
                            owner.StartCareAnimal(system.GetAnimal(int.Parse(Console.ReadLine())));
                            break;
                        case 4:
                            Console.WriteLine("Выберите номер животного");
                            owner.FreeAnimal(owner.GetAnimal(int.Parse(Console.ReadLine())));
                            break;
                        case 5:
                            NotEnded = false;
                            break;
                    }
                }
            }
        }
        public void WorkWithTime()
        {
            bool NotEnded = true;
            while (NotEnded)
            {
                try
                {
                    Console.WriteLine("Пожалуйста,выберите действие:\n1 - Пропустить время\n2 - Назад");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Введите количество часов, которые вы хотите пропустить");
                            Life.getInstance().PassTime(int.Parse(Console.ReadLine()));
                            break;

                        case 2:
                            NotEnded = false;
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void ShowAnimals(List<Animal> animals)
        {
            if (animals.Count != 0)
            {
                int count = 0;
                Console.WriteLine("Список животных:");
                foreach (Animal animal in animals)
                {
                    Type t = animal.GetType();
                    if (t == typeof(Dog))
                    {
                        Console.WriteLine(count + ") Собака");
                    }
                    else if (t == typeof(Canary))
                    {
                        Console.WriteLine(count + ") Канарейка");
                    }
                    else
                    {
                        Console.WriteLine(count + ") Ящерица");
                    }
                    count++;
                }
            }

        }
    }
}
