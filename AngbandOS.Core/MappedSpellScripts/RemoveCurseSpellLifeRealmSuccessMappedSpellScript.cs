namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RemoveCurseSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RemoveCurseSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RemoveCurseLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RemoveCurseScript) };
}