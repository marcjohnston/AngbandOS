[Serializable]
internal class CultistManaStormChaosSpell : ClassSpell
{
    private CultistManaStormChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellManaStorm);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 45;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 200;
}