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
    protected ExpAttackEffect(Game game) : base(game) { }
    protected abstract int HoldLifePercentChange { get; }
    protected abstract int DiceCount { get; }

    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        obvious = true;
        Game.TakeHit(damage, monster.IndefiniteVisibleName);
        if (Game.HasHoldLife && Game.RandomLessThan(100) < HoldLifePercentChange)
        {
            Game.MsgPrint("You keep hold of your life force!");
        }
        else if (Game.DieRoll(10) <= Game.SingletonRepository.Get<God>(nameof(HagargRyonisGod)).AdjustedFavour)
        {
            // Hagarg Ryonis can protect us from experience loss
            Game.MsgPrint("Hagarg Ryonis's favour protects you!");
        }
        else
        {
            int d = Game.DiceRoll(10, 6) + (Game.ExperiencePoints.IntValue / 100 * Constants.MonDrainLife);
            if (Game.HasHoldLife)
            {
                Game.MsgPrint("You feel your life slipping away!");
                Game.LoseExperience(d / 10);
            }
            else
            {
                Game.MsgPrint("You feel your life draining away!");
                Game.LoseExperience(d);
            }
        }
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = Game.SingletonRepository.Get<Projectile>(nameof(NetherProjectile));
    }
}