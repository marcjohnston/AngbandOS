using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ShadowDemonMonsterRace : Base2MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.Black;
        public override string Name => "Shadow demon";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new Exp80AttackEffect();
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => new Exp40AttackEffect();
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 10;
        public override BaseAttackEffect? Attack3Effect => new LoseIntAttackEffect();
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 10;
        public override BaseAttackEffect? Attack4Effect => new LoseWisAttackEffect();
        public override AttackType Attack4Type => AttackType.Claw;
        public override bool ColdBlood => true;
        public override bool Demon => true;
        public override string Description => "A mighty spirit of darkness of vaguely humanoid form. Razor-edged claws reach out to end your life as it glides towards you, seeking to suck the energy from your soul to feed its power.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Shadow demon";
        public override bool Friends => true;
        public override int Hdice => 10;
        public override int Hside => 20;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 42;
        public override int Mexp => 425;
        public override bool NetherBolt => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override bool Regenerate => true;
        public override bool ResistNether => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Shadow   ";
        public override string SplitName3 => "   demon    ";
        public override bool Undead => true;
    }
}
