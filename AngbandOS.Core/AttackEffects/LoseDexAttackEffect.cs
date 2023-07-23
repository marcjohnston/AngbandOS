// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class LoseDexAttackEffect : AttackEffect
{
    private LoseDexAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 0;
    public override string Description => "reduce dexterity";
    public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        saveGame.TakeHit(damage, monsterDescription);
        if (saveGame.TryDecreasingAbilityScore(Ability.Dexterity))
        {
            obvious = true;
        }
    }
}