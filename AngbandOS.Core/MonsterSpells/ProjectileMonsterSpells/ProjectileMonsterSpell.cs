// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

/// <summary>
/// Represents a monster spell that fires a projectile without any radius.  Default messages are provided.
/// </summary>
[Serializable]
internal abstract class ProjectileMonsterSpell : MonsterSpell
{
    protected ProjectileMonsterSpell(Game game) : base(game) { }

    public override void Bind()
    {
        base.Bind();
        Projectile = Game.SingletonRepository.Get<Projectile>(ProjectileKey);
    }

    protected virtual bool ItemProjectionFlag => false;
    protected virtual bool GridProjectionFlag => false;
    protected virtual bool KillProjectionFlag => true;
    protected virtual bool StopProjectionFlag => true;

    /// <summary>
    /// Returns the key for the projectile to use.  This property is used to bind the ProjectileProperty during the binding phase.
    /// </summary>
    protected abstract string ProjectileKey { get; }

    /// <summary>
    /// Returns the projectile that the monster will use when attacking with the spell.  This property is bound using the ProjectileKey property during the bind phase.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    protected Projectile Projectile { get; private set; }

    /// <summary>
    /// Returns the amount of damage the projectile will incur on the target.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    protected abstract int Damage(Monster monster);

    /// <summary>
    /// Fires the projectile.  This method allows derived classes to override the projectile parameters.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="who"></param>
    /// <param name="rad"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <param name="dam"></param>
    /// <param name="projectile"></param>
    /// <param name="flg"></param>
    /// <returns></returns>
    protected virtual IsNoticedEnum Project(Monster monster, int rad, int y, int x, int dam, Projectile projectile, bool grid, bool stop, bool item, bool kill)
    {
        return projectile.Fire(monster.GetMonsterIndex(), rad, Game.MapY.IntValue, Game.MapX.IntValue, dam, grid: grid, stop: stop, item: item, kill: kill, jump: false, beam: false, thru: false, hide: false);
    }

    public override void ExecuteOnPlayer(Monster monster)
    {
        int damage = Damage(monster);
        Project(monster, 0, Game.MapY.IntValue, Game.MapX.IntValue, damage, Projectile, grid: GridProjectionFlag, stop: StopProjectionFlag, kill: KillProjectionFlag, item: ItemProjectionFlag);
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        int damage = Damage(monster);
        Project(monster, 0, target.MapY, target.MapX, damage, Projectile, grid: GridProjectionFlag, stop: StopProjectionFlag, kill: KillProjectionFlag, item: ItemProjectionFlag);
    }
}
