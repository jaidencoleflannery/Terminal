import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { BodyComponent } from './body/body.component';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, BodyComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  @Input() summariesActive!: boolean;
  @Input() profileActive!: boolean;

  async showSummaries(){
    this.summariesActive = !this.summariesActive;
  }

  async showProfile(){
    this.profileActive = !this.profileActive;
  }
}
