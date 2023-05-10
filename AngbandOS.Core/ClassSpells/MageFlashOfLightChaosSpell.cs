[Serializable]
internal class MageFlashOfLightChaosSpell : ClassSpell
{
    private MageFlashOfLightChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFlashOfLight);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}