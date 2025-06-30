// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class HurtAttackEffect : AttackEffect
{
    private HurtAttackEffect(Game game) : base(game) { }
    public override int Power => 60;
    public override string Description => "attack";
    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Normal damage is reduced by armor
        int armorClass = Game.DisplayedBaseArmorClass.IntValue + Game.ArmorClassBonus;
        obvious = true;
        damage -= damage * (armorClass < 150 ? armorClass : 150) / 250;
        Game.TakeHit(damage, monster.IndefiniteVisibleName);
    }

    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        damage -= damage * (armorClass < 150 ? armorClass : 150) / 250;
    }
}