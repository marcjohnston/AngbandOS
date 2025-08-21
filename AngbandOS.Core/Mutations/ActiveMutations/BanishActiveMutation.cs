// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class BanishActiveMutation : Mutation
{
    private BanishActiveMutation(Game game) : base(game) { }
    protected override (string ActivationScriptBindingKey, int MinLevel, string CostExpression, string AbilityBindingKey, int Difficulty)? ActivationBinding => (nameof(BanishMutationScript), 25, "25", nameof(WisdomAbility), 18);

    public override string ActivationSummary(int lvl)
    {
        return lvl < 25 ? "banish evil      (unusable until level 25)" : "banish evil      (cost 25, WIS based)";
    }

    public override int Frequency => 1;
    public override string GainMessage => "You feel a holy wrath fill you.";
    public override string HaveMessage => "You can send evil creatures directly to Hell.";
    public override string LoseMessage => "You no longer feel a holy wrath.";
}