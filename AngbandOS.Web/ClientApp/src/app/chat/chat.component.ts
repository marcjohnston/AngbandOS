import { AfterViewChecked, Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatLegacySnackBar as MatSnackBar } from '@angular/material/legacy-snack-bar';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { ChatMessage } from './chat-message';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit, OnDestroy, AfterViewChecked {
  public history: ChatMessage[] | undefined;
  public isAuthenticated: boolean = false;
  public isAdministrator = false;
  public connectionId: string | null = null;
  @ViewChild('scrollDiv', { static: true }) private scrollDivRef: ElementRef | undefined;
  private scrollToBottomOfChatAfterViewChecked = false;
  private _initSubscriptions = new Subscription();
  private _chatConnection: SignalR.HubConnection | undefined; // Initialized only as needed due to two different authentication channels.
  private _serviceConnection: SignalR.HubConnection | undefined; // Initialized only as needed due to two different authentication channels.

  constructor(
    private _authenticationService: AuthenticationService,
    private _snackBar: MatSnackBar,
    private _ngZone: NgZone
  ) {
 }

  public formatDate(dateString: string | undefined) {
    if (dateString === undefined) {
      return "-";
    }

    const dateNumber: number = Date.parse(dateString);
    const date: Date = new Date(dateNumber);
    const now: Date = new Date();

    // Check to see if the message was sent today.
    if (date.getDate() === now.getDate() && date.getMonth() === now.getMonth() && date.getFullYear() === now.getFullYear()) {
      // Do not show the date.
      return date.toLocaleTimeString([], { hour: 'numeric', minute: 'numeric' });
    } else {
      // Show the date and the time.
      return date.toLocaleDateString();
   ;
    }
  }

  public deleteMessage(message: ChatMessage) {
    if (this._chatConnection !== undefined) {
      this._chatConnection.send("DeleteMessage", message.id);
    }
  }

  public input(event: Event) {
    if (this._chatConnection !== undefined) {
      const inputElement: HTMLTextAreaElement = event.currentTarget as HTMLTextAreaElement;
      const text: string = inputElement.value;
      if (text.endsWith("\n")) {
        const strippedText = text.slice(0, -1);
        if (strippedText.length > 0) {
          this._chatConnection.send("SendMessage", null, strippedText);
        }
        inputElement.value = "";
      }
    }
  }

  private scrollToBottomOfChat() {
    const scrollDiv: HTMLDivElement = this.scrollDivRef?.nativeElement as HTMLDivElement;
    scrollDiv.scrollTop = scrollDiv.scrollHeight;
  }

  ngAfterViewChecked() {
    if (this.scrollToBottomOfChatAfterViewChecked) {
      this.scrollToBottomOfChatAfterViewChecked = false;
      this.scrollToBottomOfChat();
    }
  }

  private updateHistory(history: ChatMessage[]) {
    console.log("Chat updated.")
    this._ngZone.run(() => {
      this.history = history;
      this.scrollToBottomOfChatAfterViewChecked = true;
    });
  }

  private appendHistory(message: ChatMessage) {
    console.log("Chat message received.");
    this._ngZone.run(() => {
      this.history?.push(message);
      this.scrollToBottomOfChatAfterViewChecked = true;
    });
  }

  private connectServiceHub() {
    // Since we bounce back and forth between the chat and service hubs depending on the authentication of the user, we will initialize the
    // connection only as needed.
    console.log("Connecting to service hub.");
    this._serviceConnection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/service-hub").build();
    this._serviceConnection.start().then(() => {
      this.connectionId = `Service: ${this._serviceConnection?.connectionId!}`;
      if (this._serviceConnection !== undefined) {
        this._serviceConnection.on("ChatRefreshed", (_history: ChatMessage[]) => {
          this.updateHistory(_history);
        });
        this._serviceConnection.on("ChatUpdated", (_message: ChatMessage) => {
          this.appendHistory(_message);
        });
        this._serviceConnection.send("RefreshChat", null);
      }
    }, (reason: any) => {
      console.log(`Service hub connection rejected for reason '${reason}'`);
    });
  }

  private connectChatHub(accessToken: string) {
    // Since we bounce back and forth between the chat and service hubs depending on the authentication of the user, we will initialize the
    // connection only as needed.
    console.log("Connecting to chat hub.");
    this._chatConnection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/chat-hub", {
      accessTokenFactory: () => accessToken
    }).build();
    this._chatConnection.start().then(() => {
      this.connectionId = `Chat: ${this._chatConnection?.connectionId!}`;
      if (this._chatConnection !== undefined) {
        this._chatConnection.on("ChatRefreshed", (_history: ChatMessage[]) => {
          this.updateHistory(_history);
        });
        this._chatConnection.on("ChatUpdated", (_message: ChatMessage) => {
          this.appendHistory(_message);
        });
        this._chatConnection.on("MessageFailed", () => {
          this._ngZone.run(() => {
            this._snackBar.open("Unable to send message.", "", {
              duration: 5000
            });
          })
        });
        this._chatConnection.send("RefreshChat", null);
      }
    }, (reason: any) => {
      console.log(`Chat hub connection rejected for reason '${reason}'`);
    });
  }

  private showMessage(message: string) {
    this._ngZone.run(() => {
      this._snackBar.open(message, "", {
        duration: 5000
      });
    });
  }

  private handleAuthenticationChange() {
    console.log("Reconnecting due to authentication change.");
    this.disconnectChatHub();
    this.disconnectServiceHub();

    // Check to see if we are authenticated.
    if (this._authenticationService.currentUser.value == null || this._authenticationService.currentUser.value?.jwt === undefined) {
      // Connect to the anonymous service-hub.
      this.isAuthenticated = false;
      this.connectServiceHub();
    } else {
      this.isAuthenticated = true;
      this.isAdministrator = this._authenticationService.currentUser.value?.isAdmin!;
      const accessToken = this._authenticationService.currentUser.value.jwt;
      this.connectChatHub(accessToken);
    }
  }

  ngOnInit(): void {
    // Subscribe to the current user so that we can check the authentication.
    const currentUserSubscription = this._authenticationService.currentUser.subscribe((_user: UserDetails | null) => {
      this.handleAuthenticationChange();
    }, (error: any) => {
      console.log("Error subscribing to authentication service.");
    });
    this._initSubscriptions.add(currentUserSubscription);
  }

  private disconnectServiceHub() {
    if (this._serviceConnection !== undefined) {
      console.log("Disconnecting from service hub.");
      this._serviceConnection.off("ChatUpdated");
      this._serviceConnection.off("ChatRefreshed");
      this._serviceConnection.stop();
      this._serviceConnection = undefined;
    }
  }

  private disconnectChatHub() {
    if (this._chatConnection !== undefined) {
      console.log("Disconnecting from chat hub.");
      this._chatConnection.off("ChatUpdated");
      this._chatConnection.off("MessageFailed");
      this._chatConnection.off("ChatRefreshed");
      this._chatConnection.stop();
      this._chatConnection = undefined;
   }
  }

  ngOnDestroy() {
    console.log("Destroying chat.");
    this._initSubscriptions.unsubscribe();
    this.disconnectServiceHub();
    this.disconnectChatHub();
  }
}
