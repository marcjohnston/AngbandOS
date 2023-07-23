// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class SillyVoiPassiveMutation : Mutation
{
    public override int Frequency => 2;
    public override string GainMessage => "Your voice turns into a ridiculous squeak!";
    public override string HaveMessage => "Your voice is a silly squeak (-4 CHR).";
    public override string LoseMessage => "Your voice returns to normal.";

    public override void OnGain(Genome genome)
    {
        genome.CharismaBonus -= 4;
    }

    public override void OnLose(Genome genome)
    {
        genome.CharismaBonus += 4;
    }
}