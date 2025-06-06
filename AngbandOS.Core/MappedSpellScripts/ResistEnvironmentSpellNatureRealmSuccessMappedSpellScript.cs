namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ResistEnvironmentSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ResistEnvironmentSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ResistEnvironmentNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResistEnvironmentScript) };
}