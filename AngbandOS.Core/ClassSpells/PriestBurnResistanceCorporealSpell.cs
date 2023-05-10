[Serializable]
internal class PriestBurnResistanceCorporealSpell : ClassSpell
{
    private PriestBurnResistanceCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBurnResistance);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 11;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}