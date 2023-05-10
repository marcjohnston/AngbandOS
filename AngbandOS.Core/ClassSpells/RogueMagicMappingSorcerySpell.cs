internal class RogueMagicMappingSorcerySpell : ClassSpell
{
    private RogueMagicMappingSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellMagicMapping);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 14;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 1;
}