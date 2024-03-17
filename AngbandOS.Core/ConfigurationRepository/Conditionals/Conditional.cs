// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Conditionals;

[Serializable]
internal abstract class Conditional : IGetKey<string>, IBool
{
    protected readonly SaveGame SaveGame;
    protected Conditional(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public abstract bool IsTrue { get; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind() { }

    public string ToJson()
    {
        return "";
    }
}
