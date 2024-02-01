// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class AttDragonRandomMutation : Mutation
{
    private AttDragonRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You start attracting dragons.";
    public override string HaveMessage => "You attract dragons.";
    public override string LoseMessage => "You stop attracting dragons.";

    public override void OnProcessWorld()
    {
        if (SaveGame.HasAntiMagic || base.SaveGame.Rng.DieRoll(3000) != 13)
        {
            return;
        }
        bool dSummon;
        if (base.SaveGame.Rng.DieRoll(5) == 1)
        {
            dSummon = SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(DragonMonsterFilter)), true);
        }
        else
        {
            dSummon = SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(DragonMonsterFilter)));
        }
        if (!dSummon)
        {
            return;
        }
        SaveGame.MsgPrint("You have attracted a dragon!");
        SaveGame.Disturb(false);
    }
}