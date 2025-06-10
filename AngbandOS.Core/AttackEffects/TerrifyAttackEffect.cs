// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class TerrifyAttackEffect : AttackEffect
{
    private TerrifyAttackEffect(Game game) : base(game) { }
    public override int Power => 10;
    public override string Description => "terrify";
    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        Game.TakeHit(damage, monster.IndefiniteVisibleName);
        if (Game.HasFearResistance)
        {
            Game.MsgPrint("You stand your ground!");
            obvious = true;
        }
        else if (Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You stand your ground!");
            obvious = true;
        }
        else
        {
            if (Game.FearTimer.AddTimer(3 + Game.DieRoll(monster.Level)))
            {
                obvious = true;
            }
        }
        Game.UpdateSmartLearn(monster, Game.SingletonRepository.Get<SpellResistantDetection>(nameof(FearSpellResistantDetection)));
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = Game.SingletonRepository.Get<Projectile>(nameof(TurnAllProjectile));
    }
}