// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationRteleport : Mutation
{
    public override void Initialize()
    {
        Frequency = 1;
        GainMessage = "Your position seems very uncertain...";
        HaveMessage = "You are teleporting randomly.";
        LoseMessage = "Your position seems more certain.";
    }

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (Program.Rng.DieRoll(5000) != 88)
        {
            return;
        }
        if (saveGame.Player.HasNexusResistance || saveGame.Player.HasAntiTeleport)
        {
            return;
        }
        saveGame.Disturb(false);
        saveGame.MsgPrint("Your position suddenly seems very uncertain...");
        saveGame.MsgPrint(null);
        saveGame.TeleportPlayer(40);
    }
}