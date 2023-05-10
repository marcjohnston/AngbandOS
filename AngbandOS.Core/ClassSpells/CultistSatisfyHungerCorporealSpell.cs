[Serializable]
internal class CultistSatisfyHungerCorporealSpell : ClassSpell
{
    private CultistSatisfyHungerCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSatisfyHunger);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 9;
}