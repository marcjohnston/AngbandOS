internal class PriestFlashOfLightChaosSpell : ClassSpell
{
    private PriestFlashOfLightChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFlashOfLight);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 3;
    public override int BaseFailure => 26;
    public override int FirstCastExperience => 4;
}