internal class MageMutateBodyCorporealSpell : ClassSpell
{
    private MageMutateBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMutateBody);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 10;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}