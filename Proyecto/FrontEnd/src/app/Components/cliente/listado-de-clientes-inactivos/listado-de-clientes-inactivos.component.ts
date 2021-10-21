import { Component, OnInit } from '@angular/core';
import { ClienteServicesService } from 'src/app/Services/cliente-services.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-listado-de-clientes-inactivos',
  templateUrl: './listado-de-clientes-inactivos.component.html',
  styleUrls: ['./listado-de-clientes-inactivos.component.css']
})
export class ListadoDeClientesInactivosComponent implements OnInit {

  ListadoDeClientesInactivos: any[] | undefined;
  //alerta para mostrar los mjensajes dependiendo de las respuestas del servidor
  Alerta: any;
  //datos para la paginacion
  public page = 1;
  public pageSize = 6;
  public CantDates = 0;
  constructor(private _SharedService: ClienteServicesService) { }

  ngOnInit(): void {
    this.ListadoDecLientesInactivos();
  }
  ListadoDecLientesInactivos() {
    this._SharedService.ListadoDeClientesInactivos().subscribe(data => {
      this.ListadoDeClientesInactivos = data;
      this.CantDates = this.ListadoDeClientesInactivos.length;
      //console.log(data);
    })
  }
  ReactivarCliente(item: number) {
    var val =
    {
      id: item
    }
    this._SharedService.ReactivarCliente(val).subscribe(data => {
      this.Alerta = data;
      if (this.Alerta.displayMessage = "Usuario Reactivado Exitosamente") {
        Swal.fire('Cuidado', this.Alerta.displayMessage, 'success')
        this.ListadoDecLientesInactivos();
      }
      else {
        Swal.fire('Cuidado', this.Alerta.displayMessage, 'error')
      }
    })
  }
}
