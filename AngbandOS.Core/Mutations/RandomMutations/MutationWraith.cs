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
    public override int Frequency => 1;
    public override string GainMessage => "You start to fade in and out of the physical world.";
    public override string HaveMessage => "You fade in and out of physical reality.";
    public override string LoseMessage => "You are firmly in the physical world.";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (saveGame.HasAntiMagic || Program.Rng.DieRoll(3000) != 13)
        {
            return;
        }
        saveGame.Disturb(false);
        saveGame.MsgPrint("You feel insubstantial!");
        saveGame.MsgPrint(null);
        saveGame.TimedEtherealness.AddTimer(Program.Rng.DieRoll(saveGame.ExperienceLevel / 2) + saveGame.ExperienceLevel / 2);
    }
}