[Serializable]
internal class MageBanishTarotSpell : ClassSpell
{
    private MageBanishTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellBanish);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 40;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 12;
}