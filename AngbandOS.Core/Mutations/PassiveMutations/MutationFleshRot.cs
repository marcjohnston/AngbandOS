// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class MutationFleshRot : Mutation
{
    public override void Initialize()
    {
        Frequency = 3;
        GainMessage = "Your flesh is afflicted by a rotting disease!";
        HaveMessage = "Your flesh is rotting (-2 CON, -1 CHR).";
        LoseMessage = "Your flesh is no longer afflicted by a rotting disease!";
        Group = MutationGroup.Skin;
    }

    public override void OnGain(Genome genome)
    {
        genome.ConstitutionBonus -= 2;
        genome.CharismaBonus -= 1;
        genome.SuppressRegen = true;
    }

    public override void OnLose(Genome genome)
    {
        genome.ConstitutionBonus += 2;
        genome.CharismaBonus += 1;
        genome.SuppressRegen = false;
    }
}