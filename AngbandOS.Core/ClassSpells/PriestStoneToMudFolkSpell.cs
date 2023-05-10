[Serializable]
internal class PriestStoneToMudFolkSpell : ClassSpell
{
    private PriestStoneToMudFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellStoneToMud);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 20;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 9;
}