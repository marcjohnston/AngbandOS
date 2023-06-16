// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class MutationLimber : Mutation
{
    public override void Initialize()
    {
        Frequency = 3;
        GainMessage = "Your muscles become limber.";
        HaveMessage = "Your body is very limber (+3 DEX).";
        LoseMessage = "Your muscles stiffen.";
        Group = MutationGroup.Joints;
    }

    public override void OnGain(Genome genome)
    {
        genome.DexterityBonus += 3;
    }

    public override void OnLose(Genome genome)
    {
        genome.DexterityBonus -= 3;
    }
}