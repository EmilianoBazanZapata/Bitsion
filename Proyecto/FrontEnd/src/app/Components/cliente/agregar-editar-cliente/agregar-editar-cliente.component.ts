import { ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ClienteServicesService } from 'src/app/Services/cliente-services.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-agregar-editar-cliente',
  templateUrl: './agregar-editar-cliente.component.html',
  styleUrls: ['./agregar-editar-cliente.component.css']
})
export class AgregarEditarClienteComponent implements OnInit {
  //texto del boton
  Boton = 'Registrar';
  //formulario para agregar un nuevo cliente
  form: FormGroup;
  //valores del formulario por defecto
  GeneroForm = false;
  ManejaForm = false;
  LentesForm = false;
  DiabeticoForm = false;
  OtraEnfermedadForm = false;
  //datos que llegaran d ela lista para ser actualizaados
  @Input() ClienteModel: any;
  Nombre: any;
  Apellido: any;
  Edad: any;
  Identificacion: any;
  Genero: any;
  ModalRef: BsModalRef | undefined;
  EnfermedadExrta: any;
  Id: any;
  @Output() Actualizar = new EventEmitter<boolean>();

  //alerta luego de alguna accion
  Alerta: any;

  constructor(private fb: FormBuilder,
    private _SharedService: ClienteServicesService,
    private _ModalService: BsModalService,
    private cdr: ChangeDetectorRef) {
    this.form = this.fb.group({
      Nombre: ["hola", [Validators.required, Validators.maxLength(255)]],
      Apellido: ["", [Validators.required, Validators.maxLength(255)]],
      Dni: ["", [Validators.required, Validators.maxLength(255), Validators.pattern(/^[0-9]+$/)]],
      Edad: ["", [Validators.required, Validators.maxLength(3), Validators.pattern(/^[0-9]+$/)]],
      Genero: [this.GeneroForm, [Validators.required]],
      Maneja: [this.ManejaForm, [Validators.required]],
      Lentes: [this.LentesForm, [Validators.required]],
      Diabetico: [this.DiabeticoForm, [Validators.required]],
      OtraEnfermedad: [this.OtraEnfermedadForm, [Validators.required]],
      EnfermedadExrta: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.cdr.detectChanges();
    if (this.ClienteModel != undefined) {
        this.cdr.detectChanges();
        this.Boton = 'Actualizar';
        this.Id = this.ClienteModel.id
        this.Nombre = this.ClienteModel.nombre,
        this.Apellido = this.ClienteModel.apellido,
        this.Edad = this.ClienteModel.edad,
        this.Identificacion = this.ClienteModel.identificacion,
        this.EnfermedadExrta = this.ClienteModel.otraEnfermedad;
      if (this.ClienteModel.genero == true) {
        this.GeneroForm = true;
      }
      else {
        this.GeneroForm = false;
      }
      if (this.ClienteModel.maneja == true) {
        this.ManejaForm = true;
      }
      else {
        this.ManejaForm = false;
      }
      if (this.ClienteModel.usaLentes == true) {
        this.LentesForm = true;
      }
      else {
        this.LentesForm = false;
      }
      if (this.ClienteModel.esDiabetico == true) {
        this.DiabeticoForm = true;
      }
      else {
        this.DiabeticoForm = false;
      }
      if (this.ClienteModel.padeceOtraEnfermedad == true) {
        this.OtraEnfermedadForm = true;
      }
      else {
        this.OtraEnfermedadForm = false;
      }
      this.cdr.detectChanges();
    }
  }
  AgregarCliente() {
    //console.log(val);
    if (this.Boton == "Actualizar") {
      var val =
      {
        id: this.Id,
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
      //console.log(val)
      this._SharedService.EditarCliente(val).subscribe(data => {
        this.Alerta = data;
        if (this.Alerta.displayMessage == "Usuario Actualizado Exitosamente") {
          Swal.fire('Felicidades', this.Alerta.displayMessage, 'success');
          this.Actualizar.emit(true);
          this.Boton == "Registrar";
        }
        else {
          Swal.fire('Cuidado', this.Alerta.displayMessage, 'error')
        }
      })
    }
    else if (this.Boton == "Registrar") {
      var val2 =
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
      this._SharedService.AgregarCliente(val2).subscribe(data => {
        this.Alerta = data;
        if (this.Alerta.displayMessage == "Usuario Agregado Exitosamente") {

          Swal.fire('Felicidades', this.Alerta.displayMessage, 'success');
          this.form.reset();
          this.Actualizar.emit(true);
        }
        else {
          Swal.fire('Cuidado', this.Alerta.displayMessage, 'error')
        }
      })
    }

  }
  AbrirModal(template: TemplateRef<any>) {
    this.ModalRef = this._ModalService.show(template);
  }
}