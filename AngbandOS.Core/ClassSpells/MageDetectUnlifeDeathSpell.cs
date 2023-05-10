[Serializable]
internal class MageDetectUnlifeDeathSpell : ClassSpell
{
    private MageDetectUnlifeDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDetectUnlife);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}