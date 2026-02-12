namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class OutfitManifestGameConfiguration
{
    /// <summary>
    /// Returns null to match all values (null and non-null); or a MatchValue (null or non-null) and an equality operator.
    /// </summary>
    public virtual (string? MatchValue, bool IsEqual)? CharacterClassBindingKey { get; set; } = null;
    public virtual (string? MatchValue, bool IsEqual)? RaceBindingKey { get; set; } = null;
    public virtual (string? MatchValue, bool IsEqual)? RealmBindingKey { get; set; } = null;
    public virtual (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings { get; set; }
}

