internal class HighMageBlizzardNatureSpell : ClassSpell
{
    private HighMageBlizzardNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellBlizzard);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 22;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 29;
}