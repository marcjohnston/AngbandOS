// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interfaces;

internal interface IIndexedSingletons
{
    /// <summary>
    /// Returns a unique sequential index of the singleton.  This process is handled by the <see cref="SingletonRepository"/> during the <see cref="SingletonRepository.LoadAndBind(GameConfiguration)"/> process.
    /// </summary>
    /// <remarks>
    /// The initial value must be set to -1.  The <see cref="SingletonRepository"/> uses this value to detect when the index needs to be set and detect if the index is being overwritten accidentally.  This
    /// overwrite may occur when the class is subclasses (like Attributes).
    /// </remarks>
    public int Index { get; set; }
}

