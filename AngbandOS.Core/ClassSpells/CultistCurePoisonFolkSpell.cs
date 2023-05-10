internal class CultistCurePoisonFolkSpell : ClassSpell
{
    private CultistCurePoisonFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCurePoison);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 13;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}