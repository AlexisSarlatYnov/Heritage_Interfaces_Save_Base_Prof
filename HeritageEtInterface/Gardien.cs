using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    class Gardien : Character, CharacInterface
    {
        public Gardien(string name, int maxAttackNumber)
        {
            Name = name;
            Attack = 50;
            Defense = 150;
            Initiative = 50;
            Damages = 50;
            MaxLife = 150;
            isUndead = false;
            hitRadiantDamages = true;
            hitNecroticDamages = false;
            isBlessed = true;
            isDamned = false;
            isTokyoGhoul = false;
            MaxAttackNumber = maxAttackNumber;
            this.random = new Random(NameToInt() + (int)DateTime.Now.Ticks);
        }
        public override void Counter(int _CounterBonus, Character Attacker)
        {
            _CounterBonus = _CounterBonus * 2;
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
