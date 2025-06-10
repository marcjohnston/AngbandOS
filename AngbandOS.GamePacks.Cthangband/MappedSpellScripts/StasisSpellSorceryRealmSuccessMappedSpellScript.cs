namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class StasisSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(StasisSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Stasis4xProjectileScript) };
}