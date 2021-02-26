﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProgramProf();
            TestGuerrierInit();
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
            Zombie Simon = new Zombie("Simon", 2);
            Zombie Hector = new Zombie("Hector", 2);
            Zombie Pierre = new Zombie("Pierre", 2);
            Zombie Paul = new Zombie("Paul", 2);
            List<Character> characters = new List<Character> { Simon, Hector, Pierre, Paul };
            FightManager fightManager = new FightManager(characters, 0);
            fightManager.StartCombat();
            Console.ReadLine();
        }
    }
}
