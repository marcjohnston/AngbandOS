using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DarkElvenWarlockMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Dark elven warlock";

        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "A dark elven mage with spells of frightening destructive power.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Dark elven warlock";
        public override bool Friends => true;
        public override int Hdice => 7;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmunePoison => true;
        public override int Level => 23;
        public override bool MagicMissile => true;
        public override bool Male => true;
        public override bool ManaBolt => true;
        public override int Mexp => 75;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "   elven    ";
        public override string SplitName3 => "  warlock   ";
    }
}
