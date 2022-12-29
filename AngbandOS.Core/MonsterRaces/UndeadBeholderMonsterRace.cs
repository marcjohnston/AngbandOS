using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class UndeadBeholderMonsterRace : MonsterRace
    {
        protected UndeadBeholderMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BrainSmashMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new DrainManaMonsterSpell(),
            new ManaBoltMonsterSpell(),
            new MindBlastMonsterSpell(),
            new SlowMonsterSpell(),
            new ForgetMonsterSpell(),
            new SummonUndeadMonsterSpell());
        public override char Character => 'e';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Undead beholder";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new GazeAttackType(), new Exp40AttackEffect(), 0, 0),
            new MonsterAttack(new GazeAttackType(), new ParalyzeAttackEffect(), 0, 0),
            new MonsterAttack(new GazeAttackType(), new LoseIntAttackEffect(), 2, 6),
            new MonsterAttack(new GazeAttackType(), new UnPowerAttackEffect(), 2, 6)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A disembodied eye, floating in the air. Black nether storms rage around its bloodshot pupil and light seems to bend as it sucks its power from the very air around it. Your soul chills as it drains your vitality for its evil enchantments.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Undead beholder";
        public override int Hdice => 27;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 42;
        public override int Mexp => 4000;
        public override int NoticeRange => 30;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Undead   ";
        public override string SplitName3 => "  beholder  ";
        public override bool Undead => true;
    }
}
