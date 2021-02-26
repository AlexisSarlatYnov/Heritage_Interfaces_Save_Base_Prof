using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    class Zombie : Character, CharacInterface
    {
        public Zombie(string name, int maxAttackNumber)
        {
            Name = name;
            Attack = 100;
            Defense = 0;
            Initiative = 20;
            Damages = 50;
            MaxLife = 1000;
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
            Console.WriteLine("Le zombie " + this.Name + " ne peut pas contre-attaquer contre " + Attacker.Name + " !");
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
            base.TakeDamages(_damages);
        }
    }
}
