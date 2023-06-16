namespace AngbandOS.Core.MonsterSpells;

/// <summary>
/// Represents a monster spell that fires a projectile without any radius.  Default messages are provided.
/// </summary>
[Serializable]
internal abstract class BoltProjectileMonsterSpell : MonsterSpell
{
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
    /// Returns the projectile that the monster will use when attacking with the spell.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <returns></returns>
    protected abstract Projectile Projectile(SaveGame saveGame);

    /// <summary>
    /// Returns the amount of damage the projectile will incur on the target.
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    protected abstract int Damage(Monster monster);

    /// <summary>
    /// Fires the projectile.  This method allows derived classes to override the projectile parameters.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <param name="who"></param>
    /// <param name="rad"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <param name="dam"></param>
    /// <param name="projectile"></param>
    /// <param name="flg"></param>
    /// <returns></returns>
    protected virtual bool Project(SaveGame saveGame, Monster monster, int rad, int y, int x, int dam, Projectile projectile, ProjectionFlag flg)
    {
        return saveGame.Project(monster.GetMonsterIndex(), rad, saveGame.Player.MapY, saveGame.Player.MapX, dam, projectile, flg);
    }

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        Projectile projectile = Projectile(saveGame);
        int damage = Damage(monster);
        Project(saveGame, monster, 0, saveGame.Player.MapY, saveGame.Player.MapX, damage, projectile, ProjectionFlags);
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        Projectile projectile = Projectile(saveGame);
        int damage = Damage(monster);
        Project(saveGame, monster, 0, target.MapY, target.MapX, damage, projectile, ProjectionFlags);
    }
}
