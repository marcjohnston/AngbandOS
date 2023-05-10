[Serializable]
internal class PriestDispelUndeadAndDemonsLifeSpell : ClassSpell
{
    private PriestDispelUndeadAndDemonsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelUndeadAndDemons);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 14;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 70;
}