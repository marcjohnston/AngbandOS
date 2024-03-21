// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class DarknessMonsterSpell : BallProjectileMonsterSpell
{
    private DarknessMonsterSpell(Game game) : base(game) { }
    public override bool Annoys => true;

    /// <summary>
    /// Returns the grid and kill projectile flags.
    /// </summary>
    protected override ProjectionFlag ProjectionFlags => ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectKill;

    protected override string ActionName => "gestures in shadow";
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Projectiles.Get(nameof(AcidProjectile));
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Game.DieRoll(monsterLevel * 3) + 15;
    }
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.SpellResistantDetections.Get(nameof(AcidSpellResistantDetection)) };

    public override void ExecuteOnPlayer(Game game, Monster monster)
    {
        base.ExecuteOnPlayer(game, monster);
        game.UnlightArea(0, 3);
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
        base.ExecuteOnMonster(game, monster, target);
        game.UnlightRoom(target.MapY, target.MapX);
    }
}
