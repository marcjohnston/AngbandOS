// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class ShriekActiveMutation : Mutation
{
    private ShriekActiveMutation(Game game) : base(game) { }
    protected override (string ActivationScriptBindingKey, int MinLevel, string CostExpression, string AbilityBindingKey, int Difficulty)? ActivationBinding => (nameof(ShriekMutationScript), 4, "4", nameof(ConstitutionAbility), 6);

    public override string ActivationSummary(int lvl)
    {
        return lvl < 4 ? "shriek           (unusable until level 4)" : "shriek           (cost 4, CON based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "Your vocal cords get much tougher.";
    public override string HaveMessage => "You can emit a horrible shriek.";
    public override string LoseMessage => "Your vocal cords get much weaker.";
}