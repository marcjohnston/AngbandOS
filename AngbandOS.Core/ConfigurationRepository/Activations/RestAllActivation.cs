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
    private RestAllActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 33;

    public override string? PreActivationMessage => "It glows a deep green...";

    public override bool Activate()
    {
        SaveGame.TryRestoringAbilityScore(Ability.Strength);
        SaveGame.TryRestoringAbilityScore(Ability.Intelligence);
        SaveGame.TryRestoringAbilityScore(Ability.Wisdom);
        SaveGame.TryRestoringAbilityScore(Ability.Dexterity);
        SaveGame.TryRestoringAbilityScore(Ability.Constitution);
        SaveGame.TryRestoringAbilityScore(Ability.Charisma);
        SaveGame.RunScript(nameof(RestoreLevelScript));
        return true;
    }

    public override int RechargeTime() => 750;

    public override int Value => 15000;

    public override string Name => "restore stats and life levels";

    public override string Description => $"{Name} every 750 turns";
}
