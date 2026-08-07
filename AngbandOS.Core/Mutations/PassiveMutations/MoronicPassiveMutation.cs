// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

internal class MoronicPassiveMutation : Mutation
{
    private MoronicPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 3;
    public override string GainMessage => "Your brain withers away...";
    public override string HaveMessage => "You are moronic (-4 INT/WIS).";
    public override string LoseMessage => "Your brain reverts to normal";
    public override MutationGroupEnum Group => MutationGroupEnum.Smarts;
    public override (int, string)[]? MinimumExperienceLevelAndEnhancementBindingTuples => new (int, string)[] { 
        (1, nameof(MoronicPassiveMutationItemEnhancement)) 
    };
    public override string Title => "Moronic (P)";
}