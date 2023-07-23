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

    public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        obvious = true;
        saveGame.TakeHit(damage, monsterDescription);
        if (saveGame.HasHoldLife && Program.Rng.RandomLessThan(100) < HoldLifePercentChange)
        {
            saveGame.MsgPrint("You keep hold of your life force!");
        }
        else if (Program.Rng.DieRoll(10) <= saveGame.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
        {
            // Hagarg Ryonis can protect us from experience loss
            saveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
        }
        else
        {
            int d = Program.Rng.DiceRoll(10, 6) + (saveGame.ExperiencePoints / 100 * Constants.MonDrainLife);
            if (saveGame.HasHoldLife)
            {
                saveGame.MsgPrint("You feel your life slipping away!");
                saveGame.LoseExperience(d / 10);
            }
            else
            {
                saveGame.MsgPrint("You feel your life draining away!");
                saveGame.LoseExperience(d);
            }
        }
    }
    public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = saveGame.SingletonRepository.Projectiles.Get<NetherProjectile>();
    }
}