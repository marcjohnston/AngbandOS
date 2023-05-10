internal class PaladinHealingLifeSpell : ClassSpell
{
    private PaladinHealingLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHealing);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 25;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 5;
}