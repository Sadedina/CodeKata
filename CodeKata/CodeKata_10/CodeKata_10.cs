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
        private List<Alien> _aliens;
        private List<Animal> _animals;
        public void SortAliens()
        {
            List<Alien> sortLimbAliens = _aliens.OrderBy(a => a.NumberOfLimbs).ToList();
        }
        public void SortAnimals()
        {
            List<Animal> sortLimbAnimals = _animals.OrderBy(a => a.NumberOfLimbs).ToList();
        }
    }

    public class CodeKata_10
    {
    }


}