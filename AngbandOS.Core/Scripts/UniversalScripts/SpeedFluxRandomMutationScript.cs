namespace AngbandOS.Core.Scripts;
internal class SpeedFluxRandomMutationScript : UniversalScript, IGetKey
{
    private SpeedFluxRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(6000) == 1)
        {
            Game.Disturb(false);
            if (base.Game.DieRoll(2) == 1)
            {
                Game.MsgPrint("Everything around you speeds up.");
                if (Game.HasteTimer.Value > 0)
                {
                    Game.HasteTimer.ResetTimer();
                }
                else
                {
                    Game.SlowTimer.AddTimer(base.Game.DieRoll(30) + 10);
                }
            }
            else
            {
                Game.MsgPrint("Everything around you slows down.");
                if (Game.SlowTimer.Value > 0)
                {
                    Game.SlowTimer.ResetTimer();
                }
                else
                {
                    Game.HasteTimer.AddTimer(base.Game.DieRoll(30) + 10);
                }
            }
            Game.MsgPrint(string.Empty);
        }
    }
}