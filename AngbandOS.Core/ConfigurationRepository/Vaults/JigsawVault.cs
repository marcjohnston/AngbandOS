// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class JigsawVault : Vault
{
    private JigsawVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Jigsaw";
    public override int Category => 8;
    public override int Height => 16;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%...............................................%%.#############################################.%%.#&&&&&&&&&&&&###99999999###&&&&&&&###&*&*&*&#.%%.#&9999999999&&&##,,,,,,##,,,,,,,,##*&*&*&*&*#.%%.#&99999&&&&&&&&##,,,,,,##,,,,,,,,##&*&*&*&*&#.%%.#&9999&&###&&###,,,###,,###@8,@8,@###*&###&*#.%%.#&&99&&##*##&#,,,,##9##988##@@@@@@@@#&##9##&#.%%.##&&&&##***########999#######9999######9@9###.%%.###&&##*******##,,,,,,,,,##8##@@##88##@,@,@,#.%%.#8####&&&&&&&##,,,,,,,,,##999####9999##@,@,@#.%%.#9@&@&@&@&@&@##,,,,,,,,,##,,,,,,,,,,,##,@,@,#.%%.#*************##,,,,,,,,,##&&&&&&&&&##,@,@,@#.%%.#############################################.%%...............................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 49;
}
