import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClienteComponent } from './Components/cliente/cliente.component';
import { AgregarEditarClienteComponent } from './Components/cliente/agregar-editar-cliente/agregar-editar-cliente.component';
import { ListadoDeClientesActivosComponent } from './Components/cliente/listado-de-clientes-activos/listado-de-clientes-activos.component';
import { ListadoDeClientesInactivosComponent } from './Components/cliente/listado-de-clientes-inactivos/listado-de-clientes-inactivos.component';

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
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
