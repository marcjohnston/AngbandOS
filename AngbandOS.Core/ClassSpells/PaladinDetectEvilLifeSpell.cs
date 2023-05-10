internal class PaladinDetectEvilLifeSpell : ClassSpell
{
    private PaladinDetectEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDetectEvil);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}