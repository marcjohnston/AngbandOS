namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NonMageMagicMissileSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(MagicMissileChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.NonMageMagicMissileScript) };
}
