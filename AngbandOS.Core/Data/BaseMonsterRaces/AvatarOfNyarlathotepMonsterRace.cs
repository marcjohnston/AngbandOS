using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class AvatarOfNyarlathotepMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Avatar of Nyarlathotep";

        public override int ArmourClass => 70;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 5;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 5;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override string Description => "The Crawling Chaos with 1000 forms. Nyarlathotep is amused at yourpuny attempts to kill him, and will keep coming back for another go, until he gets bored with the game.";
        public override bool EldritchHorror => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Avatar of Nyarlathotep";
        public override int Hdice => 25;
        public override int Hside => 25;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 45;
        public override bool Male => true;
        public override int Mexp => 500;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Shapechanger => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "   Avatar   ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "Nyarlathotep";
    }
}
