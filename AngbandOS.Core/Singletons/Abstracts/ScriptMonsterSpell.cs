// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class ScriptMonsterSpell : MonsterSpell
{
    public ScriptMonsterSpell(Game game) : base(game) { }

    /// <summary>
    /// Returns the binding key for the script to execute when this spell is executed on the player. If null, no script will be executed.
    /// </summary>
    public virtual string? ExecuteOnPlayerScriptBindingKey => null;

    /// <summary>
    /// Returns the script to execute when this spell is executed on the player. If null, no script will be executed.  This property is populated during the Bind phase.
    /// </summary>
    public IScriptMonster? ExecuteOnPlayerScript { get; private set; }

    /// <summary>
    /// Returns the binding key for the script to execute when this spell is executed on a monster. If null, no script will be executed.
    /// </summary>
    public virtual string? ExecuteOnMonsterScriptBindingKey => null;

    /// <summary>
    /// Returns the script to execute when this spell is executed on a monster. If null, no script will be executed.  This property is populated during the Bind phase.
    /// </summary>
    public IScriptMonsterMonster? ExecuteOnMonsterScript { get; private set; }

    public override void Bind(RestoreGameState? restoreGameState)
    {
        base.Bind(restoreGameState);
        ExecuteOnPlayerScript = Game.SingletonRepository.GetNullable<IScriptMonster>(ExecuteOnPlayerScriptBindingKey);
        ExecuteOnMonsterScript = Game.SingletonRepository.GetNullable<IScriptMonsterMonster>(ExecuteOnMonsterScriptBindingKey);
    }

    public sealed override void ExecuteOnPlayer(Monster monster)
    {
        if (ExecuteOnPlayerScript is not null)
        {
            ExecuteOnPlayerScript.ExecuteScriptMonster(monster);
        }
    }

    public sealed override void ExecuteOnMonster(Monster monster, Monster target)
    {
        if (ExecuteOnMonsterScript is not null)
        {
            ExecuteOnMonsterScript.ExecuteScriptMonsterMonster(monster, target);
        }
    }
}
