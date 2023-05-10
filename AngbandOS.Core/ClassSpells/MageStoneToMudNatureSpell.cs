[Serializable]
internal class MageStoneToMudNatureSpell : ClassSpell
{
    private MageStoneToMudNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneToMud);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}