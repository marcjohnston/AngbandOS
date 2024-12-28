// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestAllScript : Script, ICancellableScriptItem
{
    private RestAllScript(Game game) : base(game) { }

    public bool ExecuteCancellableScriptItem(Item item) // This is run by an item activation
    {
        Game.TryRestoringAbilityScore(AbilityEnum.Strength);
        Game.TryRestoringAbilityScore(AbilityEnum.Intelligence);
        Game.TryRestoringAbilityScore(AbilityEnum.Wisdom);
        Game.TryRestoringAbilityScore(AbilityEnum.Dexterity);
        Game.TryRestoringAbilityScore(AbilityEnum.Constitution);
        Game.TryRestoringAbilityScore(AbilityEnum.Charisma);
        Game.RunScript(nameof(RestoreLevelScript));
        return true;
    }
}
