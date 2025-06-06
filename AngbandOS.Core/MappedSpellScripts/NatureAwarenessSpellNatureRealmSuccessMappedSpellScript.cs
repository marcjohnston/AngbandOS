namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class NatureAwarenessSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private NatureAwarenessSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(NatureAwarenessNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NatureAwarenessScript) };
}