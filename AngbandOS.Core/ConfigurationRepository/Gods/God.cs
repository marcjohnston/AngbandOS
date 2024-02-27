// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Pantheon;

[Serializable]
internal abstract class God : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected God(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public abstract string LongName { get; }
    public abstract string ShortName { get; }
    private const int PatronMultiplier = 2;

    private int _favor = 0;
    private bool _isPatron;
    private int _restingFavor = 0;

    public int AdjustedFavour
    {
        get
        {
            if (Favor <= 0)
            {
                return 0;
            }
            var adjusted = IsPatron ? Favor * PatronMultiplier : Favor;
            return Math.Min(adjusted.ToString().Length, 10);
        }
    }

    public int Favor { get => _favor; set => _favor = value; }
    public bool IsPatron { get => _isPatron; internal set => _isPatron = value; }
    public int RestingFavor { get => _restingFavor; set => _restingFavor = value; }

    public abstract string FavorDescription { get; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
    }

    public string ToJson()
    {
        return "";
    }
}