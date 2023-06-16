// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationAttDragon : Mutation
{
    public override void Initialize()
    {
        Frequency = 1;
        GainMessage = "You start attracting dragons.";
        HaveMessage = "You attract dragons.";
        LoseMessage = "You stop attracting dragons.";
    }

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (saveGame.Player.HasAntiMagic || Program.Rng.DieRoll(3000) != 13)
        {
            return;
        }
        bool dSummon;
        if (Program.Rng.DieRoll(5) == 1)
        {
            dSummon = saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, new DragonMonsterSelector(), true);
        }
        else
        {
            dSummon = saveGame.Level.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, new DragonMonsterSelector());
        }
        if (!dSummon)
        {
            return;
        }
        saveGame.MsgPrint("You have attracted a dragon!");
        saveGame.Disturb(false);
    }
}