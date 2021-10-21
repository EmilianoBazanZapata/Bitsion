import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';



@Injectable({
  providedIn: 'root'
})
export class ClienteServicesService {
  readonly ApiUrl = "https://localhost:5001";
  constructor(private http: HttpClient) { }
  //Listado de Clientes Activos
  //Listado de Categorias Activas
  ListadoCategorias(): Observable<any[]> {
    return this.http.get<any>(this.ApiUrl + "/GetAllUsersActives");
  }

}
