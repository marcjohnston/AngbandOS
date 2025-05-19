// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BattleScarredVeteranMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerTSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "He doesn't take to strangers kindly.";
    public override bool Drop90 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Battle scarred veteran";
    public override int Hdice => 7;
    public override int Hside => 8;
    public override int LevelFound => 0;
    public override bool Male => true;
    public override int Mexp => 0;
    public override int NoticeRange => 10;
    public override bool OpenDoor => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 250;
    public override int Speed => 110;
    public override string? MultilineName => "Battle\nscarred\nveteran";
    public override bool TakeItem => true;
}
