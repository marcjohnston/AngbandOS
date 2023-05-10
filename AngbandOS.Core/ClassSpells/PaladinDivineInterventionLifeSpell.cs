internal class PaladinDivineInterventionLifeSpell : ClassSpell
{
    private PaladinDivineInterventionLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDivineIntervention);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 45;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}