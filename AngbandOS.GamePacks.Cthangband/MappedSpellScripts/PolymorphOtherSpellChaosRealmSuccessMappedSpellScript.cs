namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class PolymorphOtherSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(PolymorphOtherChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldPolymorph1xProjectileScript) };
}