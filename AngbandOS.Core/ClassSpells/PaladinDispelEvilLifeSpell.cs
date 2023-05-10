internal class PaladinDispelEvilLifeSpell : ClassSpell
{
    private PaladinDispelEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelEvil);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 32;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 75;
}