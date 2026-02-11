namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class OutfitManifestGameConfiguration
{
    public virtual string? CharacterClassBindingKey { get; set; } = null;
    public virtual string? RaceBindingKey { get; set; } = null;
    public virtual string? RealmBindingKey { get; set; } = null;
    public virtual (string ItemFactoryBindingKey, string[]? ItemEnhancementBindingKey)[] ItemFactoryAndEnhancementsBindings { get; set; } = null;
}

