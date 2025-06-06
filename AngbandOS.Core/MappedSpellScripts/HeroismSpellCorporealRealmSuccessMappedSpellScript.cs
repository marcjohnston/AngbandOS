namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HeroismSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HeroismSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HeroismCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Heroism1d25p25RestoreHealth10ResetFearScript) };
}