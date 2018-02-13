using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class System
    {
        private List<Animal> animals;
        private List<Owner> owners;
        public System()
        {
            animals = new List<Animal>();
            owners = new List<Owner>();
        }
        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }
        public void AddOwner(Owner owner)
        {
            owners.Add(owner);
        }
        public void RemoveAnimal(Animal animal)
        {
            animals.Remove(animal);
        }
        public void RemoveOwner(Owner owner)
        {
            owners.Remove(owner);
        }
        public Animal GetAnimal(int index)
        {
            return animals[index];
        }
        public Owner GetOwner(int index)
        {
            return owners[index];
        }
        public List<Animal> GetAnimalsList()
        {
            return animals;
        }
        public List<Owner> GetOwnersList()
        {
            return owners;
        }
    }
}
