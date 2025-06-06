namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportAwaySpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportAwaySpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportAwayTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportAwayAll1xProjectileScript) };
}