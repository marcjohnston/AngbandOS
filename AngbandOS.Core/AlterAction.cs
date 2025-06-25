// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an action that occurs when the player bumps into a feature.
/// </summary>
[Serializable]
internal abstract class AlterAction : IGetKey
{
    protected readonly Game Game;
    protected AlterAction(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>

    public abstract bool Execute(int x, int y);

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
}
