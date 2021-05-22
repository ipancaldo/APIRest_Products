import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Products } from '../models/products.models';

import { ProductsService } from '../services/products.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogMensajeComponent } from '../dialog-mensaje/dialog-mensaje.component';

import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.scss'],
})
export class ProductoComponent implements OnInit {
  constructor(
    private productsService: ProductsService,
    private activeRouter: ActivatedRoute,
    private router: Router,
    public dialog: MatDialog
  ) {}

  form = new FormGroup({
    nombre: new FormControl(
      '',
      Validators.compose([
        Validators.minLength(2),
        Validators.maxLength(40),
        Validators.required,
      ])
    ),
    cantidadUnidad: new FormControl(
      '',
      Validators.compose([
        Validators.minLength(2),
        Validators.maxLength(20),
        Validators.required,
      ])
    ),
    precio: new FormControl(
      '',
      Validators.compose([
        Validators.min(0.01),
        Validators.max(99999),
        Validators.required,
      ])
    ),
  });

  /* Variable para el encabezado del formulario. Si no
   ingresamos ID, va a ser POST*/
  title: string = 'crear';
  /* Variable que sirve para el ID que viene desde el GET
    Si queda en -1, es un POST
    Se modifica por el ID ingresado para el PUT */
  existeId: number = -1;
  // Visualización de pantalla y botones del celular
  visualizar: boolean = true;
  formSearch: FormGroup;
  public products: Products;

  get nombreCtrl(): AbstractControl {
    return this.form.get('nombre');
  }
  get cantidadCtrl(): AbstractControl {
    return this.form.get('cantidadUnidad');
  }
  get precioCtrl(): AbstractControl {
    return this.form.get('precio');
  }

  ngOnInit(): void {
    // Para tomar el ID y poder realizar el PUT
    let productId = this.activeRouter.snapshot.paramMap.get('id');
    if (productId != null) {
      // Si viene un ID desde el GET, cambia el título por EDITAR
      this.title = 'editar';
      // Cambiamos la variable global por el ID para buscar más adelante al querer editar
      this.existeId = parseInt(productId);
      this.productsService
        .getProductById(parseInt(productId))
        .subscribe((data) => {
            this.nombreCtrl.setValue(data.Name),
            this.cantidadCtrl.setValue(data.QuantityPerUnit),
            this.precioCtrl.setValue(data.Price);
        });
    }
  }

  btnLimpiar(): void {
    if (this.nombreCtrl) this.nombreCtrl.setValue('');

    if (this.cantidadCtrl) this.cantidadCtrl.setValue('');

    if (this.precioCtrl) this.precioCtrl.setValue('');
  }

  btnVolver() {
    this.router.navigateByUrl('/productos');
  }

  btnGuardarProducto(): void {
    var producto = new Products();
    producto.Name = this.form.get('nombre').value;
    producto.QuantityPerUnit = this.form.get('cantidadUnidad').value;
    producto.Price = this.form.get('precio').value;

    /* Si se mantiene la variable global como 'crear',
     el form es para POST, caso contrario para PUT */
    if (this.title == 'crear') {
      this.productsService.postProduct(producto).subscribe(
        (response: Products) => {
          this.popUp('Agregado', 'Producto ' + producto.Name + ' ingresado correctamente');
          this.router.navigateByUrl('/productos');
        },
        (error) => this.popUp('Editad', 'Error al ingresar el producto: ' + error.message)
      );
    } else {
      // Debemos pasarle a la base de datos el ID del producto para que realice el PUT
      producto.Id = this.existeId;
      this.productsService.putProducto(producto).subscribe(
        (response: Products) => {
          this.router.navigateByUrl('/productos');
          this.popUp('Editado', 'Producto editado correctamente');
        },
        (error) => this.popUp('Advertencia', 'Error al editar el producto: ' + error.message)
      );
    }
  }

  popUp(title: string, cuerpo: string){
      let mensaje = this.dialog.open(DialogMensajeComponent, {
        data: { 
          titulo: title,
          mensaje: cuerpo,
          // Validación string de que viene de productos y muestra dos botones
          bool: 'false'
        },
      });
  }

  // Validaciones

  nombreVacio(): string {
    return this.nombreCtrl.value == ''
      ? ''
      : this.nombreCtrl.value.length < 2
      ? 'Nombre muy corto'
      : 'Nombre ingresado';
  }

  cantidadVacio(): string {
    return this.cantidadCtrl.value == ''
      ? ''
      : this.cantidadCtrl.value.length < 2
      ? 'Debe contener más caracteres'
      : 'Nombre ingresado';
  }

  precioVacio(): string {
    return this.precioCtrl.value == ''
      ? ''
      : this.precioCtrl.value > 99999
      ? 'El precio no puede superar a 99999'
      : this.precioCtrl.value < 0.01
      ? 'El precio no puede ser menor a 0.01'
      : this.precioCtrl.value > 0.01 && 99999
      ? 'Precio ingresado'
      : 'Precio ingresado';
  }
}
