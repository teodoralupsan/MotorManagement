import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ValuesComponent } from './values/values.component';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { RoleManagementComponent } from './admin/role-management/role-management.component';
import { UsersService } from './services/users.service';

@NgModule({
   declarations: [
      AppComponent,
      ValuesComponent,
      UserManagementComponent,
      RoleManagementComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule
   ],
   providers: [
     UsersService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
