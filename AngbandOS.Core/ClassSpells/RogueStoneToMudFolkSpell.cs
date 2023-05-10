[Serializable]
internal class RogueStoneToMudFolkSpell : ClassSpell
{
    private RogueStoneToMudFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellStoneToMud);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 23;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 9;
}