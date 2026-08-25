// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

internal class WeighMagicActiveMutation : Mutation
{
    private WeighMagicActiveMutation(Game game) : base(game) { }
    protected override (string ActivationScriptBindingKey, int MinLevel, string CostExpression, string AbilityBindingKey, int Difficulty)? ActivationBinding => (nameof(WeighMagicMutationScript), 6, "6", nameof(IntelligenceAbility), 10);
    public override string Title => "Weigh Magic (A)";
    public override int Frequency => 2;
    public override string GainMessage => "You feel you can better understand the magic around you.";
    public override string HaveMessage => "You can feel the strength of the magics affecting you.";
    public override string LoseMessage => "You no longer sense magic.";
}