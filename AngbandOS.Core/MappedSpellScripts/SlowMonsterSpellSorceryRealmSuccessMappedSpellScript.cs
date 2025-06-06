namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SlowMonsterSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SlowMonsterSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SlowMonsterSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldSlow1xProjectileScript) };
}