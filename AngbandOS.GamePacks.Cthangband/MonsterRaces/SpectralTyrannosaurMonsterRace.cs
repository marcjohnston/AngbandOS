// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpectralTyrannosaurMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.NetherBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.NexusBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.HoldMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell)
    };

    public override string SymbolName => nameof(UpperRSymbol);
    public override ColorEnum Color => ColorEnum.Turquoise;
    
    public override bool Animal => true;
    public override int ArmorClass => 120;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.Exp40AttackEffect), 2, 13),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.Exp40AttackEffect), 2, 13),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 5, 8),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.TerrifyAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override string Description => "A deadly undead horror which looks like a skeletal tyrannosaur surrounded by a sickly green glow.";
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Spectral tyrannosaur";
    public override int Hdice => 70;
    public override int Hside => 50;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 46;
    public override int Mexp => 15000;
    public override bool MoveBody => true;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistNexus => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string? MultilineName => "Spectral\ntyrannosaur";
    public override bool Undead => true;
}
