[Serializable]
internal class RangerAstralLoreTarotSpell : ClassSpell
{
    private RangerAstralLoreTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralLore);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 65;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}