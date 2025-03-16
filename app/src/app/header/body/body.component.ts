import { Component, ElementRef, ViewChild, ViewEncapsulation, Input } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormBuilder } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SummariesComponent } from "./summaries/summaries.component";
import { ProfileComponent } from "./profile/profile.component";

@Component({
  selector: 'app-body',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, SummariesComponent, ProfileComponent, CommonModule],
  templateUrl: './body.component.html',
  styleUrl: './body.component.css',
  encapsulation: ViewEncapsulation.None,
})
export class BodyComponent{

  @Input() summariesActive!: boolean;
  @Input() profileActive!: boolean;

  value: any;
  form: any;

  constructor (private fb: FormBuilder) {

    this.form = this.fb.group({
      value: ''
    });
  }

  @ViewChild('valueInput') valueInput!: ElementRef<HTMLInputElement>;

  focusInput(): void {
    this.valueInput.nativeElement.focus();
  }

  async submit () {
    if (this.form.get('value').value == null || this.form.get('value').value == '') {
      return 0;
    } else {
      const url = "http://localhost:5246/value";
      try {
        const response = await fetch(url, {
          method: "POST",
          body: JSON.stringify(this.form.value),
          headers: { 
            "content-type": "application/json" 
          },
        });
        if (!response.ok) {
          throw new Error(response.statusText);
        }
        const data = await response.json();
        console.log(data);
      } catch (error) {
        console.log(error);
      }
      this.form.reset(
        this.value = ''
      );
      return null;
    }
  }
}