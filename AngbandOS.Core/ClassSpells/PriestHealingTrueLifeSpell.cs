[Serializable]
internal class PriestHealingTrueLifeSpell : ClassSpell
{
    private PriestHealingTrueLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHealingTrue);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 50;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 130;
}