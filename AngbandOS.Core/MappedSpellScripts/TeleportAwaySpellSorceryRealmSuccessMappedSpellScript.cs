namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportAwaySpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportAwaySpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportAwaySorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportAwayAll1xProjectileScript) };
}