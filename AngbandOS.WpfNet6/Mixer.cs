// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media;
namespace Cthangband
{
    public class Mixer
    {
        public float MusicVolume = 1;
        public float SoundVolume = 1;
        private readonly Assembly _assembly = Assembly.GetExecutingAssembly();
        private readonly Dictionary<MusicTrackEnum, Uri> _musicSources = new Dictionary<MusicTrackEnum, Uri>();
        private readonly Dictionary<SoundEffectEnum, List<string>> _soundResourceLists = new Dictionary<SoundEffectEnum, List<string>>();
        private MusicTrackEnum _currentMusicTrack = MusicTrackEnum.None;
        private MediaPlayer _musicPlayer = new MediaPlayer();
        private MediaPlayer _soundPlayer = new MediaPlayer();

        public Mixer()
        {
            _musicSources.Add(MusicTrackEnum.Chargen, new Uri("Music/scissors-by-kevin-macleod-from-filmmusic-io.mp3", UriKind.Relative));
            _musicSources.Add(MusicTrackEnum.Death, new Uri("Music/final-count-by-kevin-macleod-from-filmmusic-io.mp3", UriKind.Relative));
            _musicSources.Add(MusicTrackEnum.Dungeon, new Uri("Music/controlled-chaos---no-percussion-by-kevin-macleod-from-filmmusic-io.mp3", UriKind.Relative));
            _musicSources.Add(MusicTrackEnum.Menu, new Uri("Music/come-play-with-me-by-kevin-macleod-from-filmmusic-io.mp3", UriKind.Relative));
            _musicSources.Add(MusicTrackEnum.QuestLevel, new Uri("Music/the-house-of-leaves-by-kevin-macleod-from-filmmusic-io.mp3", UriKind.Relative));
            _musicSources.Add(MusicTrackEnum.Town, new Uri("Music/ghost-processional-digitally-processed-by-kevin-macleod-from-filmmusic-io.mp3", UriKind.Relative));
            _musicSources.Add(MusicTrackEnum.Victory, new Uri("Music/take-a-chance-by-kevin-macleod-from-filmmusic-io.mp3", UriKind.Relative));
            _musicSources.Add(MusicTrackEnum.Wilderness, new Uri("Music/land-of-phantoms-by-kevin-macleod-from-filmmusic-io.mp3", UriKind.Relative));
            _soundResourceLists.Add(SoundEffectEnum.ActivateArtifact, new List<string> { "plm_aim_wand.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Bell, new List<string> { "plm_jar_ding.wav" });
            _soundResourceLists.Add(SoundEffectEnum.BreathWeapon, new List<string> { "mco_attack_breath.wav" });
            _soundResourceLists.Add(SoundEffectEnum.BumpWall, new List<string> { "plm_wood_thud.wav" });
            _soundResourceLists.Add(SoundEffectEnum.CastSpell, new List<string> { "plm_spell1.wav", "plm_spell2.wav", "plm_spell3.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Cursed, new List<string> { "pls_man_oooh.wav" });
            _soundResourceLists.Add(SoundEffectEnum.DestroyItem, new List<string> { "plm_bang_metal.wav", "plm_break_canister.wav", "plm_break_glass.wav", "plm_break_glass2.wav", "plm_break_plates.wav", "plm_break_shatter.wav", "plm_break_smash.wav", "plm_glass_breaking.wav", "plm_glass_break.wav", "plm_glass_smashing.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Dig, new List<string> { "plm_metal_clank.wav" });
            _soundResourceLists.Add(SoundEffectEnum.DisarmTrap, new List<string> { "plm_bang_ceramic.wav", "plm_chest_latch.wav", "plm_click_switch3.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Drop, new List<string> { "plm_drop_boot.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Eat, new List<string> { "plm_eat_bite.wav" });
            _soundResourceLists.Add(SoundEffectEnum.EnterDungeon1, new List<string> { "amb_door_iron.wav", "amb_bell_metal1.wav" });
            _soundResourceLists.Add(SoundEffectEnum.EnterDungeon2, new List<string> { "amb_bell_tibet1.wav", "amb_bell_metal2.wav", "amb_gong_strike.wav" });
            _soundResourceLists.Add(SoundEffectEnum.EnterDungeon3, new List<string> { "amb_bell_tibet2.wav", "amb_dungeon_echo.wav", "amb_pulse_low.wav" });
            _soundResourceLists.Add(SoundEffectEnum.EnterDungeon4, new List<string> { "amb_bell_tibet3.wav", "amb_dungeon_echowet.wav", "amb_gong_undertone.wav" });
            _soundResourceLists.Add(SoundEffectEnum.EnterDungeon5, new List<string> { "amb_door_doom.wav", "amb_gong_chinese.wav", "amb_gong_low.wav" });
            _soundResourceLists.Add(SoundEffectEnum.EnterStore, new List<string> { "sto_bell_desk.wav", "sto_bell_ding.wav", "sto_bell_dingaling.wav", "sto_bell_jingles.wav", "sto_bell_ringing.wav", "sto_bell_shop.wav" });
            _soundResourceLists.Add(SoundEffectEnum.EnterTownDay, new List<string> { "amb_thunder_rain.wav" });
            _soundResourceLists.Add(SoundEffectEnum.EnterTownNight, new List<string> { "amb_guitar_chord.wav", "amb_thunder_roll.wav" });
            _soundResourceLists.Add(SoundEffectEnum.FindSecretDoor, new List<string> { "id_bad_hmm.wav" });
            _soundResourceLists.Add(SoundEffectEnum.HealthWarning, new List<string> { "plc_bell_warn.wav" });
            _soundResourceLists.Add(SoundEffectEnum.HitGood, new List<string> { "plc_hit_anvil.wav" });
            _soundResourceLists.Add(SoundEffectEnum.HitGreat, new List<string> { "plc_hit_groan.wav" });
            _soundResourceLists.Add(SoundEffectEnum.HitHiGreat, new List<string> { "plc_hit_grunt.wav" });
            _soundResourceLists.Add(SoundEffectEnum.HitHiSuperb, new List<string> { "plc_hit_anvil2.wav" });
            _soundResourceLists.Add(SoundEffectEnum.HitSuperb, new List<string> { "plc_hit_grunt2.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Hungry, new List<string> { "id_bad_hmm.wav" });
            _soundResourceLists.Add(SoundEffectEnum.IdentifyBad, new List<string> { "id_bad_hmm.wav" });
            _soundResourceLists.Add(SoundEffectEnum.IdentifyGood, new List<string> { "id_bad_hmm.wav" });
            _soundResourceLists.Add(SoundEffectEnum.IdentifySpecial, new List<string> { "id_bad_hmm.wav" });
            _soundResourceLists.Add(SoundEffectEnum.LeaveStore, new List<string> { "plm_door_bolt.wav" });
            _soundResourceLists.Add(SoundEffectEnum.LevelGain, new List<string> { "plm_levelup.wav" });
            _soundResourceLists.Add(SoundEffectEnum.LockpickFail, new List<string> { "plm_click_dry.wav", "plm_click_switch.wav", "plm_click_wood.wav", "plm_door_echolock.wav", "plm_door_wooden.wav" });
            _soundResourceLists.Add(SoundEffectEnum.LockpickSuccess, new List<string> { "plm_break_wood.wav", "plm_cabinet_open.wav", "plm_chest_unlatch.wav", "plm_lock_case.wav", "plm_lock_distant.wav", "plm_open_case.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MeleeHit, new List<string> { "plc_hit_hay.wav", "plc_hit_body.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Miss, new List<string> { "plc_miss_arrow2.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterBashes, new List<string> { "mco_squish_snap.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterBegs, new List<string> { "mco_man_mumble.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterBites, new List<string> { "mco_snarl_short.wav", "mco_bite_soft.wav", "mco_bite_munch.wav", "mco_bite_long.wav", "mco_bite_short.wav", "mco_bite_gnash.wav", "mco_bite_chomp.wav", "mco_bite_regular.wav", "mco_bite_small.wav", "mco_bite_dainty.wav", "mco_bite_hard.wav", "mco_bite_chew.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterBreeds, new List<string> { "mco_frog_trill.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterButts, new List<string> { "mco_cuica_rubbing.wav", "mco_thud_crash.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterCausesFear, new List<string> { "mco_creature_groan.wav", "mco_dino_slur.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterClaws, new List<string> { "mco_ceramic_trill.wav", "mco_scurry_dry.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterCrawls, new List<string> { "mco_card_shuffle.wav", "mco_shake_roll.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterCreatesTraps, new List<string> { "mco_thoing_deep.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterCrushes, new List<string> { "mco_dino_low.wav", "mco_squish_hit.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterDies, new List<string> { "mco_howl_croak.wav", "mco_howl_deep.wav", "mco_howl_distressed.wav", "mco_howl_high.wav", "mco_howl_long.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterDrools, new List<string> { "mco_creature_choking.wav", "mco_liquid_squirt.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterEngulf, new List<string> { "mco_dino_talk.wav", "mco_dino_yawn.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterFlees, new List<string> { "mco_creature_yelp.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterGazes, new List<string> { "mco_thoing_backwards.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterHits, new List<string> { "mco_hit_whip.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterInsults, new List<string> { "mco_strange_thwoink.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterKicks, new List<string> { "mco_rubber_thud.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterMoans, new List<string> { "mco_strange_music.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterShrieks, new List<string> { "mco_mouse_squeaks.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterSpits, new List<string> { "mco_attack_spray.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterSpores, new List<string> { "mco_dub_wobble.wav", "mco_spray_long.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterStings, new List<string> { "mco_castanet_trill.wav", "mco_tube_hit.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterTouches, new List<string> { "mco_click_vibra.wav" });
            _soundResourceLists.Add(SoundEffectEnum.MonsterWails, new List<string> { "mco_dino_low.wav" });
            _soundResourceLists.Add(SoundEffectEnum.NothingToOpen, new List<string> { "plm_click_switch2.wav", "plm_door_knob.wav" });
            _soundResourceLists.Add(SoundEffectEnum.OpenDoor, new List<string> { "plm_door_bolt.wav", "plm_door_creak.wav", "plm_door_dungeon.wav", "plm_door_entrance.wav", "plm_door_open.wav", "plm_door_opening.wav", "plm_door_rusty.wav", "plm_door_squeaky.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PickUpMoney1, new List<string> { "plm_coins_light.wav", "plm_coins_shake.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PickUpMoney2, new List<string> { "plm_chain_light.wav", "plm_coins_pour.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PickUpMoney3, new List<string> { "plm_coins_dump.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerAfraid, new List<string> { "pls_man_yell.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerBerserk, new List<string> { "pls_man_scream2.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerBlessed, new List<string> { "sum_angel_song.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerBlind, new List<string> { "pls_tone_conk.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Playerconfused, new List<string> { "pls_man_ugh.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerCut, new List<string> { "pls_man_argoh.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerDeath, new List<string> { "plc_die_laugh.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerDrugged, new List<string> { "pls_breathe_in.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerHaste, new List<string> { "pls_bell_sustain.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerHeroism, new List<string> { "pls_tone_goblet.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerInfravision, new List<string> { "pls_tone_clavelo8.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerInvulnerable, new List<string> { "pls_tone_blurk.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerParalysed, new List<string> { "pls_man_gulp_new.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerPoisoned, new List<string> { "pls_tone_guiro.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerProtEvil, new List<string> { "pls_bell_glass.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerRecover, new List<string> { "pls_bell_chime_new.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerResistAcid, new List<string> { "pls_man_sniff.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerResistCold, new List<string> { "pls_tone_stick.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerResistElectric, new List<string> { "pls_tone_elec.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerResistFire, new List<string> { "pls_tone_scrape.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerResistPoison, new List<string> { "pls_man_spit.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerSeeInvisible, new List<string> { "pls_tone_clave6.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerShield, new List<string> { "pls_bell_bowl.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerSlow, new List<string> { "pls_man_sigh.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PlayerStatDrain, new List<string> { "pls_tone_headstock.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Pray, new List<string> { "sum_angel_song.wav" });
            _soundResourceLists.Add(SoundEffectEnum.PseudoId, new List<string> { "id_good_hmm.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Quaff, new List<string> { "plm_bottle_clinks.wav", "plm_cork_pop.wav", "plm_cork_squeak.wav" });
            _soundResourceLists.Add(SoundEffectEnum.QuestMonsterDies, new List<string> { "amb_guitar_chord.wav" });
            _soundResourceLists.Add(SoundEffectEnum.RangedHit, new List<string> { "plc_hit_arrow.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Shoot, new List<string> { "plc_miss_swish.wav", "plc_miss_arrow.wav" });
            _soundResourceLists.Add(SoundEffectEnum.ShutDoor, new List<string> { "plm_bang_dumpster.wav", "plm_cabinet_shut.wav", "plm_close_hatch.wav", "plm_door_creakshut.wav", "plm_door_latch.wav", "plm_door_shut.wav", "plm_door_slam.wav" });
            _soundResourceLists.Add(SoundEffectEnum.StairsDown, new List<string> { "plm_floor_creak.wav" });
            _soundResourceLists.Add(SoundEffectEnum.StairsUp, new List<string> { "plm_floor_creak2.wav" });
            _soundResourceLists.Add(SoundEffectEnum.StoreSoldBargain, new List<string> { "id_bad_dang.wav" });
            _soundResourceLists.Add(SoundEffectEnum.StoreSoldCheaply, new List<string> { "sto_man_haha.wav" });
            _soundResourceLists.Add(SoundEffectEnum.StoreSoldExtraCheaply, new List<string> { "sto_man_whoohaha.wav" });
            _soundResourceLists.Add(SoundEffectEnum.StoreSoldWorthless, new List<string> { "sto_man_hey.wav" });
            _soundResourceLists.Add(SoundEffectEnum.StoreTransaction, new List<string> { "sto_coins_countertop.wav", "sto_bell_register1.wav", "sto_bell_register2.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Study, new List<string> { "plm_book_pageturn.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonAngel, new List<string> { "sum_angel_song.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonAnimals, new List<string> { "sum_lion_growl.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonDemons, new List<string> { "sum_ghost_wail.wav", "sum_laugh_evil2.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonDragons, new List<string> { "sum_piano_scrape.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonGreaterDemons, new List<string> { "sum_ghost_moan.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonGreaterDragons, new List<string> { "sum_gong_temple.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonGreaterUndead, new List<string> { "sum_ghost_moan.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonHounds, new List<string> { "sum_lion_growl.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonHydras, new List<string> { "sum_piano_scrape.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonMonster, new List<string> { "sum_chime_jangle.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonRingwraiths, new List<string> { "sum_bell_hand.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonSpiders, new List<string> { "sum_piano_scrape.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonUndead, new List<string> { "sum_ghost_oooo.wav" });
            _soundResourceLists.Add(SoundEffectEnum.SummonUniques, new List<string> { "sum_bell_tone.wav" });
            _soundResourceLists.Add(SoundEffectEnum.Teleport, new List<string> { "plm_chimes_jangle.wav" });
            _soundResourceLists.Add(SoundEffectEnum.TeleportLevel, new List<string> { "sum_bell_crystal.wav" });
            _soundResourceLists.Add(SoundEffectEnum.UniqueDies, new List<string> { "sum_ghost_wail.wav" });
            _soundResourceLists.Add(SoundEffectEnum.UseStaff, new List<string> { "plm_use_staff.wav" });
            _soundResourceLists.Add(SoundEffectEnum.WieldWeapon, new List<string> { "plm_metal_sharpen.wav" });
            _soundResourceLists.Add(SoundEffectEnum.ZapRod, new List<string> { "plm_zap_rod.wav" });
            _musicPlayer.MediaEnded += _mediaPlayer_MediaEnded;
        }

        public void Play(MusicTrackEnum musicTrack)
        {
            if (musicTrack == _currentMusicTrack)
            {
                return;
            }
            _currentMusicTrack = musicTrack;
            _musicPlayer.Stop();
            if (MusicVolume == 0)
            {
                return;
            }
            if (musicTrack == MusicTrackEnum.None)
            {
                return;
            }
            _musicPlayer.Volume = MusicVolume;
            _musicPlayer.Open(_musicSources[_currentMusicTrack]);
            _musicPlayer.Play();
        }

        public int DieRoll(int max)
        {
            if (max <= 1)
            {
                return 1;
            }
            Random use = new Random();
            return use.Next(max) + 1;
        }

        /// <summary>
        /// Play any one sound from a group of sound effects.
        /// </summary>
        /// <param name="sound">Which sound group to play from.</param>
        public void Play(SoundEffectEnum sound)
        {
            List<string> list = _soundResourceLists[sound];
            if (SoundVolume == 0 || list.Count == 0)
            {
                return;
            }
            string soundResourceName = @"Sounds\" + list[DieRoll(list.Count) - 1];
            Uri uri = new Uri(soundResourceName, UriKind.Relative);
            _soundPlayer.Volume = SoundVolume;
            _soundPlayer.Open(uri);
            _soundPlayer.Play();
        }

        public void ResetCurrentMusicVolume()
        {
            if (MusicVolume == 0)
            {
                _musicPlayer.Volume = 0;
                _musicPlayer.Stop();
            }
            else
            {
                if (_musicPlayer.Volume < 0.01)
                {
                    var track = _currentMusicTrack;
                    _currentMusicTrack = MusicTrackEnum.None;
                    Play(track);
                }
                else
                {
                    _musicPlayer.Volume = MusicVolume;
                }
            }
        }

        internal void Initialise(float musicVolume, float soundVolume)
        {
            MusicVolume = musicVolume;
            SoundVolume = soundVolume;
            _musicPlayer.Volume = MusicVolume;
            _soundPlayer.Volume = SoundVolume;
        }

        private void _mediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            _musicPlayer.Position = TimeSpan.Zero;
            _musicPlayer.Play();
        }
    }
}