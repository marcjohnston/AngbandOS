// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Properties;

[Serializable]
internal abstract class Property<T>
{
    protected readonly SaveGame SaveGame;
    protected Property(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public abstract T Value { get; set; }

    public override string ToString()
    {
        throw new Exception("Missing ToString override.");
    }
}

[Serializable]
internal class GoldIntProperty : Property<int>
{
    public GoldIntProperty(SaveGame saveGame) : base(saveGame) { }

    private int _value;
    public override int Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawGoldFlaggedAction)).Set();
        }
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}
