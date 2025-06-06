namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportLevelSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportLevelSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportLevelSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportLevelScript) };
}