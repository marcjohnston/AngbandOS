// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

internal class AlcoholRandomMutation : Mutation
{
    private AlcoholRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "Your body starts producing alcohol!";
    public override string HaveMessage => "Your body produces alcohol.";
    public override string LoseMessage => "Your body stops producing alcohol!";
    public override string Title => "Alcohol (R)";
    public override (int, string)[]? MinimumExperienceLevelAndEnhancementBindingTuples => new (int, string)[] 
    {
        (1, nameof(AlcoholRandomMutationItemEnhancement))
    };
}