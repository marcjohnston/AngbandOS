namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SleepMonsterSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SleepMonsterSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldSleep1xProjectileScript) };
}