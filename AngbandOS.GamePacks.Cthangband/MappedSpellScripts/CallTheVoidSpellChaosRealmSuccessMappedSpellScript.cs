namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CallTheVoidSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CallTheVoidChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CallTheVoidScript) };
}