using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    class FightManager
    {
        public List<Character> charactersList = new List<Character>();
        public int round = 0;
        public DateTime startTime;
        public int StartNumberFighter = 0;

        public FightManager(List<Character> charactersList, int round)
        {
            this.charactersList = charactersList;
            this.round = round;
            foreach (Character character in charactersList)
            {
                character.SetFightManager(this);
            }
        }

        public void StartCombat()
        {
            startTime = DateTime.Now;
            round = 0;
            StartNumberFighter = charactersList.Count;
            //faire en sorte que les personnages ne soient pas blessé avant le début du combat
            foreach (Character personnage in charactersList)
            {
                personnage.Reset();
            }
            MyLog("----- Debut du combat -----");
            //a commenter pour enchainer les rounds à la main
            //faire des rounds tant qu'il y a plus d'un combattant vivant
            while (charactersList.Count > 1)
            {
                StartRound();
            }
        }

        public void StartRound()
        {
            round++;
            MyLog("---------- Round " + round + " ----------");

            foreach (Character p in charactersList)
            {
                //reinitialiser les variables nécessaires
                p.RoundReset();
                //calculer l'initiative pour ce round
                p.CalculateInitiative();
            }

            //classer les différents personnage en fonction de initiative
            charactersList = charactersList.OrderByDescending(personnage => personnage.CurrentInitiative).ToList();

            for (int i = 0; i < charactersList.Count; i++)
            {
                //on stocke le personnage dans une variable pour éviter d'accéder inutilement à la liste
                Character currentPersonnage = charactersList[i];
                //si le personnage peut attaquer et qu'il est vivant
                if (currentPersonnage.canAttack && currentPersonnage.CurrentAttackNumber > 0 && currentPersonnage.CurrentLife > 0)
                {
                    while (currentPersonnage.CurrentAttackNumber > 0 && currentPersonnage.canAttack && currentPersonnage.CurrentAttackLoose == -1)
                    {
                        //choisir une cible puis attaquer
                        currentPersonnage.SelectTargetAndAttack();
                    }
                }
                else if (currentPersonnage.CurrentAttackNumber == 0 && currentPersonnage.CurrentLife > 0)
                {
                    MyLog(currentPersonnage.Name + " n'a plus d'attaques disponibles et ne peut rien faire pendant ce round.");
                }
            }

            int nbMorts = 0;

            foreach (Character p in charactersList)
            {
                if(p.CurrentLife <= 0)
                {
                    nbMorts++;
                }
            }

            //on fait une deuxième boucle sur les personnage pour retirer les morts de la liste
            //on fait cette boucle de la fin vers le début pour éviter les problèmes que l'on rencontre quand on modifie 
            //une liste sur laquelle on est en train d'itérer
            for (int i = charactersList.Count - 1; i >= 0; i--)
            {
                //on stocke le personnage dans une variable pour éviter d'accéder inutilement à la liste
                Character currentPersonnage = charactersList[i];
                if (currentPersonnage.CurrentLife <= 0)
                {
                    charactersList.Remove(currentPersonnage);
                }
            }

            foreach (Character p in charactersList)
            {

                p.SetCurrentAttackLoose();
                if(p.isTokyoGhoul == true && nbMorts > 0)
                {
                    Random rand = new Random();
                    for (int i = 0; i < nbMorts; i++)
                    {
                        int pvRecup = rand.Next(50, 101);
                        p.CurrentLife = p.CurrentLife + pvRecup;
                        Console.WriteLine(p.Name + " a recup " + pvRecup.ToString() + " pvs car c'est un charognard !");
                    }
                    if(p.CurrentLife >= p.MaxLife)
                    {
                        p.CurrentLife = p.MaxLife;
                        Console.WriteLine(p.Name + " a recup toute sa vie car c'est un charognard !");
                    }
                    
                }

            }

            MyLog("---------- Fin du round ----------");

            if (charactersList.Count < 2)
            {
                MyLog(charactersList[0].Name + " remporte le battle royale");
            }
        }

        public void MyLog(string text)
        {
            Console.WriteLine(text);
        }
    }
}
