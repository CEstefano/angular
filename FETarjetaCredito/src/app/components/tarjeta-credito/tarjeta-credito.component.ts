import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TarjetaService } from 'src/app/services/tarjeta.service';
// import { FormControl } from '@angular/forms';
// import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-tarjeta-credito',
  templateUrl: './tarjeta-credito.component.html',
  styleUrls: ['./tarjeta-credito.component.css']
})
export class TarjetaCreditoComponent implements OnInit {


  listTarjetas: any[] = [
    // {titular: 'Miguel Estefano' , numeroTarjeta: '0967590403', fechaExpiracion: '16/12' , cvv: '3756'},
    // {titular: 'Carlos Estefano' , numeroTarjeta: '0966893900', fechaExpiracion: '17/12' , cvv: '3776'}
  ];

  formulario : FormGroup;

  constructor (private fb : FormBuilder , private toastr: ToastrService , private _tarjetaServices : TarjetaService) {
    this.formulario=this.fb.group ({
      titular: ['', Validators.required],
      numeroTarjeta: ['', [Validators.required , Validators.minLength(13), Validators.maxLength(13)]],
      fechaExpiracion: ['', [Validators.required , Validators.minLength(5), Validators.maxLength(5)]],
      cvv: ['', [Validators.required , Validators.minLength(3), Validators.maxLength(3)]]
    })

  }

  ngOnInit(): void {

    this.obtenerTarjetas();
  }

  agregarTarjeta(){

    if (this.formulario){

      const tarjeta : any = {
          titular: this.formulario.get('titular')?.value,
          numeroTarjeta: this.formulario.get('numeroTarjeta')?.value,
          fechaExpiracion: this.formulario.get('fechaExpiracion')?.value,
          cvv: this.formulario.get('cvv')?.value
        }

        console.log(tarjeta);

        this.formulario.reset();
        this._tarjetaServices.saveTarjeta(tarjeta).subscribe(data => {
          this.toastr.success('Tarjeta registrada con exito', 'Recibido');
          this.obtenerTarjetas();

        console.log(tarjeta);

        } , error => {
          this.toastr.error("oppps ...error al agg" , "Error")
          console.log(error);
        })
      // console.log(tarjeta);
      // this.listTarjetas.push(tarjeta);

    }
  }

  eliminarTarjeta(id : number) {
    // console.log(index )
    // this.listTarjetas.splice(index , 1);
    this._tarjetaServices.deleteTarjeta(id).subscribe(data =>{
      this.toastr.error('Tarjeta eliminada con exito', 'Recibido');
      this.obtenerTarjetas();
    }, error => {
        console.log(error);
    })

  }

  obtenerTarjetas() {

    this._tarjetaServices.getListTarjetas().subscribe( data => {
      console.log(data);
      this.listTarjetas= data;
    },
    error => {
      console.log(error);
    })
  }
}
