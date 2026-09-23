// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal interface IGameSerializer
{
    /// <summary>
    /// Serializes the entity into a GameStateBag to be saved.
    /// </summary>
    /// <param name="saveGameState">The current save game state, which can be used to create game state bags for properties of the entity.</param>
    /// <returns>A GameStateBag representing the serialized state of the entity.</returns>
    byte[] Serialize(SaveGameData saveGameData);
    SaveGameData Deserialize(byte[] serializedSaveGameData);
}
