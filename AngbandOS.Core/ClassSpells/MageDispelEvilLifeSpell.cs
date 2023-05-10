internal class MageDispelEvilLifeSpell : ClassSpell
{
    private MageDispelEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelEvil);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 35;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 75;
}