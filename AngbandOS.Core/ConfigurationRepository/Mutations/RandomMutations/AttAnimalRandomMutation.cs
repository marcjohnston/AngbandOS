// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class AttAnimalRandomMutation : Mutation
{
    private AttAnimalRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You start attracting animals.";
    public override string HaveMessage => "You attract animals.";
    public override string LoseMessage => "You stop attracting animals.";

    public override void OnProcessWorld()
    {
        if (SaveGame.HasAntiMagic || base.SaveGame.Rng.DieRoll(7000) != 1)
        {
            return;
        }
        bool aSummon;
        if (base.SaveGame.Rng.DieRoll(3) == 1)
        {
            aSummon = SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(AnimalMonsterFilter)), true);
        }
        else
        {
            aSummon = SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(AnimalMonsterFilter)));
        }
        if (!aSummon)
        {
            return;
        }
        SaveGame.MsgPrint("You have attracted an animal!");
        SaveGame.Disturb(false);
    }
}