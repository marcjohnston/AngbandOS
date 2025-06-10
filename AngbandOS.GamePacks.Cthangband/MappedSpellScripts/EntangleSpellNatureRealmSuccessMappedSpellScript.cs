namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class EntangleSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(EntangleNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldSlowAtLos1xProjectileScript) };
}