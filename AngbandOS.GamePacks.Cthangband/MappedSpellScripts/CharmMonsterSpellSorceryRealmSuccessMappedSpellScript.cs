namespace AngbandOS.GamePacks.Cthangband;

internal class CharmMonsterSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CharmMonsterSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Charm1xProjectileScript) };
}