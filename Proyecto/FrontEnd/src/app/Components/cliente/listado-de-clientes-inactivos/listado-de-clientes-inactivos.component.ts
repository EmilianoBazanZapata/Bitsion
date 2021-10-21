import { Component, OnInit } from '@angular/core';
import { ClienteServicesService } from 'src/app/Services/cliente-services.service';

@Component({
  selector: 'app-listado-de-clientes-inactivos',
  templateUrl: './listado-de-clientes-inactivos.component.html',
  styleUrls: ['./listado-de-clientes-inactivos.component.css']
})
export class ListadoDeClientesInactivosComponent implements OnInit {

  ListadoDeClientesInactivos: any[] | undefined;
  constructor(private _SharedService: ClienteServicesService) { }

  ngOnInit(): void {
    this.ListadoDecLientesInactivos();
  }
  ListadoDecLientesInactivos() {
    this._SharedService.ListadoDeClientesInactivos().subscribe(data => {
      this.ListadoDeClientesInactivos = data;
      //console.log(data);
    })
  }
  ReactivarCliente(item: number) {
    console.log(item);
  }
}
