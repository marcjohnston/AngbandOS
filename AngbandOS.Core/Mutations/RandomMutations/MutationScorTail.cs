// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationScorTail : Mutation
{
    public override int Frequency => 2;
    public override string GainMessage => "You grow a scorpion tail!";
    public override string HaveMessage => "You have a scorpion tail (poison, 3d7).";
    public override string LoseMessage => "You lose your scorpion tail!";
    public override int DamageDiceSize => 3;
    public override int DamageDiceNumber => 7;
    public override int EquivalentWeaponWeight => 5;
    public override string AttackDescription => "tail";
    public override MutationAttackType MutationAttackType => MutationAttackType.Poison;

    public override void OnGain(Genome genome)
    {
        genome.NaturalAttacks.Add(this);
    }

    public override void OnLose(Genome genome)
    {
        genome.NaturalAttacks.Remove(this);
    }
}