namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MagicMissileSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private MagicMissileSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(MagicMissileChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MagicMissileScript) };
}