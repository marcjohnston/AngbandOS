[Serializable]
internal class MageAnimalTamingNatureSpell : ClassSpell
{
    private MageAnimalTamingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellAnimalTaming);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 5;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}