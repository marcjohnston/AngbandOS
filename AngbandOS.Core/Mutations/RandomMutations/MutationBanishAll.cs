// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationBanishAll : Mutation
{
    public override void Initialize()
    {
        Frequency = 2;
        GainMessage = "You feel a terrifying power lurking behind you.";
        HaveMessage = "You sometimes cause nearby creatures to vanish.";
        LoseMessage = "You no longer feel a terrifying power lurking behind you.";
    }

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (Program.Rng.DieRoll(9000) != 1)
        {
            return;
        }
        saveGame.Disturb(false);
        saveGame.MsgPrint("You suddenly feel almost lonely.");
        saveGame.BanishMonsters(100);
        saveGame.MsgPrint(null);
    }
}