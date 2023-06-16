namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class EtherealnessTimedAction : TimedAction
{
    public EtherealnessTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You feel opaque.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You leave the physical world and turn into a wraith-being!");
    }
    protected override void Noticed()
    {
        SaveGame.RedrawMapFlaggedAction.Set();
        SaveGame.UpdateMonstersFlaggedAction.Set();
        SaveGame.UpdateBonusesFlaggedAction.Set();
        base.Noticed();
    }
}
