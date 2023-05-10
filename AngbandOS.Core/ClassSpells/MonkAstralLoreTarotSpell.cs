internal class MonkAstralLoreTarotSpell : ClassSpell
{
    private MonkAstralLoreTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralLore);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 55;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}