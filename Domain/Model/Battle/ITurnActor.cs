namespace Domain.Model.Battle
{
    public interface ITurnActor
    {
        void OnTurn(BattleContext context);
        double GetCompareAGI();
    }
}
