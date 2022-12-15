using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LawGhostMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new MindBlastMonsterSpell(),
            new ForgetMonsterSpell());
        public override char Character => 'G';
        public override Colour Colour => Colour.Silver;
        public override string Name => "Law ghost";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new Exp80AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new Exp40AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Claw, new LoseIntAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Claw, new LoseWisAttackEffect(), 1, 10)
        };
        public override bool ColdBlood => true;
        public override string Description => "An almost life-like creature which is nothing more than a phantom created by the law.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Law ghost";
        public override int Hdice => 20;
        public override int Hside => 25;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 36;
        public override int Mexp => 400;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Law     ";
        public override string SplitName3 => "   ghost    ";
        public override bool Undead => true;
    }
}
