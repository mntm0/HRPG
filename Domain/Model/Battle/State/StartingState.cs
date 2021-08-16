using System;

namespace Domain.Model.Battle.State
{
    public class StartingState : BattleState
    {
        public StartingState(BattleContext context) : base(context, false) { }

        public override BattleState Update()
        {
            Console.WriteLine("バトル開始");
            this.Context.OnStart();

            return new TurnState(this.Context);
        }
    }
}
