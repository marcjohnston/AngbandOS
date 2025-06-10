namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SonicBoomSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SonicBoomChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SonicBoomProjectileScript) };
}