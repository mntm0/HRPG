using Domain.Model.Battle;
using Domain.Model.Charactor;
using Domain.ValueObject.CharactorStatus;
using Xunit;

namespace UnitTest.Domain.Charactor
{
    public class StatusTest
    {
        [Theory]
        [InlineData(-10, true)]
        [InlineData(0, true)]
        [InlineData(0.1, false)]
        void BattlerIsDead(double hp, bool expected)
        {
            var a = new TestBattler(hp, 0, 0);
            Assert.Equal(expected, a.IsDead);
        }
    }

    class TestBattler : Battler
    {
        public TestBattler(double hpValue, double atkValue, double defValue)
        {
            this.HP = new HP(hpValue);
            this.ATK = new ATK(atkValue);
            this.DEF = new DEF(defValue);
        }

        public override void OnTurn(BattleContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
