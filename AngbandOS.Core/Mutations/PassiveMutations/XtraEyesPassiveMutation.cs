// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class XtraEyesPassiveMutation : Mutation
{
    public override int Frequency => 3;
    public override string GainMessage => "You grow an extra pair of eyes!";
    public override string HaveMessage => "You have an extra pair of eyes (+15 search).";
    public override string LoseMessage => "Your extra eyes vanish!";

    public override void OnGain(Genome genome)
    {
        genome.SearchBonus += 15;
    }

    public override void OnLose(Genome genome)
    {
        genome.SearchBonus -= 15;
    }
}