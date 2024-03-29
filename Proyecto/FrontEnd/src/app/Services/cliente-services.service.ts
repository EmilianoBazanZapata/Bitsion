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
  AgregarCliente(val: any) {
    return this.http.post(this.ApiUrl + "/AddNewUser", val);
  }
  //metodo para editar un Cliente
  EditarCliente(val: any) {
    return this.http.put(this.ApiUrl + "/UpdateUser", val);
  }
  //metodo para eliminar una Cliente
  EliminarCliente(val: any) {
    return this.http.put(this.ApiUrl + '/DeleteUser', val);
  }
  //metodo para Reactivar una Cliente
  ReactivarCliente(val: any) {
    return this.http.put(this.ApiUrl + '/ReactivateUser', val);
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
