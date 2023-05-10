[Serializable]
internal class MageHeroismCorporealSpell : ClassSpell
{
    private MageHeroismCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHeroism);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 20;
}