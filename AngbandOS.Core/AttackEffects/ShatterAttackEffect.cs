﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class ShatterAttackEffect : AttackEffect
{
    private ShatterAttackEffect(Game game) : base(game) { }
    public override int Power => 60;
    public override string Description => "shatter";
    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        obvious = true;
        int armorClass = Game.Bonuses.BaseArmorClass + Game.ArmorClassBonus;
        damage -= damage * (armorClass < 150 ? armorClass : 150) / 250;
        Game.TakeHit(damage, monster.IndefiniteVisibleName);
        // Do an earthquake only if we did enough damage on the hit
        if (damage > 23)
        {
            Game.Earthquake(monster.MapY, monster.MapX, 8);
        }
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        if (damage > 23)
        {
            Game.Earthquake(monster.MapY, monster.MapX, 8);
        }
    }
}