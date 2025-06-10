namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SlowMonsterSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SlowMonsterSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldSlow1xProjectileScript) };
}