using System;

namespace Logic
{
    public abstract class Animal:IObserver
    {
        public bool HaveEyes { private set; get; }
        public bool HavePaws { private set; get; }
        public bool HaveWings { private set; get; }
        public bool IsHungry { private set; get; }
        public bool IsDead { private set; get; }
        public int HoursWithoutFood { private set; get; }
        public int HoursWithoutCleaning { private set; get; }
        public Owner Owner { get; set; }
        public Animal(bool eyes,bool paws,bool wings)
        {
            HaveEyes = eyes;
            HavePaws = paws;
            HaveWings = wings;
            HoursWithoutFood = 0;
            Life.getInstance().AddObserver(this);
        }
        public void CheckHungry()
        {
            if (HoursWithoutFood >= 24)
            {
                IsDead = true;
            }
            else if (HoursWithoutFood >= 8)
            {
                IsHungry = true;
            }
        }
        public bool IsHappy()
        {
            if (Owner == null)
            {
                return true;
            }
            else if (HoursWithoutCleaning <= 24)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Update(int hours)
        {
            HoursWithoutFood += hours;
            HoursWithoutCleaning += hours;
            CheckHungry();
        }
        public bool CanWalk()
        {
            return HavePaws;
        }
        public bool CanRun()
        {
            return HavePaws && !IsHungry;
        }
        public bool CanSing()
        {
            return !IsHungry&&GetType()==typeof(Canary);
        }
        public bool CanFly()
        {
            return HaveWings && !IsHungry;
        }
        public void Eat()
        {
            if (HoursWithoutFood <= 4)
            {
                throw new InvalidOperationException("This animal has eaten recently");             
            }
            else
            {
                HoursWithoutFood = 0;
                IsHungry = false;
            }
        }
        public void BeCleaned()
        {
            
        }
    }
}
