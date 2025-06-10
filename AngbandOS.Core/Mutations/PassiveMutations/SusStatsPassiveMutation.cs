// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class SusStatsPassiveMutation : Mutation
{
    private SusStatsPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You feel like you can recover from anything.";
    public override string HaveMessage => "Your body resists serious damage.";
    public override string LoseMessage => "You no longer feel like you can recover from anything.";

    public override void OnGain()
    {
        Game.SustainAll = true;
    }

    public override void OnLose()
    {
        Game.SustainAll = false;
    }
}