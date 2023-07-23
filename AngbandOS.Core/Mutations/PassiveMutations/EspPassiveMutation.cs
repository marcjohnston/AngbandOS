// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class EspPassiveMutation : Mutation
{
    public override int Frequency => 2;
    public override string GainMessage => "You develop a telepathic ability!";
    public override string HaveMessage => "You are telepathic.";
    public override string LoseMessage => "You lose your telepathic ability!";

    public override void OnGain(Genome genome)
    {
        genome.Esp = true;
    }

    public override void OnLose(Genome genome)
    {
        genome.Esp = false;
    }
}