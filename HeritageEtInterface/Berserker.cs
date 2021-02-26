using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    class Berserker : Character, CharacInterface
    {
        int pvPerdus = 0;
        public Berserker(string name, int maxAttackNumber)
        {
            Name = name;
            Attack = 100;
            Defense = 100;
            Initiative = 80;
            Damages = 20;
            MaxLife = 300;
            isUndead = false;
            hitRadiantDamages = false;
            hitNecroticDamages = false;
            isBlessed = false;
            isDamned = false;
            isTokyoGhoul = false;
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
            base.TakeDamages(_damages);
            if(this.CurrentLife > 0)
            {            
                this.pvPerdus = this.pvPerdus + _damages;
                this.Attack = 20 + this.pvPerdus;
                Console.WriteLine("Le berserker " + this.Name + " a une attaque de " + this.Attack.ToString() + " !");
                this.CurrentAttackLoose = -1;
            }
        }


    }
}
