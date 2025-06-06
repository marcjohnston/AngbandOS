namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HolyOrbSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HolyOrbSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HolyOrbLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(HolyOrbScript) };
}