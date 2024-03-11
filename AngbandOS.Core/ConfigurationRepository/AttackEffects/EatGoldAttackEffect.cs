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
    private EatGoldAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 5;
    public override string Description => "steal gold";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Steal some money
        SaveGame.TakeHit(damage, monsterDescription);
        obvious = true;
        if ((SaveGame.TimedParalysis.Value == 0 && SaveGame.RandomLessThan(100) < SaveGame.AbilityScores[Ability.Dexterity].DexTheftAvoidance + SaveGame.ExperienceLevel) || SaveGame.HasAntiTheft)
        {
            SaveGame.MsgPrint("You quickly protect your money pouch!");
            if (SaveGame.RandomLessThan(3) != 0)
            {
                blinked = true;
            }
        }
        else
        {
            // The amount of gold taken depends on how much you're carrying
            int gold = (SaveGame.Gold.Value / 10) + SaveGame.DieRoll(25);
            if (gold < 2)
            {
                gold = 2;
            }
            if (gold > 5000)
            {
                gold = (SaveGame.Gold.Value / 20) + SaveGame.DieRoll(3000);
            }
            if (gold > SaveGame.Gold.Value)
            {
                gold = SaveGame.Gold.Value;
            }
            SaveGame.Gold.Value -= gold;
            // The monster gets the gold it stole, in case you kill it
            // before leaving the level
            monster.StolenGold += gold;
            // Inform the player what happened
            if (gold <= 0)
            {
                SaveGame.MsgPrint("Nothing was stolen.");
            }
            else if (SaveGame.Gold.Value != 0)
            {
                SaveGame.MsgPrint("Your purse feels lighter.");
                SaveGame.MsgPrint($"{gold} coins were stolen!");
            }
            else
            {
                SaveGame.MsgPrint("Your purse feels lighter.");
                SaveGame.MsgPrint("All of your coins were stolen!");
            }
            blinked = true;
        }
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        // Monsters don't actually steal from other monsters
        pt = null;
        damage = 0;
        if (SaveGame.DieRoll(2) == 1)
        {
            blinked = true;
        }
    }
}