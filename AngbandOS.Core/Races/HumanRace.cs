// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class HumanRace : Race
{
    private HumanRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(HumanRaceItemEnhancement);
    public override string Title => "Human";
    public override int UseDevice => 0;
    public override int SavingThrow => 0;
    public override int Stealth => 0;
    public override int Search => 0;
    public override int BaseSearchFrequency => 10;
    public override int MeleeToHit => 0;
    public override int RangedToHit => 0;
    public override int HitDieBonus => 10;
    public override int ExperienceFactor => 100;
    public override int BaseAge => 14;
    public override int AgeRange => 6;
    public override int Infravision => 0;
    public override uint Choice => 0xFFFF;
    public override string Description => "Hopefully you know all about humans already because you\nare one! In game terms, humans are the average around which\nthe other races are measured. As such, humans get no\nspecial abilities, but they increase in level quicker than\nany other race. Humans are recommended for new players.";

    /// <summary>
    /// Human 1->2->3->50->51->52->53->End
    /// </summary>
    public override int Chart => 1;
    protected override string GenerateNameSyllableSetName => nameof(HumanSyllableSet);
}
