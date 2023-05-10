[Serializable]
internal class PriestAnimalFriendshipNatureSpell : ClassSpell
{
    private PriestAnimalFriendshipNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellAnimalFriendship);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 35;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 50;
}