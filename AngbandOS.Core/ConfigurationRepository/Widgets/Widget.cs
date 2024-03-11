// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class Widget : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected Widget(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public bool Invalid { get; private set; }
    public void Invalidate()
    {
        Invalid = true;
    }

    public abstract int X { get; }
    public abstract int Y { get; }
    public abstract int Width { get; }
    public abstract int Height { get; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public virtual void Bind()
    {
    }

    public string ToJson()
    {
        return "";
    }

    protected abstract void OnDraw();
    public void Draw()
    {
        OnDraw();
        Invalid = false;
    }
}
