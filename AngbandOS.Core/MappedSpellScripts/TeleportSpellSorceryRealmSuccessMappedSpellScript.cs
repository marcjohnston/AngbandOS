namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportSelf5xScript) };
}