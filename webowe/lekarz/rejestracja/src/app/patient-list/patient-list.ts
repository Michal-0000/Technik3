import { Component } from '@angular/core';
import { Patient } from '../patient.model';
import { Input } from '@angular/core';

@Component({
  selector: 'app-patient-list',
  imports: [],
  templateUrl: './patient-list.html',
  styleUrl: './patient-list.css',
})
export class PatientList {
  @Input() patientList: Patient[]=[];

}
