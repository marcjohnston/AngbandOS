[Serializable]
internal class PriestFlameStrikeChaosSpell : ClassSpell
{
    private PriestFlameStrikeChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFlameStrike);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 37;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}