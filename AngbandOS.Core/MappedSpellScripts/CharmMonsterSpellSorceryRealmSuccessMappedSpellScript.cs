namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CharmMonsterSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CharmMonsterSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CharmMonsterSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Charm1xProjectileScript) };
}