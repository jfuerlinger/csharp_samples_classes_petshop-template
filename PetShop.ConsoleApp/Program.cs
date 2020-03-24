using System;

namespace PetShop.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      int cmd;

      do
      {
        Console.Clear();


        Console.WriteLine("Operations: ");
        Console.WriteLine("   0 ... Exit");
        Console.WriteLine("   1 ... Add pet");
        Console.WriteLine("   2 ... List all pets");
        Console.WriteLine("   3 ... Print vaccination list");
        Console.WriteLine("   4 ... Vaccinate pet");
        Console.WriteLine("   5 ... Print pet statistics");

        Console.WriteLine("Which operation do you want to perform?");

        Console.WriteLine("");
        cmd = Convert.ToInt32(Console.ReadLine());

        switch (cmd)
        {
          case 0:
            // do nothing -> exit
            break;

          case 1:
            AddNewPet();
            break;

          case 2:
            ListAllPets();
            break;

          case 3:
            PrintVaccinationList();
            break;

          case 4:
            VaccinatePet();
            break;

          case 5:
            PrintPetStatistics();
            break;
        }

      } while (cmd != 0);

      Console.WriteLine("Have a nice day.");
    }

    


    /// <summary>
    /// The name, kind and birthday of a new pet shall be entered by a user.
    /// Your program shall instantiate a new object of type Pet, store the entered data and
    /// add the object to a list holding all pets.The Id of the pet shall be generated
    /// automatically and the property IsVaccinated shall be initialized as false.
    /// </summary>
    private static void AddNewPet()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// List all stored pets in a well formatted table – Id, Name, Kind, Birthday
    /// </summary>
    private static void ListAllPets()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// All pets which are not vaccinated yet (IsVaccinated is false) shall be
    /// listed in the same form as in ListAllPets
    /// </summary>
    private static void PrintVaccinationList()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// The user shall enter the id of an animal that should be vaccinated. If the
    /// user enters an invalid id(no number or no existing number) the program shall print
    /// an error message and shall re-ask the user for an id.The property IsVaccinated of
    /// this animal shall be set to true.
    /// </summary>
    private static void VaccinatePet()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// All different kinds of pets and the corresponding number
    /// of pets of this kind are listed
    /// </summary>
    private static void PrintPetStatistics()
    {
      throw new NotImplementedException();
    }
  }
}
