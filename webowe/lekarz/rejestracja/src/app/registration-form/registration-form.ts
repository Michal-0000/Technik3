import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Patient } from '../patient.model';
import { EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-registration-form',
  imports: [FormsModule, CommonModule],
  templateUrl: './registration-form.html',
  styleUrl: './registration-form.css',
})
export class RegistrationForm {

  newPatient: Patient= {fullName:'', pesel:'', specialist:'Internista'};

  @Output() patientAdded = new EventEmitter<Patient>();

  submit(){
    const regex = /^[0-9]{11}$/;
    if(!regex.test(this.newPatient.pesel)){
      alert("Błędny Pesel");
      return;
    }
    if(this.newPatient.fullName){
      this.patientAdded.emit({...this.newPatient});
      this.newPatient.fullName = '';
      this.newPatient.pesel = '';
    }

  }

}
