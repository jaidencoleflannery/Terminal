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
  
    ngOnInit(): void {
      this.getUserInfo();
    }
  
    navPop() {
      this.isActive = !this.isActive;
    }
  
    getUserInfo(){
      console.log('Implement user info');
    }

    register(){
      console.log('Implement register');
    }
}
