using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    class Guerrier : Character, CharacInterface
    {
        public Guerrier(string name, int maxAttackNumber)
        {
            Name = name;
            Attack = 100;
            Defense = 100;
            Initiative = 50;
            Damages = 100;
            MaxLife = 200;
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
        }
    }
}
