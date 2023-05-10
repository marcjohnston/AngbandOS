[Serializable]
internal class PriestManaBurstChaosSpell : ClassSpell
{
    private PriestManaBurstChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellManaBurst);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 6;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 5;
}