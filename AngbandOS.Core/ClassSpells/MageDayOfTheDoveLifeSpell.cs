[Serializable]
internal class MageDayOfTheDoveLifeSpell : ClassSpell
{
    private MageDayOfTheDoveLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDayOfTheDove);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 35;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 75;
}