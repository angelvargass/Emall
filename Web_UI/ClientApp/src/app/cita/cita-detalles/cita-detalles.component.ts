import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CitaService } from 'src/app/services/cita.service';
import { Cita } from 'src/app/models/Cita';
import { QrScannerComponent } from 'angular2-qrscanner';
import { Item } from 'src/app/models/item';
import { Multa } from 'src/app/models/multa';
import { CitaList } from 'src/app/models/CitaList';
import { MultaService } from 'src/app/services/multa.service';
import { Regla } from '../../models/regla.model';
import { ReglaService } from '../../services/regla.service';

@Component({
  selector: 'app-cita-detalles',
  templateUrl: './cita-detalles.component.html',
  styleUrls: ['./cita-detalles.component.css']
})

export class CitaDetallesComponent implements OnInit {
  cita: Cita = null;
  items: Item[] = null;
  reglas: Regla[];
  private id_usuario: number;
  
  constructor(
    private route: ActivatedRoute, 
    private service: CitaService, 
    private multaService: MultaService, 
    private reglaService: ReglaService,
    private router:Router) { }

  ngOnInit() {
    this.id_usuario = JSON.parse(localStorage.getItem('usuario-logueado')).usuario.Id;
    let idCita = this.route.snapshot.params['id'];
    this.service.obtenerCita(idCita)
    .subscribe(
      (data: Cita) => {
        this.cita = data;
        console.log(this.cita.id_sucursal);
        this.obtenerReglas(+this.cita.id_sucursal);
      }
    );

    this.service.obtenerItemsCita(idCita)
    .subscribe(
      (data: Item[]) => {
        this.items = data;
      }
    );
  }

  obtenerReglas(sucursalId: number) {
    this.reglaService.obtenerReglasPorSucursal(sucursalId)
    .subscribe((data) => {
      this.reglas = data;
    });
  }
}
