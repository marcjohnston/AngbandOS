// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BoldorKingOfTheYeeksMonsterRace : MonsterRace
{
    protected BoldorKingOfTheYeeksMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BlindnessMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SlowMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BlinkMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(HealMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonKinMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(TeleportSelfMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerYSymbol));
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Boldor, King of the Yeeks";

    public override bool Animal => true;
    public override int ArmorClass => 24;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 9),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 9),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A great yeek, powerful in magic and sorcery, but a yeek all the same.";
    public override bool Drop_1D2 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Boldor, King of the Yeeks";
    public override int Hdice => 18;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 13;
    public override bool Male => true;
    public override int Mexp => 200;
    public override int NoticeRange => 18;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Boldor   ";
    public override bool Unique => true;
}
