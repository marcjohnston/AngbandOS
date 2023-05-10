[Serializable]
internal class MageDetoxifyCorporealSpell : ClassSpell
{
    private MageDetoxifyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellDetoxify);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 7;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}