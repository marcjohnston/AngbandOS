namespace AngbandOS.GamePacks.Cthangband;

internal class ElementalBallSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ElementalBallFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ElementalBall75PXProjectileScriptWeightedRandom) };
}