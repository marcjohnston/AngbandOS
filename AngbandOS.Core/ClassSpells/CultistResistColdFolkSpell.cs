[Serializable]
internal class CultistResistColdFolkSpell : ClassSpell
{
    private CultistResistColdFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistCold);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 14;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}