namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class WordOfDestructionSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(WordOfDestructionChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.WordOfDestructionScript) };
}