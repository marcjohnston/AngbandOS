// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Properties;

[Serializable]
internal abstract class FlaggedProperty : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    private bool _flag;
    protected FlaggedProperty(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual void Set()
    {
        _flag = true;
    }
    public virtual void Clear()
    {
        _flag = false;
    }
    public virtual bool IsSet => _flag;

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public override string ToString()
    {
        throw new Exception($"ToString override missing for {GetType().Name}.");
    }

    public void Bind() { }

    public string ToJson()
    {
        return "";
    }
}
