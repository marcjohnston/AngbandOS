// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;


internal class MindcrafterCharacterClass : CharacterClass
{
    private MindcrafterCharacterClass(Game savedGame) : base(savedGame) { }
    protected override (int, bool?, string)[]? ExperienceLevelHasHeavyArmorAndEnhancementBindingTuples => new (int, bool?, string)[]
    {
        (1, null, nameof(MindcrafterCharacterClassItemEnhancement)),
        (10, null, nameof(MindcrafterCharacterClassLevel10ItemEnhancement)),
        (20, null, nameof(MindcrafterCharacterClassLevel20ItemEnhancement)),
        (30, null, nameof(MindcrafterCharacterClassLevel30ItemEnhancement)),
        (40, null, nameof(MindcrafterCharacterClassLevel40ItemEnhancement)),
    };
    public override int ID => 9;
    public override string Title => "Mindcrafter";
    public override bool RenderSpellsPerLevel => false;
    public override int BasePerception => 16;
    public override int MeleeToHit => 50;
    public override int RangedToHit => 40;
    public override int DisarmBonusPerLevel => 10;
    public override int MeleeAttackBonusPerLevel => 20;
    public override int RangedAttackBonusPerLevel => 30;
    public override int HitDieBonus => 2;
    public override int ExperienceFactor => 25;
    public override Ability PrimeStat => Game.SingletonRepository.Get<Ability>(nameof(WisdomAbility));
    public override string[] Info => new string[] {
        "Disciples of the psionic arts, Mindcrafters learn a range",
        "of mental abilities; which they power using WIS. As well",
        "as their powers, they learn to resist fear (at lvl 10),",
        "prevent wis drain (at lvl 20), resist confusion",
        "(at lvl 30), and gain telepathy (at lvl 40)."
    };
    public override string MagicType => "psychic talents";
    public override int SpellWeight => 300;

    public override void Cast() => CastMentalism();

    protected override string SpellAbilityBindingKey => nameof(WisdomAbility);
    protected override (string?, int)[]? ArtifactBiasAndWeightBindingKeys => new (string?, int)[] { (nameof(PriestlyArtifactBias), 3), (null, 2) };
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(55000 / ((level * level) + 40)));
}
