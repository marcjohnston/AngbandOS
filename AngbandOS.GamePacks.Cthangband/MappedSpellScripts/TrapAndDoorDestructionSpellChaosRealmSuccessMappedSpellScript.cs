namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TrapAndDoorDestructionSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TrapAndDoorDestructionChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DestroyAdjacentDoorsScript) };
}