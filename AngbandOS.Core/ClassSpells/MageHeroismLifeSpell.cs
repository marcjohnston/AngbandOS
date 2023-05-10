[Serializable]
internal class MageHeroismLifeSpell : ClassSpell
{
    private MageHeroismLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHeroism);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 40;
}