namespace Domain.Model.Battle.State
{
    public abstract class BattleState
    {
        public BattleContext Context { get; set; }
        public bool IsEndState { get; }

        public BattleState(BattleContext context, bool isEndState)
        {
            this.Context = context;
            this.IsEndState = isEndState;
        }

        public abstract BattleState Update();
    }
}
