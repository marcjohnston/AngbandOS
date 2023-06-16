// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class MutationResTime : Mutation
{
    public override void Initialize()
    {
        Frequency = 1;
        GainMessage = "You feel immortal.";
        HaveMessage = "You are protected from the ravages of time.";
        LoseMessage = "You feel all too mortal.";
    }

    public override void OnGain(Genome genome)
    {
        genome.ResTime = true;
    }

    public override void OnLose(Genome genome)
    {
        genome.ResTime = false;
    }
}