using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GhoulMonsterRace : MonsterRace
    {
        public override char Character => 'z';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Ghoul";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new PoisonAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new ParalyzeAttackEffect(), 1, 5),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "Flesh is falling off in chunks from this decaying abomination.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Ghoul";
        public override bool Friends => true;
        public override int Hdice => 15;
        public override bool Hold => true;
        public override int Hside => 9;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 26;
        public override int Mexp => 95;
        public override int NoticeRange => 30;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Ghoul    ";
        public override bool Undead => true;
    }
}
