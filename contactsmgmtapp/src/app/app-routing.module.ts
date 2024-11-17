import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactListComponent } from './contact-list/contact-list.component';
import { ContactAddEditComponent } from './contact-add-edit/contact-add-edit.component';

const routes: Routes = [

  {

    path : "",
    component : ContactListComponent
  },
  {

    path : "contact",
    component : ContactAddEditComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
