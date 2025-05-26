namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfGiantRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfGiantRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HalfGiantRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;

[Serializable]
internal class HalfGiantRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfGiantRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HalfGiantRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}
[Serializable]
internal class HalfOgreRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HalfOgreRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}
[Serializable]
internal class HalfOgreRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HalfOgreRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class HalfOgreRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HalfOgreRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class HalfOgreRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HalfOgreRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class HalfOgreRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HalfOgreRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}

[Serializable]
internal class HalfOgreRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HalfOgreRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}
[Serializable]
internal class HalfOrcRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HalfOrcRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}
[Serializable]
internal class HalfOrcRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HalfOrcRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class HalfOrcRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HalfOrcRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class HalfOrcRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HalfOrcRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class HalfOrcRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HalfOrcRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class HalfOrcRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HalfOrcRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}
[Serializable]
internal class HalfTitanRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HalfTitanRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 5;
}
[Serializable]
internal class HalfTitanRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HalfTitanRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class HalfTitanRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HalfTitanRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class HalfTitanRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HalfTitanRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}

[Serializable]
internal class HalfTitanRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HalfTitanRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}

[Serializable]
internal class HalfTitanRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HalfTitanRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}
[Serializable]
internal class HalfTrollRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HalfTrollRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}
[Serializable]
internal class HalfTrollRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HalfTrollRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}

[Serializable]
internal class HalfTrollRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HalfTrollRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class HalfTrollRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HalfTrollRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}

[Serializable]
internal class HalfTrollRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HalfTrollRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}

[Serializable]
internal class HalfTrollRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HalfTrollRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus =>-6 ;
}
[Serializable]
internal class HighElfRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HighElfRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}
[Serializable]
internal class HighElfRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HighElfRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}

[Serializable]
internal class HighElfRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HighElfRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class HighElfRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HighElfRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}

[Serializable]
internal class HighElfRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HighElfRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class HighElfRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HighElfRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 5;
}
[Serializable]
internal class HobbitRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HobbitRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}
[Serializable]
internal class HobbitRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HobbitRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class HobbitRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HobbitRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class HobbitRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HobbitRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}

[Serializable]
internal class HobbitRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HobbitRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class HobbitRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HobbitRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}
[Serializable]
internal class HumanRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HumanRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}
[Serializable]
internal class HumanRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HumanRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class HumanRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HumanRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class HumanRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private HumanRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class HumanRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HumanRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class HumanRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HumanRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}
[Serializable]
internal class ImpRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private ImpRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}
[Serializable]
internal class ImpRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private ImpRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class ImpRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private ImpRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class ImpRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private ImpRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class ImpRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private ImpRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class ImpRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private ImpRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}
[Serializable]
internal class KlackonRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private KlackonRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}
[Serializable]
internal class KlackonRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private KlackonRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class KlackonRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private KlackonRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class KlackonRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private KlackonRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class KlackonRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private KlackonRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class KlackonRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private KlackonRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}
[Serializable]
internal class KoboldRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private KoboldRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}
[Serializable]
internal class KoboldRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private KoboldRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class KoboldRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private KoboldRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class KoboldRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private KoboldRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class KoboldRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private KoboldRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class KoboldRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private KoboldRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}
[Serializable]
internal class MindFlayerRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private MindFlayerRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}
[Serializable]
internal class MindFlayerRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private MindFlayerRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}

[Serializable]
internal class MindFlayerRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private MindFlayerRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}

[Serializable]
internal class MindFlayerRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private MindFlayerRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class MindFlayerRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private MindFlayerRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}

[Serializable]
internal class MindFlayerRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private MindFlayerRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -5;
}
[Serializable]
internal class MiriNigriRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private MiriNigriRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}
[Serializable]
internal class MiriNigriRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private MiriNigriRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}

[Serializable]
internal class MiriNigriRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private MiriNigriRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class MiriNigriRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private MiriNigriRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class MiriNigriRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private MiriNigriRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class MiriNigriRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private MiriNigriRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}
[Serializable]
internal class NibelungRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private NibelungRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}
[Serializable]
internal class NibelungRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private NibelungRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class NibelungRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private NibelungRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class NibelungRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private NibelungRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class NibelungRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private NibelungRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class NibelungRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private NibelungRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}
[Serializable]
internal class SkeletonRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private SkeletonRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}
[Serializable]
internal class SkeletonRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private SkeletonRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}

[Serializable]
internal class SkeletonRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private SkeletonRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}

[Serializable]
internal class SkeletonRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private SkeletonRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}

[Serializable]
internal class SkeletonRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private SkeletonRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class SkeletonRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SkeletonRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private SkeletonRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}
[Serializable]
internal class SpectreRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private SpectreRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -5;
}
[Serializable]
internal class SpectreRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private SpectreRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}

[Serializable]
internal class SpectreRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private SpectreRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}

[Serializable]
internal class SpectreRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private SpectreRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class SpectreRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private SpectreRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}

[Serializable]
internal class SpectreRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private SpectreRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -6;
}
[Serializable]
internal class SpriteRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private SpriteRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}
[Serializable]
internal class SpriteRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private SpriteRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}

[Serializable]
internal class SpriteRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private SpriteRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}

[Serializable]
internal class SpriteRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private SpriteRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}

[Serializable]
internal class SpriteRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private SpriteRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}

[Serializable]
internal class SpriteRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private SpriteRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}
[Serializable]
internal class TchoTchoRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private TchoTchoRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}
[Serializable]
internal class TchoTchoRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private TchoTchoRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}

[Serializable]
internal class TchoTchoRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private TchoTchoRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class TchoTchoRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private TchoTchoRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class TchoTchoRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private TchoTchoRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}

[Serializable]
internal class TchoTchoRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private TchoTchoRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}
[Serializable]
internal class VampireRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private VampireRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}
[Serializable]
internal class VampireRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private VampireRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}

[Serializable]
internal class VampireRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private VampireRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class VampireRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private VampireRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}

[Serializable]
internal class VampireRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private VampireRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class VampireRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private VampireRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}
[Serializable]
internal class YeekRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private YeekRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}
[Serializable]
internal class YeekRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private YeekRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class YeekRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private YeekRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class YeekRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private YeekRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class YeekRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private YeekRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}

[Serializable]
internal class YeekRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private YeekRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -7;
}
[Serializable]
internal class ZombieRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private ZombieRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}
[Serializable]
internal class ZombieRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private ZombieRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -6;
}

[Serializable]
internal class ZombieRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private ZombieRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -6;
}

[Serializable]
internal class ZombieRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private ZombieRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}

[Serializable]
internal class ZombieRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private ZombieRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}

[Serializable]
internal class ZombieRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private ZombieRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -5;
}
}