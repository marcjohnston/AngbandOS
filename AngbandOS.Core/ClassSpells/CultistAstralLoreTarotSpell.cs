[Serializable]
internal class CultistAstralLoreTarotSpell : ClassSpell
{
    private CultistAstralLoreTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralLore);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 60;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}