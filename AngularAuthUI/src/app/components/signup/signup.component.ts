import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

import ValidateForm from 'src/app/helpers/validateForm';

import { AuthService } from 'src/app/services/auth.service';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  // these are properties
  // changes the input keyword "type" to password
  type: string = "password";

  // boolean to show if the thing being clicked is not text
  isText: boolean = false;

  // uses {{ eyeIcon }} to replace fa-eye-slash
  eyeIcon: string ="fa-eye-slash";

  SignUpForm!: FormGroup;
  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.SignUpForm = this.fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: ['', Validators.required],
      Username: ['', Validators.required],
      Password: ['', Validators.required],
      Role: ['', Validators.nullValidator],
      Token: ['', Validators.nullValidator]
    })
  }
  
  hideShowPass() {
    // toggles the isText boolean
    this.isText = !this.isText;

    // this is a ternary to change the eyeIcon class
    // removes the slash
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";

    // determines if the input is text or password typed
    // if text, shows the password in plain text
    this.isText ? this.type ="text" : this.type="password";
  }

  onSignUp() {
    if (this.SignUpForm.valid) {
      // send the obj to database
      console.log(this.SignUpForm.value);

      this.auth.signUp(this.SignUpForm.value)
      .subscribe({
        next:(res) => {
          alert(res.message);
          this.SignUpForm.reset();
          this.router.navigate(['login']);
        },
        error:(err) => {
          alert(err?.error.message)
        }
      });
    } else {
      // throw error using taoster and with required fields.
      ValidateForm.validateAllFormFields(this.SignUpForm);

      alert("Please enter the required information");
    }
  }
}