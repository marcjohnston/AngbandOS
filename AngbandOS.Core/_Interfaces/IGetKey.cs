// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

internal interface IGetKey : IToJson // TODO: Not all keyed entities will be deserialized as a configuration item.  IToJson should be separated.
{
    /// <summary>
    /// Returns the key to be used for other items to link to this repository item.
    /// </summary>
    string GetKey { get; }

    /// <summary>
    /// Process the binding phase for addressable repository items.  The loaded phase happens once all of the repository items are created.  This allows items to link to
    /// other items without needing to worry about the load order and whether the target item exists.  Most repository items will need to implement this interface.
    /// </summary>
    void Bind();
}
