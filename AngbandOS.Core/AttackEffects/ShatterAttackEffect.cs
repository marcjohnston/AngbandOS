// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class ShatterAttackEffect : BaseAttackEffect
{
    public override int Power => 60;
    public override string Description => "shatter";
    public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        obvious = true;
        damage -= damage * (armourClass < 150 ? armourClass : 150) / 250;
        saveGame.Player.TakeHit(damage, monsterDescription);
        // Do an earthquake only if we did enough damage on the hit
        if (damage > 23)
        {
            saveGame.Earthquake(monster.MapY, monster.MapX, 8);
        }
    }
    public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        if (damage > 23)
        {
            saveGame.Earthquake(monster.MapY, monster.MapX, 8);
        }
    }
}