// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class FireBodyPassiveMutation : Mutation
{
    public override int Frequency => 2;
    public override string GainMessage => "Your body is enveloped in flames!";
    public override string HaveMessage => "Your body is enveloped in flames.";
    public override string LoseMessage => "Your body is no longer enveloped in flames.";

    public override void OnGain(Genome genome)
    {
        genome.FireHit = true;
    }

    public override void OnLose(Genome genome)
    {
        genome.FireHit = false;
    }
}