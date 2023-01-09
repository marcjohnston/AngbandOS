// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects
{
    [Serializable]
    internal class EatGoldAttackEffect : BaseAttackEffect
    {
        public override int Power => 5;
        public override string Description => "steal gold";
        public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
        {
            // Steal some money
            saveGame.Player.TakeHit(damage, monsterDescription);
            obvious = true;
            if ((saveGame.Player.TimedParalysis.TimeRemaining == 0 && Program.Rng.RandomLessThan(100) < saveGame.Player.AbilityScores[Ability.Dexterity].DexTheftAvoidance + saveGame.Player.Level) || saveGame.Player.HasAntiTheft)
            {
                saveGame.MsgPrint("You quickly protect your money pouch!");
                if (Program.Rng.RandomLessThan(3) != 0)
                {
                    blinked = true;
                }
            }
            else
            {
                // The amount of gold taken depends on how much you're carrying
                int gold = (saveGame.Player.Gold / 10) + Program.Rng.DieRoll(25);
                if (gold < 2)
                {
                    gold = 2;
                }
                if (gold > 5000)
                {
                    gold = (saveGame.Player.Gold / 20) + Program.Rng.DieRoll(3000);
                }
                if (gold > saveGame.Player.Gold)
                {
                    gold = saveGame.Player.Gold;
                }
                saveGame.Player.Gold -= gold;
                // The monster gets the gold it stole, in case you kill it
                // before leaving the level
                monster.StolenGold += gold;
                // Inform the player what happened
                if (gold <= 0)
                {
                    saveGame.MsgPrint("Nothing was stolen.");
                }
                else if (saveGame.Player.Gold != 0)
                {
                    saveGame.MsgPrint("Your purse feels lighter.");
                    saveGame.MsgPrint($"{gold} coins were stolen!");
                }
                else
                {
                    saveGame.MsgPrint("Your purse feels lighter.");
                    saveGame.MsgPrint("All of your coins were stolen!");
                }
                saveGame.RedrawGoldFlaggedAction.Set();
                blinked = true;
            }
        }
        public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
        {
            // Monsters don't actually steal from other monsters
            pt = null;
            damage = 0;
            if (Program.Rng.DieRoll(2) == 1)
            {
                blinked = true;
            }
        }
    }
}