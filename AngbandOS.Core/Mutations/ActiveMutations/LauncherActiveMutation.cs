// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class LauncherActiveMutation : Mutation
{
    private LauncherActiveMutation(Game game) : base(game) { }
    protected override (string ActivationScriptBindingKey, int MinLevel, string CostExpression, string AbilityBindingKey, int Difficulty)? ActivationBinding => (nameof(LauncherMutationScript), 1, "X", nameof(StrengthAbility), 6);

    public override string ActivationSummary(int lvl)
    {
        return "throw object     (cost lev, STR based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "Your throwing arm feels much stronger.";
    public override string HaveMessage => "You can hurl objects with great force.";
    public override string LoseMessage => "Your throwing arm feels much weaker.";
}