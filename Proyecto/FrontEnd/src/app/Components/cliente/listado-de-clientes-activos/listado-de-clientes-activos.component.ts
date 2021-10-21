import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ClienteServicesService } from 'src/app/Services/cliente-services.service';

@Component({
  selector: 'app-listado-de-clientes-activos',
  templateUrl: './listado-de-clientes-activos.component.html',
  styleUrls: ['./listado-de-clientes-activos.component.css']
})
export class ListadoDeClientesActivosComponent implements OnInit {
  ListaDeClientes: any[] | undefined;


  constructor(private _SharedService: ClienteServicesService,
    private _ModalService: BsModalService) { }


  ClienteModel: any;
  ModalRef: BsModalRef | undefined;
  ngOnInit(): void {
    this.ListarClientesActivos();
  }
  ListarClientesActivos() {
    this._SharedService.ListadoDeClientesActivos().subscribe(data => {
      this.ListaDeClientes = data;
      //console.log(data);
    })
  }
  AgregarCliente(template: TemplateRef<any>) {
    var val :undefined;
    this.ClienteModel = val;
    this.ModalRef = this._ModalService.show(template);
  }
  EditarCliente(template: TemplateRef<any>, item: any) {
    //console.log(item);
    var val =
    {
      id: item.id,
      nombre: item.nombre,
      apellido: item.apellido,
      identificacion: item.identificacion,
      edad: item.edad,
      genero: item.genero,
      activo: item.activo,
      maneja: item.maneja,
      usaLentes: item.usaLentes,
      esDiabetico: item.esDiabetico,
      padeceOtraEnfermedad: item.padeceOtraEnfermedad,
      otraEnfermedad: item.otraEnfermedad
    }
    this.ClienteModel = val;
    this.ModalRef = this._ModalService.show(template);
    //console.log(val);
  }
    //cerrar modal
    Close() {
      if (this.ModalRef) {
        this.ModalRef.hide();
      }
    }
  actualizar(val: boolean) {
    if (val === true) {
      this.Close();
      this.ListarClientesActivos();
    }
  }
}