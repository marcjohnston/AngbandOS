// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Genders;

[Serializable]
internal abstract class Gender : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected Gender(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public abstract string Title { get; }
    public abstract string Winner { get; }

    public virtual bool CanBeRandomlySelected => true;
    [Obsolete]
    public abstract int Index { get; }
}
