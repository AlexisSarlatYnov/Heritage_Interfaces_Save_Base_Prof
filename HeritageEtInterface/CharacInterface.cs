using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeritageEtInterface
{
    interface CharacInterface
    {
        /*int CurrentCounterBonus { get; }
        int CurrentLife { get; }
        int CurrentInitiative { get; }
        int CurrentAttackNumber { get; }
        bool canAttack { get; }
        int MaxAttackNumber { get; }*/

        void Reset();
        void RoundReset();
        void Counter(int _CounterBonus, Character Attacker);
        void TakeDamages(int _damages);
        void SelectTargetAndAttack();

    }
}
