namespace AngbandOS.Core.Rewards;

[Serializable]
internal class SerUndeReward : Reward
{
    private SerUndeReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"{patron.ShortName} rewards you with an undead servant!");
        if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty, new UndeadMonsterSelector(), false))
        {
            SaveGame.MsgPrint("Nobody ever turns up...");
        }
    }
}