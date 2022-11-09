using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class BansheeMonsterRace : MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Banshee";

        public override int ArmourClass => 24;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Wail, new TerrifyAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new Exp20AttackEffect(), 0, 0),
        };
        public override bool ColdBlood => true;
        public override string Description => "It is a ghostly woman's form that wails mournfully.";
        public override bool DrainMana => true;
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Banshee";
        public override int Hdice => 6;
        public override int Hside => 8;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 24;
        public override int Mexp => 60;
        public override int NoticeRange => 20;
        public override bool PassWall => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Banshee   ";
        public override bool TakeItem => true;
        public override bool TeleportSelf => true;
        public override bool Undead => true;
    }
}
