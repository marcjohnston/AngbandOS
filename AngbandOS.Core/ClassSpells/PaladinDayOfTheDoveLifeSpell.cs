[Serializable]
internal class PaladinDayOfTheDoveLifeSpell : ClassSpell
{
    private PaladinDayOfTheDoveLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDayOfTheDove);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 30;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 75;
}