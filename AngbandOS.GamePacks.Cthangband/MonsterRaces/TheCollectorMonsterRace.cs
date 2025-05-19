// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TheCollectorMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.CauseMortalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell),
        nameof(MonsterSpellsEnum.HoldMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBallMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.CreateTrapsMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetMonsterSpell),
        nameof(MonsterSpellsEnum.HiDragonSummonMonsterSpell),
        nameof(MonsterSpellsEnum.HiUndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.UniqueSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportAwayMonsterSpell)
    };

    public override string SymbolName => nameof(LowerHSymbol);
    public override ColorEnum Color => ColorEnum.Copper;
    
    public override int ArmorClass => 100;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.LoseChaAttackEffect), 5, 5),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.EatItemAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.LoseAllAttackEffect), 10, 1),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.EatGoldAttackEffect), 0, 0)
    };
    public override bool ColdBlood => true;
    public override string Description => "A strange little gnome, he's been collecting toys and friends and doesn't want to give them up.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "The Collector";
    public override int Hdice => 25;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool ImmuneStun => true;
    public override int LevelFound => 52;
    public override bool Male => true;
    public override int Mexp => 45000;
    public override int NoticeRange => 90;
    public override bool OnlyDropItem => true;
    public override int Rarity => 3;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 150;
    public override string? MultilineName => "The\nCollector";
    public override bool Unique => true;
}
