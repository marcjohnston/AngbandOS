[Serializable]
internal class CultistStoneToMudNatureSpell : ClassSpell
{
    private CultistStoneToMudNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneToMud);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}