import { Component, Input, OnDestroy, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { BodyComponent } from './body/body.component';
import { AuthService } from '../services/auth.service';
import { Subscription } from 'rxjs';
 
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, BodyComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit, OnDestroy{
  isAuthenticated: boolean = false;
  private authSubscription!: Subscription;

  @Input() summariesActive!: boolean;
  @Input() profileActive!: boolean;

  constructor (private authService: AuthService) {}

  ngOnInit() {
    this.authSubscription = this.authService.isAuthenticated$.subscribe(
      (authStatus) => {
        this.isAuthenticated = authStatus;
        console.log('Auth status:', this.isAuthenticated);
      }
    );
  }

  ngOnDestroy() {
    if (this.authSubscription) {
      this.authSubscription.unsubscribe();
    }
  }

  async showSummaries(){
    this.summariesActive = !this.summariesActive;
  }

  async showProfile(){
    this.profileActive = !this.profileActive;
  }
}
