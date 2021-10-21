import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteServicesService } from 'src/app/Services/cliente-services.service';

@Component({
  selector: 'app-agregar-editar-cliente',
  templateUrl: './agregar-editar-cliente.component.html',
  styleUrls: ['./agregar-editar-cliente.component.css']
})
export class AgregarEditarClienteComponent implements OnInit {
  //formulario para agregar un nuevo cliente
  form: FormGroup;
  //valores del formulario por defecto
  GeneroForm = false;
  ManejaForm = false;
  LentesForm = false;
  DiabeticoForm = false;
  OtraEnfermedadForm = false;
  constructor(private fb: FormBuilder, private _SharedService: ClienteServicesService) {
    this.form = this.fb.group({
      Nombre: ["", [Validators.required, Validators.maxLength(255)]],
      Apellido: ["", [Validators.required, Validators.maxLength(255)]],
      Dni: ["", [Validators.required, Validators.maxLength(255)]],
      Edad: ["", [Validators.required, Validators.maxLength(3)]],
      Genero: [this.GeneroForm, [Validators.required]],
      Maneja: [this.ManejaForm, [Validators.required]],
      Lentes: [this.LentesForm, [Validators.required]],
      Diabetico: [this.DiabeticoForm, [Validators.required]],
      OtraEnfermedad: [this.OtraEnfermedadForm, [Validators.required]],
      EnfermedadExrta: ["", [Validators.maxLength(5000)]]
    })
  }

  ngOnInit(): void {
  }
  AgregarCliente() {
    var val =
    {
      nombre: this.form?.value.Nombre,
      apellido: this.form?.value.Apellido,
      identificacion: this.form?.value.Dni,
      edad: this.form?.value.Edad,
      genero: this.form?.value.Genero,
      activo: true,
      maneja: this.form?.value.Maneja,
      usaLentes: this.form?.value.Lentes,
      esDiabetico: this.form?.value.Diabetico,
      padeceOtraEnfermedad: this.form?.value.OtraEnfermedad,
      otraEnfermedad: this.form?.value.EnfermedadExrta
    }
    //console.log(val);
    this._SharedService.AgregarCategoiria(val).subscribe(data => {
      console.log(data);
    })
  }
}