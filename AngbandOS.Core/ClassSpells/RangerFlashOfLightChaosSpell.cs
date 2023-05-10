[Serializable]
internal class RangerFlashOfLightChaosSpell : ClassSpell
{
    private RangerFlashOfLightChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFlashOfLight);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 3;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 2;
}