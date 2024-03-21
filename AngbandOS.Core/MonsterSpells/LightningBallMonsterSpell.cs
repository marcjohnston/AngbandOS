// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class LightningBallMonsterSpell : BallProjectileMonsterSpell
{
    private LightningBallMonsterSpell(Game game) : base(game) { }
    public override bool UsesLightning => true;
    public override bool IsAttack => true;
    protected override string ActionName => "casts a lightning ball";
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Projectiles.Get(nameof(ElecProjectile));
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Game.DieRoll(monsterLevel * 3 / 2) + 8;
    }
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.SpellResistantDetections.Get(nameof(ElecSpellResistantDetection)) };
}
