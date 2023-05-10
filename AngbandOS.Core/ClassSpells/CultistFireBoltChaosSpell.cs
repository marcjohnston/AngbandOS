[Serializable]
internal class CultistFireBoltChaosSpell : ClassSpell
{
    private CultistFireBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBolt);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 5;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 6;
}