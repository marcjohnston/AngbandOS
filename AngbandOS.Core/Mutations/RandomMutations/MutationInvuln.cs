// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationInvuln : Mutation
{
    public override void Initialize()
    {
        Frequency = 1;
        GainMessage = "You are blessed with fits of invulnerability.";
        HaveMessage = "You occasionally feel invincible.";
        LoseMessage = "You are no longer blessed with fits of invulnerability.";
    }

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (!saveGame.HasAntiMagic && Program.Rng.DieRoll(5000) == 1)
        {
            saveGame.Disturb(false);
            saveGame.MsgPrint("You feel invincible!");
            saveGame.MsgPrint(null);
            saveGame.TimedInvulnerability.AddTimer(Program.Rng.DieRoll(8) + 8);
        }
    }
}