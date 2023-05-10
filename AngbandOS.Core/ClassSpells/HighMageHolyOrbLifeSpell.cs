internal class HighMageHolyOrbLifeSpell : ClassSpell
{
    private HighMageHolyOrbLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHolyOrb);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 17;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}