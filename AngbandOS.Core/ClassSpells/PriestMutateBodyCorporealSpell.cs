[Serializable]
internal class PriestMutateBodyCorporealSpell : ClassSpell
{
    private PriestMutateBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMutateBody);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 18;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}