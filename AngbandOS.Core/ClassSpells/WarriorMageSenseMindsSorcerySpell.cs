internal class WarriorMageSenseMindsSorcerySpell : ClassSpell
{
    private WarriorMageSenseMindsSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSenseMinds);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 14;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}