[Serializable]
internal class MageStoneToMudFolkSpell : ClassSpell
{
    private MageStoneToMudFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellStoneToMud);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 16;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 9;
}