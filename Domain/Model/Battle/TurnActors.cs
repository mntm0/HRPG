using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Model.Battle
{
    public class TurnActors : IEnumerable<ITurnActor>
    {
        private List<ITurnActor> _Actors = new List<ITurnActor>();

        public void Add(params ITurnActor[] actors)
        {
            this._Actors.AddRange(actors);
            this._Actors = this._Actors.OrderByDescending(a => a.GetCompareAGI()).ToList();
        }

        public IEnumerator<ITurnActor> GetEnumerator() => this._Actors.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this._Actors.GetEnumerator();
    }
}
