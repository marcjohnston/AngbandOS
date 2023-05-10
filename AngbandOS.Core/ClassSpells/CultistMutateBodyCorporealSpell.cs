internal class CultistMutateBodyCorporealSpell : ClassSpell
{
    private CultistMutateBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMutateBody);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 14;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}