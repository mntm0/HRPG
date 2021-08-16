using System;

namespace Domain.Model.Battle.State
{
    public class TurnState : BattleState
    {
        public TurnState(BattleContext context) : base(context, false) { }

        public override BattleState Update()
        {
            this.Context.OnTurn();

            Console.WriteLine($"ターン{this.Context.TurnCount}: 開始");

            var turnActors = new TurnActors();
            turnActors.Add(this.Context.Party1.Battlers.ToArray());
            turnActors.Add(this.Context.Party2.Battlers.ToArray());
            foreach (var actor in turnActors)
            {
                actor.OnTurn(this.Context);
            }

            Console.WriteLine($"ターン{this.Context.TurnCount}: 終了");

            var result = this.Context.GetBattleResult();
            switch (result)
            {
                case BattleResult.InBattle:
                    return new TurnState(this.Context);
                case BattleResult.WinParty1:
                    return new WinParty1State(this.Context);
                case BattleResult.WinParty2:
                    return new WinParty2State(this.Context);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
