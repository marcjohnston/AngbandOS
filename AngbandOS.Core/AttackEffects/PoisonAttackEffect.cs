// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class PoisonAttackEffect : AttackEffect
{
    private PoisonAttackEffect(Game game) : base(game) { }
    public override int Power => 5;
    public override string Description => "poison";
    public override void ApplyToPlayer(int monsterLevel, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Poison does additional damage
        Game.TakeHit(damage, monsterDescription);
        if (!(Game.HasPoisonResistance || Game.PoisonResistanceTimer.Value != 0))
        {
            // Hagarg Ryonis might save us from the additional damage
            if (Game.DieRoll(10) <= Game.SingletonRepository.Get<God>(nameof(HagargRyonisGod)).AdjustedFavour)
            {
                Game.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (Game.PoisonTimer.AddTimer(Game.DieRoll(monsterLevel) + 5))
            {
                obvious = true;
            }
        }
        Game.UpdateSmartLearn(monster, Game.SingletonRepository.Get<SpellResistantDetection>(nameof(PoisSpellResistantDetection)));
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = Game.SingletonRepository.Projectiles.Get(nameof(PoisProjectile));
    }
}