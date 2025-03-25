import { Component, Input, ViewChild, ElementRef, Output, EventEmitter, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-summaries',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './summaries.component.html',
  styleUrl: './summaries.component.css'
})
export class SummariesComponent implements OnInit {
  @Input() isActive!: boolean;
  @Output() newConversation = new EventEmitter(false);
  @ViewChild('newConversation') valueInput!: ElementRef<HTMLInputElement>;

  ngOnInit(): void {
    this.getSummaries();
  }

  navPop() {
    this.isActive = !this.isActive;
  }

  createConversation() {
    this.newConversation.emit(true);
  }

  getSummaries(){

  }
}
