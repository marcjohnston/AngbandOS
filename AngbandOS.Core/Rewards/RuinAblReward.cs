namespace AngbandOS.Core.Rewards;

[Serializable]
internal class RuinAblReward : Reward
{
    private RuinAblReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} thunders:");
        SaveGame.MsgPrint("'Thou needst a lesson in humility, mortal!'");
        SaveGame.MsgPrint("You feel less powerful!");
        for (int dummy = 0; dummy < 6; dummy++)
        {
            SaveGame.Player.DecreaseAbilityScore(dummy, 10 + Program.Rng.DieRoll(15), true);
        }
    }
}