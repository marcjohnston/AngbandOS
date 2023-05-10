internal class HighMageVampirismTrueDeathSpell : ClassSpell
{
    private HighMageVampirismTrueDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampirismTrue);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 30;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 125;
}