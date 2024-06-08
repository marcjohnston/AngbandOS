// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Restore all ability drain and lost experience.
/// </summary>
[Serializable]
internal class RestAllActivation : Activation
{
    private RestAllActivation(Game game) : base(game) { }
    
    public override string? PreActivationMessage => "Your {0} glows a deep green...";

    protected override bool OnActivate(Item item)
    {
        Game.TryRestoringAbilityScore(Ability.Strength);
        Game.TryRestoringAbilityScore(Ability.Intelligence);
        Game.TryRestoringAbilityScore(Ability.Wisdom);
        Game.TryRestoringAbilityScore(Ability.Dexterity);
        Game.TryRestoringAbilityScore(Ability.Constitution);
        Game.TryRestoringAbilityScore(Ability.Charisma);
        Game.RunScript(nameof(RestoreLevelScript));
        return true;
    }

    protected override string RechargeTimeRollExpression => "750";

    public override int Value => 15000;

    public override string Name => "Restore stats and life levels";

}
