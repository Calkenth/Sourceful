import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IUserDetail } from '../models/IUserDetail';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  pageTitle = "User Details";
  userDetail: IUserDetail = null;
  constructor(private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit(): void {
    let id = +this.route.snapshot.params['id'];

    if(!isNaN(id)){
      this.userService.getUserDetail(id).subscribe(
        data => {
          this.userDetail = data;
        }
      )
    }
  }

}
