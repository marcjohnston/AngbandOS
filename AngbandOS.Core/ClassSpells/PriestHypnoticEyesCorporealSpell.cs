[Serializable]
internal class PriestHypnoticEyesCorporealSpell : ClassSpell
{
    private PriestHypnoticEyesCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHypnoticEyes);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 100;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 200;
}