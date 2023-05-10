[Serializable]
internal class WarriorMageStoneToMudNatureSpell : ClassSpell
{
    private WarriorMageStoneToMudNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneToMud);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}