[Serializable]
internal class MonkBanishTarotSpell : ClassSpell
{
    private MonkBanishTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellBanish);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 45;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 12;
}