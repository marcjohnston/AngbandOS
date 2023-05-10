internal class PriestLightAreaFolkSpell : ClassSpell
{
    private PriestLightAreaFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellLightArea);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}