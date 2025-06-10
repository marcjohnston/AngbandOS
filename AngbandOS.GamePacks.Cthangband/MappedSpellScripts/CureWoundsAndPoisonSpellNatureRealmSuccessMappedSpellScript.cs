namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CureWoundsAndPoisonSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CureWoundsAndPoisonNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CureWoundsAndPoisonScript) };
}