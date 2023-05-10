[Serializable]
internal class PriestDivineInterventionLifeSpell : ClassSpell
{
    private PriestDivineInterventionLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDivineIntervention);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 40;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}