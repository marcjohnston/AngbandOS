// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;


[Serializable]
internal class ShardBallMonsterSpell : BallProjectileMonsterSpell
{
    private ShardBallMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool IsInnate => true;
    public override bool UsesShards => true;
    public override bool IsAttack => true;
    protected override string ActionName => "casts a shard ball";
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<ShardProjectile>();
    protected override int Damage(Monster monster) => monster.Health / 4 > 800 ? 800 : monster.Health / 4;
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { SaveGame.SingletonRepository.SpellResistantDetections.Get<ShardSpellResistantDetection>() };
}
