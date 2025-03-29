import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit {
    @Input() isActive!: boolean;
    accountActive: boolean = false;
    settingsActive: boolean = false;
    credActive: boolean = false;
    subActive: boolean = false;
  
    ngOnInit(): void {
      this.getUserInfo();
    }
  
    navPop() {
      this.isActive = !this.isActive;
    }
    accountPop() {
      this.accountActive = !this.accountActive;
    }
    settingsPop() {
      this.settingsActive = !this.settingsActive;
    }
    credPop() {
      this.credActive = !this.credActive;
    }
    subPop() {
      this.subActive = !this.subActive;
    }
  
    getUserInfo(){
      console.log('Implement user info');
    }

    register(){
      console.log('Implement register');
    }
}
