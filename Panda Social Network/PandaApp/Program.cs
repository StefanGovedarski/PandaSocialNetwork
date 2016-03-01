using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandaClassLibrary;

namespace PandaApp
{
    class Program
    {
        // some global variables we're going to use in out program
        static string pandaName, pandaEmail, genderInput;
        static GenderType pandaGender;

        static Panda GetPandaInfo()
        {
            Console.Write("\tName: ");
            pandaName = Console.ReadLine();
            Console.Write("\tEmail: ");
            pandaEmail = Console.ReadLine();
            Console.Write("\tGender: ");
            genderInput = Console.ReadLine();
            genderInput = genderInput.ToLower();
            if (genderInput.Contains("female"))
                pandaGender = GenderType.Female;
            else
                pandaGender = GenderType.Male;

            return new Panda(pandaName, pandaEmail, pandaGender);
        }

        static void PrintHelp()
        {
            Console.Write(new string('-', Console.WindowWidth));
            Console.WriteLine("addpanda - adds a panda to the social network");
            Console.WriteLine("haspanda - returns true or false if the panda is in the network or not");
            Console.WriteLine("makefriends - makes two panda friends");
            Console.WriteLine("arefriends - returns true if the panda are friends, otherwise false");
            Console.WriteLine("friendsof - returns a list of Panda with the friends of the given panda");
            Console.WriteLine("connectionlevel - returns the connection level between two pandas");
            Console.WriteLine("areconnected - returns true if two pandas are friends, otherwise false");
            Console.WriteLine("howmanygenderinnetwork - returns the number of gender pandas that in the network are that many level's deep");
            Console.WriteLine("help - prints the full list of commands");
            Console.WriteLine("exit - exits the application");
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t Panda Social Network App\n\n" );
            var network = SocialNetwork.PandaNetwork;

            Console.ForegroundColor = ConsoleColor.Cyan;
            string userInput = null;
            while(true)
            {
                userInput = Console.ReadLine();
                if (userInput.Contains("addpanda"))
                {
                    Panda pandaToAdd = GetPandaInfo();

                    try
                    {
                        network.AddPanda(pandaToAdd);
                        Console.WriteLine("Panda successfully added!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error occured! Cannot add panda to the network!");
                    }
                }
                else if (userInput.Contains("haspanda"))
                {
                    Panda pandaToFind = GetPandaInfo();

                    try
                    {
                        if(network.HasPanda(pandaToFind))
                            Console.WriteLine("The panda is in the network.");
                        else
                            Console.WriteLine("The panda is not in the network.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("An error occured! Cannot search for panda in the network!");
                    }
                }
                else if (userInput.Contains("makefriends"))
                {
                    Console.WriteLine("First panda:");
                    Panda panda1 = GetPandaInfo();
                    Console.WriteLine("Second panda:");
                    Panda panda2 = GetPandaInfo();
                       
                    try
                    {
                        network.MakeFriends(panda1, panda2);
                        Console.WriteLine("The two pandas are now friends.");
                    }
                    catch(PandasAlreadyFriendsException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Unknown error has occurred!");
                    }

                }
                else if (userInput.Contains("arefriends"))
                {
                    Console.WriteLine("First panda:");
                    Panda panda1 = GetPandaInfo();
                    Console.WriteLine("Second panda:");
                    Panda panda2 = GetPandaInfo();

                    try
                    {
                        if(network.AreFriends(panda1, panda2))
                            Console.WriteLine("The two pandas are friends.");
                        else
                            Console.WriteLine("The two pandas are not friends.");
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("An unkown error occurred!");
                    }
                }
                else if (userInput.Contains("friendsof"))
                {
                    Panda panda = GetPandaInfo();
                    foreach (var pandaFriend in network.FriendsOf(panda))
                        Console.WriteLine($"{pandaFriend.Name}, {pandaFriend.Gender}");

                    if(network.FriendsOf(panda).Count == 0)
                        Console.WriteLine("The panda has no friends.");
                }
                else if (userInput.Contains("connectionlevel"))
                {
                    Console.WriteLine("First panda:");
                    Panda panda1 = GetPandaInfo();
                    Console.WriteLine("Second panda:");
                    Panda panda2 = GetPandaInfo();

                    Console.WriteLine("Connection level between the pandas is: " + network.ConnectionLevel(panda1, panda2));
                }
                else if (userInput.Contains("areconnected"))
                {
                    Console.WriteLine("First panda:");
                    Panda panda1 = GetPandaInfo();
                    Console.WriteLine("Second panda:");
                    Panda panda2 = GetPandaInfo();

                    if(network.AreConnected(panda1, panda2))
                        Console.WriteLine("The two pandas are connected.");
                    else
                        Console.WriteLine("The two pandas are not connected.");
                }
                else if (userInput.Contains("howmanygenderinnetwork"))
                {
                    Console.WriteLine("Panda info:");
                    Panda panda = GetPandaInfo();
                    Console.Write("\n\tLevel: ");
                    int level = int.Parse(Console.ReadLine());
                    Console.Write("\tGender");
                    genderInput = Console.ReadLine();
                    if (genderInput.Contains("female"))
                        pandaGender = GenderType.Female;
                    else
                        pandaGender = GenderType.Male;

                    //Console.WriteLine("There are {0} pandas({1}) that are {2} levels deep in the network.", network.HowManyGenderInNetwork(level, panda, pandaGender), pandaGender, level);
                }
                else if (userInput.Contains("help"))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    PrintHelp();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (userInput.Contains("exit"))
                    break;
                else
                    Console.WriteLine("Invalid command! Write 'help' for the full list of commands.");
            }

        }
    }
}
