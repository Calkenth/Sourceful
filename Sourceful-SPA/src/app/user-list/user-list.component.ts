import { Component, OnInit } from '@angular/core';
import { IUser } from '../models/IUser';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  pageTitle: "User List";
  users: IUser[];
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(
      data => {
        this.users = data;
      }
    );
  }

  onDeleteUser(id: number) {
    console.log(id)
    this.userService.deleteUser(id).subscribe(
      data => {
        this.ngOnInit();
      }
    );
  }

}
