using System;
using System.Linq;
using Domain.Model.Battle;
using Domain.ValueObject.CharactorStatus;

namespace Domain.Model.Charactor
{
    public abstract class Battler : ITurnActor
    {
        public HP HP { get; set; }
        public MP MP { get; set; }
        public STR STR { get; set; }
        public VIT VIT { get; set; }
        public AGI AGI { get; set; }
        public DEX DEX { get; set; }
        public bool IsDead => this.HP.Value <= 0.0;

        public abstract void OnTurn(BattleContext context);

        public override string ToString()
        {
            var status = $"{HP}, {MP}, {STR}, {VIT}, {AGI}, {DEX}";
            return status;
        }

        public double GetCompareAGI() => this.AGI.Value;
    }
}
