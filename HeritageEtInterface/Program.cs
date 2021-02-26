using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    class Program
    {
        public static FightManager fightManager;
        static void Main(string[] args)
        {
            //ProgramProf();
            TestGuerrierInit();
            //TestEcritureLecture();
        }

        public static void ProgramProf()
        {
            //coucou
            Character Simon = new Character("Simon", 100, 100, 50, 100, 200, 2);
            Character Hector = new Character("Hector", 75, 125, 25, 125, 200, 2);
            Character Pierre = new Character("Pierre", 125, 75, 25, 125, 200, 2);
            Character Paul = new Character("Paul", 50, 50, 50, 75, 200, 4);
            List<Character> characters = new List<Character> { Simon, Hector, Pierre, Paul };
            FightManager fightManager = new FightManager(characters, 0);
            fightManager.StartCombat();
            Console.ReadLine();
        }

        public static void TestGuerrierInit()
        {
            //coucou
            Goule Simon = new Goule("Simon", 2);
            Goule Hector = new Goule("Hector", 2);
            Goule Pierre = new Goule("Pierre", 2);
            Goule Paul = new Goule("Paul", 2);
            List<Character> characters = new List<Character> { Simon, Hector, Pierre, Paul };
            fightManager = new FightManager(characters, 0);
            fightManager.StartCombat();
            Console.ReadLine();
        }

        public static void TestEcritureLecture()
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\Users\\Public\\Test.txt");
                //Write a line of text
                sw.WriteLine("Hello World!!");
                //Write a second line of text
                sw.WriteLine("From the StreamWriter class");
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            string line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Public\\Test.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        public static void waitInput()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.S:
                    SaveJson(fightManager);
                    break;
                case ConsoleKey.L:
                    string line;
                    string json = "";
                    try
                    {
                        //Pass the file path and file name to the StreamReader constructor
                        StreamReader sr = new StreamReader("C:\\Users\\Public\\Test.txt");
                        //Read the first line of text
                        line = sr.ReadLine();
                        //Continue to read until you reach end of file
                        while (line != null)
                        {
                            //Read the next line
                            line = sr.ReadLine();
                            json = json + "\n" + line;
                        }
                        //close the file
                        sr.Close();
                        Console.WriteLine(json);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally block.");
                    }
                    LoadJson(json).CombatReStart();
                    break;
                default:
                    fightManager.continueFight = true;
                    break;
            }
        }

        public static string SaveJson(FightManager f)
        {
            //string output = JsonConvert.SerializeObject(c);
            string output = JsonConvert.SerializeObject(f, Formatting.Indented, new JsonSerializerSettings
            {
                //ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                TypeNameHandling = TypeNameHandling.All
                //MetadataPropertyHandling = MetadataPropertyHandling.Default
            });
            /*string output = JsonConvert.SerializeObject(f, Formatting.Indented, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });*/
            Console.WriteLine(output);
            return output;
        }

        public static FightManager LoadJson(string json)
        {
            //string output = JsonConvert.SerializeObject(c);
            /*string output = JsonConvert.SerializeObject(c, Formatting.Indented,new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                });*/
            fightManager = JsonConvert.DeserializeObject<FightManager>(json, new JsonSerializerSettings
            {
                //ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                TypeNameHandling = TypeNameHandling.All
                //MetadataPropertyHandling = MetadataPropertyHandling.Ignore
            });
            return fightManager;
        }
    }
}
