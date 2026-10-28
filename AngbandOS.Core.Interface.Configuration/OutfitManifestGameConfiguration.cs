using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Outfit Manifest",
    EntityNoun = "outfit manifest")]
public class OutfitManifestGameConfiguration : IGetKeyGameConfiguration // We cannot use the CompositeSingletonGameConfiguration, because the composite keys in the definition only support strings and we have tuples
{
    public string GetKey => GameConfiguration.GetCompositeKey(CharacterClassBindingKey, RaceBindingKey, RealmBindingKey); // CONFIRMED

    /// <summary>
    /// Returns null to match all values (null and non-null); or a MatchValue (null or non-null) and an equality operator.
    /// </summary>
    [ConfigurationTupleItem(
        "MatchValues",
        Title = "Match Values")]
    [ConfigurationTupleItem(
        "IsEqual",
        Title = "Is Equal")]
    [ConfigurationMetadata(
        Title = "Character Class Binding Key",
        Summary = "Returns null to match all character classes, or specifies the character class values and equality operator used for matching.",
        DataType = "(string[] MatchValues, bool IsEqual)?")]
    public virtual (string[] MatchValues, bool IsEqual)? CharacterClassBindingKey { get; set; } = null;

    [ConfigurationTupleItem(
        "MatchValues",
        Title = "Match Values")]
    [ConfigurationTupleItem(
        "IsEqual",
        Title = "Is Equal")]
    [ConfigurationMetadata(
        Title = "Race Binding Key",
        Summary = "Returns null to match all races, or specifies the race values and equality operator used for matching.",
        DataType = "(string[] MatchValues, bool IsEqual)?")]
    public virtual (string[] MatchValues, bool IsEqual)? RaceBindingKey { get; set; } = null;

    [ConfigurationTupleItem(
        "MatchValues",
        Title = "Match Values")]
    [ConfigurationTupleItem(
        "IsEqual",
        Title = "Is Equal")]
    [ConfigurationMetadata(
        Title = "Realm Binding Key",
        Summary = "Returns null to match all realms, or specifies the realm values and equality operator used for matching.",
        DataType = "(string[] MatchValues, bool IsEqual)?")]
    public virtual (string[] MatchValues, bool IsEqual)? RealmBindingKey { get; set; } = null;

    [ConfigurationTupleItem(
        "ItemFactoryBindingKey",
        Title = "Item Factory Binding Key")]
    [ConfigurationTupleItem(
        "ItemEnhancementBindingKey",
        Title = "Item Enhancement Binding Key")]
    [ConfigurationTupleItem(
        "StackCountExpression",
        Title = "Stack Count Expression")]
    [ConfigurationTupleItem(
        "MakeKnown",
        Title = "Make Known")]
    [ConfigurationTupleItem(
        "WieldOne",
        Title = "Wield One")]
    [ConfigurationMetadata(
        Title = "Item Factory and Enhancements Bindings",
        Summary = "Specifies the item factories, item enhancements, stack counts, identification state, and wield-one behavior for the outfit manifest.",
        DataType = "(string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[]")]
    public virtual (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey, string StackCountExpression, bool MakeKnown, bool WieldOne)[] ItemFactoryAndEnhancementsBindings { get; set; }
}