using System.Linq;
using System;
using Domain.Model.Battle;
using Domain.Model.Charactor;
using Domain.ValueObject.CharactorStatus;
using Xunit;

namespace UnitTest.Domain.Battle
{
    public class BattleTest
    {
        [Theory]
        [InlineData(10, 10, 10, 7, 7, 7, BattleResult.WinParty1, 3)]
        [InlineData(7, 7, 7, 10, 10, 10, BattleResult.WinParty2, 3)]
        void Battle1vs1(
            double hpa, double atka, double defa, 
            double hpb, double atkb, double defb, 
            BattleResult expectedResult, int expectedTurnCount)
        {
            var a = new TestBattler(hpa, atka, defa);
            var b = new TestBattler(hpb, atkb, defb);

            var context = new BattleContext(
                new Party(a),
                new Party(b)
            );
            var battle = new BattleObject(context);

            battle.Battle();
            var result = context.GetBattleResult();
            Assert.True(battle.State.IsEndState);
            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedTurnCount, context.TurnCount);
        }
    }

    class TestBattler : Battler
    {
        public TestBattler(double hpValue, double atkValue, double defValue)
        {
            this.HP = new HP(hpValue);
            this.ATK = new ATK(atkValue);
            this.DEF = new DEF(defValue);
            this.AGI = new AGI(0);
        }

        public override void OnTurn(BattleContext context)
        {
            // 死んでいる場合とバトル終了の場合は何もしない
            if (this.IsDead) return;
            if (context.GetBattleResult() != BattleResult.InBattle) return;

            // 敵1体を取得して攻撃
            var enemies = context.GetEnemyParty(this);
            var target = enemies.First(x => !x.IsDead);
            this.Attack(target);
        }

        public void Attack(Battler target)
        {
            // ダメージ = 自分のATK - 相手のDEF
            // ※ただし最低でも1ダメージ
            var damage = Math.Max(this.ATK.Value - target.DEF.Value, 1);
            target.HP = new HP(target.HP.Value - damage);
        }
    }
}
