// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class MutationSillyVoi : Mutation
{
    public override void Initialize()
    {
        Frequency = 2;
        GainMessage = "Your voice turns into a ridiculous squeak!";
        HaveMessage = "Your voice is a silly squeak (-4 CHR).";
        LoseMessage = "Your voice returns to normal.";
    }

    public override void OnGain(Genome genome)
    {
        genome.CharismaBonus -= 4;
    }

    public override void OnLose(Genome genome)
    {
        genome.CharismaBonus += 4;
    }
}