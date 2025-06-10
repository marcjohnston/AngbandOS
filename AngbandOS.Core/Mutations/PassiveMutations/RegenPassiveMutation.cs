// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class RegenPassiveMutation : Mutation
{
    private RegenPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You start regenerating.";
    public override string HaveMessage => "You are regenerating.";
    public override string LoseMessage => "You stop regenerating.";

    public override void OnGain()
    {
        Game.Regen = true;
    }

    public override void OnLose()
    {
        Game.Regen = false;
    }
}