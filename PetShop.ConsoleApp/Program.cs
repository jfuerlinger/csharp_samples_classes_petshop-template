using System;

namespace PetShop.ConsoleApp
{
  class Pet
  {
    public int Id { get; private set; }
    public string Kind { get; private set; }
    public string Name { get; private set; }
    public bool IsVaccinated { get; set; }
    public string Birthday { get; private set; }

    public Pet(int id, string name, string kind, string birthday)
    {
      Id = id;
      Kind = kind;
      Name = name;
      IsVaccinated = false;
      Birthday = birthday;
    }
  }


  class Program
  {
    static Pet[] pets = new Pet[100];
    static int nrOfPets = 0;

    static void Main(string[] args)
    {
      int cmd;

      InitPets();
      PrintPetStatistics();

      do
      {
        Console.Clear();


        Console.WriteLine("Operations: ");
        Console.WriteLine("   0 ... Exit");
        Console.WriteLine("   1 ... Add new pet");
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

    private static void InitPets()
    {
      pets = new Pet[]
      {
        new Pet(++nrOfPets, "Susi", "Cat", "Friday"),
        new Pet(++nrOfPets, "Hansi", "Rabbit", "Tuesday"),
        new Pet(++nrOfPets, "Marlene", "Cat", "Monday")
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

      pets[nrOfPets] = new Pet(nrOfPets + 1, kind, name, birthday);
      nrOfPets++;

    }

    /// <summary>
    /// List all stored pets in a well formatted table – Id, Name, Kind, Birthday
    /// </summary>
    private static void ListAllPets()
    {
      Console.Clear();
      Console.WriteLine("Pet list:");

      for (int i = 0; i < nrOfPets; i++)
      {
        Console.WriteLine($"{pets[i].Id,-3}{pets[i].Name,-10} {pets[i].Kind,-10} {pets[i].Birthday,-10}");
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
      Console.WriteLine("Vaccinated pets:");

      for (int i = 0; i < nrOfPets; i++)
      {
        if (pets[i].IsVaccinated)
        {
          Console.WriteLine($"{pets[i].Id,-3}{pets[i].Name,-10} {pets[i].Kind,-10} {pets[i].Birthday,-10}");
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
      bool isValidId = true;
      int petId;

      do
      {
        Console.Write("Please enter the id of the pet to be vaccinated: ");
        petId = Convert.ToInt32(Console.ReadLine());

        if (petId < 1 || petId > nrOfPets)
        {
          isValidId = false;
          Console.WriteLine("Invalid id - please repeat!");
        }
        else
        {
          isValidId = true;
        }

      } while (!isValidId);


      pets[petId].IsVaccinated = true;
    }

    /// <summary>
    /// All different kinds of pets and the corresponding number
    /// of pets of this kind are listed
    /// </summary>
    private static void PrintPetStatistics()
    {
      string[] kinds = new string[nrOfPets];

      bool kindAlreadyInList = false;
      int nrOfKinds = 0;

      for (int i = 0; i < pets.Length; i++)
      {
        kindAlreadyInList = false;
        for (int j = 0; j < nrOfKinds && !kindAlreadyInList; j++)
        {
          if (pets[i].Kind == kinds[j])
          {
            kindAlreadyInList = true;
          }
        }

        if (!kindAlreadyInList)
        {
          kinds[nrOfKinds++] = pets[i].Kind;
        }

      }

      Console.Clear();
      Console.WriteLine("Statistics:");

      for (int i = 0; i < nrOfKinds; i++)
      {
        string kind = kinds[i];
        int cntOfKind = CountPetsOfKind(kind);

        Console.WriteLine($"{kind, -10}: { cntOfKind }");
      }

    }


    // -> Beispielaufruf  CountPetsOfKind("Rabbit") -> 1
    // -> Beispielaufruf  CountPetsOfKind("Cat") -> 2
    private static int CountPetsOfKind(string kind)
    {
      int count = 0;

      for (int i = 0; i < nrOfPets; i++)
      {
        if (pets[i].Kind == kind)
        {
          count++;
        }
      }

      return count;
    }
  }
}
