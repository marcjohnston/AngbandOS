namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class FireResistanceTimedAction : TimedAction
{
    public FireResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You feel less resistant to fire.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You feel resistant to fire!");
    }
}
