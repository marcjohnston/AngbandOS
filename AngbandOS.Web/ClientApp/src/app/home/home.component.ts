import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

export class PostNewGame {
  public username: string = "";
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public gameGuid: string | null = null;

  constructor(
    private _httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {

  }

  ngOnInit(): void {
    const postNewGame: PostNewGame = {
      username: "marc"
    };
    this._httpClient.post<string>(`api/games`, postNewGame).toPromise().then((guid: string | undefined) => {
      if (guid !== undefined) {
        this.gameGuid = guid;
      }
    }, (error: HttpErrorResponse) => {
      this.gameGuid = "post failed";
    });
  //  this._httpClient.get<string>(`api/games`).toPromise().then((guid: string | undefined) => {
  //    this.gameGuid = "get worked";
  //  }, (error: HttpErrorResponse) => {
  //    this.gameGuid = "get failed";
  //  });
  }
}

