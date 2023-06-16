namespace AngbandOS.Core.Rewards;

[Serializable]
internal class SerMonsReward : Reward
{
    private SerMonsReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"{patron.ShortName} rewards you with a servant!");
        if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty, new NoUniquesMonsterSelector(), false))
        {
            SaveGame.MsgPrint("Nobody ever turns up...");
        }
    }
}