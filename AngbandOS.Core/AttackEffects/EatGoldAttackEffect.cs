// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class EatGoldAttackEffect : AttackEffect
{
    private EatGoldAttackEffect(Game game) : base(game) { }
    public override int Power => 5;
    public override string Description => "steal gold";
    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Steal some money
        Game.TakeHit(damage, monster.IndefiniteVisibleName);
        obvious = true;
        if ((Game.ParalysisTimer.Value == 0 && Game.RandomLessThan(100) < Game.DexterityAbility.DexTheftAvoidance + Game.ExperienceLevel.IntValue) || Game.HasAntiTheft)
        {
            Game.MsgPrint("You quickly protect your money pouch!");
            if (Game.RandomLessThan(3) != 0)
            {
                blinked = true;
            }
        }
        else
        {
            // The amount of gold taken depends on how much you're carrying
            int gold = (Game.Gold.IntValue / 10) + Game.DieRoll(25);
            if (gold < 2)
            {
                gold = 2;
            }
            if (gold > 5000)
            {
                gold = (Game.Gold.IntValue / 20) + Game.DieRoll(3000);
            }
            if (gold > Game.Gold.IntValue)
            {
                gold = Game.Gold.IntValue;
            }
            Game.Gold.IntValue -= gold;
            // The monster gets the gold it stole, in case you kill it
            // before leaving the level
            monster.StolenGold += gold;
            // Inform the player what happened
            if (gold <= 0)
            {
                Game.MsgPrint("Nothing was stolen.");
            }
            else if (Game.Gold.IntValue != 0)
            {
                Game.MsgPrint("Your purse feels lighter.");
                Game.MsgPrint($"{gold} coins were stolen!");
            }
            else
            {
                Game.MsgPrint("Your purse feels lighter.");
                Game.MsgPrint("All of your coins were stolen!");
            }
            blinked = true;
        }
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        // Monsters don't actually steal from other monsters
        pt = null;
        damage = 0;
        if (Game.DieRoll(2) == 1)
        {
            blinked = true;
        }
    }
}