[Serializable]
internal class MageAstralLoreTarotSpell : ClassSpell
{
    private MageAstralLoreTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralLore);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 50;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}