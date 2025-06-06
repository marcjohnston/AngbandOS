namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SenseMindsSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SenseMindsSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SenseMindsSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(AddTelepathy25p1d30Script) };
}