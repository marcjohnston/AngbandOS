namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class ProtectionFromEvilTimedAction : TimedAction
{
    public ProtectionFromEvilTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You no longer feel safe from evil.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You feel safe from evil!");
    }
}
