[Serializable]
internal class MageSatisfyHungerCorporealSpell : ClassSpell
{
    private MageSatisfyHungerCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSatisfyHunger);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 9;
}