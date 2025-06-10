// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class AcidAttackEffect : AttackEffect
{
    private AcidAttackEffect(Game game) : base(game) { }
    public override int Power => 0;
    public override string Description => "shoot acid";
    public override void ApplyToPlayer(Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        obvious = true;
        Game.MsgPrint("You are covered in acid!");
        Game.AcidDam(damage, monster.IndefiniteVisibleName);
        Game.UpdateSmartLearn(monster, Game.SingletonRepository.Get<SpellResistantDetection>(nameof(AcidSpellResistantDetection)));
    }
    public override void ApplyToMonster(Monster monster, int armorClass, ref int damage, ref Projectile? pt, ref bool blinked)
    {
        pt = Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile));
    }
}