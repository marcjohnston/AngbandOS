[Serializable]
internal class WarriorMageCurePoisonFolkSpell : ClassSpell
{
    private WarriorMageCurePoisonFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCurePoison);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 13;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}