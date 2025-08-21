// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class SmellMetActiveMutation : Mutation
{
    private SmellMetActiveMutation(Game game) : base(game) { }
    protected override (string ActivationScriptBindingKey, int MinLevel, string CostExpression, string AbilityBindingKey, int Difficulty)? ActivationBinding => (nameof(SmellMetMutationScript), 3, "2", nameof(IntelligenceAbility), 12);

    public override string ActivationSummary(int lvl)
    {
        return lvl < 3 ? "smell metal      (unusable until level 3)" : "smell metal      (cost 2, INT based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You smell a metallic odor.";
    public override string HaveMessage => "You can smell nearby precious metal.";
    public override string LoseMessage => "You no longer smell a metallic odor.";
}