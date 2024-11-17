import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ContactModel } from './models/contact-model';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  constructor(private httpClient: HttpClient) {}

  getAll() {
    return this.httpClient.get<ContactModel[]>(
      environment.baseUrl + 'Contact/GetAll'
    );
  }
  getById(id: number) {
    return this.httpClient.get<ContactModel>(
      environment.baseUrl + 'Contact/GetById?id=' + id
    );
  }
  create(contact: ContactModel) {
    return this.httpClient.post<any>(
      environment.baseUrl + 'Contact/Create',
      contact
    );
  }
  update(contact: ContactModel) {
    return this.httpClient.put<any>(
      environment.baseUrl + 'Contact/Update',
      contact
    );
  }
  delete(id: number) {
    return this.httpClient.delete<any>(
      environment.baseUrl + 'Contact/Delete?id=' + id
    );
  }
}
