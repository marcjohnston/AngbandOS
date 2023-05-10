[Serializable]
internal class WarriorMageAnimalTamingNatureSpell : ClassSpell
{
    private WarriorMageAnimalTamingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellAnimalTaming);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}