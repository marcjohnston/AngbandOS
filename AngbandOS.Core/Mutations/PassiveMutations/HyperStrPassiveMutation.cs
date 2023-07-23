// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class HyperStrPassiveMutation : Mutation
{
    private HyperStrPassiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 3;
    public override string GainMessage => "You turn into a superhuman he-man!";
    public override string HaveMessage => "You are superhumanly strong (+4 STR).";
    public override string LoseMessage => "Your muscles revert to normal.";
    public override MutationGroup Group => MutationGroup.Strength;

    public override void OnGain(Genome genome)
    {
        genome.StrengthBonus += 4;
    }

    public override void OnLose(Genome genome)
    {
        genome.StrengthBonus -= 4;
    }
}