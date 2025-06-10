namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class AstralSpyingSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(AstralSpyingTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.AddTelepathy25p1d30Script) };
}