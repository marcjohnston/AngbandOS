namespace AngbandOS.Core.Interface.Configuration;

public class OutfitManifestGameConfiguration : IGetKeyGameConfiguration // We cannot use the CompositeSingletonGameConfiguration, because the composite keys in the definition only support strings and we have tuples
{
    public string GetKey => GameConfiguration.GetCompositeKey(CharacterClassBindingKey, RaceBindingKey, RealmBindingKey); // CONFIRMED

    /// <summary>
    /// Returns null to match all values (null and non-null); or a MatchValue (null or non-null) and an equality operator.
    /// </summary>
    public virtual (string[] MatchValues, bool IsEqual)? CharacterClassBindingKey { get; set; } = null;
    public virtual (string[] MatchValues, bool IsEqual)? RaceBindingKey { get; set; } = null;
    public virtual (string[] MatchValues, bool IsEqual)? RealmBindingKey { get; set; } = null;
    public virtual (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings { get; set; }

}