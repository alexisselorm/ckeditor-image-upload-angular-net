import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import Editor from 'ckeditor5/build/ckeditor';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'ckedior-image-upload-angular-net.client';
  constructor() {}

  public editor = Editor;

  form: FormGroup = new FormGroup({
    title: new FormControl('', Validators.required),
    body: new FormControl('', Validators.required),
  });

  onSubmit() {}
}
