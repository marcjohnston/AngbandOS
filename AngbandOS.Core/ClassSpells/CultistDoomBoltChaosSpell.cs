internal class CultistDoomBoltChaosSpell : ClassSpell
{
    private CultistDoomBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDoomBolt);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 12;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 11;
}