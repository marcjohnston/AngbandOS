internal class WarriorMageDetectCreaturesNatureSpell : ClassSpell
{
    private WarriorMageDetectCreaturesNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDetectCreatures);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 23;
    public override int FirstCastExperience => 4;
}