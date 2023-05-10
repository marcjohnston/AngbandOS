internal class RangerLightAreaFolkSpell : ClassSpell
{
    private RangerLightAreaFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellLightArea);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}