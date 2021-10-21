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
  //metodo para agregar un Cliente
  AgregarCategoiria(val: any) {
    return this.http.post(this.ApiUrl + "/AddNewUser", val);
  }
  //Listado de Clientes Activos
  ListadoDeClientesActivos(): Observable<any[]> {
    return this.http.get<any>(this.ApiUrl + "/GetAllUsersActives");
  }
  //Listado de Clientes Inactivos
  ListadoDeClientesInactivos(): Observable<any[]> {
    return this.http.get<any>(this.ApiUrl + "/GetAllUsersInactives");
  }
}