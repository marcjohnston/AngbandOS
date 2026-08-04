namespace AngbandOS.GamePacks.Cthangband;

internal class LifeRealmFailureMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override bool Success => false;
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { };
}