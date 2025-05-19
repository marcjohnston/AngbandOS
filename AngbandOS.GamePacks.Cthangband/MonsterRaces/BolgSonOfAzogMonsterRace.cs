// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BolgSonOfAzogMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerOSymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    
    public override int ArmorClass => 50;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A large and powerful orc. He looks just like his daddy. He is tall and fast, but fortunately blessed with orcish brains.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Bolg, Son of Azog";
    public override int Hdice => 50;
    public override int Hside => 10;
    public override bool ImmunePoison => true;
    public override int LevelFound => 20;
    public override bool Male => true;
    public override int Mexp => 800;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 4;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Bolg";
    public override bool Unique => true;
}
