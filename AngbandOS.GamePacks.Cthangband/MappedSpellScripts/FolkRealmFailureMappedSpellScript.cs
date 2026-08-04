namespace AngbandOS.GamePacks.Cthangband;

internal class FolkRealmFailureMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override bool Success => false;
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { };
}