namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TelekinesisSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TelekinesisSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TelekinesisSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TelekinesisScript) };
}