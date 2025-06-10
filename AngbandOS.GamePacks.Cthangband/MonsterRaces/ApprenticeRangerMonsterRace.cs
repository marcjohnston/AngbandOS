// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ApprenticeRangerMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.Arrow3D6MonsterSpell)
    };

    public override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 6;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "An agile hunter, ready and relaxed.";
    public override bool Drop60 => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Apprentice Ranger";
    public override bool Friends => true;
    public override int Hdice => 6;
    public override int Hside => 8;
    public override int LevelFound => 8;
    public override bool Male => true;
    public override int Mexp => 18;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 5;
    public override int Speed => 110;
    public override string? MultilineName => "Apprentice\nranger";
}
