internal class RogueCurePoisonFolkSpell : ClassSpell
{
    private RogueCurePoisonFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCurePoison);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 14;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}