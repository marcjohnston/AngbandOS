[Serializable]
internal class MageDivineInterventionLifeSpell : ClassSpell
{
    private MageDivineInterventionLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDivineIntervention);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 50;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}