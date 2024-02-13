// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal abstract class ExpAttackEffect : AttackEffect
{
    protected ExpAttackEffect(SaveGame saveGame) : base(saveGame) { }
    protected abstract int HoldLifePercentChange { get; }
    protected abstract int DiceCount { get; }

    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        obvious = true;
        SaveGame.TakeHit(damage, monsterDescription);
        if (SaveGame.HasHoldLife && SaveGame.RandomLessThan(100) < HoldLifePercentChange)
        {
            SaveGame.MsgPrint("You keep hold of your life force!");
        }
        else if (SaveGame.DieRoll(10) <= SaveGame.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
        {
            // Hagarg Ryonis can protect us from experience loss
            SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
        }
        else
        {
            int d = SaveGame.DiceRoll(10, 6) + (SaveGame.ExperiencePoints / 100 * Constants.MonDrainLife);
            if (SaveGame.HasHoldLife)
            {
                SaveGame.MsgPrint("You feel your life slipping away!");
                SaveGame.LoseExperience(d / 10);
            }
            else
            {
                SaveGame.MsgPrint("You feel your life draining away!");
                SaveGame.LoseExperience(d);
            }
        }
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = SaveGame.SingletonRepository.Projectiles.Get(nameof(NetherProjectile));
    }
}