[Serializable]
internal class CultistDivineInterventionLifeSpell : ClassSpell
{
    private CultistDivineInterventionLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDivineIntervention);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 50;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}