using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    class Robot : Character, CharacInterface
    {
        public Robot(string name, int maxAttackNumber)
        {
            Name = name;
            Attack = 10;
            Defense = 100;
            Initiative = 50;
            Damages = 50;
            MaxLife = 200;
            isUndead = true;
            hitRadiantDamages = false;
            hitNecroticDamages = false;
            isBlessed = false;
            isDamned = false;
            isTokyoGhoul = false;
            MaxAttackNumber = maxAttackNumber;
            this.random = new Random(NameToInt() + (int)DateTime.Now.Ticks);

            Reset();
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
            this.Attack = (int)(this.Attack * 1.5f);
            Console.WriteLine("Le robot " + this.Name + " a une attaque de " + this.Attack.ToString() + " !");
        }

        public override int RollDice()
        {
            return 50;
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
