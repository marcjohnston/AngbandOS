namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectMonstersSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectMonstersSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectMonstersSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectNormalMonstersScript) };
}