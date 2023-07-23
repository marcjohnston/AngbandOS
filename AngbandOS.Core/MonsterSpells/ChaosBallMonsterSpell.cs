// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ChaosBallMonsterSpell : BallProjectileMonsterSpell
{
    private ChaosBallMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    /// <summary>
    /// Returns a message that the monster is mumbling something frighteningly.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public override string? VsPlayerBlindMessage => $"You hear someone mumble frighteningly.";

    public override bool IsInnate => true;
    public override bool UsesChaos => true;
    public override bool IsAttack => true;
    protected override string ActionName => "invokes raw chaos";
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<ChaosProjectile>();
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return (monsterLevel * 2) + SaveGame.Rng.DiceRoll(10, 10);
    }
    protected override int Radius => 4;
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { SaveGame.SingletonRepository.SpellResistantDetections.Get<ChaosSpellResistantDetection>() };
}
