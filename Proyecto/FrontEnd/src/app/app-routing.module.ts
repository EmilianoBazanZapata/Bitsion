import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListadoDeClientesActivosComponent } from './Components/cliente/listado-de-clientes-activos/listado-de-clientes-activos.component';
import { ListadoDeClientesInactivosComponent } from './Components/cliente/listado-de-clientes-inactivos/listado-de-clientes-inactivos.component';

const routes: Routes = [
  { path: 'ClientesActivos', component: ListadoDeClientesActivosComponent},
  { path: 'ClientesInactivos', component: ListadoDeClientesInactivosComponent},
  { path: '', component: ListadoDeClientesActivosComponent},
  { path: '**', component: ListadoDeClientesActivosComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
