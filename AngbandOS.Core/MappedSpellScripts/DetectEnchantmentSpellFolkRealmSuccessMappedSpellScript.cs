namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectEnchantmentSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectEnchantmentSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectEnchantmentFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectMagicalObjectsScript) };
}