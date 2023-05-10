internal class HighMageDeathRayDeathSpell : ClassSpell
{
    private HighMageDeathRayDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDeathRay);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 16;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 50;
}