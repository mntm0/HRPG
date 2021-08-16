using System;

namespace Domain.Model.Battle.State
{
    public class WinParty1State : BattleState
    {
        public WinParty1State(BattleContext context) : base(context, true) { }

        public override BattleState Update()
        {
            Console.WriteLine("1の勝利");
            return null;
        }
    }
}
