[Serializable]
internal class WarriorMageSatisfyHungerCorporealSpell : ClassSpell
{
    private WarriorMageSatisfyHungerCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSatisfyHunger);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 9;
}