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
    private static MemberInfo? GetMemberInfo(Type type, string name)
    {
        const BindingFlags flags =
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public |
            BindingFlags.NonPublic;

        while (type != null)
        {
            // Check property
            var prop = type.GetProperty(name, flags);
            if (prop != null)
                return prop;

            // Check field
            var field = type.GetField(name, flags);
            if (field != null)
                return field;

            type = type.BaseType!;
        }

        return null;
    }

    private static object? GetMemberValue(MemberInfo member, object obj)
    {
        return member switch
        {
            PropertyInfo p => p.GetValue(obj),
            FieldInfo f => f.GetValue(obj),
            _ => throw new NotSupportedException($"Unsupported member type: {member.GetType().Name}")
        };
    }

    public override bool Verify(RestoreGameState restoreGameState, object? singleton)
    {
        if (singleton is null)
        {
            throw new Exception($"During restore verification, a null singleton cannot verify as an object.");
        }

        foreach ((string PropertyName, GameStateBag ExpectedValue) in Values)
        {
            // Retrieve the field info from the singleton.
            MemberInfo? singletonMemberInfo = GetMemberInfo(singleton.GetType(), PropertyName);
            if (singletonMemberInfo is null)
            {
                throw new Exception($"During restore verification, the {PropertyName} property for the {singleton.GetType().Name} singleton could not be found.");
            }

            // Retrieve the actual value from the singleton.
            object? singletonFieldValue = GetMemberValue(singletonMemberInfo, singleton);
            if (!restoreGameState.New(ExpectedValue).Verify(singletonFieldValue))
            {
                throw new Exception($"During restore verification, the {PropertyName} property of the {singleton.GetType().Name} singleton did not verify.  Expected {ExpectedValue}.");
            }
        }
        return true;
    }
}