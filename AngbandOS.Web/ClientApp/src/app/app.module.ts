import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PlayComponent } from './play/play.component';
import { WatchComponent } from './watch/watch.component';

import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { ResetPasswordComponent } from './accounts/reset-password/reset-password.component';
import { LoginComponent } from './accounts/login/login.component';
import { LoginMenuComponent } from './login-menu/login-menu.component';
import { ForgotPasswordComponent } from './accounts/forgot-password/forgot-password.component';
import { RegistrationComponent } from './accounts/registration/registration.component';
import { AuthenticationInterceptor } from './accounts/authentication-interceptor/authentication-interceptor';
import { ProfileComponent } from './accounts/profile/profile.component';
import { LogoutComponent } from './accounts/logout/logout.component';
import { UnauthorizedInterceptorService } from './accounts/unauthorized-interceptor/unauthorized-interceptor.service';
import { AccountConfirmationComponent } from './accounts/account-confirmation/account-confirmation.component';

import { AbilityScoresComponent } from './manual/ability-scores/ability-scores.component';
import { ChannelerComponent } from './manual/channeler/channeler.component';
import { ChaosSpellsComponent } from './manual/chaos-spells/chaos-spells.component';
import { CharismaComponent } from './manual/charisma/charisma.component';
import { ChosenOneComponent } from './manual/chosen-one/chosen-one.component';
import { CombatComponent } from './manual/combat/combat.component';
import { CommandsComponent } from './manual/commands/commands.component';
import { ConstitutionComponent } from './manual/constitution/constitution.component';
import { CorporealSpellsComponent } from './manual/corporeal-spells/corporeal-spells.component';
import { CultistComponent } from './manual/cultist/cultist.component';
import { DeathSpellsComponent } from './manual/death-spells/death-spells.component';
import { DexterityComponent } from './manual/dexterity/dexterity.component';
import { DruidComponent } from './manual/druid/druid.component';
import { ElementsComponent } from './manual/elements/elements.component';
import { FanaticComponent } from './manual/fanatic/fanatic.component';
import { FavourComponent } from './manual/favour/favour.component';
import { FeelingsComponent } from './manual/feelings/feelings.component';
import { FolkSpellsComponent } from './manual/folk-spells/folk-spells.component';
import { GreatOnesComponent } from './manual/great-ones/great-ones.component';
import { HighMageComponent } from './manual/high-mage/high-mage.component';
import { HistoryComponent } from './manual/history/history.component';
import { IntelligenceComponent } from './manual/intelligence/intelligence.component';
import { IntroductionComponent } from './manual/introduction/introduction.component';
import { ItemsComponent } from './manual/items/items.component';
import { LicenseComponent } from './manual/license/license.component';
import { LifeSpellsComponent } from './manual/life-spells/life-spells.component';
import { MageComponent } from './manual/mage/mage.component';
import { MagicBasicsComponent } from './manual/magic-basics/magic-basics.component';
import { MartialArtsComponent } from './manual/martial-arts/martial-arts.component';
import { MentalismTalentsComponent } from './manual/mentalism-talents/mentalism-talents.component';
import { MindcrafterComponent } from './manual/mindcrafter/mindcrafter.component';
import { MonkComponent } from './manual/monk/monk.component';
import { MutationsComponent } from './manual/mutations/mutations.component';
import { MysticComponent } from './manual/mystic/mystic.component';
import { NatureSpellsComponent } from './manual/nature-spells/nature-spells.component';
import { PaladinComponent } from './manual/paladin/paladin.component';
import { PatronsComponent } from './manual/patrons/patrons.component';
import { PriestComponent } from './manual/priest/priest.component';
import { RangerComponent } from './manual/ranger/ranger.component';
import { RogueComponent } from './manual/rogue/rogue.component';
import { ScoreComponent } from './manual/score/score.component';
import { SorcerySpellsComponent } from './manual/sorcery-spells/sorcery-spells.component';
import { StrengthComponent } from './manual/strength/strength.component';
import { TarotSpellsComponent } from './manual/tarot-spells/tarot-spells.component';
import { TownsAndShopsComponent } from './manual/towns-and-shops/towns-and-shops.component';
import { TurnsTimeAndSpeedComponent } from './manual/turns-time-and-speed/turns-time-and-speed.component';
import { WarriorComponent } from './manual/warrior/warrior.component';
import { WarriorMageComponent } from './manual/warrior-mage/warrior-mage.component';
import { WhatsNewComponent } from './manual/whats-new/whats-new.component';
import { WisdomComponent } from './manual/wisdom/wisdom.component';
import { TableOfContentsComponent } from './manual/table-of-contents/table-of-contents.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PlayComponent,
    WatchComponent,

    LoginComponent,
    RegistrationComponent,
    LoginMenuComponent,
    ForgotPasswordComponent,
    ProfileComponent,
    AccountConfirmationComponent,
    LogoutComponent,
    ResetPasswordComponent,

    AbilityScoresComponent,
    ChannelerComponent,
    ChaosSpellsComponent,
    CharismaComponent,
    ChosenOneComponent,
    CombatComponent,
    CommandsComponent,
    ConstitutionComponent,
    CorporealSpellsComponent,
    CultistComponent,
    DeathSpellsComponent,
    DexterityComponent,
    DruidComponent,
    ElementsComponent,
    FanaticComponent,
    FavourComponent,
    FeelingsComponent,
    FolkSpellsComponent,
    GreatOnesComponent,
    HighMageComponent,
    HistoryComponent,
    IntelligenceComponent,
    IntroductionComponent,
    ItemsComponent,
    LicenseComponent,
    LifeSpellsComponent,
    MageComponent,
    MagicBasicsComponent,
    MartialArtsComponent,
    MentalismTalentsComponent,
    MindcrafterComponent,
    MonkComponent,
    MutationsComponent,
    MysticComponent,
    NatureSpellsComponent,
    PaladinComponent,
    PatronsComponent,
    PriestComponent,
    RangerComponent,
    RogueComponent,
    ScoreComponent,
    SorcerySpellsComponent,
    StrengthComponent,
    TarotSpellsComponent,
    TownsAndShopsComponent,
    TurnsTimeAndSpeedComponent,
    WarriorComponent,
    WarriorMageComponent,
    WhatsNewComponent,
    WisdomComponent,
    TableOfContentsComponent
  ],
  imports: [
    MatTableModule,
    MatSnackBarModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,

    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'play', component: PlayComponent },
      { path: 'play/:guid', component: PlayComponent },
      { path: 'watch/:guid', component: WatchComponent },

      { path: 'accounts/login', component: LoginComponent },
      { path: 'accounts/logout', component: LogoutComponent },
      { path: 'accounts/profile', component: ProfileComponent },
      { path: 'accounts/confirm', component: AccountConfirmationComponent },
      { path: 'accounts/register', component: RegistrationComponent },
      { path: 'accounts/forgot-password', component: ForgotPasswordComponent },
      { path: 'accounts/reset-password', component: ResetPasswordComponent },

      { path: 'manual/table-of-contents', component: TableOfContentsComponent },
      { path: 'manual/ability-scores', component: AbilityScoresComponent },
      { path: 'manual/channeler', component: ChannelerComponent },
      { path: 'manual/chaos-spells', component: ChaosSpellsComponent },

      { path: 'manual/charisma', component: CharismaComponent },
      { path: 'manual/chosen-one', component: ChosenOneComponent },
      { path: 'manual/combat', component: CombatComponent },
      { path: 'manual/commands', component: CommandsComponent },
      { path: 'manual/constitution', component: ConstitutionComponent },
      { path: 'manual/corporeal-spells', component: CorporealSpellsComponent },
      { path: 'manual/cultist', component: CultistComponent },
      { path: 'manual/death-spells', component: DeathSpellsComponent },
      { path: 'manual/dexterity', component: DexterityComponent },
      { path: 'manual/druid', component: DruidComponent },
      { path: 'manual/elements', component: ElementsComponent },
      { path: 'manual/fanatic', component: FanaticComponent },
      { path: 'manual/favour', component: FavourComponent },
      { path: 'manual/feelings', component: FeelingsComponent },
      { path: 'manual/folk-spells', component: FolkSpellsComponent },
      { path: 'manual/great-ones', component: GreatOnesComponent },
      { path: 'manual/high-mage', component: HighMageComponent },
      { path: 'manual/history', component: HistoryComponent },
      { path: 'manual/intelligence', component: IntelligenceComponent },
      { path: 'manual/introduction', component: IntroductionComponent },
      { path: 'manual/items', component: ItemsComponent },
      { path: 'manual/license', component: LicenseComponent },
      { path: 'manual/life-spells', component: LifeSpellsComponent },
      { path: 'manual/mage', component: MageComponent },
      { path: 'manual/magic-beasts', component: MagicBasicsComponent },
      { path: 'manual/martial-arts', component: MartialArtsComponent },
      { path: 'manual/mentalism-talents', component: MentalismTalentsComponent },
      { path: 'manual/mindcrafter', component: MindcrafterComponent },
      { path: 'manual/monk', component: MonkComponent },
      { path: 'manual/mutations', component: MutationsComponent },
      { path: 'manual/mystic', component: MysticComponent },
      { path: 'manual/nature-spells', component: NatureSpellsComponent },
      { path: 'manual/paladin', component: PaladinComponent },
      { path: 'manual/patrons', component: PatronsComponent },
      { path: 'manual/priest', component: PriestComponent },
      { path: 'manual/ranger', component: RangerComponent },
      { path: 'manual/rogue', component: RogueComponent },
      { path: 'manual/score', component: ScoreComponent },
      { path: 'manual/sorcery-spells', component: SorcerySpellsComponent },
      { path: 'manual/strength', component: StrengthComponent },
      { path: 'manual/tarot-spells', component: TarotSpellsComponent },
      { path: 'manual/towns-and-shops', component: TownsAndShopsComponent },
      { path: 'manual/turns-time-and-speed', component: TurnsTimeAndSpeedComponent },
      { path: 'manual/warrior', component: WarriorComponent },
      { path: 'manual/warrior-mage', component: WarriorMageComponent },
      { path: 'manual/whats-new', component: WhatsNewComponent },
      { path: 'manual/wisdom', component: WisdomComponent },

    ]),
    BrowserAnimationsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: UnauthorizedInterceptorService, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
