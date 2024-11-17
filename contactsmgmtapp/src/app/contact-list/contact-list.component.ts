import { Component, OnInit } from '@angular/core';
import { ContactService } from '../contact-service.service';
import { ContactModel } from '../models/contact-model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css'],
})
export class ContactListComponent implements OnInit {
  users: ContactModel[] = [];

  resmessage: string = '';
  showAddEditContact: boolean = false;
  currentid: number;

  constructor(private contactService: ContactService, private router: Router) {}

  ngOnInit(): void {
    this.getContacts();
  }

  getContacts() {
    this.contactService.getAll().subscribe({
      next: (response) => {
        this.users = response;
      },
      error: (error) => {
        alert(error.error.AppErrorMsg);
        console.log(error);
      },
    });
  }

  onDelete(id: number) {
    this.contactService.delete(id).subscribe({
      next: (response) => {
        alert(response.message);
        this.getContacts();
      },
      error: (error) => {
        alert(error.error.AppErrorMsg);
        console.log(error);
      },
    });
  }

  AddEditContact(id: number) {
    this.currentid = id;
    this.showAddEditContact = true;
  }
  onEdit(id: number) {
    this.router.navigateByUrl('/contact?id=' + id);
  }
  receiveData(data: string) {
    this.currentid = -1;
    this.showAddEditContact = false;
    this.getContacts();
    console.log(data); // Handle the emitted data
  }
}
