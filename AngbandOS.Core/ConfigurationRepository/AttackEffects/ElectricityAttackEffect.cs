﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class ElectricityAttackEffect : AttackEffect
{
    private ElectricityAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 10;
    public override string Description => "electrocute";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        obvious = true;
        SaveGame.MsgPrint("You are struck by electricity!");
        SaveGame.ElecDam(damage, monsterDescription);
        SaveGame.UpdateSmartLearn(monster, SaveGame.SingletonRepository.SpellResistantDetections.Get<ElecSpellResistantDetection>());
    }
    public override void ApplyToMonster(Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>();
    }
}