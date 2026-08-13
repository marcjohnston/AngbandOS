namespace AngbandOS.Core.Scripts;
internal class WeirdMindRandomMutationMutationScript : UniversalScript, IGetKey
{
    private WeirdMindRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(3000) != 1)
        {
            return;
        }
        if (Game.TelepathyTimer.Value > 0)
        {
            Game.MsgPrint("Your mind feels cloudy!");
            Game.RunScript(nameof(TelepathyResetTimerScript));
        }
        else
        {
            Game.MsgPrint("Your mind expands!");
            Game.RunScript(nameof(Telepathy1xTimerScript));
        }
    }
}