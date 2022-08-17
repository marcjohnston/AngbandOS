import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, HostListener, NgZone, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { SavedGameDetails } from './saved-game-details';

export class PostNewGame {
  public username: string = "";
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: [
    './home.component.scss'
  ]
})
export class HomeComponent implements OnInit {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  public readonly connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/hub").build();
  public savedGames: SavedGameDetails[] | undefined = undefined;
  public displayedColumns: string[] = ['guid'];
  public selectedSavedGame: SavedGameDetails | null = null;

  constructor(
    private _httpClient: HttpClient,
    private _router: Router
  ) {
  }

  ngOnInit() {
    this._httpClient.get<SavedGameDetails[]>(`/apiv1/games/marc`).toPromise().then((_savedGames) => {
      this.savedGames = _savedGames;
    }, (error: HttpErrorResponse) => {

    });
  }

  public onRowClick(savedGame: SavedGameDetails) {
    this._router.navigate(['/play', savedGame.guid]);
  }

  public onNewGame() {
    const postNewGame: PostNewGame = {
      username: "marc"
    };
    this._httpClient.post<string>(`/apiv1/games`, postNewGame).toPromise().then((guid: string | undefined) => {
      if (guid !== undefined) {
        this._router.navigate(['/play', guid]);
      }
    }, (error: HttpErrorResponse) => {
    });
  }
}
