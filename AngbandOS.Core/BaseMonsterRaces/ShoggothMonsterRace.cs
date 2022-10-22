using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ShoggothMonsterRace : Base2MonsterRace
    {
        public override char Character => 'A';
        public override Colour Colour => Colour.Black;
        public override string Name => "Shoggoth";

        public override int ArmourClass => 80;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new AcidAttackEffect();
        public override AttackType Attack1Type => AttackType.Crush;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new AcidAttackEffect();
        public override AttackType Attack2Type => AttackType.Crush;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new AcidAttackEffect();
        public override AttackType Attack3Type => AttackType.Crush;
        public override int Attack4DDice => 6;
        public override int Attack4DSides => 6;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Crush;
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override string Description => "A nightmarish fetid, black irididescence oozing towards you.";
        public override bool Drop_2D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Shoggoth";
        public override int Hdice => 50;
        public override int Hside => 20;
        public override bool HurtByLight => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int Level => 41;
        public override int Mexp => 2500;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool Regenerate => true;
        public override bool ResistPlasma => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override int Speed => 140;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Shoggoth  ";
    }
}
