using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    class Liche : Character, CharacInterface
    {
        public Liche(string name, int maxAttackNumber)
        {
            Name = name;
            Attack = 75;
            Defense = 125;
            Initiative = 80;
            Damages = 50;
            MaxLife = 125;
            isUndead = true;
            hitRadiantDamages = false;
            hitNecroticDamages = true;
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
            base.TakeDamages(_damages);
        }
    }
}
