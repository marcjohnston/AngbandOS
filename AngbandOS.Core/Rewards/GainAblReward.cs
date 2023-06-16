namespace AngbandOS.Core.Rewards;

[Serializable]
internal class GainAblReward : Reward
{
    private GainAblReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} rings out:");
        SaveGame.MsgPrint("'Stay, mortal, and let me mould thee.'");
        if (Program.Rng.DieRoll(3) == 1 && !(patron.PreferredAbility < 0))
        {
            SaveGame.Player.TryIncreasingAbilityScore(patron.PreferredAbility);
        }
        else
        {
            SaveGame.Player.TryIncreasingAbilityScore(Program.Rng.DieRoll(6) - 1);
        }
    }
}