namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SorceryRealmFailureMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override bool Success => false;
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { };
}