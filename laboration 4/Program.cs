using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace laboration_4
{
    internal class Program
    {
        public static List<Person> listPerson = new List<Person>();
        static void Main(string[] args)
        {
            bool exitBool = false;
            int menuSelector = 0;

            while (exitBool == false)
            {
                try
                {
                    Console.WriteLine(

                    "Välj ett av alternativen: " +
                    "\n1.) Lägg till person" +
                    "\n2.) Visa alla personer" +
                    "\n3.) Avslutar");
                    menuSelector = int.Parse(Console.ReadLine());
                }
                
                catch (Exception e)
                { 
                    Console.WriteLine(e.Message);
                }
                switch (menuSelector)
                {
                    case 1:
                        AddPerson();
                        break;

                    case 2:
                        if (listPerson == null ||  listPerson.Count == 0)
                        {
                            Console.WriteLine("Tyvärr det finns inga registrerade personer, testa igen!");
                        }
                        else
                        {

                            ListPersons();
                        }
                            
                        break;
                    case 3:
                        exitBool = true;
                        break;
                        
                        default:
                        Console.WriteLine("OBS! du måste ange ett nummer mellan 1-3\n");
                        break;
                }
            }
        }
        static void AddPerson()
        {
            Hair hair = new Hair { };
            DateTime inputDate = DateTime.Today;
            bool wrongInput = true;
            int hairChoice = 0;
            string eyesColor = " ";

            int userChoice = 1;
            Console.WriteLine("Vad heter personen?");
            String name = Console.ReadLine();
            do
            {
                try
                {
                    Console.WriteLine("Vilket kön har personen? \n1.Man \n2.Kvinna \n3.Ickebinär \n4.Annan");
                    bool parse;
                    parse = int.TryParse(Console.ReadLine(), out userChoice);

                    if (parse == false || userChoice == 0 || userChoice < 0 || userChoice > 4)
                    {
                        Console.WriteLine("OBS! Välj en siffa mellan 1-4");
                        wrongInput = false;
                    }
                    else
                    {
                        wrongInput = true;
                    }
                    
                }
                catch
                {
                    Console.WriteLine("OBS! Skriv med siffror tack :)");
                    wrongInput = true;
                }
            } while (wrongInput == false);

            bool wrongdate = false;
            do
            {
                try
                {
                    Console.WriteLine("När fyller du år?,skriv i YYYY-MM-DD format");
                    inputDate = DateTime.Parse(Console.ReadLine());
                    wrongdate = false;
                }
                catch
                {
                    Console.WriteLine("OBS! Skriv med siffror och glöm inte bindesträck (-) :)");
                    wrongdate = true;
                }

            } while (wrongdate == true);

            Gender genderinput = Gender.Male;
            switch (userChoice)
            {
                case 1:
                    genderinput = Gender.Male;
                    break;
                case 2:
                    genderinput = Gender.Female;
                    break;
                case 3:
                    genderinput = Gender.Nonbinary;
                    break;
                case 4:
                    genderinput = Gender.Other;

                    break;
            }

            bool wronghair = false;
            do
            {
                try
                {

                    Console.WriteLine("Vad har du för hårfärg?");
                    hair.color = Console.ReadLine();
                    wronghair = false;
                    if (hair.color.All(Char.IsDigit)){
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("OBS! Skriv någon färg istället.");
                    wronghair = true;
                }

            } while (wronghair == true);
      
            bool hairWrongInput;
            do
            {
                try
                {
                    Console.WriteLine("Vad har du för hårlängd? ange i cm :)");
                    hairChoice = int.Parse(Console.ReadLine());
                    hairWrongInput = false;
                }
                catch
                {
                    Console.WriteLine("OBS! Skriv med siffror Tack :)");
                    hairWrongInput = true;
                }
            } while (hairWrongInput == true);
         
            bool wrongeyas;
            do
            {
                try
                {
                    Console.WriteLine("Vad har du för ögonfärg?");
                    eyesColor = Console.ReadLine();
                    wrongeyas = false;
                    if (eyesColor.All(Char.IsDigit))
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("OBS! Skriv med bokstäver Tack:)");
                    wrongeyas = true;
                }
            } while (wrongeyas == true);
            hair.length = hairChoice;

            Person person = new Person(name,inputDate, genderinput,hair, eyesColor);
            listPerson.Add(person);
        }
        static void ListPersons()
        {
            foreach (Person person in listPerson)
            {
                Console.WriteLine(person.ToString()+"\n");
            }
        }
    }
}