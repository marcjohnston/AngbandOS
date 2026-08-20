// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Mutations.RandomMutations;

internal class ProdManaRandomMutation : Mutation
{
    private ProdManaRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You start producing magical energy uncontrollably.";
    public override string HaveMessage => "You are producing magical energy uncontrollably.";
    public override string LoseMessage => "You stop producing magical energy uncontrollably.";
    public override string Title => "Random Magic (R)";
    public override (int, string)[]? MinimumExperienceLevelAndEnhancementBindingTuples => new (int, string)[]
    {
        (1, nameof(ProdManaRandomMutationItemEnhancement))
    };
}