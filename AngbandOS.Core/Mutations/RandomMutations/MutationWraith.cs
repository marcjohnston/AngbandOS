// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationWraith : Mutation
{
    public override void Initialize()
    {
        Frequency = 1;
        GainMessage = "You start to fade in and out of the physical world.";
        HaveMessage = "You fade in and out of physical reality.";
        LoseMessage = "You are firmly in the physical world.";
    }

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (saveGame.Player.HasAntiMagic || Program.Rng.DieRoll(3000) != 13)
        {
            return;
        }
        saveGame.Disturb(false);
        saveGame.MsgPrint("You feel insubstantial!");
        saveGame.MsgPrint(null);
        saveGame.Player.TimedEtherealness.AddTimer(Program.Rng.DieRoll(saveGame.Player.ExperienceLevel / 2) + saveGame.Player.ExperienceLevel / 2);
    }
}