using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MindFlayerMonsterRace : MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Mind flayer";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new LoseIntAttackEffect(), 2, 6),
            new MonsterAttack(AttackType.Gaze, new LoseWisAttackEffect(), 2, 6),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override string Description => "A humanoid form with a gruesome head, tentacular mouth, and piercing eyes. Claws reach out for you and you feel a presence invade your mind.";
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Mind flayer";
        public override int Hdice => 15;
        public override bool Hold => true;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 28;
        public override int Mexp => 200;
        public override bool MindBlast => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Mind    ";
        public override string SplitName3 => "   flayer   ";
    }
}
