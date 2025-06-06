namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportLevelSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportLevelSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportLevelTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportLevelScript) };
}