import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClienteComponent } from './Components/cliente/cliente.component';
import { AgregarEditarClienteComponent } from './Components/Cliente/agregar-editar-cliente/agregar-editar-cliente.component';
import { ListadoDeClientesActivosComponent } from './Components/Cliente/listado-de-clientes-activos/listado-de-clientes-activos.component';
import { ListadoDeClientesInactivosComponent } from './Components/Cliente/listado-de-clientes-inactivos/listado-de-clientes-inactivos.component';

@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
    AgregarEditarClienteComponent,
    ListadoDeClientesActivosComponent,
    ListadoDeClientesInactivosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
