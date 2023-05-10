internal class MageAnimalFriendshipNatureSpell : ClassSpell
{
    private MageAnimalFriendshipNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellAnimalFriendship);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 30;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}