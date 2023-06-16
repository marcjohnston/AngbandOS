namespace AngbandOS.Core.Rewards;

[Serializable]
internal class SummonMReward : Reward
{
    private SummonMReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'My pets, destroy the arrogant mortal!'");
        for (int dummy = 0; dummy < Program.Rng.DieRoll(5) + 1; dummy++)
        {
            SaveGame.Level.SummonSpecific(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty, null);
        }
    }
}