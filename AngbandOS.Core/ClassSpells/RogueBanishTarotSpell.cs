internal class RogueBanishTarotSpell : ClassSpell
{
    private RogueBanishTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellBanish);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 50;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 12;
}