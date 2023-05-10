internal class CultistClairvoyanceFolkSpell : ClassSpell
{
    private CultistClairvoyanceFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellClairvoyance);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 140;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}