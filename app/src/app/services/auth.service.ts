import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private isAuthenticatedSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public isAuthenticated$: Observable<boolean> = this.isAuthenticatedSubject.asObservable();

  constructor() { 
    this.checkAuth();
  }

  async checkAuth() {
    try {
      const response = await fetch('http://localhost:5246/auth/check', {
        credentials: 'include' // ensures cookies are sent with the request
      });
      if (!response.ok) {
        throw new Error('Not authenticated');
      }
    } catch (error) {
      this.isAuthenticatedSubject.next(false);
      return false;
    }
    this.isAuthenticatedSubject.next(true);
    return true;
  }
}
