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
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Steal some money
        SaveGame.TakeHit(damage, monsterDescription);
        obvious = true;
        if ((SaveGame.TimedParalysis.TurnsRemaining == 0 && SaveGame.Rng.RandomLessThan(100) < SaveGame.AbilityScores[Ability.Dexterity].DexTheftAvoidance + SaveGame.ExperienceLevel) || SaveGame.HasAntiTheft)
        {
            SaveGame.MsgPrint("You quickly protect your money pouch!");
            if (SaveGame.Rng.RandomLessThan(3) != 0)
            {
                blinked = true;
            }
        }
        else
        {
            // The amount of gold taken depends on how much you're carrying
            int gold = (SaveGame.Gold / 10) + SaveGame.Rng.DieRoll(25);
            if (gold < 2)
            {
                gold = 2;
            }
            if (gold > 5000)
            {
                gold = (SaveGame.Gold / 20) + SaveGame.Rng.DieRoll(3000);
            }
            if (gold > SaveGame.Gold)
            {
                gold = SaveGame.Gold;
            }
            SaveGame.Gold -= gold;
            // The monster gets the gold it stole, in case you kill it
            // before leaving the level
            monster.StolenGold += gold;
            // Inform the player what happened
            if (gold <= 0)
            {
                SaveGame.MsgPrint("Nothing was stolen.");
            }
            else if (SaveGame.Gold != 0)
            {
                SaveGame.MsgPrint("Your purse feels lighter.");
                SaveGame.MsgPrint($"{gold} coins were stolen!");
            }
            else
            {
                SaveGame.MsgPrint("Your purse feels lighter.");
                SaveGame.MsgPrint("All of your coins were stolen!");
            }
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawGoldFlaggedAction)).Set();
            blinked = true;
        }
    }
    public override void ApplyToMonster(Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        // Monsters don't actually steal from other monsters
        pt = null;
        damage = 0;
        if (SaveGame.Rng.DieRoll(2) == 1)
        {
            blinked = true;
        }
    }
}