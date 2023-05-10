[Serializable]
internal class MageHerbalHealingNatureSpell : ClassSpell
{
    private MageHerbalHealingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellHerbalHealing);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 100;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 50;
}