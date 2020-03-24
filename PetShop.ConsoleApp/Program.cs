using System;
using System.Threading.Channels;

namespace PetShop.ConsoleApp
{
  class Pet
  {
    public int Id { get; set; }
    public string Kind { get; set; }
    public string Name { get; set; }
    public bool IsVaccinated { get; set; }
    public string Birthday { get; set; }

    public Pet(int id, string name, string kind, string birthday)
    {
      Id = id;
      Kind = kind;
      Name = name;
      Birthday = birthday;
      IsVaccinated = false;
    }
  }

  class Program
  {
    static int id = 0;
    static Pet[] pets = new Pet[100];

    static void Main(string[] args)
    {

      InitPets();

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
            id++;
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

    private static void InitPets()
    {
      pets = new Pet[]
      {
        new Pet(++id, "Susi", "Cat", "Friday"),
        new Pet(++id, "Hansi", "Rabbit", "Tuesday"),
        new Pet(++id, "Marlene", "Cat", "Monday")
      };
    }


    /// <summary>
    /// The name, kind and birthday of a new pet shall be entered by a user.
    /// Your program shall instantiate a new object of type Pet, store the entered data and
    /// add the object to a list holding all pets.The Id of the pet shall be generated
    /// automatically and the property IsVaccinated shall be initialized as false.
    /// </summary>
    private static void AddNewPet()
    {
      Console.Write("Name: ");
      string name = Console.ReadLine();

      Console.Write("Kind: ");
      string kind = Console.ReadLine();

      Console.Write("Birthday: ");
      string birthday = Console.ReadLine();

      Pet pet = new Pet(id + 1, kind, name, birthday);
      pets[id] = pet;
    }

    /// <summary>
    /// List all stored pets in a well formatted table – Id, Name, Kind, Birthday
    /// </summary>
    private static void ListAllPets()
    {
      Console.Clear();
      Console.WriteLine("Pets list:");
      for (int i = 0; i < id; i++)
      {
        Console.WriteLine($"{pets[i].Id,3 }{pets[i].Name,10 }{pets[i].Kind,10 }{pets[i].Birthday,10}");
      }

      Console.ReadKey();
    }

    /// <summary>
    /// All pets which are not vaccinated yet (IsVaccinated is false) shall be
    /// listed in the same form as in ListAllPets
    /// </summary>
    private static void PrintVaccinationList()
    {
      Console.Clear();
      Console.WriteLine("Vaccinated pets list:");
      for (int i = 0; i < id; i++)
      {
        if (pets[i].IsVaccinated)
        {
          Console.WriteLine($"{pets[i].Id,3}{pets[i].Name,10}{pets[i].Kind,10}{pets[i].Birthday,10}");
        }
      }

      Console.ReadKey();
    }

    /// <summary>
    /// The user shall enter the id of an animal that should be vaccinated. If the
    /// user enters an invalid id(no number or no existing number) the program shall print
    /// an error message and shall re-ask the user for an id.The property IsVaccinated of
    /// this animal shall be set to true.
    /// </summary>
    private static void VaccinatePet()
    {
      bool isSuccess = false;

      while (!isSuccess)
      {
        Console.WriteLine("Please enter valid id:");
        int enteredId = Convert.ToInt32(Console.ReadLine());

        if (enteredId > id || enteredId < 0)
        {
          Console.WriteLine("Invalid id - please try again!");
        }
        else
        {
          pets[enteredId].IsVaccinated = true;
          isSuccess = true;
        }
      }
    }

    /// <summary>
    /// All different kinds of pets and the corresponding number
    /// of pets of this kind are listed
    /// </summary>
    private static void PrintPetStatistics()
    {
      int count = 0;
      string[] kinds = new string[id];
      bool kindAlreadyInList = false;

      for (int i = 0; i < id; i++) // über alle pets iterieren
      {
        string kindOfCurrentPet = pets[i].Kind;

        kindAlreadyInList = false;
        for (int j = 0; j < kinds.Length; j++)
        {
          if (kindOfCurrentPet == kinds[j])
          {
            kindAlreadyInList = true;
          }
        }
        if (!kindAlreadyInList)
        {
          kinds[count++] = pets[i].Kind;
        }
      }


      Console.WriteLine("Pet statistics:");

      for (int i = 0; i < count; i++)
      {
        int sum = 0;
        for (int j = 0; j < id; j++)
        {
          if (kinds[i] == pets[j].Kind)
          {
            sum++;
          }
        }

        Console.WriteLine($"{kinds[i]}: {sum}");
      }

      Console.ReadKey();
    }
  }
}
