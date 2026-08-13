// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

internal class BanishAllRandomMutation : Mutation
{
    private BanishAllRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You feel a terrifying power lurking behind you.";
    public override string HaveMessage => "You sometimes cause nearby creatures to vanish.";
    public override string LoseMessage => "You no longer feel a terrifying power lurking behind you.";
    public override string Title => "Banish Creatures (R)";

    public override void ProcessWorld()
    {
        Game.RunScript(nameof(BanishAllRandomMutationMutationScript));
    }
}