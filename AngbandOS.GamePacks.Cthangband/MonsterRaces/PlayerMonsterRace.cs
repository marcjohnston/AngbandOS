// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PlayerMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(AtSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    
    public override int ArmorClass => 0;
    public override string Description => "You";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Player";
    public override int Hdice => 0;
    public override int Hside => 0;
    public override int LevelFound => -1;
    public override int Mexp => 0;
    public override int NoticeRange => 0;
    public override int Rarity => 0;
    public override int Sleep => 0;
    public override int Speed => 0;
    public override string? MultilineName => "Player";
}
