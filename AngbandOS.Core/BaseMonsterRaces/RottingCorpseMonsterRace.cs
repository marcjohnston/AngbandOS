using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class RottingCorpseMonsterRace : MonsterRace
    {
        public override char Character => 'z';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Rotting corpse";

        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new PoisonAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Claw, new PoisonAttackEffect(), 1, 3),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "Corpses awakened from their sleep by dark sorceries. ";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Rotting corpse";
        public override bool Friends => true;
        public override int Hdice => 8;
        public override int Hside => 8;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 7;
        public override int Mexp => 15;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Rotting   ";
        public override string SplitName3 => "   corpse   ";
        public override bool Undead => true;
    }
}
