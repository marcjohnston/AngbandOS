namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class PoisonResistanceTimedAction :TimedAction
{
    public PoisonResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You feel less resistant to poison.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You feel resistant to poison!");
    }
}
