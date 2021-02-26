using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    class Goule : Character, CharacInterface
    {
        public Goule(string name, int maxAttackNumber)
        {
            Name = name;
            Attack = 80;
            Defense = 80;
            Initiative = 120;
            Damages = 30;
            MaxLife = 250;
            isUndead = true;
            hitRadiantDamages = false;
            hitNecroticDamages = false;
            isBlessed = false;
            isDamned = true;
            isTokyoGhoul = true;
            MaxAttackNumber = maxAttackNumber;
            this.random = new Random(NameToInt() + (int)DateTime.Now.Ticks);
        }

        public override void Counter(int _CounterBonus, Character Attacker)
        {
            base.Counter(_CounterBonus, Attacker);
        }

        public override void Reset()
        {
            base.Reset();
        }

        public override void RoundReset()
        {
            base.RoundReset();
        }

        public override void SelectTargetAndAttack()
        {
            base.SelectTargetAndAttack();
        }

        public override void TakeDamages(int _damages)
        {
            {
                MyLog(Name + " subis " + _damages + " points de dégats.");
                CurrentLife -= _damages;
                if (CurrentLife <= 0)
                {
                    canAttack = false;
                    MyLog(Name + " est mort.");
                }
                else
                {
                    if (this.CurrentLife < _damages && this.CurrentAttackLoose == -1)
                    {
                        int chanceDePasAttaquer = (_damages - this.CurrentLife) * 2 / (this.CurrentLife + _damages) * 100;
                        int percentLostAttack = RollDice();
                        if (percentLostAttack < chanceDePasAttaquer)
                        {
                            CurrentAttackLoose = random.Next(0, 3);
                            switch (CurrentAttackLoose)
                            {
                                case 0:
                                    Console.WriteLine("La goule " + this.Name + " ne peut plus attaquer pour ce round !");
                                    break;
                                case 1:
                                    Console.WriteLine("La goule " + this.Name + " ne peut plus attaquer pour ce round et celui d'après !");
                                    break;
                                case 2:
                                    Console.WriteLine("La goule " + this.Name + " ne peut plus attaquer pour ce round et les 2 d'après!");
                                    break;
                                default:
                                    Console.WriteLine("Tu as atteri en case default !");
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
