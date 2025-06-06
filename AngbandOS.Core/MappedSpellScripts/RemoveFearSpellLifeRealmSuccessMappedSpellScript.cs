namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RemoveFearSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RemoveFearSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RemoveFearLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResetFearTimerScript) };
}