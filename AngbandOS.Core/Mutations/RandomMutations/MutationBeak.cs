// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationBeak : Mutation
{
    public override void Initialize()
    {
        Frequency = 2;
        GainMessage = "Your mouth turns into a sharp, powerful beak!";
        HaveMessage = "You have a beak (dam. 2d4).";
        LoseMessage = "Your mouth reverts to normal!";
        Group = MutationGroup.Mouth;
        DamageDiceSize = 2;
        DamageDiceNumber = 4;
        EquivalentWeaponWeight = 5;
        AttackDescription = "beak";
    }

    public override void OnGain(Genome genome)
    {
        genome.NaturalAttacks.Add(this);
    }

    public override void OnLose(Genome genome)
    {
        genome.NaturalAttacks.Remove(this);
    }
}