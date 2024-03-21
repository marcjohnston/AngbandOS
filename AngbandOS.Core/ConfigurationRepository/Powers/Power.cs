// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Powers;

[Serializable]
internal abstract class Power : IGetKey
{
    protected readonly SaveGame SaveGame;
    protected Power(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    public abstract void Activate(Item item);
    public virtual bool IsResistance => false;
    public virtual bool IsSustain => false;
    public virtual bool IsAbility => false;

    public void Bind() { }

    public string ToJson()
    {
        return "";
    }
}
