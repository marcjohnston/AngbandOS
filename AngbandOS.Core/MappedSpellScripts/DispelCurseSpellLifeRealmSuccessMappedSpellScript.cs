namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DispelCurseSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DispelCurseSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DispelCurseLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RemoveAllCurseScript) };
}