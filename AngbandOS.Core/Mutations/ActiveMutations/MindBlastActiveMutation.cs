// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MindBlastActiveMutation : Mutation
{
    private MindBlastActiveMutation(Game game) : base(game) { }
    protected override (string ActivationScriptBindingKey, int MinLevel, string CostExpression, string AbilityBindingKey, int Difficulty)? ActivationBinding => (nameof(MindBlastMutationScript), 5, "3", nameof(WisdomAbility), 15);

    public override string ActivationSummary(int lvl)
    {
        return lvl < 5 ? "mind blast       (unusable until level 5)" : "mind blast       (cost 3, WIS based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You gain the power of Mind Blast.";
    public override string HaveMessage => "You can Mind Blast your enemies.";
    public override string LoseMessage => "You lose the power of Mind Blast.";
}