[Serializable]
internal class MonkPhantasmalServantTarotSpell : ClassSpell
{
    private MonkPhantasmalServantTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellPhantasmalServant);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 25;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}