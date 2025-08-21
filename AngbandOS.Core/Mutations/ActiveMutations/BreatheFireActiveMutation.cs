// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class BreatheFireActiveMutation : Mutation
{
    private BreatheFireActiveMutation(Game game) : base(game) { }
    protected override (string ActivationScriptBindingKey, int MinLevel, string CostExpression, string AbilityBindingKey, int Difficulty)? ActivationBinding => (nameof(BrFireMutationScript), 20, "X", nameof(ConstitutionAbility), 18);

    public override string ActivationSummary(int lvl)
    {
        return lvl < 20
            ? "fire breath      (unusable until level 20)"
            : $"fire breath      (cost {lvl}, dam {lvl * 2}, CON based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You gain the ability to breathe fire.";
    public override string HaveMessage => "You can breathe fire (dam lvl * 2).";
    public override string LoseMessage => "You lose the ability to breathe fire.";
}