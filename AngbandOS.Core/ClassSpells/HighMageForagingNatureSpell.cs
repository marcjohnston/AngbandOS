internal class HighMageForagingNatureSpell : ClassSpell
{
    private HighMageForagingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellForaging);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}