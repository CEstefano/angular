import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { PersonaService } from 'src/app/services/persona.service';
import { SectorService } from 'src/app/services/sector.service';
import { ZonaService } from 'src/app/services/zona.service';

@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html',
  styleUrls: ['./persona.component.css']
})
export class PersonaComponent implements OnInit {

  formulario : FormGroup;

  listPersonas: any[] = [
    // {nombre: 'Carlos Gabriel' , fechaNacimiento: '1949-12-01', sector: 'Norte' , zona: 'Garzota'},
    // {nombre: 'Minerva garcia' , fechaNacimiento: '1990-09-01', sector: 'Sur' , zona: 'Los Rios'},
  ];

  listSectores: any[] = [
    // {ide: 101, des_sector: 'Norte'},
    // {ide: 102, des_sector: 'Sur'},
  ];

  listZonas: any[] = [
    // {ide: 50, des_zona: 'Garzota'},
    // {ide: 51, des_zona: 'Prosperina'},
  ];

  listZonasAsociadas: any[] = [
    // {ide: 50, des_zona: 'Garzota'},
    // {ide: 51, des_zona: 'Prosperina'},
  ];


  //
  constructor(private fb : FormBuilder, private toastr: ToastrService ,  private _personaServices : PersonaService ,
    private _zonasServices : ZonaService, private _sectorServices : SectorService) {
    this.formulario=this.fb.group ({
      id:[''],
      nombre: ['',Validators.required],
      fechaNacimiento: ['',Validators.required],
      sector: ['', Validators.min(1)],
      zona : ['', Validators.min(1)],
      sueldo: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.obtenerPersonas();

    this.obtenerSectores();

    this.obtenerZonas();
  }

  agregarPersona(){

    console.log(this.formulario);

      const persona : any = {
          id:this.formulario.get('id')?.value,
          nombre: this.formulario.get('nombre')?.value,
          fechaNacimiento: this.formulario.get('fechaNacimiento')?.value,
          sector: this.formulario.get('sector')?.value,
          zona: this.formulario.get('zona')?.value,
          sueldo: this.formulario.get('sueldo')?.value
    }


    console.log(persona);

  }

    eliminarPersona(id : number){
        // this.listPersonas.splice(index,1);
        this._personaServices.deletePersona(id).subscribe(data =>{
          this.toastr.error('Tarjeta eliminada con exito', 'Recibido');
          this.obtenerPersonas();
        }, error => {
            console.log(error);
        })
    }

    obtenerPersonas() {
      this._personaServices.getlistPersonas().subscribe(data =>{
        console.log(data);
        this.listPersonas = data;
      }, error =>{
        console.log(error);
      })
    }

    // ZONAS///77777777777777777777777777777777777777777777777777777777777777

    obtenerZonas() {
      this._zonasServices.getlistZonas().subscribe(data =>{
        console.log(data);
        this.listZonas = data;

      }, error =>{
        console.log(error);
      })
    }

    ////// SECTORES ///7///////////////////////////////////////////////////7///

    obtenerSectores() {
      this._sectorServices.getlistSectores().subscribe(data =>{
        console.log(data);
        this.listSectores = data;
      }, error =>{
        console.log(error);
      })
    }


    // filtroZonas(){

    // }


    // onSelect(listSectores : any){
    //   // console.log(listSectores.id);
    //   this.obtenerZonas();
    //   this.listZonasAsociadas=this.listZonas.filter(word => word.sectorId == listSectores.target);
    //   console.log(this.listZonasAsociadas);
    // }

}
