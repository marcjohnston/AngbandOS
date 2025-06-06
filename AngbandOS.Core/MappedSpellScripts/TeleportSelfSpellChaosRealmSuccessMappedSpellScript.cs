namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportSelfSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportSelfSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportSelfChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportSelf5xScript) };
}