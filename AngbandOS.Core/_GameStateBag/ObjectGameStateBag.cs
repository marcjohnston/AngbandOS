// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class ObjectGameStateBag : GameStateBag
{
    public int ObjectId { get; }
    public string TypeName { get; }
    public readonly DictionaryGameStateBag? Values;

    /// <summary>
    /// Constructs a new ObjectGameStateBag.
    /// </summary>
    /// <param name="objectId">The unique ID of this object.  During restore operations, this value will come from the serialized data.  During save operations, this value will be provided by the object registration dictionary.</param>
    /// <param name="typeName">The type name to construct, when the object needs to be constructed during the restore operation.  During save operations, this should be the object.GetType().Name value.</param>
    /// <param name="value">Additional data provided by the object to be serialized for the save operations.  Null, if the object has no additional data/state.</param>
    public ObjectGameStateBag(int objectId, string typeName, DictionaryGameStateBag? value)
    {
        ObjectId = objectId;
        TypeName = typeName;
        Values = value;
    }

    /// <summary>
    /// Returns a string for debugging purposes that represents the object ID.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"Object#{ObjectId}";
    }

    public GameStateBag? GetByKey(string key, int currentSequentialIndex, bool verifySequentialRetrieval)
    {
        if (Values is null)
        {
            return null;
        }
        return Values.GetByKey(key, currentSequentialIndex, verifySequentialRetrieval);
    }

    public void PruneItems(SaveGameState saveGameState)
    {
        if (Values is not null)
        {
            Values.PruneItems(saveGameState);
        }
    }

    public override bool Verify(RestoreGameState restoreGameState, object? singleton)
    {
        if (Values is not null)
        {
            Values.Verify(restoreGameState, singleton);
        }
        return true;
    }
}