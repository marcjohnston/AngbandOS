namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HeroismSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HeroismSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HeroismLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Heroism1d25p25RestoreHealth10ResetFearScript) };
}