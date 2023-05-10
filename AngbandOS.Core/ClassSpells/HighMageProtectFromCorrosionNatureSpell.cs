internal class HighMageProtectFromCorrosionNatureSpell : ClassSpell
{
    private HighMageProtectFromCorrosionNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellProtectFromCorrosion);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 65;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}