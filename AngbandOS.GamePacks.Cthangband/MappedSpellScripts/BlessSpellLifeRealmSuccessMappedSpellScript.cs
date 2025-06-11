namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class BlessSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(BlessLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Blessing1d12p12TimerScript) };
}