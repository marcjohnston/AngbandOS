namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class StasisSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private StasisSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(StasisSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Stasis4xProjectileScript) };
}