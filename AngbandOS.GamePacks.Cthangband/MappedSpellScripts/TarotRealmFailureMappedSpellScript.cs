namespace AngbandOS.GamePacks.Cthangband;

internal class TarotRealmFailureMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override bool Success => false;
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { };
}