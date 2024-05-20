// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemQualityRatings;

[Serializable]
internal abstract class ItemQualityRating : IGetKey
{
    protected readonly Game Game;
    protected ItemQualityRating(Game game)
    {
        Game = game;
    }

    public abstract string Description { get; }

    /// <summary>
    /// Returns the index into the Stompable for which the item pertains; or null, if the item is special and should never be stomped.
    /// </summary>
    public abstract int? StompIndex { get; }

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
