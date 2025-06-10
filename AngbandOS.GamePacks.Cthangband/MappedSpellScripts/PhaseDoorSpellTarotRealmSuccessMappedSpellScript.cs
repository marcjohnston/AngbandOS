namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class PhaseDoorSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(PhaseDoorTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.PhaseDoorScript) };
}