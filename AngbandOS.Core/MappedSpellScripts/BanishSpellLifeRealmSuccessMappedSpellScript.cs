namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BanishSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BanishSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BanishLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportAwayEvilAtLosByGod100ProjectileScript) };
}