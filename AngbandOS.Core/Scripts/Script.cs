// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal abstract class Script : IGetKey
{
    protected readonly SaveGame SaveGame;
    protected Script(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    /// <summary>
    /// Tests an item to determine if it belongs to an IScript and returns a the item casted into that type; or null, if the item doesn't belong to the type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T? TryCast<T>()
    {
        switch (this)
        {
            case T t:
                return t;
            default:
                return default;
        }
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
}