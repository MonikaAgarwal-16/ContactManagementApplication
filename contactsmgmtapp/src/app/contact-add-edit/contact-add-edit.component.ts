import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactModel } from '../models/contact-model';
import { ContactService } from '../contact-service.service';

@Component({
  selector: 'app-contact-add-edit',
  templateUrl: './contact-add-edit.component.html',
  styleUrls: ['./contact-add-edit.component.css'],
})
export class ContactAddEditComponent implements OnInit, OnChanges {
  form: FormGroup;
  isEditMode = false;
  //id: number = -1;
  @Input() id!: number;
  @Output() dataEmitter = new EventEmitter<string>();
  currentContact: ContactModel = new ContactModel();

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private contactService: ContactService
  ) {
    this.form = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
    });
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes.id) {
      let prv = changes.id.previousValue;
      let current = changes.id.currentValue;

      if (prv != current && current > 0) {
        this.getContactById(this.id);
        this.isEditMode = true;
      } else {
        this.isEditMode = false;
      }
    }
  }

  get formControls() {
    return this.form.controls;
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      // this.id = params['id'] ? params['id'] : -1;
      // if (this.id > 0) {
      //   this.getContactById(this.id);
      //   this.isEditMode = true;
      // }
    });
  }

  getContactById(id: number) {
    this.contactService.getById(id).subscribe({
      next: (response) => {
        this.currentContact = response;
        this.bindContact(this.currentContact);
      },
      error: (error) => {
        alert(error.error.AppErrorMsg);
      },
    });
  }

  bindContact(contact: ContactModel) {
    this.formControls.firstName.setValue(contact.firstName);
    this.formControls.lastName.setValue(contact.lastName);
    this.formControls.email.setValue(contact.email);
  }

  onSubmit(): void {
    this.form.markAllAsTouched();
    this.form.updateValueAndValidity();
    if (this.form.invalid) {
      return;
    }

    var contact = new ContactModel();

    contact.firstName = this.formControls.firstName.value;
    contact.lastName = this.formControls.lastName.value;
    contact.email = this.formControls.email.value;
    contact.id = this.currentContact.id;

    if (this.isEditMode) {
      this.contactService.update(contact).subscribe({
        next: (response) => {
          alert(response.message);
          this.onCancel();
        },
        error: (error) => {
          alert(error.error.AppErrorMsg);
          console.log(error);
        },
      });
    } else {
      this.contactService.create(contact).subscribe({
        next: (response) => {
          alert(response.message);
          this.onCancel();
        },
        error: (error) => {
          alert(error.error.AppErrorMsg);
          console.log(error);
        },
      });
    }
  }

  onCancel() {
    //this.router.navigateByUrl('/');
    this.form.reset();
    this.currentContact = new ContactModel();

    this.dataEmitter.emit('Contact List is updated.');
  }
}
