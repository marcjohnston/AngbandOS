namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetoxifySpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetoxifyCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(PoisonResetTimerScript) };
}