import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable, NgZone } from '@angular/core';
import { Observable, throwError, Subscriber } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication-service/authentication.service';
import { from } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UnauthorizedInterceptorService implements HttpInterceptor {

  constructor(
    private _snackBar: MatSnackBar,
    private _authenticationService: AuthenticationService,
    private _zone: NgZone,
    private _router: Router
  ) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request.clone()).pipe(
      catchError((error: HttpErrorResponse) => {
        //401 UNAUTHORIZED
        if (error && error.status === 401 && request.url !== "/api/accounts") {
          return new Observable<HttpEvent<any>>((subscriber: Subscriber<any>) => {
            this._authenticationService.autoLogin().then(() => {
              const token = this._authenticationService.currentUser.value?.jwt;
              next.handle(request.clone({
                setHeaders: {
                  Authorization: `Bearer ${token}`
                }
              })).subscribe(
                response => subscriber.next(response),
                error => subscriber.error(error),
                () => subscriber.complete()
              );
            }, () => {
              this._zone.run(() => {
                this._snackBar.open(`ERROR 401 UNAUTHORIZED.  ${error.message}`, "", {
                  duration: 5000
                });
              });
              this._router.navigateByUrl(`/login?url=${encodeURIComponent(request.url)}`);
            });
          });
        } else {

          // this._snackBarService.show(err); Showing this error on all screens affects the registration component that renders errors
          return throwError(error);
        }
      })
    );
  }
}
