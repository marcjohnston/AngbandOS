internal class PriestHealingLifeSpell : ClassSpell
{
    private PriestHealingLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHealing);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 16;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 7;
}