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
        public TestBattler(double hpValue, double strValue, double vitValue)
        {
            this.HP = new HP(hpValue);
            this.STR = new STR(strValue);
            this.VIT = new VIT(vitValue);
        }

        public override void OnTurn(BattleContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
