// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class UnPowerAttackEffect : AttackEffect
{
    private UnPowerAttackEffect(Game game) : base(game) { }
    public override int Power => 15;
    public override string Description => "drain charges";
    public override void ApplyToPlayer(int monsterLevel, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Unpower might drain charges from our items
        Game.TakeHit(damage, monsterDescription);
        for (int k = 0; k < 10; k++)
        {
            BaseInventorySlot packInventorySlot = Game.SingletonRepository.InventorySlots.Get(nameof(PackInventorySlot));
            int i = packInventorySlot.WeightedRandom.Choose();
            Item? item = Game.GetInventoryItem(i);
            if (item != null && (item.Category == ItemTypeEnum.Staff || item.Category == ItemTypeEnum.Wand) && item.TypeSpecificValue != 0)
            {
                Game.MsgPrint("Energy drains from your pack!");
                obvious = true;
                int j = monsterLevel;
                monster.Health += j * item.TypeSpecificValue * item.Count;
                if (monster.Health > monster.MaxHealth)
                {
                    monster.Health = monster.MaxHealth;
                }
                if (Game.TrackedMonster.Value != null && Game.TrackedMonster.Value == monster)
                {
                    Game.SingletonRepository.FlaggedActions.Get(nameof(RedrawMonsterHealthFlaggedAction)).Set();
                }
                item.TypeSpecificValue = 0;
                Game.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
                return;
            }
        }
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = Game.SingletonRepository.Projectiles.Get(nameof(DisenchantProjectile));
    }
}