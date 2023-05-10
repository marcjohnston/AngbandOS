[Serializable]
internal class CultistPhaseDoorTarotSpell : ClassSpell
{
    private CultistPhaseDoorTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellPhaseDoor);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 3;
}