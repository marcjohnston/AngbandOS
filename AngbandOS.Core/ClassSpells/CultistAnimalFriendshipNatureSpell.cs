internal class CultistAnimalFriendshipNatureSpell : ClassSpell
{
    private CultistAnimalFriendshipNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellAnimalFriendship);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 38;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 80;
}