namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class IdentifySpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private IdentifySpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(IdentifySorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(IdentifyItemScript) };
}