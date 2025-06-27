namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SenseUnseenSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SenseUnseenLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SeeInvisibility24P1d24TimerScript) };
}