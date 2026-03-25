import { Component, signal } from '@angular/core';
import { Patient } from './patient.model';
import { RegistrationForm } from './registration-form/registration-form';
import { PatientList } from './patient-list/patient-list';

@Component({
  selector: 'app-root',
  imports: [RegistrationForm, PatientList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  allPatients: Patient[] = [];

  onNewPatient(patient:Patient){
    this.allPatients = [...this.allPatients, patient]
  }

}
