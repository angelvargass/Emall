import { Component, OnInit } from '@angular/core';
import { Reporte } from '../../models/Reporte';
import { ReporteService } from '../../services/reporte.service';

@Component({
  selector: 'app-transacciones',
  templateUrl: './transacciones.component.html',
  styleUrls: ['./transacciones.component.css']
})
export class TransaccionesComponent implements OnInit {
  categorias: string[] = [];
  comerciosPorCat: number[] = [];
  reportes: Reporte[] = [];

  public pieChartLabels = [];
  public pieChartData = [];
  public pieChartType = 'pie';
  public randomColor = [];
  public pieColors = [];
  constructor(private service: ReporteService) { }

  ngOnInit() {
    this.service.getTransacciones()
      .subscribe(
        (data: Reporte[]) => {
          for (const report of data) {
            this.pieChartLabels.push(report.nombre);
            this.pieChartData.push(report.cantidad);
            this.randomColor.push(this.getRandomColor());
          }
          this.pieColors = [{
            backgroundColor: this.randomColor
          }];
        },
        (err: any) => console.log(err)
      );
  }

  getRandomColor() {
    const rgba = 'rgba(' +
      (Math.floor(Math.random() * (256 - 1) + 1)) + ', ' +
      (Math.floor(Math.random() * (256 - 1) + 1)) + ', ' +
      '171' + ', ' + '1)';
    return rgba;
  }
}
