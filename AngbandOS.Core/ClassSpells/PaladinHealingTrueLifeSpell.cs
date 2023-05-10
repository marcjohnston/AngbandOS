internal class PaladinHealingTrueLifeSpell : ClassSpell
{
    private PaladinHealingTrueLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHealingTrue);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 80;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 115;
}