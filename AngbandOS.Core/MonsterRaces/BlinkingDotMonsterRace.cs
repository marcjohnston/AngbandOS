using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BlinkingDotMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlinkMonsterSpell());
        public override char Character => ',';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Blinking dot";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Spore, new ConfuseAttackEffect(), 1, 4),
        };
        public override string Description => "Is it there or is it not?";
        public override bool EmptyMind => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Blinking dot";
        public override int Hdice => 1;
        public override int Hside => 2;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 1;
        public override int Mexp => 1;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Blinking  ";
        public override string SplitName3 => "    dot     ";
        public override bool Stupid => true;
    }
}
