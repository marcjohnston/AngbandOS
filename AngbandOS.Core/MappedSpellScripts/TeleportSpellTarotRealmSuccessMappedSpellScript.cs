namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportSelf4xScript) };
}