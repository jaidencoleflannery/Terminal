import { Component, ViewEncapsulation, OnInit } from '@angular/core';
import  { ReactiveFormsModule, FormsModule, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-body',
  standalone: true,
  imports: [ ReactiveFormsModule, FormsModule ],
  templateUrl: './body.component.html',
  styleUrl: './body.component.css',
  encapsulation: ViewEncapsulation.None,
})
export class BodyComponent{

  value: any;
  form: any;

  constructor (private fb: FormBuilder) {
    this.form = this.fb.group({
      value: ''
    });
  }

  submit () {
    console.log(this.form.value);
    this.form.reset(
      this.value = ''
    );
  }
}