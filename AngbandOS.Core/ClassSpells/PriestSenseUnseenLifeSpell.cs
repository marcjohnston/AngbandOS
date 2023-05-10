[Serializable]
internal class PriestSenseUnseenLifeSpell : ClassSpell
{
    private PriestSenseUnseenLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSenseUnseen);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 8;
    public override int BaseFailure => 38;
    public override int FirstCastExperience => 4;
}