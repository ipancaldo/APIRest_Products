import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { HttpClientModule } from '@angular/common/http'

import {MatDialogModule} from '@angular/material/dialog';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ProductosComponent } from './productos/productos.component';
import { ProductoComponent } from './producto/producto.component';

import {MatSnackBarModule} from '@angular/material/snack-bar';
import { DialogMensajeComponent } from './dialog-mensaje/dialog-mensaje.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductosComponent,
    ProductoComponent,
    DialogMensajeComponent,
  ],
  entryComponents: [DialogMensajeComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatListModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    HttpClientModule,
    MatSnackBarModule,
    MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
