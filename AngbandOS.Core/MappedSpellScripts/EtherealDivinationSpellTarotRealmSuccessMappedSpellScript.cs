namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class EtherealDivinationSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private EtherealDivinationSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(EtherealDivinationTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectionScript) };
}