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
      const response = await fetch('http://localhost:5246/auth/check');
      if (!response.ok) {
        throw new Error('Not authenticated.');
      }
    } catch (error) {
      console.error(error);
      this.isAuthenticatedSubject.next(false);
      return false;
    }
    return true;
  }
}
