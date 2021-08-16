using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Model.Charactor
{
    public class Party : IEnumerable<Battler>
    {
        public List<Battler> Battlers { get; set; }
        public Battler this[int i] => this.Battlers[i];
        public bool IsAllDead => this.All(x => x.IsDead);

        public Party(params Battler[] battlers)
        {
            this.Battlers = battlers.ToList();
        }

        public IEnumerator<Battler> GetEnumerator() => this.Battlers.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.Battlers.GetEnumerator();
    }
}
