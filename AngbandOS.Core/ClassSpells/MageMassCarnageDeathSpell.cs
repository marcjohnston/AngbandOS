internal class MageMassCarnageDeathSpell : ClassSpell
{
    private MageMassCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMassCarnage);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 75;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}