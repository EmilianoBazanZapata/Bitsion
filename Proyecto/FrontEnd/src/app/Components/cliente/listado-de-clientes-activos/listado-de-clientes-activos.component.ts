import { Component, OnInit } from '@angular/core';
import { ClienteServicesService } from 'src/app/Services/cliente-services.service';

@Component({
  selector: 'app-listado-de-clientes-activos',
  templateUrl: './listado-de-clientes-activos.component.html',
  styleUrls: ['./listado-de-clientes-activos.component.css']
})
export class ListadoDeClientesActivosComponent implements OnInit {
  ListaDeClientes:any[] | undefined;
  constructor(private _SharedService:ClienteServicesService) { }

  ngOnInit(): void {
    this.ListarClientesActivos();
  }
  ListarClientesActivos(){
      this._SharedService.ListadoDeClientesActivos().subscribe(data => {
        this.ListaDeClientes = data;
        //console.log(data);
      })
  }
}
