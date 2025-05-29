//// AngbandOS: 2022 Marc Johnston
////
//// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
//// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
//// and not for profit purposes provided that this copyright and statement are included in all such
//// copies. Other copyrights may also apply.”
//namespace AngbandOS.Core.CharacterClassRaces;

//[Serializable]
//internal abstract class CharacterClassRace : IGetKey
//{
//    protected readonly Game Game;
//    protected CharacterClassRace(Game game)
//    {
//        Game = game;
//    }
//    public BaseCharacterClass CharacterClass { get; private set; }
//    public Race Race { get; private set; }
//    public virtual string CharacterClassBindingKey { get; }
//    public virtual string RaceBindingKey { get; }
//    public string GetKey => $"{CharacterClassBindingKey}-{RaceBindingKey}";

//    public static string GetCompositeKey(BaseCharacterClass characterClass, Race race) => $"{characterClass.Key}-{race.Key}";

//    //protected virtual string? RacialPowerBindingKey => null;
//    //public RacialPower? RacialPower { get; private set; }

//    public void Bind()
//    {
//        CharacterClass = Game.SingletonRepository.Get<BaseCharacterClass>(CharacterClassBindingKey);
//        Race = Game.SingletonRepository.Get<Race>(RaceBindingKey);
//        //RacialPower = Game.SingletonRepository.GetNullable<RacialPower>(RacialPowerBindingKey);
//    }

//    public string ToJson()
//    {
//        return "";
//    }
//}

//[Serializable]
//internal class WarriorCharacterClassDraconianRace : CharacterClassRace
//{
//    private WarriorCharacterClassDraconianRace(Game game) : base(game) { }
//    public override string RaceBindingKey => nameof(DraconianRace);
//    public override string CharacterClassBindingKey => nameof(WarriorCharacterClass);
//    public override void UseRacialPower()
//    {
//        base.UseRacialPower();
//    }
//}