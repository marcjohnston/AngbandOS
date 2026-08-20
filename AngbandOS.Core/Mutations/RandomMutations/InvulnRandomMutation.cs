// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

internal class InvulnRandomMutation : Mutation
{
    private InvulnRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You are blessed with fits of invulnerability.";
    public override string HaveMessage => "You occasionally feel invincible.";
    public override string LoseMessage => "You are no longer blessed with fits of invulnerability.";
    public override string Title => "Invulnerability (R)";
    public override (int, string)[]? MinimumExperienceLevelAndEnhancementBindingTuples => new (int, string)[]
    {
        (1, nameof(InvulnRandomMutationItemEnhancement))
    };
}