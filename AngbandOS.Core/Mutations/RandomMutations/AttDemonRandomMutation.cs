// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class AttDemonRandomMutation : Mutation
{
    public override int Frequency => 2;
    public override string GainMessage => "You start attracting demons.";
    public override string HaveMessage => "You attract demons.";
    public override string LoseMessage => "You stop attracting demons.";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (saveGame.HasAntiMagic || Program.Rng.DieRoll(6666) != 666)
        {
            return;
        }
        bool dSummon;
        if (Program.Rng.DieRoll(6) == 1)
        {
            dSummon = saveGame.SummonSpecificFriendly(saveGame.MapY, saveGame.MapX, saveGame.Difficulty, new DemonMonsterSelector(), true);
        }
        else
        {
            dSummon = saveGame.SummonSpecific(saveGame.MapY, saveGame.MapX, saveGame.Difficulty, new DemonMonsterSelector());
        }
        if (!dSummon)
        {
            return;
        }
        saveGame.MsgPrint("You have attracted a demon!");
        saveGame.Disturb(false);
    }
}