using System;

namespace Domain.Model.Battle.State
{
    public class WinParty2State : BattleState
    {
        public WinParty2State(BattleContext context) : base(context, true) { }

        public override BattleState Update()
        {
            Console.WriteLine("2の勝利");
            return null;
        }
    }
}
