import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Post} from "../../models/post";

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {

  constructor(private fb: FormBuilder) { }

  private post: Post;
  signupForm: FormGroup;

  ngOnInit() {
    this.signupForm  = this.fb.group({
      email: ['', [Validators.required,
        Validators.pattern('[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$')]]
      });
  }

  get email() { return this.signupForm.get('email'); }

  get text() { return this.signupForm.get('text'); }

  public onFormSubmit() {
    if (this.signupForm.valid) {
      this.post = this.signupForm.value;
      console.log(this.post);
      /* Any API call logic via services goes here */
    }
  }
}
