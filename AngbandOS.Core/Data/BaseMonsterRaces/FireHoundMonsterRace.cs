using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FireHoundMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.Red;
        public override string Name => "Fire hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override AttackEffect Attack1Effect => AttackEffect.Fire;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 3;
        public override AttackEffect Attack2Effect => AttackEffect.Fire;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Fire;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override string Description => "Flames lick at its feet and its tongue is a blade of fire. You can feel a furnace heat radiating from the creature.";
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Fire hound";
        public override bool Friends => true;
        public override int Hdice => 10;
        public override int Hside => 6;
        public override bool ImmuneFire => true;
        public override int Level => 18;
        public override int Mexp => 70;
        public override int NoticeRange => 30;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Fire    ";
        public override string SplitName3 => "   hound    ";
    }
}
