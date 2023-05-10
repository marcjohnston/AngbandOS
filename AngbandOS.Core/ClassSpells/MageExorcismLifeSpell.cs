[Serializable]
internal class MageExorcismLifeSpell : ClassSpell
{
    private MageExorcismLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellExorcism);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 30;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}