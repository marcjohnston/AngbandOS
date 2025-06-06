namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ResistanceTrueSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ResistanceTrueSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ResistanceTrueNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResistTrueScript) };
}