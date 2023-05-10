internal class HighMageAnimalFriendshipNatureSpell : ClassSpell
{
    private HighMageAnimalFriendshipNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellAnimalFriendship);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}