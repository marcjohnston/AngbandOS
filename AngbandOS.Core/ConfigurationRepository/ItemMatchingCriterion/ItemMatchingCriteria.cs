// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class ItemMatchingCriteria : IGetKey<string>
{
    protected SaveGame SaveGame { get; }
    protected ItemMatchingCriteria(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual bool? Blessed => null;
    public virtual bool? Value => true;

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    public void Bind()
    {
    }

    public virtual bool ItemMatches(Item item)
    {
        if (Blessed != null)
        {
            item.RefreshFlagBasedProperties();
            if (item.Characteristics.Blessed != Blessed)
            {
                return false;
            }
        }
        if (Value == true && item.Value() <= 0)
        {
            return false;
        }
        if (Value == false && item.Value() > 0)
        {
            return false;
        }
        return true;
    }

}
