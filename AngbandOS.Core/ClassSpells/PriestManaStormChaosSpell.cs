[Serializable]
internal class PriestManaStormChaosSpell : ClassSpell
{
    private PriestManaStormChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellManaStorm);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 50;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 200;
}