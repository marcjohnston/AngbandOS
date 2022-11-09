using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class NexusQuylthulgMonsterRace : MonsterRace
    {
        public override char Character => 'Q';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Nexus quylthulg";

        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => null;
        public override bool Blink => true;
        public override string Description => "It is a very unstable, strange pulsing mound of flesh.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 1;
        public override int FreqSpell => 1;
        public override string FriendlyName => "Nexus quylthulg";
        public override int Hdice => 10;
        public override int Hside => 12;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 32;
        public override int Mexp => 300;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 10;
        public override int Rarity => 1;
        public override bool ResistNexus => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Nexus    ";
        public override string SplitName3 => " quylthulg  ";
        public override bool TeleportAway => true;
    }
}
