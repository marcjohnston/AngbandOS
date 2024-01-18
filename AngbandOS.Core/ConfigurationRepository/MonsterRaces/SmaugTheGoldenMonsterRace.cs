// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SmaugTheGoldenMonsterRace : MonsterRace
{
    protected SmaugTheGoldenMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheFireMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(CauseCriticalWoundsMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ConfuseMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperDSymbol));
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Smaug the Golden";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 4, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 4, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 4, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 6, 14)
    };
    public override bool BashDoor => true;
    public override string Description => "Smaug is one of the Uruloki that still survive, a fire-drake of immense cunning and intelligence. His speed through air is matched by few other dragons and his dragonfire is what legends are made of.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Smaug the Golden";
    public override int Hdice => 20;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 45;
    public override bool Male => true;
    public override int Mexp => 19000;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool Reflecting => true;
    public override int Sleep => 70;
    public override int Speed => 120;
    public override string SplitName1 => "   Smaug    ";
    public override string SplitName2 => "    the     ";
    public override string SplitName3 => "   Golden   ";
    public override bool Unique => true;
}
