import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { NewUserComponent } from './new-user/new-user.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserListComponent } from './user-list/user-list.component';


const routes: Routes = [
  {path: "home", component: UserListComponent},
  {path: "userdetail/:id", component: UserDetailComponent},
  {path: "newuser", component: NewUserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
