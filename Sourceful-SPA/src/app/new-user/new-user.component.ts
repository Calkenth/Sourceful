import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUserDetail } from '../models/IUserDetail';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.css']
})
export class NewUserComponent{

  pageTitle = "Create new user";
  rForm: FormGroup;
  constructor(private fb: FormBuilder, private userService: UserService, private router: Router) {
      this.rForm = this.fb.group({
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      town: ['', Validators.required],
      streetName: ['', Validators.required],
      number: ['', Validators.required],
      shortDesc: ['', Validators.required],
      longDesc: ['', Validators.required]
    });
  }

  get f() {
    return this.rForm.controls;
  }

  get fValid() {
    return this.rForm.valid;
  }

  onSubmit() {
    let newUser: IUserDetail = this.rForm.value;
    this.userService.postNewUser(newUser).subscribe(
      data => {
        this.router.navigateByUrl("/userdetail/" + data);
      }
    );
  }

  onReset() {
    this.rForm.reset();
  }

}
