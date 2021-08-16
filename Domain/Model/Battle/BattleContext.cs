using System.Linq;
using Domain.Model.Charactor;

namespace Domain.Model.Battle
{
    public class BattleContext
    {
        /// <summary>戦闘に参加するパーティー1(プレイヤーサイド)</summary>
        public Party Party1 { get; }
        /// <summary>戦闘に参加するパーティーB(敵サイド)</summary>
        public Party Party2 { get; }
        /// <summary>現在のターン数</summary>
        public int TurnCount { get; private set; }

        public BattleContext(Party party1, Party party2)
        {
            this.Party1 = party1;
            this.Party2 = party2;
        }

        public void OnStart()
        {
            this.TurnCount = 0;
        }

        public void OnTurn()
        {
            this.TurnCount++;
        }

        /// <summary>バトルの結果を取得する</summary>
        /// <returns>バトルの結果</returns>
        public BattleResult GetBattleResult()
        {
            if (this.Party1.IsAllDead) return BattleResult.WinParty2;
            if (this.Party2.IsAllDead) return BattleResult.WinParty1;
            return BattleResult.InBattle;
        }

        /// <summary>バトラーの敵パーティーを取得する</summary>
        /// <param name="battler">バトラー</param>
        /// <returns>敵パーティー</returns>
        public Party GetEnemyParty(Battler battler)
        {
            if (this.Party1.Contains(battler)) return this.Party2;
            else return this.Party1;
        }
    }
}
