using System;
using System.Collections.Generic;
using System.Linq;
/*
*                                  CodeKata Number 10
*
* Consider the following classes and interface:
* 
*   public interface IMultiLimb
*   {
*       public string Name { get; set; }
*       public int NumberOfLimbs { get; set; }
*   }
*   
*   public class Animal :IMultiLimb
*   {
*       public string Name { get; set; }
*       public int NumberOfLimbs { get; set; }
*   }
*   
*   public class Alien : IMultiLimb
*   {
*       public string Name { get; set; }
*       public int NumberOfLimbs { get; set; }
*   }
*   
*   
*   Create a Generic Method which takes a list of a Type (in this case Animal or Alien) 
*   and returns the Type sorted by their number of limbs. This will require further reading around generic 
*   contraints on type parameters: 
*   
*   docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
*/

namespace CodeKata
{
    public interface IMultiLimb
    {
        public string Name { get; set; }
        public int NumberOfLimbs { get; set; }
    }

    public class Alien : IMultiLimb
    {
        public string Name { get; set; }
        public int NumberOfLimbs { get; set; }
        public Alien(string name, int num) => (Name, NumberOfLimbs) = (name, num);
    }

    public class Animal : IMultiLimb
    {
        public string Name { get; set; }
        public int NumberOfLimbs { get; set; }
        public Animal(string name, int num) => (Name, NumberOfLimbs) = (name, num);
    }

    public class GenericList<T, U> where T : Alien, new() where U : Animal
    {
        private List<Alien> aliens;
        private List<Animal> animals;
        public void SortAliens()
        {
            List<Alien> sortLimbAliens = aliens.OrderBy(a => a.NumberOfLimbs).ToList();
        }
        public void SortAnimals()
        {
            List<Animal> sortLimbAnimals = animals.OrderBy(a => a.NumberOfLimbs).ToList();
        }
        public GenericList<T, U> SortLimbs(T alien, U animal)
        {
            var list = new GenericList<T, U>();
            list.aliens.Add(alien);
            list.animals.Add(animal);
            list.SortAliens();
            list.SortAnimals();
            return list;
        }
    }
}