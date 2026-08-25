// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

internal class TeleportationAtWillActiveMutation : Mutation
{
    private TeleportationAtWillActiveMutation(Game game) : base(game) { }
    protected override (string ActivationScriptBindingKey, int MinLevel, string CostExpression, string AbilityBindingKey, int Difficulty)? ActivationBinding => (nameof(TeleportAtWillMutationScript), 7, "7", nameof(WisdomAbility), 15);
    public override string Title => "Teleportation at Will (A)";
    public override int Frequency => 3;
    public override string GainMessage => "You gain the power of teleportation at will.";
    public override string HaveMessage => "You can teleport at will.";
    public override string LoseMessage => "You lose the power of teleportation at will.";
}