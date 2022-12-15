using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class StormGiantMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ConfuseMonsterSpell(),
            new LightningBallMonsterSpell(),
            new LightningBoltMonsterSpell(),
            new ScareMonsterSpell(),
            new BlinkMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => 'P';
        public override Colour Colour => Colour.BrightTurquoise;
        public override string Name => "Storm giant";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new ElectricityAttackEffect(), 3, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a twenty-five foot tall giant wreathed in lighting.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Storm giant";
        public override bool Giant => true;
        public override int Hdice => 38;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneLightning => true;
        public override int LevelFound => 32;
        public override bool LightningAura => true;
        public override bool Male => true;
        public override int Mexp => 1500;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Storm    ";
        public override string SplitName3 => "   giant    ";
        public override bool TakeItem => true;
    }
}
