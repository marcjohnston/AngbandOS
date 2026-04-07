// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Reflection;

namespace AngbandOS.Core;

internal class ObjectGameStateBag : GameStateBag
{
    public int ObjectId { get; }
    public Dictionary<string, GameStateBag> Values { get; }

    public ObjectGameStateBag(int objectId, Dictionary<string, GameStateBag>? value)
    {
        ObjectId = objectId;
        Values = value ?? new Dictionary<string, GameStateBag>();
    }
    public override string ToString()
    {
        return $"Object#{ObjectId}";
    }
    public override void Verify(RestoreGameState restoreGameState, object? singleton)
    {
        if (singleton is null)
        {
            throw new Exception($"During restore verification, the null singleton did not verify as an object.");
        }

        foreach ((string PropertyName, GameStateBag ExpectedValue) in Values)
        {
            // Retrieve the field info from the singleton.
            FieldInfo? singletonFieldInfo = SaveGameState.GetAllFields(singleton.GetType()).SingleOrDefault(_fieldInfo => _fieldInfo.Name == PropertyName);
            if (singletonFieldInfo is null)
            {
                throw new Exception($"During restore verification, the {PropertyName} property for the {singleton.GetType().Name} singleton could not be found.");
            }

            // Retrieve the actual value from the singleton.
            object? singletonFieldValue = singletonFieldInfo.GetValue(singleton);
            restoreGameState.New(ExpectedValue).Verify(singletonFieldValue);
        }
    }
}