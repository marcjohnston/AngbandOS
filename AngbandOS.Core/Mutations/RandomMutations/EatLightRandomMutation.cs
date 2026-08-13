// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

internal class EatLightRandomMutation : Mutation
{
    private EatLightRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You feel a strange kinship with Nyogtha.";
    public override string HaveMessage => "You sometimes feed off of the light around you.";
    public override string LoseMessage => "You feel the world's a brighter place.";
    public override string Title => "Eat Light (R)";

    public override void ProcessWorld()
    {
        Game.RunScript(nameof(EatLightRandomMutationScript));
    }
}