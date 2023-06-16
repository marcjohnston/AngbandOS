namespace AngbandOS.Core.Rewards;

[Serializable]
internal class LoseAblReward : Reward
{
    private LoseAblReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'I grow tired of thee, mortal.'");
        if (Program.Rng.DieRoll(3) == 1 && !(patron.PreferredAbility < 0))
        {
            SaveGame.Player.TryDecreasingAbilityScore(patron.PreferredAbility);
        }
        else
        {
            SaveGame.Player.TryDecreasingAbilityScore(Program.Rng.DieRoll(6) - 1);
        }
    }
}