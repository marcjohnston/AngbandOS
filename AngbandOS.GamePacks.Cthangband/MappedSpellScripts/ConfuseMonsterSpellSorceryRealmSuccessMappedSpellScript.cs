namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ConfuseMonsterSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ConfuseMonsterSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldConfuse3xO2ProjectileScript) };
}