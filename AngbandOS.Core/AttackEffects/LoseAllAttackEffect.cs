// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class LoseAllAttackEffect : AttackEffect
{
    private LoseAllAttackEffect(Game game) : base(game) { }
    public override int Power => 2;
    public override string Description => "reduce all stats";
    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Try to decrease all six ability scores
        Game.TakeHit(damage, monster.IndefiniteVisibleName);
        if (Game.TryDecreasingAbilityScore(AbilityEnum.Strength))
        {
            obvious = true;
        }
        if (Game.TryDecreasingAbilityScore(AbilityEnum.Dexterity))
        {
            obvious = true;
        }
        if (Game.TryDecreasingAbilityScore(AbilityEnum.Constitution))
        {
            obvious = true;
        }
        if (Game.TryDecreasingAbilityScore(AbilityEnum.Intelligence))
        {
            obvious = true;
        }
        if (Game.TryDecreasingAbilityScore(AbilityEnum.Wisdom))
        {
            obvious = true;
        }
        if (Game.TryDecreasingAbilityScore(AbilityEnum.Charisma))
        {
            obvious = true;
        }
    }
}