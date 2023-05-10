[Serializable]
internal class PriestPhantasmalServantTarotSpell : ClassSpell
{
    private PriestPhantasmalServantTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellPhantasmalServant);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 25;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}