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
    public override int Power => 2;
    public override string Description => "reduce all stats";
    public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Try to decrease all six ability scores
        saveGame.TakeHit(damage, monsterDescription);
        if (saveGame.TryDecreasingAbilityScore(Ability.Strength))
        {
            obvious = true;
        }
        if (saveGame.TryDecreasingAbilityScore(Ability.Dexterity))
        {
            obvious = true;
        }
        if (saveGame.TryDecreasingAbilityScore(Ability.Constitution))
        {
            obvious = true;
        }
        if (saveGame.TryDecreasingAbilityScore(Ability.Intelligence))
        {
            obvious = true;
        }
        if (saveGame.TryDecreasingAbilityScore(Ability.Wisdom))
        {
            obvious = true;
        }
        if (saveGame.TryDecreasingAbilityScore(Ability.Charisma))
        {
            obvious = true;
        }
    }
}