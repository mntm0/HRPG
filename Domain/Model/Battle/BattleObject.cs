using Domain.Model.Battle.State;

namespace Domain.Model.Battle
{
    public class BattleObject
    {
        public BattleContext Context { get; }
        public BattleState State { get; private set; }

        public BattleObject(BattleContext context)
        {
            this.Context = context;
        }

        public void Battle()
        {
            this.State = new StartingState(this.Context);
            while (true)
            {
                var nextState = this.State.Update();
                if (this.State.IsEndState) break;
                this.State = nextState;
            }
        }
    }
}
