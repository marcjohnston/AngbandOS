namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SelfKnowledgeSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SelfKnowledgeSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SelfKnowledgeScript) };
}