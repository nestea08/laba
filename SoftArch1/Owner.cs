using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public abstract class Owner
    {
        private List<Animal> animals;
        public Owner()
        {
            animals = new List<Animal>();
        }
        public void StartCareAnimal(Animal animal)
        {
            animals.Add(animal);
            animal.Owner = this;
        }
        public void FreeAnimal(Animal animal)
        {
            animals.Remove(animal);
            animal.Owner = null;
        }
        public Animal GetAnimal(int index)
        {
            return animals[index];
        }
        public List<Animal> GetAnimals()
        {
            return animals;
        }
        public void FeedAnimal(Animal animal)
        {
            animal.Eat();
        }
        public void FeedAll()
        {
            foreach(Animal animal in animals)
            {
                FeedAnimal(animal);
            }
        }
        public void CleanAnimal(Animal animal)
        {
            animal.BeCleaned();
        }
        public void CleanAll()
        {
            foreach (Animal animal in animals)
            {
                FeedAnimal(animal);
            }
        }

    }
}
