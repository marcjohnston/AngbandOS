internal class HighMageHellfireDeathSpell : ClassSpell
{
    private HighMageHellfireDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHellfire);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 100;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 250;
}