[Serializable]
internal class CultistEsoteriaDeathSpell : ClassSpell
{
    private CultistEsoteriaDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEsoteria);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 45;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}