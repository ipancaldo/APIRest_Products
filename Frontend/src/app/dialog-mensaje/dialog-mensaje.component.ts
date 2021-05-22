import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-mensaje',
  templateUrl: './dialog-mensaje.component.html',
  styleUrls: ['./dialog-mensaje.component.scss']
})
export class DialogMensajeComponent implements OnInit {

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }


  mostrar : boolean = true;

  // Si ingresa un 'false', no se debe mostrar el cuadro de CANCELAR
  ngOnInit(): void {
    if(this.data.bool == 'false') this.mostrar = false;
  }
}