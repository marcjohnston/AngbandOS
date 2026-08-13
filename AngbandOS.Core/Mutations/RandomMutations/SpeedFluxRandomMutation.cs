// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

internal class SpeedFluxRandomMutation : Mutation
{
    private SpeedFluxRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You have become unstuck in time.";
    public override string HaveMessage => "You move faster or slower randomly.";
    public override string LoseMessage => "You are firmly anchored in time.";
    public override string Title => "Random Speed (R)";

    public override void ProcessWorld()
    {
        Game.RunScript(nameof(SpeedFluxRandomMutationMutationScript));
    }
}