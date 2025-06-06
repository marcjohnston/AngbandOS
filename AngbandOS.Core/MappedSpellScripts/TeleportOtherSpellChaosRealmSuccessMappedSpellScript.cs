namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportOtherSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportOtherSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportOtherChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportAwayAll1xProjectileScript) };
}