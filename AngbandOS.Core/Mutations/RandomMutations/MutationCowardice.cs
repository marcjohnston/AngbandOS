// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationCowardice : Mutation
{
    public override void Initialize()
    {
        Frequency = 1;
        GainMessage = "You become an incredible coward!";
        HaveMessage = "You are subject to cowardice.";
        LoseMessage = "You are no longer an incredible coward!";
        Group = MutationGroup.Bravery;
    }

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (Program.Rng.DieRoll(3000) != 13)
        {
            return;
        }
        if (saveGame.HasFearResistance || saveGame.TimedHeroism.TurnsRemaining != 0 || saveGame.TimedSuperheroism.TurnsRemaining != 0)
        {
            return;
        }
        saveGame.Disturb(false);
        saveGame.MsgPrint("It's so dark... so scary!");
        saveGame.RedrawAfraidFlaggedAction.Set();
        saveGame.TimedFear.AddTimer(13 + Program.Rng.DieRoll(26));
    }
}