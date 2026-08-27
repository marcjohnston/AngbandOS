namespace AngbandOS.GamePacks.Cthangband;

internal class SeeInvisibleSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SeeInvisibleFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SeeInvisibility24P1d24TimerScript) };
}