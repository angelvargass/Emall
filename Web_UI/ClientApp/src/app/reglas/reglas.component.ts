import { Component, OnInit } from '@angular/core';
import { Regla } from '../models/regla.model';
import { ReglaService } from '../services/regla.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-reglas',
  templateUrl: './reglas.component.html',
  styleUrls: ['./reglas.component.css']
})

export class ReglasComponent implements OnInit {
  private reglas: Regla[];
  private regla: Regla = new Regla();
  private tieneErrores: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private reglaService: ReglaService,
  ) { }

  ngOnInit() {
    this.obtenerReglas();
    this.regla.Detalle = '';
  }

  onKeyArrowUp($event) {
    console.log('Tecla arriba');
  }
  
  onKeyArrowDown($event) {
    console.log('Tecla abajo');
  }

  onfocusOut(id: number) {
    this.reglaService.editarRegla(this.reglas[id])
    .subscribe((response) => {
      this.obtenerReglas();
    });
  }

  obtenerReglas(): void {
    this.regla.SucursalId = +this.route.snapshot.paramMap.get('id');

    this.reglaService.obtenerReglasPorSucursal(this.regla.SucursalId)
      .subscribe(data => this.reglas = data);
  }

  crearRegla() {
    this.reglaService.registrarRegla(this.regla)
    .subscribe((response) => {
      this.obtenerReglas();
    });
  }

  eliminarRegla(id: number) {
    this.reglaService.eliminarRegla(id)
        .subscribe((data) => {
          this.obtenerReglas();
        });
  }

  submit() {
    if (this.regla.Detalle.length < 5) {
      this.tieneErrores = true;
    } else {
      this.tieneErrores = false;
      
      this.reglaService.registrarRegla(this.regla)
        .subscribe((data) => {
          this.regla.Detalle = '';
          this.obtenerReglas();
        });
    }
  }
}
