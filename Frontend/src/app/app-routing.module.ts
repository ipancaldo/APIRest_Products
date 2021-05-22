import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ProductoComponent } from './producto/producto.component';
import { ProductosComponent } from './productos/productos.component';




const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'productos', component: ProductosComponent },
  { path: 'producto', component: ProductoComponent },
  { path: 'producto/:id', component: ProductoComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
