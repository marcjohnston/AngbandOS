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

    /// <summary>
    /// Returns a message that the monster performed an action specified by the protected ActionName method.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} {ActionName}.";

    /// <summary>
    /// Returns a message that the monster performed an action specified by the protected ActionName method against another monster.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <param name="targetName"></param>
    /// <returns></returns>
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} {ActionName} at {target.Name}";

    /// <summary>
    /// Returns the name of the action.  This action name is being used to generate the messages rendered to the player.  If both the
    /// VsPlayer and VsMonster messages are overridden, this property is ignored.  This property needs to follow the following syntax:
    /// 
    /// {verb noun}
    /// 
    /// Examples: casts an arrow, invokes raw chaos
    /// </summary>
    protected abstract string ActionName { get; }

    /// <summary>
    /// Returns the flags used by the projectile.  Defaults to stop and kill.
    /// </summary>
    protected virtual ProjectionFlag ProjectionFlags => ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;

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
    protected virtual bool Project(Monster monster, int rad, int y, int x, int dam, Projectile projectile, ProjectionFlag flg)
    {
        return Game.Project(monster.GetMonsterIndex(), rad, Game.MapY.IntValue, Game.MapX.IntValue, dam, projectile, flg);
    }

    public override void ExecuteOnPlayer(Monster monster)
    {
        int damage = Damage(monster);
        Project(monster, 0, Game.MapY.IntValue, Game.MapX.IntValue, damage, Projectile, ProjectionFlags);
    }

    public override void ExecuteOnMonster(Monster monster, Monster target)
    {
        int damage = Damage(monster);
        Project(monster, 0, target.MapY, target.MapX, damage, Projectile, ProjectionFlags);
    }
}
