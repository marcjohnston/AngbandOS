// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class ResTimePassiveMutation : Mutation
{
    private ResTimePassiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You feel immortal.";
    public override string HaveMessage => "You are protected from the ravages of time.";
    public override string LoseMessage => "You feel all too mortal.";

    public override void OnGain(Genome genome)
    {
        genome.ResTime = true;
    }

    public override void OnLose(Genome genome)
    {
        genome.ResTime = false;
    }
}