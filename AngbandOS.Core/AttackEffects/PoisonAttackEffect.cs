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
    private PoisonAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 5;
    public override string Description => "poison";
    public override void ApplyToPlayer(SaveGame saveGame, int monsterLevel, int monsterIndex, int armourClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        // Poison does additional damage
        saveGame.TakeHit(damage, monsterDescription);
        if (!(saveGame.HasPoisonResistance || saveGame.TimedPoisonResistance.TurnsRemaining != 0))
        {
            // Hagarg Ryonis might save us from the additional damage
            if (Program.Rng.DieRoll(10) <= saveGame.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
            {
                saveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (saveGame.TimedPoison.AddTimer(Program.Rng.DieRoll(monsterLevel) + 5))
            {
                obvious = true;
            }
        }
        saveGame.UpdateSmartLearn(monster, SaveGame.SingletonRepository.SpellResistantDetections.Get<PoisSpellResistantDetection>());
    }
    public override void ApplyToMonster(SaveGame saveGame, Monster monster, int armourClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = saveGame.SingletonRepository.Projectiles.Get<PoisProjectile>();
    }
}