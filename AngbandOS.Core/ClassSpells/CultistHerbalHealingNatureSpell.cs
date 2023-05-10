[Serializable]
internal class CultistHerbalHealingNatureSpell : ClassSpell
{
    private CultistHerbalHealingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellHerbalHealing);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 100;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 50;
}