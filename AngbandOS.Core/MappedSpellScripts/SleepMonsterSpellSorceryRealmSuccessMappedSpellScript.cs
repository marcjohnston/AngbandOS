namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SleepMonsterSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SleepMonsterSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SleepMonsterSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldSleep1xProjectileScript) };
}