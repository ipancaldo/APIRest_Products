import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';

import { Router } from '@angular/router';

import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { DialogMensajeComponent } from '../dialog-mensaje/dialog-mensaje.component';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.scss'],
})
export class ProductosComponent implements OnInit {
  constructor(
    private productsService: ProductsService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog
  ) {}

  public products: Array<any> = [];

  ngOnInit(): void {
    this.productsService.getProducts().subscribe((prod: any) => {
      this.products = prod;
    });
  }

  editarProducto(id: number) {
    this.router.navigate(['producto', id]);
  }

  eliminarProducto(id: number) {
    if (confirm('Realmente desea eliminar el producto?')) {
      // if(this.confirmarEliminar("Advertencia", "Realmente desea eliminar el producto?", id)){
      this.productsService.deleteProduct(id).subscribe(
        (res) => {
          this.openSnackBar('Item eliminado', 'Cerrar');
          this.ngOnInit();
        },
        (error) => {
          this.openSnackBar(
            'No se puede eliminar el producto seleccionado',
            'Cerrar'
          );
        }
      );
    }
  }

  btnAgregarProducto() {
    this.router.navigateByUrl('/producto');
  }

  openSnackBar(message, action) {
    let snackBarRef = this.snackBar.open(message, action);

    snackBarRef.afterDismissed().subscribe(() => {});

    snackBarRef.onAction().subscribe(() => {});
  }

  // No funciona. Elimina siempre por SI o NO
  confirmarEliminar(title: string, cuerpo: string, id: number) {
    let mensaje = this.dialog.open(DialogMensajeComponent, {
      data: {
        titulo: title,
        mensaje: cuerpo,
        // Validación string de que viene de productos y muestra dos botones
        bool: 'true',
      },
    });
    mensaje.afterClosed().subscribe((res) => {
      if (res) this.eliminarProducto(id);
    });
  }
}
