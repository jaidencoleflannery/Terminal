import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, filter } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {

  private isAuthenticatedSubject = new BehaviorSubject<boolean | null>(null);

  public isAuthenticated$: Observable<boolean> =
    this.isAuthenticatedSubject.asObservable()
      .pipe(filter((val): val is boolean => val !== null));

  constructor() {
    this.checkAuth();
  }

  async checkAuth(): Promise<boolean> {
    try {
      const res = await fetch('http://localhost:5246/auth', {
        credentials: 'include',
        method: 'GET'
      });

      if (!res.ok) throw new Error('unauth');
      const { authenticated } = await res.json();
      this.isAuthenticatedSubject.next(authenticated);
      return authenticated;

    } catch {
      this.isAuthenticatedSubject.next(false);
      return false;
    }
  }
}
