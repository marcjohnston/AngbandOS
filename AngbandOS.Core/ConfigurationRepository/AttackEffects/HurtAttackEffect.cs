﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class HurtAttackEffect : AttackEffect
{
    private HurtAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 60;
    public override string Description => "attack";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Normal damage is reduced by armour
        obvious = true;
        damage -= damage * (armourClass < 150 ? armourClass : 150) / 250;
        SaveGame.TakeHit(damage, monsterDescription);
    }

    public override void ApplyToMonster(Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        damage -= damage * (armourClass < 150 ? armourClass : 150) / 250;
    }
}